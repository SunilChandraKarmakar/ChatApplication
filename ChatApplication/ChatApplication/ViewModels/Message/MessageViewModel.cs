using ChatApplication.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.ViewModels.Message
{
    public class MessageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please Select User Account")]
        public int AccountId { get; set; }

        [Required(ErrorMessage = "Please Provied Your Message.")]
        [StringLength(1000, MinimumLength = 1)]
        [DataType(DataType.MultilineText)]
        public string MessageBody { get; set; }

        public virtual AccountViewModel Account { get; set; } 
    }
}
