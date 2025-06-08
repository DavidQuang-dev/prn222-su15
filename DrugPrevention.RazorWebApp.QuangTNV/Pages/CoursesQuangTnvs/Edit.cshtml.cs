using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using DrugPrevention.Repositories.QuangTNV.Models;
using DrugPrevention.Services.QuangTNV;

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.CoursesQuangTnvs
{
    public class EditModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly ICoursesQuangTnvService _service;

        public EditModel(ICoursesQuangTnvService service)
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
            CoursesQuangTnv = coursesquangtnv;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Optionally update the timestamp
            CoursesQuangTnv.UpdatedDate = DateTime.UtcNow;

            try
            {
                var result = await _service.UpdateCourseAsync(CoursesQuangTnv);
                if (result == 0)
                {
                    // Update failed, possibly not found
                    if (!await CoursesQuangTnvExists(CoursesQuangTnv.CourseIdquangTnv))
                    {
                        return NotFound();
                    }
                    // Otherwise, let it fall through to throw
                    throw new DbUpdateConcurrencyException();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return RedirectToPage("./Index");
        }

        private async Task<bool> CoursesQuangTnvExists(int id)
        {
            return await _service.GetCourseByIdAsync(id) != null;
        }
    }
}
