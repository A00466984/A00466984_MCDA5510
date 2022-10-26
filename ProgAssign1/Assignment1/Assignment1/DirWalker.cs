using System;
using System.IO;

namespace Assignment1
{
  

    public class DirWalker
    {
        public int SkippedCount { get; set; }
        public int TotalCount { get; set; }
        public void walk(String path)
        {

            string[] list = Directory.GetDirectories(path);


            if (list == null) return;

            foreach (string dirpath in list)
            {
                if (Directory.Exists(dirpath))
                {
                    walk(dirpath);
                    //Console.WriteLine("Dir:" + dirpath);
                }
            }
            string[] fileList = Directory.GetFiles(path);
            foreach (string filepath in fileList)
            {

                //Console.WriteLine("File:" + filepath);
               // String path1 = "E:/MCDA/DotNet/MCDA5510_Assignments/Sample Data/2017/11/8";

                SimpleCSVParser parser = new SimpleCSVParser();
                
                parser.parse(filepath, out int skipCount, out int total);

                SkippedCount += skipCount;
                TotalCount += total;
            }
        }

        public static void Main(String[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            DirWalker fw = new DirWalker();
            var folderpath = "E:\\MCDA\\DotNet\\MCDA5510_Assignments\\Sample Data";
            
            //StreamWriter sw = new StreamWriter();
            // OpenStream(folderpath);
            fw.walk(folderpath);
            watch.Stop();
            var logpath = "E:/MCDA/DotNet/MCDA5510_Assignments/Assignment1/Assignment1/Logs.txt";
            using (StreamWriter writer = new StreamWriter(logpath, true))
            {

                writer.WriteLine("total skipped rows: " + fw.SkippedCount);
                writer.WriteLine("total rows: " + fw.TotalCount);
                writer.WriteLine("Total Execution Time: " + watch.ElapsedMilliseconds + " ms");
            }
        }

    }
}
