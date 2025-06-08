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

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.UserCoursesQuangTnvs
{
    public class EditModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly IUserCoursesQuangTnvService _service;

        public EditModel(IUserCoursesQuangTnvService service)
        {
            _service = service;
        }

        [BindProperty]
        public UserCoursesQuangTnv UserCoursesQuangTnv { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usercoursesquangtnv =  await _context.UserCoursesQuangTnvs.FirstOrDefaultAsync(m => m.UserCourseIdquangTnv == id);
        //    if (usercoursesquangtnv == null)
        //    {
        //        return NotFound();
        //    }
        //    UserCoursesQuangTnv = usercoursesquangtnv;
        //   ViewData["CourseId"] = new SelectList(_context.UserCoursesQuangTnv, "CourseIdquangTnv", "AgeGroup");
        //   ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email");
        //    return Page();
        //}

        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.Attach(UserCoursesQuangTnv).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserCoursesQuangTnvExists(UserCoursesQuangTnv.UserCourseIdquangTnv))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return RedirectToPage("./Index");
        //}

        //private bool UserCoursesQuangTnvExists(int id)
        //{
        //    return _context.UserCoursesQuangTnvs.Any(e => e.UserCourseIdquangTnv == id);
        //}
    }
}
