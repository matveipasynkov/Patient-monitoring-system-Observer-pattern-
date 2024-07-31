using System;
namespace Library;

/// <summary>
/// Класс, содержащий различные проверки корректности данных.
/// </summary>
public static class Checks
{
    /// <summary>
    /// Данный метод реализует проверку пути, введённого пользователем.
    /// </summary>
    /// <returns></returns>
    public static string CheckPathOfInput()
    {
        bool flagPath = false;

        string path = "";

        while (!flagPath)
        {
            Console.Write("Введите путь: ");

            path = Console.ReadLine();

            try
            {
                File.ReadAllLines(path);

                if (path[^5..] == ".json")
                {
                    flagPath = true;
                }
                else
                {
                    Console.Write("Файл неверного формата. Попробуйте ещё раз. ");
                }
            }
            catch
            {
                Console.Write("Введён неверный путь. Попробуйте ещё раз. ");
            }
        }

        return path;
    }

    /// <summary>
    /// Данный метод проверяет корректность команды меню, введённой пользователем.
    /// </summary>
    /// <returns></returns>
    public static int CheckMenuCommand()
    {
        bool flagMenuCommand = false;

        int cmd = 0;

        while (!flagMenuCommand)
        {
            Console.Write("Введите команду: ");

            string msg = Console.ReadLine();

            if (int.TryParse(msg, out cmd))
            {
                if (cmd >= 1 && cmd <= 3)
                {
                    flagMenuCommand = true;
                }
            }

            if (!flagMenuCommand)
            {
                Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
            }
        }

        return cmd;
    }

