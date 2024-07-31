// Пасынков Матвей Евгеньевич, БПИ237-2, КДЗ, Вариант 16.
using Library;
using System.Text.Json;

class Program
{
    static void Main()
    {
        do
        {
            try
            {
                bool programIsWorking = true;

                // Очищаем консоль перед очередной итерацией.
                Console.Clear();

                InteractWithUser.Menu(ref programIsWorking, false);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Список пациентов пуст. Скорее всего на вход был подан пустой JSON-файл, или он неверного формата.");
            }
            catch
            {
                Console.WriteLine("Возникла непредвиденная ошибка.");
            }
            finally
            {
                Console.WriteLine("Нажмите ESC, чтобы завершить повтор решений. Иначе нажмите любую другую кнопку.");
            }
        }
        while (Console.ReadKey().Key != ConsoleKey.Escape);
    }
}