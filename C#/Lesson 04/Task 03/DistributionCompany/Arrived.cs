using System;

namespace DistributionCompany
{
    class Arrived
    {
        private DateTime arrivalDate;
        private Goods arrivedGood;

        public Arrived(DateTime arrivalDate, Goods arrivedGood)
        {
            this.arrivalDate = arrivalDate;
            this.arrivedGood = arrivedGood;
        }

        public DateTime ArrivalDate
        {
            get { return arrivalDate; }
        }

        public Goods ArrivedGood
        {
            get { return arrivedGood; }
        }
    }
}