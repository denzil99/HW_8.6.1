using System;
using System.IO;

namespace HW_8._6._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите путь к папке, которую желаете удалить: ");
            string pathTemp = Console.ReadLine();
            string path = @pathTemp;

            while (!Directory.Exists(path))
            {
                Console.WriteLine("Вы ввели путь неправильно");
                Console.Write("Введите путь еще раз - ");
                path = $"{Console.ReadLine()}";
            }



            //string path = @"C:\Users\Артем\Desktop\testDeleteFiles\TestTrue"; //тестовый путь
            DateTime dayT = DateTime.Now;
            TimeSpan timeS = TimeSpan.FromMinutes(30);
            FindAndDeleteFiles(path, dayT, timeS);
            PereborFold(path, dayT, timeS);

            Console.ReadKey();

        }


        public static void FindAndDeleteFiles(string path, DateTime dayT, TimeSpan timeS)
        {

            

                var dir = Directory.GetFiles(path);
                foreach (var file in dir)
                {
                    var flwt = File.GetLastWriteTime(file);

                    if ((dayT - flwt) > timeS)
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            
        }

        public static void PereborFold(string path, DateTime dayT, TimeSpan timeS)
        {


            var dirIs = Directory.GetDirectories(path);
            foreach (var dir in dirIs)
            {
                FindAndDeleteFiles(dir, dayT, timeS);
                PereborFold(dir, dayT, timeS);


                DirectoryInfo di = new DirectoryInfo(dir);
                var flwt = di.LastWriteTime;

                try
                {
                    if ((dayT - flwt) > timeS)
                    {
                        di.Delete();
                    }
                    
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }

            //foreach (var dir in dirs)
            //{

            //    Console.WriteLine();
            //    //GetFolders(dir);
            //}

            //using (FileStream fs = Directory.GetFiles(path))
            //{

            //}

        }
        //public void Perebor (string path)
        //{
        //    foreach 
        //}


    }
}
