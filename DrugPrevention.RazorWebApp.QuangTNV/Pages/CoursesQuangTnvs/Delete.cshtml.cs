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
using Microsoft.AspNetCore.Authorization;

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.CoursesQuangTnvs
{
    [Authorize(Roles = "1")]
    public class DeleteModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly ICoursesQuangTnvService _service;

        public DeleteModel(ICoursesQuangTnvService service)
        {
            _service = service;
        }

        [BindProperty]
        public CoursesQuangTnv CoursesQuangTnv { get; set; } = default!;

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
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var coursesquangtnv = await _service.GetCourseByIdAsync(id.Value);
            if (coursesquangtnv != null)
            {
                CoursesQuangTnv = coursesquangtnv;
                await _service.DeleteCourseAsync(CoursesQuangTnv);
            }

            return RedirectToPage("./Index");
        }
    }
}
