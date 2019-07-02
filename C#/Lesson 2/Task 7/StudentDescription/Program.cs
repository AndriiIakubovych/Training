using System;

namespace StudentDescription
{
    class Student
    {
        private string lastName;
        private string firstName;
        private string patronymic;
        private int group;
        private int age;
        private int[][] gradesArray;

        public Student(string lastName, string firstName, string patronymic, int group, int age)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.group = group;
            this.age = age;
            gradesArray = new int[3][];
            gradesArray[0] = new int[] { };
            gradesArray[1] = new int[] { };
            gradesArray[2] = new int[] { };
        }

        public void SetGrade(int subject, int grade, int p, int a, int d)
        {
            if (subject == 1)
            {
                Array.Resize(ref gradesArray[subject - 1], p);
                gradesArray[subject - 1][p - 1] = grade;
            }
            if (subject == 2)
            {
                Array.Resize(ref gradesArray[subject - 1], a);
                gradesArray[subject - 1][a - 1] = grade;
            }
            if (subject == 3)
            {
                Array.Resize(ref gradesArray[subject - 1], d);
                gradesArray[subject - 1][d - 1] = grade;
            }
        }

        public int GetAverageGrade(int subject)
        {
            double average = 0;
            if (gradesArray[subject - 1].Length > 0)
            {
                foreach (int value in gradesArray[subject - 1])
                    average += value;
                average /= gradesArray[subject - 1].Length;
                return Convert.ToInt32(Math.Round(average));
            }
            else
                return 0;
        }

        public void PrintData()
        {
            Console.WriteLine("\nФамилия: " + lastName);
            Console.WriteLine("Имя: " + firstName);
            Console.WriteLine("Отчество: " + patronymic);
            Console.WriteLine("Группа: " + group);
            Console.WriteLine("Возраст: " + age);
            Console.Write("Оценки по программированию: ");
            if (gradesArray[0].Length > 0)
                foreach (int value in gradesArray[0])
                    Console.Write(value + " ");
            else
                Console.Write("нет");
            Console.Write("\nОценки по администрированию: ");
            if (gradesArray[1].Length > 0)
                foreach (int value in gradesArray[1])
                    Console.Write(value + " ");
            else
                Console.Write("нет");
            Console.Write("\nОценки по дизайну: ");
            if (gradesArray[2].Length > 0)
                foreach (int value in gradesArray[2])
                    Console.Write(value + " ");
            else
                Console.Write("нет");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int itemNumber, id = 0, idInfo, group, age, subject, grade;
            string lastName, firstName, patronymic;
            Student[] studentInfo = new Student[] { };
            int[] p = new int[] { };
            int[] a = new int[] { };
            int[] d = new int[] { };
            Console.Title = "Студенты";
            do
            {
                Console.Clear();
                Console.WriteLine("М Е Н Ю");
                Console.WriteLine("\n1 - Добавить нового студента");
                Console.WriteLine("2 - Добавить оценку за предмет");
                Console.WriteLine("3 - Получить средний балл по заданному предмету");
                Console.WriteLine("4 - Распечатать данные о студенте");
                Console.WriteLine("5 - Выход");
                Console.Write("\nВаш выбор: ");
                itemNumber = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (itemNumber)
                {
                    case 1:
                        Console.Write("Введите фамилию студента: ");
                        lastName = Console.ReadLine();
                        Console.Write("Введите имя студента: ");
                        firstName = Console.ReadLine();
                        Console.Write("Введите отчество студента: ");
                        patronymic = Console.ReadLine();
                        Console.Write("Введите группу студента: ");
                        group = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите возраст студента: ");
                        age = Convert.ToInt32(Console.ReadLine());
                        if (group > 0 && age > 0)
                        {
                            id++;
                            Array.Resize(ref studentInfo, id);
                            Array.Resize(ref p, id);
                            Array.Resize(ref a, id);
                            Array.Resize(ref d, id);
                            p[id - 1] = 0;
                            a[id - 1] = 0;
                            d[id - 1] = 0;
                            studentInfo[id - 1] = new Student(lastName, firstName, patronymic, group, age);
                            Console.WriteLine("\nДанные о студенте успешно добавлены! Код студента: " + id);
                        }
                        else
                            Console.WriteLine("\nДанные о студенте введены неверно!");
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Write("Введите код студента: ");
                        idInfo = Convert.ToInt32(Console.ReadLine());
                        if (idInfo > 0 && idInfo <= id)
                        {
                            Console.Write("\nВыберите предмет (1 - программирование, 2 - администрирование, 3 - дизайн): ");
                            subject = Convert.ToInt32(Console.ReadLine());
                            if (subject > 0 && subject <= 3)
                            {
                                Console.Write("\nВведите оценку по предмету: ");
                                grade = Convert.ToInt32(Console.ReadLine());
                                if (grade >= 0)
                                {
                                    if (subject == 1)
                                        p[idInfo - 1]++;
                                    if (subject == 2)
                                        a[idInfo - 1]++;
                                    if (subject == 3)
                                        d[idInfo - 1]++;
                                    studentInfo[idInfo - 1].SetGrade(subject, grade, p[idInfo - 1], a[idInfo - 1], d[idInfo - 1]);
                                    Console.WriteLine("\nОценка по предмету успешно добавлена!");
                                }
                                else
                                    Console.WriteLine("\nОценка по предмету введена неверно!");
                            }
                            else
                                Console.WriteLine("\nНет такого предмета!");
                        }
                        else
                            Console.WriteLine("\nНет студента с таким кодом!");
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Write("Введите код студента: ");
                        idInfo = Convert.ToInt32(Console.ReadLine());
                        if (idInfo > 0 && idInfo <= id)
                        {
                            Console.Write("\nВыберите предмет (1 - программирование, 2 - администрирование, 3 - дизайн): ");
                            subject = Convert.ToInt32(Console.ReadLine());
                            if (subject > 0 && subject <= 3)
                                Console.WriteLine("\nСредний балл по заданному предмету: " + studentInfo[idInfo - 1].GetAverageGrade(subject));
                            else
                                Console.WriteLine("\nНет такого предмета!");
                        }
                        else
                            Console.WriteLine("\nНет студента с таким кодом!");
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Write("Введите код студента: ");
                        idInfo = Convert.ToInt32(Console.ReadLine());
                        if (idInfo > 0 && idInfo <= id)
                            studentInfo[idInfo - 1].PrintData();
                        else
                            Console.WriteLine("\nНет студента с таким кодом!");
                        Console.ReadKey();
                        break;
                    case 5:
                        Console.WriteLine("Работа завершена!");
                        break;
                    default:
                        Console.WriteLine("Нет такого пункта меню!");
                        Console.ReadKey();
                        break;
                }
            }
            while (itemNumber != 5);
            Console.ReadKey();
        }
    }
}