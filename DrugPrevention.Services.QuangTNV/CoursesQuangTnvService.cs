using DrugPrevention.Repositories.QuangTNV;
using DrugPrevention.Repositories.QuangTNV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Services.QuangTNV
{    public class CoursesQuangTnvService : ICoursesQuangTnvService
    {
        private readonly CoursesQuangTnvRepository _repository;
        
        public CoursesQuangTnvService(CoursesQuangTnvRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> AddCourseAsync(CoursesQuangTnv course)
        {
            return await _repository.CreateAsync(course);
        }

        public async Task<bool> DeleteCourseAsync(CoursesQuangTnv course)
        {
            return await _repository.RemoveAsync(course);
        }
        public async Task<bool> DeleteCourseAsync(int courseID)
        {
            if (courseID <= 0)
            {
                throw new ArgumentException("Course ID must be greater than 0.", nameof(courseID));
            }
            var course = await _repository.GetByIdAsync(courseID);
            if (course == null)
            {
                throw new KeyNotFoundException($"Course with ID {courseID} not found.");
            }
            return await _repository.RemoveAsync(course);
        }

        public async Task<List<CoursesQuangTnv>> GetAllCoursesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<CoursesQuangTnv> GetCourseByIdAsync(int courseId)
        {
            return await _repository.GetByIdAsync(courseId);
        }

        public async Task<int> UpdateCourseAsync(CoursesQuangTnv course)
        {
            return await _repository.UpdateAsync(course);
        }
    }
}
