using DrugPrevention.Repositories.QuangTNV.Basic;
using DrugPrevention.Repositories.QuangTNV.DBContext;
using DrugPrevention.Repositories.QuangTNV.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrugPrevention.Repositories.QuangTNV
{
    public class CoursesQuangTnvRepository : GenericRepository<CoursesQuangTnv>
    {
        public CoursesQuangTnvRepository()
        {
        }
        public CoursesQuangTnvRepository(SU25_SE183008_PRN222_SE1709_G2_DrugPreventionContext context) : base(context)
        {
        }

        // Override GetByIdAsync to ensure it uses the correct int overload
        public new async Task<CoursesQuangTnv> GetByIdAsync(int courseId)
        {
            return await _context.CoursesQuangTnvs.FindAsync(courseId);
        }

        // Override GetById to ensure it uses the correct int overload
        public new CoursesQuangTnv GetById(int courseId)
        {
            return _context.CoursesQuangTnvs.Find(courseId);
        }
    }
}
