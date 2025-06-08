using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using DrugPrevention.Repositories.QuangTNV.Models;
using DrugPrevention.Services.QuangTNV;

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.UserCoursesQuangTnvs
{
    public class CreateModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly IUserCoursesQuangTnvService _service;
        public CreateModel(IUserCoursesQuangTnvService service)
        {
            _service = service;
        }

        //public IActionResult OnGet()
        //{
        //ViewData["CourseId"] = new SelectList(_context.UserCoursesQuangTnv, "CourseIdquangTnv", "AgeGroup");
        //ViewData["UserId"] = new SelectList(_context.SystemUserAccounts, "UserAccountId", "Email");
        //    return Page();
        //}

        [BindProperty]
        public UserCoursesQuangTnv UserCoursesQuangTnv { get; set; } = default!;

        //// For more information, see https://aka.ms/RazorPagesCRUD.
        //public async Task<IActionResult> OnPostAsync()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }

        //    _context.UserCoursesQuangTnvs.Add(UserCoursesQuangTnv);
        //    await _context.SaveChangesAsync();

        //    return RedirectToPage("./Index");
        //}
    }
}
