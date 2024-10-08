﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ChatAppTest.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Text { get; set; }

        public DateTime When { get; set; }

        public string UserID { get; set; }

        [JsonIgnore]
        public virtual AppUser Sender { get; set; }
    }
}
