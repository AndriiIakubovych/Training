using System.IO;
using System.Threading;

namespace ClassPropertiesSave
{
    class Bank
    {
        private int Money { get; set; }
        private string Name { get; set; }
        private int Percent { get; set; }

        public void ChangeProperties(int money, string name, int percent)
        {
            ThreadStart threadStart = new ThreadStart(SaveProperties);
            Thread thread = new Thread(threadStart);
            Money = money;
            Name = name;
            Percent = percent;
            thread.Start();
        }

        private void SaveProperties()
        {
            StreamWriter sw = new StreamWriter("class-properties.txt");
            sw.WriteLine("Бюджет банка: " + Money + " грн.");
            sw.WriteLine("Название банка: " + Name);
            sw.WriteLine("Количество процентов за кредит: " + Percent + "%");
            sw.Dispose();
        }
    }
}