﻿using Microsoft.AspNetCore.Identity;

namespace ChatAppTest.Models
{
    public class AppUser : IdentityUser
    {
        public AppUser() 
        {
            Messages = new HashSet<Message>();
        }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
