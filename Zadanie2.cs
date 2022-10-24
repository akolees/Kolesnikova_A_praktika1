/*2.	Работа с файлами ( класс File, FileInfo, FileStream и другие) 
•	Создать файл 
•	Записать в файл строку 
•	Прочитать файл в консоль 
•	Удалить файл */

using System;
using System.IO;

namespace HelloApp
{
    class Zadanie2
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\student\Desktop\Zadanie2.txt";
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists)
            {
                fileInf.Create(); // создание файла
            }
            Console.WriteLine("Введите строку для записи в файл:");
            string text = Console.ReadLine();

            //запись строки в файл
            using (FileStream fstream = new FileStream($"{path}", FileMode.Open))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                fstream.Write(array, 0, array.Length);
                Console.WriteLine("Текст записан в файл");
            }

            //чтение строки из файла
            using (FileStream fstream = File.OpenRead($"{path}"))
            {
                byte[] array = new byte[fstream.Length];
                fstream.Read(array, 0, array.Length);
                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"Текст из файла: {textFromFile}");
            }

            //удаление файла
            if (fileInf.Exists)
            {
                fileInf.Delete();
            }
        }
    }
}

