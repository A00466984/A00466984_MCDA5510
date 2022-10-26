using System;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Linq;

namespace Assignment1
{
    public class SimpleCSVParser
    {


        //public static void Main(String[] args)
        //{

        //    SimpleCSVParser parser = new SimpleCSVParser();
        //    parser.parse(@"E:/MCDA/DotNet/MCDA5510_Assignments/Sample Data/2017/11/8/CustomerData0.csv");
        //}

        public void parse(String fileName,out int skippedCount, out int validCount)
        {
            skippedCount = 0;
            validCount = 0;
            try {
                var watch = new System.Diagnostics.Stopwatch();
                //watch.Start();
                using (TextFieldParser parser = new TextFieldParser(fileName))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                   
                    while (!parser.EndOfData)
                {
                    //Process row
                    string[] fields = parser.ReadFields();
                        //var writer = new StreamWriter(File.OpenWrite("D:\\work\\POCs\\POC_RESOURCES\\Pricing_Files\\index-edited-ap-east-1.csv"));
                        //foreach (string field in fields)
                        //{
                    string value = "";
                    
                    int pos = Array.IndexOf(fields, value);
                        if (pos > -1)
                        {
                            skippedCount++;
                        }
                        else
                        {
                           var filepath = "E:/MCDA/DotNet/MCDA5510_Assignments/Assignment1/Assignment1/Solution.csv";
                            
                            var line = string.Join(",", fields);
                            bool hasText = File.ReadLines(filepath).Any(l => l.Contains(line, StringComparison.Ordinal));  //to avoid repeating headers
                            if (hasText)
                            {
                                continue;
                            }
                            else
                            {
                                //Console.WriteLine(line);
                                using (StreamWriter writer = new StreamWriter(filepath, true))
                                {

                                    writer.WriteLine(line);
                                }
                                validCount++;
                                //writer.WriteLine(field);

                                // }
                            }
                        }
                }
                    //watch.Stop();
                    //var logpath = "E:/MCDA/DotNet/MCDA5510_Assignments/Assignment1/Assignment1/Logs.txt";
                    //using (StreamWriter writer = new StreamWriter(logpath, true))
                    //{
                        
                    //    writer.WriteLine("Total Skipped rows: "+skipped_rows);
                    //    writer.WriteLine("Total Valid Rows: "+valid_rows);
                    //    writer.WriteLine("Total Execution Time: " + watch.ElapsedMilliseconds + " ms");
                    //}
                }
        
        }catch(IOException ioe){
                Console.WriteLine(ioe.StackTrace);
         }

    }


    }
}
