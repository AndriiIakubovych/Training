namespace DistributionCompany
{
    abstract class HouseholdChemicals : Goods
    {
        protected string instruction;

        public string Instruction
        {
            get { return instruction; }
        }
    }
}