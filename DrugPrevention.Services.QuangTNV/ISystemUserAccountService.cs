using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{
    public interface ISystemUserAccountService
    {
        Task<SystemUserAccount> GetUserAccount(string username, string password);
    }
}
