using System;
using System.IO;
using Newtonsoft.Json;

namespace ConsoleApp45
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
           
            string str = @"C:\Users/source/repos/ConsoleApp45 ";
           
            Console.WriteLine("Folderin name  :");
            string folderName = Console.ReadLine();
             if (!Directory.Exists(str + folderName))
            {
                Directory.CreateDirectory(str + folderName);
            }
            else
            {
                Console.WriteLine($"{folderName} -Folder");
            }

            if (!File.Exists(str + folderName + @"\Database.json"))
            {
                var createFile = File.Create(str + folderName + @"\Database.json");
                createFile.Close();
            }
            else
            {
                Console.WriteLine("Database.json -  file");
            }

            Library library1 = new Library()
            {
                Name = "YorqunbirProqramci",
                Id = 20,
            };


            bool menuu = true;
            while (menuu)
            {
                Console.WriteLine("1. Add book");
                Console.WriteLine("2. Get book by id");
                Console.WriteLine("3. Remove book");
                Console.WriteLine("0. Quit");
                Console.WriteLine("Choice ");
                int input =int.Parse( Console.ReadLine());
                switch (input)
                {
                   
                    case 1:
                        int Id = IntInput(" Daxil Edin :", "tekrar ceht et");
                        string name = StringInput("name daxil et :");
                        double price = Musi("daxil Edin :", " xxxxxxxxxxxxxxxxx");
                        string authorName = StringInput("AuthorName daxil et :");
                       
                        Book book1 = new Book()
                        {
                            Id = Id,
                            Name = name,
                            Price = price,
                            AuthorName = authorName,
                        };

                        library1.AddBook(book1);
                        var a = JsonConvert.SerializeObject(library1);
                       //--------------------------------------------------------------------------
                        using (StreamWriter writer = new StreamWriter(str + folderName + @"\Database.json"))
                        {
                                writer.WriteLine(a);
                        }

                        break;
                    case 2:
                        int enterId = IntInput("Id daxil Ed :", "tekrar ceht et");                       
                        using (StreamReader reader = new StreamReader(str + folderName + @"\Database.json"))
                        {
                            var content = reader.ReadToEnd();
                            var decode = JsonConvert.DeserializeObject<Library>(content);
                           decode.GetBookById(enterId).ShowInfo();
                        }
                        break;
                    case 3:
                        int newId = IntInput("id daxil et :", "tekrar ceht et :");
                        string newLib = null;
                        using (StreamReader reader = new StreamReader(str + folderName + @"\Database.json"))
                        {
                            var b = reader.ReadToEnd();
                            var decode = JsonConvert.DeserializeObject<Library>(b);
                            decode.RemoveBook(newId);
                            var enCode = JsonConvert.SerializeObject(decode);
                            newLib = enCode;
                        }
                        using (StreamWriter writer = new StreamWriter(str + folderName + @"\Database.json"))
                        {
                            writer.WriteLine(newLib);
                        }
                        break;
                    case 0:
                        menuu = false;
                        break;



                }
            }
        }
        static string StringInput(string mssg)
        {
            Console.WriteLine(mssg);
            string input = Console.ReadLine();
            return input;
        }
        static int IntInput(string mssg1, string mssg2)
        {
            Console.WriteLine(mssg1);
            string inputStr = Console.ReadLine();
            int input;
            while (!int.TryParse(inputStr, out input))
            {
                Console.WriteLine(mssg2);
                inputStr = Console.ReadLine();
            }
            int.TryParse(inputStr, out input);
            return input;
        }
        static double Musi(string mssg1, string mssg2)
        {
            Console.WriteLine("mesaj 1");
            string inputStr = Console.ReadLine();
            double dbl;
            while (!double.TryParse(inputStr, out dbl))
            {
                Console.WriteLine(mssg2);
                inputStr = Console.ReadLine();
            }
            double.TryParse(inputStr, out dbl);
            return dbl;
        }
       

    }
}