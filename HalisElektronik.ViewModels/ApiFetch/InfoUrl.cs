using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalisElektronik.ViewModels.ApiFetch
{
    public class InfoUrl
    {
        public string InfoList { get; } = "Info/InfoList";
        public string InfoGet { get; } = "Info/InfoGet";
        public string InfoEdit { get; } = "Info/InfoEdit";
        public string InfoCreate { get; } = "Info/InfoCreate";
        public string InfoDelete { get; } = "Info/InfoDelete";

    }
}
