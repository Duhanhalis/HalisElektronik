using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class BlogUrl
    {
        public string BlogList { get; } = "Blog/BlogList";
        public string BlogGetAsync { get; } = "Blog/BlogGetAsync";
        public string BlogCreate { get; } = "Blog/BlogCreate";
        public string BlogEdit { get; } = "Blog/BlogEdit";
        public string BlogDelete { get; } = "Blog/BlogDelete";

    }

}
