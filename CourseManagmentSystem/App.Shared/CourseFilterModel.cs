using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Shared
{
    public class CourseFilterModel
    {
        public readonly int Page;
        public readonly string? Keyword; 
        public CourseFilterModel(int page=1,string keyword="")
        {
            Keyword = keyword;
            Page = page;
        }
    }
}
