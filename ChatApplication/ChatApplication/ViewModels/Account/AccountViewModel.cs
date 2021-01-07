using ChatApplication.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.ViewModels.Account
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
            Messages = new HashSet<MessageViewModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Please Provied First Name.")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please Provied Last Name.")]
        [StringLength(20, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Provied Valid Email Address.")]
        [StringLength(50, MinimumLength = 11)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<MessageViewModel> Messages { get; set; }
    }
}
