using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{
    public interface IUserCoursesQuangTnvService
    {
        Task<List<UserCoursesQuangTnv>> GetAllUserCoursesAsync();
        Task<List<UserCoursesQuangTnv>> SearchAsync(string? Title = null, string? InstructorName = null, string? UserName = null);
        Task<int> CreateAsync(UserCoursesQuangTnv userCoursesQuangTnv);
        Task<int> UpdateAsync(UserCoursesQuangTnv userCoursesQuangTnv);
        Task<bool> DeleteAsync(int userCourseId);
    }
}
