using System;

namespace DistributionCompany
{
    class ChargedOff
    {
        private DateTime chargeOffDate;
        private Goods chargedOffGood;
        private int chargeOffReason;

        public ChargedOff(DateTime chargeOffDate, Goods chargedOffGood, int chargeOffReason)
        {
            this.chargeOffDate = chargeOffDate;
            this.chargedOffGood = chargedOffGood;
            this.chargeOffReason = chargeOffReason;
        }

        public DateTime ChargeOffDate
        {
            get { return chargeOffDate; }
        }

        public Goods ChargedOffGood
        {
            get { return chargedOffGood; }
        }

        public int ChargeOffReason
        {
            get { return chargeOffReason; }
        }
    }
}