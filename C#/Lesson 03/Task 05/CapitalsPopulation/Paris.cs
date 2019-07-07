namespace France
{
    class Paris
    {
        private string name;
        private string countryName;
        private int population;

        public Paris()
        {
            name = "Париж";
            countryName = "Франция";
            population = 2196936;
        }

        public string GetName()
        {
            return name;
        }

        public string GetCountryName()
        {
            return countryName;
        }

        public int GetPopulation()
        {
            return population;
        }
    }
}