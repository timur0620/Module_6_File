using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Bogus;
using System.IO;


namespace Module_6_File
{
    internal class Program
    {   
        static void Main(string[] args)
        {
            string path = @"F:\c#Projects\Module_6_File\FileFromHomeWork\PersonData.txt";

            DataController(path);
        }
        static string[,] AddStatusEmployer()
        {
            Console.WriteLine("Enter the employee's data");
                            
            var faker = new Faker("sk");
            Console.Write(faker.Name.FullName());

            string[,] dataEmployer = new string[,] { { "id", "null"},
                                                     { "date registration", "null"},
                                                     { "full name","null" },
                                                     { "height", "null" },
                                                     { "date of birth", "null" },
                                                     { "place of birth", "null" } 
                                                     };

            for (int i = 0; i < dataEmployer.Length / 2; i++)
            {   
                Console.Write($" {dataEmployer[i, 0]}_____ ".ToUpper());
                string someData = Console.ReadLine();

                dataEmployer[i, 1] = someData;

                if (someData.Equals(""))
                {   
                    Console.WriteLine($"Random employee data {dataEmployer[i, 0]}".ToUpper());
                    Random random = new Random();

                    if (dataEmployer[i, 0] == "id") dataEmployer[i, 1] = int.MaxValue.ToString();
                    else if (dataEmployer[i, 0] == "date registration") dataEmployer[i, 1] = DateTime.Now.ToString();
                    else if (dataEmployer[i, 0] == "full name") dataEmployer[i, 1] = faker.Person.FullName;
                    else if (dataEmployer[i, 0] == "height") dataEmployer[i, 1] = random.Next(150, 180).ToString();
                    else if (dataEmployer[i, 0] == "date of birth") dataEmployer[i, 1] = faker.Person.DateOfBirth.ToString();
                    else if (dataEmployer[i, 0] == "place of birth") dataEmployer[i, 1] = faker.Person.Address.City;
                }
            }
            return dataEmployer;
        }
        static void RecordInFile(string[,] dataPerson, string path)
        {          
            if (!File.Exists(path))
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.Write("<> ");
                    for (int i = 0; i < dataPerson.Length / 2; i++)
                    {
                        sw.Write(dataPerson[i, 0].ToUpper() + "-->" + dataPerson[i, 1] + " | ");
                    }
                    sw.Write(" <>");
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.Write('\n');
                    sw.Write("<> ");
                    for (int i = 0; i < dataPerson.Length / 2; i++)
                    {
                        sw.Write(dataPerson[i, 0].ToUpper() + "-->" + dataPerson[i, 1] + " | ");
                    }
                    sw.Write(" <>");
                }
            }
            
        }
        static void DataController (string path)
        {
            Console.Write(" Press 1 if you want to view the data \n " +
                           "Press 2 if you want to entered data \n");

            char choice = char.Parse (Console.ReadLine());

            if (choice == '1')
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }
            else if (choice == '2')
            {
                string[,] dataEmployer = AddStatusEmployer();

                RecordInFile(dataEmployer, path);
            }
            else
            {
                Console.WriteLine("Error!!! Try again");
            }
        }
    }
}
