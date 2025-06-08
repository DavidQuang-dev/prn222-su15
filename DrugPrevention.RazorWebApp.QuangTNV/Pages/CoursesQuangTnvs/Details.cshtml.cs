using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using DrugPrevention.Repositories.QuangTNV.Models;
using DrugPrevention.Services.QuangTNV;

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.CoursesQuangTnvs
{
    public class DetailsModel : PageModel
    {
        private readonly ICoursesQuangTnvService _service;
        private readonly IUserCoursesQuangTnvService _userCoursesService;

        public DetailsModel(ICoursesQuangTnvService service, IUserCoursesQuangTnvService userCoursesService)
        {
            _service = service;
            _userCoursesService = userCoursesService;
        }

        public CoursesQuangTnv CoursesQuangTnv { get; set; } = default!;
        public List<UserCoursesQuangTnv> UserCoursesQuangTnv { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesquangtnv = await _service.GetCourseByIdAsync(id.Value);

            if (coursesquangtnv == null)
            {
                return NotFound();
            }
            else
            {
                CoursesQuangTnv = coursesquangtnv;
                List<UserCoursesQuangTnv> userCourses = await _userCoursesService.SearchAsync(coursesquangtnv.Title);
                if (userCourses == null)
                {
                    UserCoursesQuangTnv = new List<UserCoursesQuangTnv>();
                }
                else
                {
                    UserCoursesQuangTnv = userCourses;
                }
                return Page();
            }
        }
    }
}
