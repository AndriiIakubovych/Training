namespace Calendar
{
    class DayOfMonth
    {
        private string dayName;
        private int dayNumber;

        public DayOfMonth(string dayName, int dayNumber)
        {
            this.dayName = dayName;
            this.dayNumber = dayNumber;
        }

        public string DayName
        {
            get { return dayName; }
            set { dayName = value; }
        }

        public int DayNumber
        {
            get { return dayNumber; }
            set { dayNumber = value; }
        }
    }
}