using System;
using BusinessLogic;

namespace ConsoleView
{
    class Program
    {
        static Logic logic = new Logic();

        static void Main(string[] args)
        {
            SeedData();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("DecanatPRO");
                Console.WriteLine("1. Добавить студента");
                Console.WriteLine("2. Удалить студента");
                Console.WriteLine("3. Показать всех");
                Console.WriteLine("4. Гистограмма");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                switch (Console.ReadLine())
                {
                    case "1": AddStudent(); break;
                    case "2": DeleteStudent(); break;
                    case "3": ShowAll(); break;
                    case "4": ShowHistogram(); break;
                    case "0": return;
                }
                Console.ReadKey();
            }
        }

        static void SeedData()
        {
            logic.AddStudent("Иванов Иван Иванович", "ИВТ", "ИВТ-21-1");
            logic.AddStudent("Петров Пётр Петрович", "ИВТ", "ИВТ-21-1");
            logic.AddStudent("Сидоров Сидор Сидорович", "ПМИ", "ПМИ-21-2");
            logic.AddStudent("Иванов Иван Иванович", "ИВТ", "ИВТ-21-1");
            logic.AddStudent("Кузнецова Анна Сергеевна", "ИБ", "ИБ-21-3");
            logic.AddStudent("Смирнов Алексей Олегович", "ПМИ", "ПМИ-21-2");
            logic.AddStudent("Волкова Мария Дмитриевна", "ИБ", "ИБ-21-3");
            logic.AddStudent("Иванов Иван Иванович", "ПМИ", "ПМИ-21-2");
        }
        static void AddStudent()
        {
            Console.Write("ФИО: ");
            string name = Console.ReadLine();
            Console.Write("Специальность: ");
            string spec = Console.ReadLine();
            Console.Write("Группа: ");
            string group = Console.ReadLine();

            try
            {
                logic.AddStudent(name, spec, group);
                Console.WriteLine("Студент добавлен!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Введите ID студента для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Некорректный ID");
                return;
            }

            try
            {
                logic.DeleteStudent(id);
                Console.WriteLine("Студент удалён!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
        }

        static void ShowAll()
        {
            var students = logic.GetStudentsForView();

            if (students.Count == 0)
            {
                Console.WriteLine("Список пуст.");
                return;
            }

            foreach (var s in students)
                Console.WriteLine("ID: " + s[0] + ". ФИО: " + s[1] + ". Специальность: " + s[2] + ". Группа: " + s[3]);
        }

        static void ShowHistogram()
        {
            var data = logic.GetDistributionBySpeciality();

            if (data.Count == 0)
            {
                Console.WriteLine("Нет данных.");
                return;
            }

            Console.WriteLine("Распределение по специальностям\n");

            foreach (var pair in data)
            {
                string stars = new string('*', pair.Value);
                Console.WriteLine($"{pair.Key,-20} | {stars} ({pair.Value})");
            }
        }
    }
}