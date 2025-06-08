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
    public class IndexModel : PageModel
    {
        //private readonly DrugPrevention.Repositories.QuangTNV.DBContext.SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext _context;
        private readonly ICoursesQuangTnvService _service;

        public IndexModel(ICoursesQuangTnvService service)
        {
            _service = service;
        }

        public IList<CoursesQuangTnv> CoursesQuangTnv { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CoursesQuangTnv = await _service.GetAllCoursesAsync();
        }
    }
}
