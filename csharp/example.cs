using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

using Newtonsoft.Json;
using System.Text.RegularExpressions;


namespace Formating
{
    public static class Formating
    {
        // read Json file
        public static dynamic readJson()
        {
            string currentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().CodeBase);
            currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string relativePath = Path.Combine(currentDirectory, @"..\..\configuration.json");
            relativePath = new Uri(relativePath).LocalPath;

            StreamReader stream = new StreamReader(relativePath);
            string json = stream.ReadToEnd();

            dynamic configuration = JsonConvert.DeserialiseObject<dynamic>(json.ToString());
            return configuration;
        }


        public static string formating(string ValueToFormat, dynamic configuration, bool reverse)
        {
            string Result = ValueToFormat;

            int i;
            int increment;
            string input;
            string output;
        
            if(reverse)
            {
                i = configuration.Count - 1;
                increment = -1;
                input = "output";
                output = "input";
            }
            else
            {
                i = 0;
                increment = 1;
                input = "input";
                output = "output";
            }


            for(; i < configuration.Count && i >=0; i=i+increment)
            {
                string valueInput = "";
                string valueOutput = "";

                try{
                    if(configuration[i][0].ContainsKey("replacement"))
                    {
                        valueInput = configuration[i][0]["replacement"][input];
                        valueOutput = configuration[i][0]["replacement"][output];
                        Result = Regex.Replace(Result, @"" + "" + valueInput, @"" + "" + valueOutput);
                    }
                }
                catch{

                }

                try{
                    if(configuration[i][0].ContainsKey("regex")){
                        if(reverse)
                        {
                            valueInput = configuration[i][0]["regex"]["regex-unformating-input"];
                            valueOutput = configuration[i][0]["regex"]["regex-unformating-output"];
                        }
                        else
                        {
                            valueInput = configuration[i][0]["regex"]["regex-formating-input"];
                            valueOutput = configuration[i][0]["regex"]["regex-formating-output"];
                        }
                        Result = Regex.Replace(Result, @"" + "" + valueInput, @"" + "" + valueOutput);
                    }
                }
                catch
                {

                }

                
                try{
                    if(configuration[i][0].ContainsKey("function")){
                       if(reverse)
                       {
                           valueInput = configuration[i][0]["function"]["function_unformating"];
                       }
                       else
                       {
                           valueInput = configuration[i][0]["function"]["function_formating"];
                       }

                       switch(valueInput)
                       {
                            case "function_formating1":
                                //Console.WriteLine("function for formating");
                                Result = function_formating1(Result);
                                break;
                            case "function_unformating1":
                                //Console.WriteLine("function for unformating");
                                Result = function_unformating1(Result);
                                break;
                            default:
                                Console.WriteLine("no function implemented with this name");
                                break;
            
                       }
                    }
                }
                catch
                {

                }
            }


        return Result;
        }


        private static string function_formating1(string lresult)
        {
            Console.WriteLine("function for formating");
            return lresult;
        }

        private static string function_unformating1(string lresult)
        {
            Console.WriteLine("function for unformating");
            return lresult;
        }
    }   
}
