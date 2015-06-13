using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPdfOrImage
{
    public enum ClientMessageType
    {
        Exception = 1,
        Message = 2,
        Alert = 3
    }
    public class ClientMessageViewModel
    {
        public ClientMessageType Type { get; set; }
        public string Message { get; set; }
    }
}