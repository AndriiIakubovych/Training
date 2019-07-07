using System;

namespace DistributionCompany
{
    class Transfered
    {
        private DateTime transferDate;
        private Goods transferedGood;

        public Transfered(DateTime transferDate, Goods transferedGood)
        {
            this.transferDate = transferDate;
            this.transferedGood = transferedGood;
        }

        public DateTime TransferDate
        {
            get { return transferDate; }
        }

        public Goods TransferedGood
        {
            get { return transferedGood; }
        }
    }
}