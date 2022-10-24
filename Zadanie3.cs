/*3.	Работа с форматом JSON 
•	Создать файл формате JSON из редактора в 
•	Создать новый объект. Выполнить сериализацию объекта в формате JSON и записать в файл. 
•	Прочитать файл в консоль 
•	Удалить файл 
 */

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;


namespace HelloApp
{
    class Person
    {
        public string Name { get; set; }
        public string Age { get; set; }
    }
    class Zadanie3
    {
        static async Task Main(string[] args)
        {
            string path = @"C:\Users\student\Desktop\Zadanie3.json";
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists)
            {
                fileInf.Create(); // создание файла
            }
            Console.WriteLine("Введите имя для записи в файл:");
            string text1 = Console.ReadLine();
            Console.WriteLine("Введите возраст для записи в файл:");
            string text2 = Console.ReadLine();
            using (FileStream fs = new FileStream($"{path}user.json", FileMode.OpenOrCreate))
            {
                Person chel = new Person() { Name = text1, Age = text2 };
                await JsonSerializer.SerializeAsync<Person>(fs, chel);
                Console.WriteLine("Данные были записаны в файл");
            }
            using (FileStream fs = new FileStream($"{path}user.json", FileMode.OpenOrCreate))
            {
                Person restoredPerson = await JsonSerializer.DeserializeAsync<Person>(fs);
                Console.WriteLine($"Name: {restoredPerson.Name} Age: {restoredPerson.Age}");
            }
            string path2 = $"{path}user.json";
            FileInfo fInf = new FileInfo(path2);
            Console.WriteLine("После нажатия ENTER файл будет удалён:");
            string enter = Console.ReadLine();
            if (enter == "")
                if (fInf.Exists)
                {
                    fInf.Delete();
                }
        }
    }
}