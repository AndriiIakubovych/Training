using System;
using System.Windows.Forms;

namespace NumberGuessing
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            int requestsCount;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            do
                MessageBox.Show("Задуманное число: " + Guessing(1, 2000, out requestsCount) + "\nКоличество потребовавшихся запросов: " + requestsCount, "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            while (MessageBox.Show("Желаете сыграть ещё?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.No);
        }

        static int Guessing(int min, int max, out int requestsCount)
        {
            Random rand = new Random();
            int number = 0, question;
            bool ask, answer;
            requestsCount = 0;
            do
            {
                if (requestsCount > 0)
                {
                    ask = true;
                    if (number == min)
                    {
                        ask = false;
                        if (max - min == 1)
                        {
                            number++;
                            break;
                        }
                        min++;
                    }
                    if (number == max)
                    {
                        ask = false;
                        if (max - min == 1)
                        {
                            number--;
                            break;
                        }
                        max--;
                    }
                    if (ask)
                    {
                        question = rand.Next(0, 2);
                        if (question > 0)
                            answer = MessageBox.Show("Задуманное число больше, чем " + number + "?", "Запрос к пользователю", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                        else
                            answer = MessageBox.Show("Задуманное число меньше, чем " + number + "?", "Запрос к пользователю", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
                        if (answer)
                        {
                            if (number == max - 1)
                            {
                                number++;
                                break;
                            }
                            min = number + 1;
                        }
                        else
                        {
                            if (number == min + 1)
                            {
                                number--;
                                break;
                            }
                            max = number - 1;
                        }
                    }
                }
                requestsCount++;
                number = rand.Next(min, max + 1);
            }
            while (MessageBox.Show("Вы задумали число: " + number.ToString() + "! Правильно?", "Запрос к пользователю", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes);
            return number;
        }
    }
}