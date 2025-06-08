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
    public class UserCoursesQuangTnvRepository : GenericRepository<UserCoursesQuangTnv>
    {
        public UserCoursesQuangTnvRepository()
        {
        }
        public UserCoursesQuangTnvRepository(SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext context) : base(context)
        {
        }
        public async Task<List<UserCoursesQuangTnv>> GetAllUserCourses()
        {
            return await _context.UserCoursesQuangTnvs.Include(uc => uc.User).Include(uc => uc.Course).ToListAsync() ?? new List<UserCoursesQuangTnv>();
        }
        public async Task<UserCoursesQuangTnv> GetUserCourseByIdAsync(int code)
        {
            return await _context.UserCoursesQuangTnvs.FirstOrDefaultAsync(c => c.UserCourseIdquangTnv == code) ?? new UserCoursesQuangTnv();
        }
        public async Task<List<UserCoursesQuangTnv>> SearchAsync(string? Title, string? InstructorName, string? FullName)
        {
            return await _context.UserCoursesQuangTnvs
                .Include(uc => uc.Course)
                .Include(uc => uc.User)
                .Where(uc => (string.IsNullOrEmpty(Title) || uc.Course.Title.Contains(Title)) &&
                             (string.IsNullOrEmpty(InstructorName) || uc.Course.InstructorName.Contains(InstructorName)) &&
                             (string.IsNullOrEmpty(FullName) || uc.User.FullName.Contains(FullName)))
                .ToListAsync() ?? new List<UserCoursesQuangTnv>();
        }
    }
}
