namespace Germany
{
    class Berlin
    {
        private string name;
        private string countryName;
        private int population;

        public Berlin()
        {
            name = "Берлин";
            countryName = "Германия";
            population = 3490105;
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