using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HtmlToPdfOrImage.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var api = new HtmlToPdfOrImage.Api("99433eae-569c-470d-a763-0a3d0b28ad21", "vmZ2Qryg");
            var result = api.Convert("<b>Html to PDF Sample</b>");
            //var result = api.Convert(new Uri("http://google.com"));
            if (result.error)
            {
                foreach (var msg in result.msgs)
                {
                    System.Console.WriteLine(msg.Message);
                }
            }
            else
            {
                File.WriteAllBytes("myfile.pdf", (byte[])result.model);
                System.Console.WriteLine("Done.");
            }
            var creditResult = api.Credit();
            if (result.error)
            {
                foreach (var msg in result.msgs)
                {
                    System.Console.WriteLine(msg.Message);
                }
            }
            else
            {
                System.Console.WriteLine("Credit: " + creditResult.model);
            }
        }
    }
}
