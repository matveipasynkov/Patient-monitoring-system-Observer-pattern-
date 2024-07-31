using System.Text.Json;

namespace Library;

/// <summary>
/// Данный класс содержит методы для взаимодействия с пользователем (меню, вывод данных на консоль и т.д.).
/// </summary>
public static class InteractWithUser
{
    // Путь открытого файла.
    static string openedFile = "";

    // Список пациентов.
    static List<Patient> patients = new List<Patient> { };

    // Перечисление команд меню.
    enum MenuCommand
    {
        Sorting = 1,
        ChangeTheField = 2,
        StopTheProgramm = 3
    }

    // Перечисление типов вывода данных.
    enum TypeOfSavingData
    {
        Standart = 1,
        InFile = 2,
        Nothing = 3
    }

    // Тип сохранения в файл (существующий, т.е. открытый, или в новый.)
    enum TypeOfFile
    {
        Exist,
        NotExist
    }

    /// <summary>
    /// Данный метод получает список пациентов из JSON-файла.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static List<Patient> GetTheData()
    {

        string path = Checks.CheckPathOfInput();

        string inputJson = File.ReadAllText(path);

        JsonElement jsonPatients = JsonSerializer.Deserialize<JsonElement>(inputJson);

        List<Patient> patients = new List<Patient> { };

        foreach (JsonElement jsonPatient in jsonPatients.EnumerateArray())
        {
            patients.Add(new Patient(jsonPatient));
        }

        openedFile = path;

        if (patients.Count == 0)
        {
            // В случае, если в файле нет пациентов, то мы выбрасываем ошибку аргумента, так как он неверен.
            throw new ArgumentException();
        }

        return patients;
    }

    /// <summary>
    /// Данный метод выводит меню пользователю.
    /// </summary>
    public static void PrintMenu()
    {
        Console.WriteLine("Доступные команды:");
        Console.WriteLine("    1. Отсортировать данные по одному из полей.");
        Console.WriteLine("    2. Изменить параметры одного из пациентов.");
        Console.WriteLine("    3. Завершить программу.");
    }

    /// <summary>
    /// Данный метод реализует меню.
    /// </summary>
    /// <param name="programIsWorking"></param>
    /// <param name="havePatients"></param>
    public static void Menu(ref bool programIsWorking, bool havePatients)
    {
        if (!havePatients)
        {
            patients = GetTheData();
            AutoSaver autosaver = new AutoSaver(patients, openedFile);
        }

        Console.Clear();

        PrintMenu();

        MenuCommand cmd = (MenuCommand)Checks.CheckMenuCommand();
        List<Patient> result = new List<Patient> { };

        Console.Clear();

        switch (cmd)
        {
            case MenuCommand.ChangeTheField:

                result = ChangeTheField.ChangeInfo(patients);

                break;

            case MenuCommand.Sorting:

                // В качестве альтернативного решения можно использовать альтернативную сортировку из класса Sortings (InsertionSort).
                result = Sortings.BubbleSort(patients);

                break;

            case MenuCommand.StopTheProgramm:

                programIsWorking = false;

                break;
        }

        Console.Clear();

        if (result.Count > 0)
        {
            patients = result;
            SaveTheData(patients);
        }

        // В случае, если пользователь не хочет завершать работу с файлом, то мы запускаем меню вновь. 
        if (programIsWorking)
        {
            Menu(ref programIsWorking, true);
        }
    }

    /// <summary>
    /// Данный метод реализует вывод (сохранение) данных в файл.
    /// </summary>
    /// <param name="patients"></param>
    public static void SaveTheData(List<Patient> patients)
    {
        PrintSaveTheData();

        JsonSerializerOptions options = new(JsonSerializerDefaults.Web)
        {
            WriteIndented = true
        };

        string result = JsonSerializer.Serialize(patients, options);

        TypeOfSavingData typeOfSaving = (TypeOfSavingData)Checks.CheckTypeOfSavingData();

        Console.Clear();

        switch (typeOfSaving)
        {
            case TypeOfSavingData.Standart:

                Console.WriteLine(result);

                break;

            case TypeOfSavingData.InFile:

                Console.WriteLine("Вы хотите перезаписать файл, из которого были получены данные, или записать в новый?");

                TypeOfFile typeOfFile = (TypeOfFile)Checks.CheckTypeOfFile();

                Console.Clear();

                string path = "";

                if (typeOfFile == TypeOfFile.NotExist)
                {
                    path = Checks.CheckPathOfOutput();
                    Console.Clear();
                }
                else
                {
                    path = openedFile;
                }

                File.WriteAllText(path, result);

                Console.WriteLine("Выполнено!");

                break;
        }

        if (typeOfSaving != TypeOfSavingData.Nothing)
        {
            Checks.CheckEndOfView();
        }
    }

    /// <summary>
    /// Данный метод выводит тип вывода данных.
    /// </summary>
    public static void PrintSaveTheData()
    {
        Console.WriteLine("Как вы хотите сохранить данные?");
        Console.WriteLine("	1. Вывести на консоль.");
        Console.WriteLine("	2. Сохранить в файл.");
        Console.WriteLine("	3. Я не хочу выводить/сохранять данные.");
    }
}