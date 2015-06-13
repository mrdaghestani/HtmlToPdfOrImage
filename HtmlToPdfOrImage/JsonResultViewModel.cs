using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPdfOrImage
{
    public class JsonResultViewModel
    {
        public bool error { get; set; }
        public List<ClientMessageViewModel> msgs { get; set; }
        public object model { get; set; }
        public string modelType { get; set; }
        public int? exceptionType { get; set; }
    }
}
