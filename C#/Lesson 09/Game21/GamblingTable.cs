using System;

namespace Game21
{
    [Serializable]
    class GamblingTable
    {
        private const int COLOUR_COUNT = 4;
        private int[][] pack;
        private int[] playerCards;
        private int[] computerCards;
        private string[] playerCardsSymbols;
        private string[] computerCardsSymbols;
        private bool stopTaking;

        public GamblingTable() { }

        public void InitGame()
        {
            pack = new int[COLOUR_COUNT][];
            for (int i = 0; i < COLOUR_COUNT; i++)
                pack[i] = new int[] { 6, 7, 8, 9, 10, 2, 3, 4, 11 };
            playerCards = new int[] { };
            computerCards = new int[] { };
            playerCardsSymbols = new string[] { };
            computerCardsSymbols = new string[] { };
            stopTaking = false;
        }

        public int ColourCount
        {
            get { return COLOUR_COUNT; }
        }

        public int[][] Pack
        {
            get { return pack; }
            set { pack = value; }
        }

        public int[] PlayerCards
        {
            get { return playerCards; }
            set { playerCards = value; }
        }

        public int[] ComputerCards
        {
            get { return computerCards; }
            set { computerCards = value; }
        }

        public string[] PlayerCardsSymbols
        {
            get { return playerCardsSymbols; }
            set { playerCardsSymbols = value; }
        }

        public string[] ComputerCardsSymbols
        {
            get { return computerCardsSymbols; }
            set { computerCardsSymbols = value; }
        }

        public bool StopTaking
        {
            get { return stopTaking; }
            set { stopTaking = value; }
        }

        public int GetPlayerPoints()
        {
            int sum = 0;
            for (int i = 0; i < playerCards.Length; i++)
                sum += playerCards[i];
            return sum;
        }

        public int GetComputerPoints()
        {
            int sum = 0;
            for (int i = 0; i < computerCards.Length; i++)
                sum += computerCards[i];
            return sum;
        }

        public string GetCardSymbols(int card, int colourNumber)
        {
            string symbols;
            switch (card)
            {
                case 2:
                    symbols = "В";
                    break;
                case 3:
                    symbols = "Д";
                    break;
                case 4:
                    symbols = "К";
                    break;
                case 11:
                    symbols = "Т";
                    break;
                default:
                    symbols = card.ToString();
                    break;
            }
            switch (colourNumber)
            {
                case 0:
                    symbols += '\u2660';
                    break;
                case 1:
                    symbols += '\u2663';
                    break;
                case 2:
                    symbols += '\u2665';
                    break;
                case 3:
                    symbols += '\u2666';
                    break;
            }
            return symbols;
        }

        public string TakeCard(bool flag)
        {
            Random rand = new Random();
            int colourNumber, cardNumber, card;
            int[] cards = flag ? playerCards : computerCards;
            string[] cardsSymbols = flag ? playerCardsSymbols : computerCardsSymbols; 
            colourNumber = rand.Next(0, COLOUR_COUNT);
            cardNumber = rand.Next(0, pack[colourNumber].Length);
            card = pack[colourNumber][cardNumber];
            Array.Resize(ref cards, cards.Length + 1);
            cards[cards.Length - 1] = card;
            Array.Resize(ref cardsSymbols, cardsSymbols.Length + 1);
            cardsSymbols[cardsSymbols.Length - 1] = GetCardSymbols(card, colourNumber);
            for (int i = 0; i < pack[colourNumber].Length; i++)
                if (pack[colourNumber][i] == card)
                {
                    for (int j = i; j < pack[colourNumber].Length - 1; j++)
                        pack[colourNumber][j] = pack[colourNumber][j + 1];
                    break;
                }
            Array.Resize(ref pack[colourNumber], pack[colourNumber].Length - 1);
            if (flag)
            {
                playerCards = cards;
                playerCardsSymbols = cardsSymbols;
            }
            else
            {
                computerCards = cards;
                computerCardsSymbols = cardsSymbols;
            }
            return cardsSymbols[cardsSymbols.Length - 1];
        }
    }
}