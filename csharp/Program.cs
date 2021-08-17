using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;

using Newtonsoft.Json;
using System.Text.RegularExpressions;

namespace Formating
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            string test = "AKLOP89J";
            Console.WriteLine("test = ",test);

            dynamic configuration = Formating.readJson();
            test = Formating.formating(test, configuration, false);
            Console.WriteLine("formated test = ",test)
            test = Formating.formating(test, configuration, true)
            Console.WriteLine("unformated (test formated) = test = ", test)
        }
    }
}