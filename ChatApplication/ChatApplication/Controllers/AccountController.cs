using AutoMapper;
using ChatApplication.Manager.Contract;
using ChatApplication.Models.Model;
using ChatApplication.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountManager _accountManager;
        private readonly IMapper _mapper;

        public AccountController(IAccountManager accountManager, IMapper mapper)
        {
            _accountManager = accountManager;
            _mapper = mapper;
        }

        // GET: api/<AccountController>
        [HttpGet]
        public async Task<ICollection<AccountViewModel>> Get()
        {
            return _mapper.Map<ICollection<AccountViewModel>>(await _accountManager.GetAll());
        }

        // GET api/<AccountController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AccountViewModel>> Get(int? id)
        {
            if (id == null)
                return BadRequest( new { ErrorMessage = "Account id is not found! Try again." });
            
            AccountViewModel existAccount = _mapper.Map<AccountViewModel>(await _accountManager.GetById(id));

            if (existAccount == null)
                return NotFound(new { ErrorMessage = "Account info is not found! Try again." });

            return Ok(existAccount);
        }

        // POST api/<AccountController>
        [HttpPost]
        public async Task<ActionResult<AccountViewModel>> Post(AccountCreateViewModel accountInfo)
        {
            if(ModelState.IsValid)
            {
                Account createAccount = _mapper.Map<Account>(accountInfo);
                createAccount = await _accountManager.Create(createAccount);

                if (createAccount != null)
                {
                    AccountViewModel createdAccountInfo = _mapper.Map<AccountViewModel>(createAccount);
                    return Ok(createdAccountInfo);
                }

                return BadRequest(new { ErrorMessage = "Account create failed! Try again." });
                    
            }

            return BadRequest(ModelState);
        }

        // PUT api/<AccountController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<AccountUpdateViewModel>> Put(int? id, 
            AccountUpdateViewModel accountUpdateInfo)
        {
            if(ModelState.IsValid)
            {
                if (id == null || accountUpdateInfo.Id != id)
                    return NotFound(new { ErrorMessage = "Account id was not found! try again." });

                Account updateAccountInfo = _mapper.Map<Account>(accountUpdateInfo);
                updateAccountInfo = await _accountManager.Update(updateAccountInfo);

                if(updateAccountInfo != null)
                {
                    AccountViewModel updatedAccountInfo = _mapper.Map<AccountViewModel>(updateAccountInfo);
                    return Ok(updatedAccountInfo);
                }

                return BadRequest(new { ErrorMessage = "Account update failed! Try again." });
            }

            return BadRequest(ModelState);
        }

        // DELETE api/<AccountController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound(new { ErrorMessage = "Account id was not found! Try again." });

            Account existingAccount = await _accountManager.GetById(id);

            if (existingAccount == null)
                return NotFound(new { ErrorMessage = "Account was not found! Try again." });

            bool isRemove = await _accountManager.Remove(existingAccount);

            if (isRemove)
                return Ok();

            return BadRequest(new { ErrorMessage = "Account remove failed! Try again. " });
        }
    }
}
