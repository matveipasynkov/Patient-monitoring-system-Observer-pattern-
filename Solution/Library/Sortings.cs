using System;
namespace Library;

/// <summary>
/// Класс различных сортировок.
/// </summary>
public static class Sortings
{
    /// <summary>
    /// Реализация сортировки пузырьком.
    /// </summary>
    /// <param name="patients"></param>
    /// <returns></returns>
	public static List<Patient> BubbleSort(List<Patient> patients)
	{
        PrintInstructionsForSorting();

        string field = Checks.CheckPatientField(patients, true);

        bool flagStopBubbleSort = false;

        while (!flagStopBubbleSort)
        {
            flagStopBubbleSort = true;

            for (int i = 0; i < patients.Count - 1; ++i)
            {
                switch (field)
                {
                    case "patient_id":

                        if (patients[i].PatientId.CompareTo(patients[i + 1].PatientId) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "name":

                        if (patients[i].Name.CompareTo(patients[i + 1].Name) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "age":

                        if (patients[i].Age > patients[i + 1].Age)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "gender":

                        if (patients[i].Gender.CompareTo(patients[i + 1].Gender) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "diagnosis":

                        if (patients[i].Diagnosis.CompareTo(patients[i + 1].Diagnosis) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "state":

                        if (patients[i].State > patients[i + 1].State)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;

                    case "sensors":

                        if (patients[i].Sensors.Count > patients[i + 1].Sensors.Count)
                        {
                            patients = Swap(patients, i, i + 1);
                            flagStopBubbleSort = false;
                        }

                        break;
                }
            }
        }

        return patients;
    }

    /// <summary>
    /// Реализация сортировки вставками.
    /// </summary>
    /// <param name="patients"></param>
    /// <returns></returns>
    public static List<Patient> InsertionSort(List<Patient> patients)
    {
        PrintInstructionsForSorting();

        string field = Checks.CheckPatientField(patients, true);

        for (int j = 1; j < patients.Count; ++j)
        {
            for (int i = j - 1; i >= 0; --i)
            {
                switch (field)
                {
                    case "patient_id":

                        if (patients[i].PatientId.CompareTo(patients[i + 1].PatientId) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "name":

                        if (patients[i].Name.CompareTo(patients[i + 1].Name) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "age":

                        if (patients[i].Age > patients[i + 1].Age)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "gender":

                        if (patients[i].Gender.CompareTo(patients[i + 1].Gender) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "diagnosis":

                        if (patients[i].Diagnosis.CompareTo(patients[i + 1].Diagnosis) > 0)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "state":

                        if (patients[i].State > patients[i + 1].State)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;

                    case "sensors":

                        if (patients[i].Sensors.Count > patients[i + 1].Sensors.Count)
                        {
                            patients = Swap(patients, i, i + 1);
                        }

                        break;
                }
            }
        }

        return patients;
    }

    /// <summary>
    /// Метод обмена значений между двумя объектами в List<Patient>.
    /// </summary>
    /// <param name="patients"></param>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <returns></returns>
    public static List<Patient> Swap(List<Patient> patients, int index1, int index2)
    {
        Patient tmp = patients[index1];
        patients[index1] = patients[index2];
        patients[index2] = tmp;

        return patients;
    }

    /// <summary>
    /// Данный метод выводит инструкции по сортировке.
    /// </summary>
    public static void PrintInstructionsForSorting()
    {
        Console.WriteLine("Доступные поля данных: patient_id, name, age, gender, diagnosis, state, sensors.");
        Console.WriteLine("В случае с sensors сортировка будет происходить по количеству элементов.");
        Console.WriteLine("По какому полю вы хотите отсортировать данные?");
    }
}