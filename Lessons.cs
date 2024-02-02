using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Module_6_File
{
    internal class Lessons
    {
        static void MathDatetime()
        {
            DateTime date = new DateTime(2020, 09, 28, 01, 30, 00);

            date.ToShortTimeString();
            date.ToShortDateString();

            date = DateTime.Now;
            static void SomeFunc()
            {
                for (int i = 0; i < 1_000_000; i++)
                {
                    double z = Math.PI * i;
                }
            }
            TimeSpan timeSpan = DateTime.Now.Subtract(date);

            double workTime = timeSpan.TotalMicroseconds;
        }
        static void StringFunc()
        {
            string str = "JKNKNLKNLMNLmm,n";
            str.IndexOf('J');
            

            str.Insert(str.IndexOf(' ') + 1, "lklk");
            str.Remove(10);

            String.IsNullOrEmpty(str);

            char c = 'a';
            Char.IsDigit(c);
            Char.IsLetter(c);
            Char.IsLetterOrDigit(c);
        }
        static void FileFunc()
        {
            string text = File.ReadAllText("F:\\c#Projects\\Module_6_File\\TestText\\Text.txt");
            //Console.WriteLine(text);

            string[] textLine = File.ReadAllLines("F:\\c#Projects\\Module_6_File\\TestText\\Text.txt");
            //Console.WriteLine(String.Concat(textLine));

            File.WriteAllText("F:\\c#Projects\\Module_6_File\\TestText\\Text_2.txt", text);
            File.WriteAllLines("F:\\c#Projects\\Module_6_File\\TestText\\Text_3.txt", textLine);

            File.AppendAllLines("F:\\c#Projects\\Module_6_File\\TestText\\Text.txt", textLine);
            File.AppendAllText("F:\\c#Projects\\Module_6_File\\TestText\\Text.txt", text);

            //File.Copy("F:\\c#Projects\\Module_6_File\\TestText\\Text_3.txt", "F:\\c#Projects\\Module_6_File\\TestText\\Text.txt");
            //File.Delete("");
            //File.Exists("");
            //File.Move("", "");
        }
        static void __SrteamWriter()
        {
            var dirs  = new DirectoryInfo(@"c:\").GetDirectories();


            StreamWriter streamWriter = new StreamWriter("F:\\c#Projects\\Module_6_File\\TestText\\newTextFile.txt");
            foreach (var item in dirs)
            {
                 streamWriter.WriteLine(item.Name);
            }
            streamWriter.Close();

            using (StreamWriter sw = new StreamWriter("newTextFile.txt"))
            {
                foreach (var item in dirs)
                {
                    sw.WriteLine(item.Name);
                }
            }
            using (StreamReader sr = new StreamReader("newTextFile.txt"))
            {
                 while(!sr.EndOfStream)
                {
                    Console.WriteLine(sr.Read());
                }
            }
        }
        static void StringBuilder()
        {
            StringBuilder sb = new StringBuilder("kjlkjhjkhkjhkjh");
            sb.Append("k");
            sb.AppendLine("lklklk ;l;");
            sb.Remove(1, 4);
            sb.Replace("d", "a");
            sb[1] = 's';
            
        }
    }   
}
