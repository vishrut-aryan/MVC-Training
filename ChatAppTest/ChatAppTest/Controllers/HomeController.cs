using ChatAppTest.Data;
using ChatAppTest.Hubs;
using ChatAppTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatAppTest.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public readonly UserManager<AppUser> _userManager;
        public readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, ApplicationDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.CurrentUserName = currentUser.UserName;
            }
            var messages = await _context.Messages.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Text")] Message message)
        {
            var sender = await _userManager.GetUserAsync(User);

            if (sender == null)
            {
                return Unauthorized();
            }

            message.UserName = sender.UserName;
            message.UserID = sender.Id;
            message.Sender = sender;
            message.When = DateTime.Now;

            if (message.Sender != null && message.UserID != null && message.UserName != null)
            {
                ModelState["UserName"].ValidationState = ModelValidationState.Valid;
                ModelState["UserID"].ValidationState = ModelValidationState.Valid;
                ModelState["Sender"].ValidationState = ModelValidationState.Valid;
            }

            if (ModelState.IsValid)
            {
                await _context.Messages.AddAsync(message);
                await _context.SaveChangesAsync();

                var hubContext = HttpContext.RequestServices.GetRequiredService<IHubContext<ChatHub>>();
                await hubContext.Clients.All.SendAsync("receiveMessage", message);

                return Json(new { success = true });
            }
            var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            return BadRequest(errors);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
