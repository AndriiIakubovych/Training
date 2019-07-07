using System;
using System.Windows.Forms;

namespace Resume
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            const int messagesCount = 8;
            int symbolsCount = 0;
            string text = null, heading = null;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            for (int i = 1; i <= messagesCount; i++)
            {
                switch (i)
                {
                    case 1:
                        text = "E-mail: AndriiIakubovych@gmail.com\nSkype: kinky1006\nТелефон: +380677802265\nГород: Харьков";
                        heading = "Контакты";
                        break;
                    case 2:
                        text = "Получить должность Junior .NET Developer и использовать свои технические знания в разработке приложений на .NET Framework";
                        heading = "Цель";
                        break;
                    case 3:
                        text = "Языки программирования: C++, Delphi, C#, JavaScript, SQL\nТехнологии: MFC, Win32 API, Windows Forms, ADO.NET, WPF, ASP.NET MVC, HTML, CSS, jQuery, AJAX, AngularJS, XML\nСУБД: Microsoft SQL Server, MySQL, MongoDB\nОС: WIndows, Linux\nИСР: Microsoft Visual Studio, C++ Builder, NetBeans";
                        heading = "Технические навыки";
                        break;
                    case 4:
                        text = "ИВЦ \"Поток\"\nИнженер-программист\n(2010 - Настоящее время)\nОбязанности: разработка ПО для внутренних нужд компании, доработка существующих ГИС";
                        heading = "Профессиональный опыт";
                        break;
                    case 5:
                        text = "ХНЭУ им. С. Кузнеца\nИнформационные Управляющие Системы и Технологии\n2004 - 2009 (степень магистра)";
                        heading = "Образование";
                        break;
                    case 6:
                        text = "JavaScript Front End (Source IT)\n28.01.2017 - 16.05.2017\nMarkup Development (Source IT)\n08.11.2016 - 21.01.2017\nAmerican English Center\n07.11.2015 - 22.12.2016\nКурсы .NET (GlobalLogic)\n01.03.2008 - 06.06.2008";
                        heading = "Дополнительное образование";
                        break;
                    case 7:
                        text = "Украинский\nРусский\nАнглийский\nЧешский";
                        heading = "Языки";
                        break;
                    case 8:
                        text = "Футбол, плавание, шахматы, походы с палатками, игра на гитаре";
                        heading = "Хобби";
                        break;
                }
                MessageBox.Show(text, heading, MessageBoxButtons.OK, MessageBoxIcon.Information);
                symbolsCount += text.Length + heading.Length;
            }
            MessageBox.Show("Спасибо за внимание!", "Среднее число символов в резюме: " + symbolsCount / messagesCount, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}