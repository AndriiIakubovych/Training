namespace GreatBritain
{
    class London
    {
        private string name;
        private string countryName;
        private int population;

        public London()
        {
            name = "Лондон";
            countryName = "Великобритания";
            population = 8538689;
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