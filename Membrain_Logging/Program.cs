using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membrain_Logging
{
    class Program
    {

        // function calculate calenderweek
        public static int calculate_calenderweek(DateTime datum)
        {
            int calenderweek = (datum.DayOfYear / 7) + 1;
            if (calenderweek == 53) calenderweek = 1;
            return calenderweek;
        }

        static void Main(string[] args)
        {
            
            int week = calculate_calenderweek(DateTime.Now);
            string file_prefix = DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "-";

            string[] files = { "Server.log", "Server-SAP.log", "Server-SFC.log", "Json-Messages.log" };
            string sourcePath = @"c:\Program Files (x86)\Membrain\logs", targetPath = @"c:\Program Files (x86)\Membrain\logs\Archiv\";            

            foreach (string file in files)
            {
                string sourceFile = System.IO.Path.Combine(sourcePath, file);
                string destFile = System.IO.Path.Combine(targetPath, file_prefix + file);

                // check if file exist
                if (System.IO.File.Exists(sourceFile))
                {                    
                    // copy file to archiv with overwrite
                    System.IO.File.Copy(sourceFile, destFile, true);

                    // delete file in source
                    System.IO.File.Delete(sourceFile);
                }                
            }
        }
    }
}