    /// <summary>
    /// Данный метод проверяет корректность номера пациента, введённого пользователем.
    /// </summary>
    /// <param name="patients"></param>
    /// <returns></returns>
    public static int CheckPatientNumber(List<Patient> patients)
    {
        int index = 0;

        bool flagCheckedPatientNumber = false;

        while (!flagCheckedPatientNumber)
        {
            Console.Write($"Введите нормер нужного вам пациента (от 1 до {patients.Count}): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out index))
            {
                if (index >= 1 && index <= patients.Count)
                {
                    flagCheckedPatientNumber = true;
                }
                else
                {
                    Console.Write("Номер пациента не лежит в нужном диапазоне. Попробуйте ещё раз. ");
                }
            }
            else
            {
                Console.Write("Введённое значение - не число. Попробуйте ещё раз. ");
            }
        }

        return index - 1;
    }

    /// <summary>
    /// Данный метод проверяет корректность поля пациента, введённого пользователем.
    /// </summary>
    /// <param name="patients"></param>
    /// <param name="isSorting"></param>
    /// <returns></returns>
    public static string CheckPatientField(List<Patient> patients, bool isSorting)
    {
        string[] patientFields = new string[0];
        if (!isSorting)
        {
            patientFields = new string[] { "name", "age", "gender", "diagnosis", "state", "sensors" };
            Console.WriteLine("Доступные команды: name, age, gender, diagnosis, state, sensors.");
        }
        else
        {
            patientFields = new string[] { "patient_id", "name", "age", "gender", "diagnosis", "state", "sensors" };
        }

        string cmd = "";
        bool flagPatientField = false;

        while (!flagPatientField)
        {
            Console.Write("Введите одну из доступных команд: ");

            cmd = Console.ReadLine();

            int index = Array.IndexOf(patientFields, cmd);

            if (index != -1)
            {
                flagPatientField = true;
            }
            else
            {
                Console.Write("Введено неверное поле. Попробуйте ещё раз. ");
            }
        }

        return cmd;
    }

    /// <summary>
    /// Данный метод проверяет корректность номера сенсора, введённого пользователем.
    /// </summary>
    /// <param name="patient"></param>
    /// <returns></returns>
    public static int CheckSensorNumber(Patient patient)
    {
        int index = 0;

        bool flagCheckedSensorNumber = false;

        while (!flagCheckedSensorNumber)
        {
            Console.Write($"Введите нормер нужного вам сенсора (от 1 до {patient.Sensors.Count}): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out index))
            {
                if (index >= 1 && index <= patient.Sensors.Count)
                {
                    flagCheckedSensorNumber = true;
                }
                else
                {
                    Console.Write("Номер сенсора не лежит в нужном диапазоне. Попробуйте ещё раз. ");
                }
            }
            else
            {
                Console.Write("Введённое значение - не число. Попробуйте ещё раз. ");
            }
        }

        return index - 1;
    }

    /// <summary>
    /// Данный метод проверяет корректность поля сенсора, введённого пользователем.
    /// </summary>
    /// <param name="sensor"></param>
    /// <returns></returns>
    public static string CheckSensorField(Sensor sensor)
    {
        string[] sensorFields = { "sensor_name", "severity", "lower_threshold", "upper_threshold" };
        Console.WriteLine("Доступные команды: sensor_name, severity, lower_threshold, upper_threshold.");

        string cmd = "";
        bool flagSensorField = false;

        while (!flagSensorField)
        {
            Console.Write("Введите одну из доступных команд: ");

            cmd = Console.ReadLine();

            int index = Array.IndexOf(sensorFields, cmd);

            if (index != -1)
            {
                flagSensorField = true;
            }
            else
            {
                Console.Write("Введено неверное поле. Попробуйте ещё раз. ");
            }
        }

        return cmd;
    }

    /// <summary>
    /// Данный метод проверяет корректность нового значения поля сенсора, введённого пользователем.
    /// </summary>
    /// <param name="sensor"></param>
    /// <param name="field"></param>
    /// <returns></returns>
    public static string CheckSensorValue(Sensor sensor, string field)
    {
        string input = "";

        bool flagCheckedValue = false;

        while (!flagCheckedValue)
        {
            Console.Write($"Введите новое значение поля {field} для сенсора {sensor.SensorName}: ");

            input = Console.ReadLine();

            if (field == "sensor_name" || field == "severity")
            {
                flagCheckedValue = true;
            }
            else if (field == "lower_threshold")
            {
                int value = 0;

                if (int.TryParse(input, out value))
                {
                    if (value < sensor.UpperThreshold)
                    {
                        flagCheckedValue = true;
                    }
                    else
                    {
                        Console.Write("Нижний порог больше верхнего, чего быть не может. Попробуйте ещё раз. ");
                    }
                }
                else
                {
                    Console.Write("Вы ввели не число. Попробуйте ещё раз. ");
                }
            }
            else
            {
                int value = 0;

                if (int.TryParse(input, out value))
                {
                    if (value > sensor.LowerThreshold)
                    {
                        flagCheckedValue = true;
                    }
                    else
                    {
                        Console.Write("Верхний порог меньше нижнего, чего быть не может. Попробуйте ещё раз. ");
                    }
                }
                else
                {
                    Console.Write("Вы ввели не число. Попробуйте ещё раз. ");
                }
            }
        }

        return input;
    }

    /// <summary>
    /// Данный метод проверяет корректность нового значения поля пациента, введённого пользователем.
    /// </summary>
    /// <param name="patient"></param>
    /// <param name="field"></param>
    /// <returns></returns>
    public static string CheckPatientValue(Patient patient, string field)
    {
        string input = "";

        bool flagCheckedValue = false;

        while (!flagCheckedValue)
        {
            Console.Write($"Введите новое значение поля {field} для пациента {patient.Name}: ");

            input = Console.ReadLine();

            if (field == "name" || field == "gender" || field == "diagnosis")
            {
                flagCheckedValue = true;
            }
            else if (field == "age")
            {
                int value = 0;

                if (int.TryParse(input, out value))
                {
                    if (value > 0)
                    {
                        flagCheckedValue = true;
                    }
                    else
                    {
                        Console.Write("Возраст меньше или равен 0, чего быть не может. Попробуйте ещё раз. ");
                    }
                }
                else
                {
                    Console.Write("Вы ввели не число. Попробуйте ещё раз. ");
                }
            }
            else
            {
                double value = 0;

                if (double.TryParse(input, out value))
                {
                    flagCheckedValue = true;
                }
                else
                {
                    Console.Write("Вы ввели не число. Попробуйте ещё раз. ");
                }
            }
        }

        return input;
    }

    /// <summary>
    /// Данный метод проверяет, что пользователь нажал Enter, чтобы завершить просмотр результата программы.
    /// </summary>
    public static void CheckEndOfView()
    {
        Console.WriteLine("Нажмите Enter, чтобы завершить просмотр.");

        while (Console.ReadKey().Key != ConsoleKey.Enter) ;
    }

    /// <summary>
    /// Данный метод проверяет корректность типа вывода данных.
    /// </summary>
    /// <returns></returns>
    public static int CheckTypeOfSavingData()
    {
        bool flagCheckTypeOfSaving = false;

        int typeOfSaving = 0;

        while (!flagCheckTypeOfSaving)
        {
            Console.Write("Введите команду: ");

            string value = Console.ReadLine();

            if (int.TryParse(value, out typeOfSaving))
            {
                if (typeOfSaving >= 1 && typeOfSaving <= 3)
                {
                    flagCheckTypeOfSaving = true;
                }

            }

            if (!flagCheckTypeOfSaving)
            {
                Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
            }
        }

        return typeOfSaving;
    }

    /// <summary>
    /// Данный метод проверяет корректность пути для создания нового файла.
    /// </summary>
    /// <returns></returns>
    public static string CheckPathOfOutput()
    {
        bool flagCheckPath = false;

        string path = "";

        while (!flagCheckPath)
        {
            Console.Write("Введите путь к файлу (он должен быть в .json формате): ");

            path = Console.ReadLine();

            if (!File.Exists(path) && path[^5..] == ".json")
            {
                try
                {
                    File.Create(path).Dispose();
                    flagCheckPath = true;
                }
                catch
                {
                    Console.Write("Путь к файлу неверного формата. Попробуйте ещё раз. ");
                }
            }
            else
            {
                Console.Write("Файл уже существует или он не json-формата. Попробуйте ещё раз. ");
            }
        }

        return path;
    }

    /// <summary>
    /// Данный метод проверяет корректность типа записи результата работы программы в файл.
    /// </summary>
    /// <returns></returns>
    public static int CheckTypeOfFile()
    {
        bool flagCheckTypeOfFile = false;

        int typeOfFile = 0;

        while (!flagCheckTypeOfFile)
        {
            Console.Write("Введите команду (0 - перезаписать открытый файл, 1 - записать в новый файл): ");

            string value = Console.ReadLine();

            if (int.TryParse(value, out typeOfFile))
            {
                if (typeOfFile >= 0 && typeOfFile <= 1)
                {
                    flagCheckTypeOfFile = true;
                }
            }

            if (!flagCheckTypeOfFile)
            {
                Console.Write("Введена неверная команда. Попробуйте ещё раз. ");
            }
        }

        return typeOfFile;
    }
}