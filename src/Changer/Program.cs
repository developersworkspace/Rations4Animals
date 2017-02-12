using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace Run
{
    class Program
    {
        static void Main(string[] args)
        {
            //Run version Web.config
            if (args[0].Equals("version")) {
            string data = File.ReadAllText(args[1]);

            MatchCollection mc1 = Regex.Matches(data, "<add key=\"webpages:Version\" value=\"[0-9]+[.][0-9]+[.][0-9]+[.][0-9]+\" />");

            string match = mc1[0].Value;

            MatchCollection mc2 = Regex.Matches(match, "[0-9]+[.][0-9]+[.][0-9]+[.][0-9]+");

            string[] version = mc2[0].Value.Split('.');
            int build = Convert.ToInt32(version[3]) + 1;

            string newVersion = string.Format("<add key=\"webpages:Version\" value=\"{0}.{1}.{2}.{3}\" />", version[0], version[1], version[2], build);


            StreamWriter sw = new StreamWriter(args[1]);
            sw.WriteLine(data.Replace(match, newVersion));
            sw.Close();

            }
            //Run backup Web.config BaseFolder BackupFolder
            if (args[0].Equals("backup"))
            {
                string data = File.ReadAllText(args[1]);

                MatchCollection mc1 = Regex.Matches(data, "<add key=\"webpages:Version\" value=\"[0-9]+[.][0-9]+[.][0-9]+[.][0-9]+\" />");

                string match = mc1[0].Value;

                MatchCollection mc2 = Regex.Matches(match, "[0-9]+[.][0-9]+[.][0-9]+[.][0-9]+");

                string version = mc2[0].Value;

                Form1 f = new Form1();
                f.ShowDialog();

                if (f.comment != null) {
                    Copy(args[2], string.Format("{0}_{1}", args[3], version));
                    File.AppendAllText(string.Format("{0}_{1}\\LogFile.txt", args[3], version), f.comment);
                }

            }

        }

        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists; if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

    }
}
