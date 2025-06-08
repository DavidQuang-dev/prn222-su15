using DrugPrevention.Repositories.QuangTNV.Basic;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using DrugPrevention.Repositories.QuangTNV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.QuangTNV
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository()
        {
        }
        public SystemUserAccountRepository(SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext context) : base(context)
        {
        }
        public async Task<SystemUserAccount> GetUserByEmailAndPassword(string username, string password)
        {
            return await _context.SystemUserAccounts.FirstOrDefaultAsync(u => u.UserName == username && u.Password == password);
        }
    }
}
