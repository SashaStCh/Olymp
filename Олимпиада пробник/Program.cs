using System;

namespace Olymp
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                Rating rating = new Rating();
                Console.Clear();
                Console.WriteLine("Введите путь к файлу или выберите один из имеющихся тестов:");
                Console.WriteLine("1 - Стандартный тест.");
                Console.WriteLine("2 - Не может участвовать более 5-ти учеников от школы.");
                Console.WriteLine("3 - Недостаточно учеников. Необходимо не менее 5-ти.");
                Console.WriteLine("4 - Проверка на дублирование поберителей и призёров.");
                Console.WriteLine("5 - Сдвинутые данные и пустые строки.");
                Console.WriteLine("6 - Другой формат файла.");
                Console.WriteLine("7 - Оценка ученика не входит в диапазон от 0 до 100.");
                Console.WriteLine("0 - Выход из программы.");
                string path = Console.ReadLine();
                Console.Clear();
                switch (path)
                {
                    case "1":
                        rating.LoadFromExcel("olymp.xlsx");
                        break;
                    case "2":
                        rating.LoadFromExcel("olymp2.xlsx");
                        break;
                    case "3":
                        rating.LoadFromExcel("olymp3.xlsx");
                        break;
                    case "4":
                        rating.LoadFromExcel("olymp4.xlsx");
                        break;
                    case "5":
                        rating.LoadFromExcel("olymp5.xlsx");
                        break;
                    case "6":
                        rating.LoadFromExcel("olymp6.txt");
                        break;
                    case "7":
                        rating.LoadFromExcel("olymp7.xlsx");
                        break;
                    case "0":
                        return;
                    default:
                        rating.LoadFromExcel($@"{path}");
                        break;
                }
                Console.WriteLine("\nВернуться к выбору теста? Нажмите 'Y' чтобы продолжить или любую кнопку для выхода из программы. ");
            } while (Convert.ToString(Console.ReadKey().Key) == "Y");
        }
    }
}
