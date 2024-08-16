using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class BlogTagUrl
    {
        public string BlogTagList { get; } = "BlogTag/BlogTagList";
        public string BlogTagCreate { get; } = "BlogTag/BlogTagCreate";
        public string BlogTagEdit { get; } = "BlogTag/BlogTagEdit";
        public string BlogTagGet { get; } = "BlogTag/BlogTagGet";
        public string BlogTagDelete { get; } = "BlogTag/BlogTagDelete";
    }
}
