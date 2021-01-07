using ChatApplication.Manager.Base;
using ChatApplication.Manager.Contract;
using ChatApplication.Models.Model;
using ChatApplication.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChatApplication.Manager
{
    public class AccountManager : BaseManager<Account>, IAccountManager 
    {
        private readonly IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository) : base(accountRepository)
        {
            _accountRepository = accountRepository;
        }
    }
}
