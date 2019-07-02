using System;
using System.Collections.Generic;
using System.Xml;

namespace ExamModeling
{
    class Program
    {
        static Class ExamProcess(string fileName)
        {
            Random rand = new Random();
            int minSuccessLevel = 80, maxSuccessLevel = 100;
            double minAngerСoefficient = 0.5, maxAngerСoefficient = 1;
            List<Student> studentsList;
            Group group;
            Subject subject;
            Teacher teacher;
            List<Class> classesList = new List<Class>();
            XmlDocument document = new XmlDocument();
            XmlElement root;
            XmlNodeList studentsNodes, classesNodes;
            XmlNode groupNode;
            document.Load(fileName);
            root = document.DocumentElement;
            classesNodes = root.SelectNodes("classes/class");
            foreach (XmlNode c in classesNodes)
            {
                studentsList = new List<Student>();
                groupNode = root.SelectSingleNode("groups/group[@name = '" + c.SelectSingleNode("group").InnerText + "']");
                studentsNodes = groupNode.SelectNodes("student");
                foreach (XmlNode s in studentsNodes)
                    studentsList.Add(new Student() { Name = s.InnerText, SuccessLevel = rand.Next(minSuccessLevel, maxSuccessLevel + 1) });
                group = new Group() { Name = c.SelectSingleNode("group").InnerText, StudentsList = studentsList };
                subject = new Subject() { Name = c.SelectSingleNode("subject").InnerText };
                teacher = new Teacher() { Name = c.SelectSingleNode("teacher").InnerText, AngerСoefficient = Math.Round(rand.NextDouble() * (maxAngerСoefficient - minAngerСoefficient) + minAngerСoefficient, 1) };
                classesList.Add(new Class() { Group = group, Subject = subject, Teacher = teacher });
            }
            return classesList[rand.Next(0, classesList.Count)];
        }

        static void PrintExamResults(Class examClass)
        {
            Console.WriteLine("Group: " + examClass.Group.Name);
            Console.WriteLine("Subject: " + examClass.Subject.Name);
            Console.WriteLine("Teacher: " + examClass.Teacher.Name);
            Console.WriteLine("Date: " + DateTime.Today.ToShortDateString());
            Console.WriteLine("\nExam results:");
            Console.Write("\u250C");
            for (int i = 0; i < 30; i++) Console.Write("\u2500");
            Console.Write("\u252C");
            for (int i = 0; i < 5; i++) Console.Write("\u2500");
            Console.Write("\u2510\n");
            Console.WriteLine("\u2502           Student            \u2502Grade\u2502");
            foreach (Student s in examClass.Group.StudentsList)
            {
                Console.Write("\u251C");
                for (int i = 0; i < 30; i++) Console.Write("\u2500");
                Console.Write("\u253C");
                for (int i = 0; i < 5; i++) Console.Write("\u2500");
                Console.Write("\u2524\n");
                Console.WriteLine("\u2502{0, -30}\u2502{1, 5}\u2502", s.Name, Math.Round(s.SuccessLevel * examClass.Teacher.AngerСoefficient / 100 * 12, 0));
            }
            Console.Write("\u2514");
            for (int i = 0; i < 30; i++) Console.Write("\u2500");
            Console.Write("\u2534");
            for (int i = 0; i < 5; i++) Console.Write("\u2500");
            Console.Write("\u2518\n");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Console.Title = "Exam modeling";
            try
            {
                PrintExamResults(ExamProcess("education.xml"));
            }
            catch (Exception)
            {
                Console.WriteLine("Error: Can't find the file!");
                Console.ReadKey();
            }
        }
    }
}