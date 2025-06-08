using DrugPrevention.Repositories.QuangTNV;
using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{
    public class UserCoursesQuangTnvService : IUserCoursesQuangTnvService
    {
        private readonly UserCoursesQuangTnvRepository _repository;
        public UserCoursesQuangTnvService()
        {
            _repository ??= new UserCoursesQuangTnvRepository();
        }

        public async Task<int> CreateAsync(UserCoursesQuangTnv userCoursesQuangTnv)
        {
            return await _repository.CreateAsync(userCoursesQuangTnv);
        }

        public async Task<bool> DeleteAsync(int userCourseId)
        {
            var userCourse = await _repository.GetUserCourseByIdAsync(userCourseId);
            if (userCourse != null)
            {
                return await _repository.RemoveAsync(userCourse);
            }
            return false;
        }
        public async Task<List<UserCoursesQuangTnv>> GetAllUserCoursesAsync()
        {
            return await _repository.GetAllUserCourses();
        }
        public async Task<List<UserCoursesQuangTnv>> SearchAsync(string? Title = null, string? InstructorName = null, string? UserName = null)
        {
            return await _repository.SearchAsync(Title, InstructorName, UserName);
        }

        public Task<int> UpdateAsync(UserCoursesQuangTnv userCoursesQuangTnv)
        {
            return _repository.UpdateAsync(userCoursesQuangTnv);
        }
    }
}
