using System;
using System.IO;

namespace _MDK_0104_Practice_8_
{
    internal class Program
    {
        delegate void MyDelegate();
        static void Main()
        {
            Delegate criateCreatingСatalog = new MyDelegate(CreatingTwoСatalog);
            CreatingTwoСatalog();
            Delegate outputInfoСatalog = new MyDelegate(OutputInfoСatalog);
            OutputInfoСatalog();
            Delegate outputInfoFileСatalog = new MyDelegate(OutputInfoFileCatalog);
            OutputInfoFileCatalog();
        }
        static void CreatingTwoСatalog()
        {
            string path = @"D:\MyDir\temp";
            string path2 = @"D:\1111";
            FileStream file = new FileStream("file1.txt", FileMode.Create);
            if (!Directory.Exists(path) && !Directory.Exists(path2))
            {
                Directory.CreateDirectory(path);
                Directory.CreateDirectory(path2);
                Console.WriteLine("Создание каталога по пути D:\\MyDir\\temp - успешно");
                Console.WriteLine("Создание каталога по пути D:\\1111 - успешно");
            }
            //Заполнение 2 файлами каталога 1111
            if (Directory.Exists(path2))
            {
                string directoryPath = @"D:\1111";
                string fileName1 = "file1.txt";
                string fileName2 = "file2.txt";
                string filePath1 = Path.Combine(directoryPath, fileName1);
                string filePath2 = Path.Combine(directoryPath, fileName2);
                File.Create(filePath1).Close();
                File.Create(filePath2).Close();
            }

        }

        static void OutputInfoСatalog()
        {
            string path = @"D:\MyDir\temp";
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            if (Directory.Exists(path))
            {
                Console.WriteLine("|| Информация о каталоге:");
                Console.WriteLine("|| Имя каталога: " + Path.GetFileName(path));
                Console.WriteLine("|| Имя диска: " + Path.GetPathRoot(path));
                Console.WriteLine("|| Имя родительского каталога: " + Directory.GetParent(path));
                Console.WriteLine("|| Полный путь к каталогу: " + Path.GetFullPath(path));
                Console.WriteLine("|| Дата создания: " + Directory.GetCreationTime(path));
                Console.WriteLine("|| Дата последнего доступа: " + Directory.GetLastAccessTime(path));
                Console.WriteLine("|| Дата последнего изменения: " + Directory.GetLastWriteTime(path));
                Console.WriteLine("|| Атрибуты: " + directoryInfo.Attributes);
            }
        }
        static void OutputInfoFileCatalog()
        {
            string sourceDirectory = @"D:\1111";
            string targetDirectory = @"D:\MyDir\temp";

            if (Directory.Exists(sourceDirectory) && Directory.Exists(targetDirectory))
            {
                string[] directories = Directory.GetDirectories(sourceDirectory);

                foreach (string directory in directories)
                {
                    string[] files = Directory.GetFiles(directory);

                    foreach (string file in files)
                    {
                        FileInfo fileInfo = new FileInfo(file);

                        Console.WriteLine("Название файла: " + fileInfo.Name);
                        Console.WriteLine("Полное имя: " + fileInfo.FullName);
                        Console.WriteLine("Расширение: " + fileInfo.Extension);
                        Console.WriteLine("Имя родительского каталога: " + Path.GetDirectoryName(directory));
                        Console.WriteLine("Время создания: " + fileInfo.CreationTime);
                        Console.WriteLine("Время последнего доступа: " + fileInfo.LastAccessTime);
                        Console.WriteLine("Время последнего изменения: " + fileInfo.LastWriteTime);
                        Console.WriteLine("Атрибуты: " + fileInfo.Attributes);
                    }
                }
            }
        }
    }
}