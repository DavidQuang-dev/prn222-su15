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
    }
}
