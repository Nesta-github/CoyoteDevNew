using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebNesta.Coyote.Core.Data;
using WebNesta.Coyote.Core.Domain;
using WebNesta.Coyote.Geral.Service;

namespace WebNesta.Coyote.Geral.Domain.Service
{
    public class AccountService : IDomainService, IDomainAccountService
    {
        public readonly IAccountRepository<Account> _repository;
        public AccountService(IAccountRepository<Account> repository)
        {
            _repository = repository;
        }

        public  Account GetAccount(string username, string password)
        {
            var account = _repository.GetAccount(username, password);


            return account;
        }
    }
}
