using System;
using System.IO;

class FileManager
{
    public void CreateFileWithText(string path, string text)
    {
        File.WriteAllText(path, text);
    }

    public string ReadFile(string path)
    {
        return File.ReadAllText(path);
    }

    public void DeleteFile(string path)
    {
        File.Delete(path);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path);
    }

    public void CopyFile(string sourcePath, string destPath)
    {
        File.Copy(sourcePath, destPath, true);
    }

    public void MoveFile(string sourcePath, string destPath)
    {
        File.Move(sourcePath, destPath, true);
    }

    public void RenameFile(string sourcePath, string newPath)
    {
        File.Move(sourcePath, newPath, true);
    }

    public void WriteToFile(string path, string text)
    {
        File.AppendAllText(path, text);
    }

    public void DeleteFilesByPattern(string folderPath, string pattern)
    {
        string[] files = Directory.GetFiles(folderPath, pattern);

        foreach (string file in files)
        {
            File.Delete(file);
        }
    }

    public void ShowAllFiles(string folderPath)
    {
        string[] files = Directory.GetFiles(folderPath);

        Console.WriteLine("\nСписок файлов в папке:");
        foreach (string file in files)
        {
            Console.WriteLine(Path.GetFileName(file));
        }
    }

    public void SetReadOnly(string path, bool readOnly)
    {
        FileInfo fileInfo = new FileInfo(path);

        if (readOnly)
            fileInfo.Attributes |= FileAttributes.ReadOnly;
        else
            fileInfo.Attributes &= ~FileAttributes.ReadOnly;
    }

    public void ShowFilePermissions(string path)
    {
        FileInfo fileInfo = new FileInfo(path);

        Console.WriteLine("\nПрава доступа к файлу:");
        Console.WriteLine("Чтение: доступно");

        if ((fileInfo.Attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
            Console.WriteLine("Запись: запрещена");
        else
            Console.WriteLine("Запись: доступна");

        Console.WriteLine("Выполнение: зависит от типа файла и ОС");
    }

    public void CompareFilesBySize(string file1, string file2)
    {
        FileInfo f1 = new FileInfo(file1);
        FileInfo f2 = new FileInfo(file2);

        Console.WriteLine("\nСравнение файлов по размеру:");
        if (f1.Length > f2.Length)
            Console.WriteLine($"{Path.GetFileName(file1)} больше");
        else if (f1.Length < f2.Length)
            Console.WriteLine($"{Path.GetFileName(file2)} больше");
        else
            Console.WriteLine("Файлы одинакового размера");
    }
}

class FileInfoProvider
{
    public void ShowFileInfo(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не существует");
            return;
        }

        FileInfo fileInfo = new FileInfo(path);

        Console.WriteLine("\nИнформация о файле:");
        Console.WriteLine("Имя: " + fileInfo.Name);
        Console.WriteLine("Размер: " + fileInfo.Length + " байт");
        Console.WriteLine("Дата создания: " + fileInfo.CreationTime);
        Console.WriteLine("Дата изменения: " + fileInfo.LastWriteTime);
    }
}

class Program
{
    static void Main()
    {
        FileManager fileManager = new FileManager();
        FileInfoProvider infoProvider = new FileInfoProvider();

        string baseFolder = Path.Combine(Directory.GetCurrentDirectory(), "FilesDemo");
        string newFolder = Path.Combine(baseFolder, "NewFolder");

        Directory.CreateDirectory(baseFolder);
        Directory.CreateDirectory(newFolder);

        string filePath = Path.Combine(baseFolder, "августинович.ав");
        string copyPath = Path.Combine(baseFolder, "copy_августинович.ав");
        string movedPath = Path.Combine(newFolder, "moved_августинович.ав");
        string renamedPath = Path.Combine(newFolder, "familiya.io");
        string file2Path = Path.Combine(baseFolder, "second.av");

        // 1. Создать файл, записать текст, прочитать и вывести
        Console.WriteLine("1. Создание, запись и чтение файла");
        fileManager.CreateFileWithText(filePath, "Это тестовый текст в файле августинович.ав");
        Console.WriteLine(fileManager.ReadFile(filePath));

        // 2. Проверить существование перед удалением
        Console.WriteLine("\n2. Проверка существования файла перед удалением");
        if (fileManager.FileExists(file2Path))
        {
            fileManager.DeleteFile(file2Path);
            Console.WriteLine("Файл second.av удален");
        }
        else
        {
            Console.WriteLine("Файл second.av не существует");
        }

        // 3. Получить информацию о файле
        Console.WriteLine("\n3. Информация о файле");
        infoProvider.ShowFileInfo(filePath);

        // 4. Скопировать файл и убедиться, что копия существует
        Console.WriteLine("\n4. Копирование файла");
        fileManager.CopyFile(filePath, copyPath);
        if (fileManager.FileExists(copyPath))
            Console.WriteLine("Копия файла успешно создана");

        // 5. Переместить файл в новую директорию
        Console.WriteLine("\n5. Перемещение файла");
        fileManager.MoveFile(copyPath, movedPath);
        if (fileManager.FileExists(movedPath))
            Console.WriteLine("Файл успешно перемещен");

        // 6. Переименовать файл в familiya.io
        Console.WriteLine("\n6. Переименование файла");
        fileManager.RenameFile(movedPath, renamedPath);
        if (fileManager.FileExists(renamedPath))
            Console.WriteLine("Файл успешно переименован в familiya.io");

        // 7. Обработать ошибку при удалении несуществующего файла
        Console.WriteLine("\n7. Удаление несуществующего файла");
        try
        {
            string fakePath = Path.Combine(baseFolder, "not_exists.av");
            fileManager.DeleteFile(fakePath);
            Console.WriteLine("Попытка удаления завершена");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }

        // 8. Сравнить два файла по размеру
        Console.WriteLine("\n8. Сравнение файлов по размеру");
        fileManager.CreateFileWithText(file2Path, "Короткий текст");
        fileManager.CompareFilesBySize(filePath, file2Path);

        // 9. Удалить все файлы с расширением .ав
        Console.WriteLine("\n9. Удаление файлов по шаблону");
        string extra1 = Path.Combine(baseFolder, "one.ав");
        string extra2 = Path.Combine(baseFolder, "two.ав");
        File.WriteAllText(extra1, "1");
        File.WriteAllText(extra2, "2");

        fileManager.DeleteFilesByPattern(baseFolder, "*.ав");
        Console.WriteLine("Все файлы с расширением .ав удалены");

        // 10. Вывести список всех файлов в директории
        Console.WriteLine("\n10. Список файлов в директории");
        fileManager.ShowAllFiles(baseFolder);

        // 11. Запретить запись в файл и попытаться записать в него
        Console.WriteLine("\n11. Запрет записи в файл");
        string protectedFile = Path.Combine(baseFolder, "protected.txt");
        fileManager.CreateFileWithText(protectedFile, "Начальный текст");
        fileManager.SetReadOnly(protectedFile, true);

        try
        {
            fileManager.WriteToFile(protectedFile, "\nНовая строка");
            Console.WriteLine("Запись выполнена");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка записи: " + ex.Message);
        }

        // 12. Проверить права к файлу
        Console.WriteLine("\n12. Проверка прав доступа");
        fileManager.ShowFilePermissions(protectedFile);

        Console.ReadLine();
    }
}