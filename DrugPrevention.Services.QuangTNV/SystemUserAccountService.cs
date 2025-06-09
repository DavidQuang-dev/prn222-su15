using DrugPrevention.Repositories.QuangTNV;
using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{    public class SystemUserAccountService : ISystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        
        public SystemUserAccountService(SystemUserAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<SystemUserAccount> GetUserAccount(string username, string password)
        {
            return await _repository.GetUserByEmailAndPassword(username, password);
        }
    }
}
