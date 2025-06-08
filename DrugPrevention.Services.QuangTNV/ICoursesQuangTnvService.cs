using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{
    public interface ICoursesQuangTnvService
    {
        Task<List<CoursesQuangTnv>> GetAllCoursesAsync();
        Task<CoursesQuangTnv> GetCourseByIdAsync(int courseId);
        Task<int> AddCourseAsync(CoursesQuangTnv course);
        Task<int> UpdateCourseAsync(CoursesQuangTnv course);
        Task<bool> DeleteCourseAsync(CoursesQuangTnv course);
        Task<bool> DeleteCourseAsync(string courseID);

    }
}
