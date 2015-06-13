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
            var api = new HtmlToPdfOrImage.Api("f4a43488-8896-491c-a07c-4605175346b1", "8U9G6GSa");
            //var result = convertor.Convert("<b>Html to PDF Sample</b>");
            var result = api.Convert(new Uri("http://google.com"));
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
