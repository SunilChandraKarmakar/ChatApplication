using AutoMapper;
using ChatApplication.Models.Model;
using ChatApplication.ViewModels.Account;
using ChatApplication.ViewModels.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApplication.AutoMapper
{
    public class AutoMapper : Profile 
    {
        public AutoMapper()
        {
            CreateMap<Account, AccountViewModel>();
            CreateMap<AccountCreateViewModel, Account>();
            CreateMap<AccountCreateViewModel, AccountViewModel>();
            CreateMap<AccountUpdateViewModel, Account>();

            CreateMap<Message, MessageViewModel>();
        }
    }
}
