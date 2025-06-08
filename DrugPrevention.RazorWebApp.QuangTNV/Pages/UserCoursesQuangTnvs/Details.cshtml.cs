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

namespace DrugPrevention.RazorWebApp.QuangTNV.Pages.UserCoursesQuangTnvs
{
    public class DetailsModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly IUserCoursesQuangTnvService _service;

        public DetailsModel(IUserCoursesQuangTnvService service)
        {
            _service = service;
        }

        public UserCoursesQuangTnv UserCoursesQuangTnv { get; set; } = default!;

        //public async Task<IActionResult> OnGetAsync(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var usercoursesquangtnv = await _context.UserCoursesQuangTnvs.FirstOrDefaultAsync(m => m.UserCourseIdquangTnv == id);
        //    if (usercoursesquangtnv == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        UserCoursesQuangTnv = usercoursesquangtnv;
        //    }
        //    return Page();
        //}
    }
}
