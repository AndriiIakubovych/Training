using System;
using System.Collections;

namespace CountriesDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            int translationType = 0;
            SortedList list = new SortedList(193);
            string countryName;
            bool hasValue;
            Console.Title = "Словарь";
            list.Add("Abkhazia", "Абхазия");
            list.Add("Afghanistan", "Афганистан");
            list.Add("Albania", "Албания");
            list.Add("Algeria", "Алжир");
            list.Add("Andorra", "Андорра");
            list.Add("Angola", "Ангола");
            list.Add("Antigua and Barbuda", "Антигуа и Барбуда");
            list.Add("Argentina", "Аргентина");
            list.Add("Armenia", "Армения");
            list.Add("Australia", "Австралия");
            list.Add("Austria", "Австрия");
            list.Add("Azerbaijan", "Азербайджан");
            list.Add("Bahamas", "Багамские острова");
            list.Add("Bahrain", "Бахрейн");
            list.Add("Bangladesh", "Бангладеш");
            list.Add("Barbados", "Барбадос");
            list.Add("Belarus", "Белоруссия");
            list.Add("Belgium", "Бельгия");
            list.Add("Belize", "Белиз");
            list.Add("Benin", "Бенин");
            list.Add("Bhutan", "Бутан");
            list.Add("Bolivia", "Боливия");
            list.Add("Bosnia and Herzegovina", "Босния и Герцеговина");
            list.Add("Botswana", "Ботсвана");
            list.Add("Brazil", "Бразилия");
            list.Add("Brunei", "Бруней");
            list.Add("Bulgaria", "Болгария");
            list.Add("Burkina Faso", "Буркина-Фасо");
            list.Add("Burundi", "Бурунди");
            list.Add("Cambodia", "Камбоджа");
            list.Add("Cameroon", "Камерун");
            list.Add("Canada", "Канада");
            list.Add("Cape Verde", "Кабо-Верде");
            list.Add("CAR", "ЦАР");
            list.Add("Chad", "Чад");
            list.Add("Chile", "Чили");
            list.Add("China", "Китай");
            list.Add("Colombia", "Колумбия");
            list.Add("Comoro Islands", "Коморские Острова");
            list.Add("Costa Rica", "Коста-Рика");
            list.Add("Cote d'Ivoire", "Кот-д'Ивуар");
            list.Add("Croatia", "Хорватия");
            list.Add("Cuba", "Куба");
            list.Add("Cyprus", "Кипр");
            list.Add("Czech Republic", "Чехия");
            list.Add("Denmark", "Дания");
            list.Add("Djibouti", "Джибути");
            list.Add("Dominica", "Доминика");
            list.Add("Dominican Republic", "Доминиканская Республика");
            list.Add("DPRK", "КНДР");
            list.Add("DR Congo", "ДР Конго");
            list.Add("East Timor", "Восточный Тимор");
            list.Add("Ecuador", "Эквадор");
            list.Add("Egypt", "Египет");
            list.Add("El Salvador", "Сальвадор");
            list.Add("Equatorial Guinea", "Экваториальная Гвинея");
            list.Add("Eritrea", "Эритрея");
            list.Add("Estonia", "Эстония");
            list.Add("Ethiopia", "Эфиопия");
            list.Add("Federal States Micronesia", "Федеративные Штаты Микронезии");
            list.Add("Fiji", "Фиджи");
            list.Add("Finland", "Финляндия");
            list.Add("France", "Франция");
            list.Add("Gabon", "Габон");
            list.Add("Gambia", "Гамбия");
            list.Add("Georgia", "Грузия");
            list.Add("Germany", "Германия");
            list.Add("Ghana", "Гана");
            list.Add("Great Britain", "Великобритания");
            list.Add("Greece", "Греция");
            list.Add("Grenada", "Гренада");
            list.Add("Guatemala", "Гватемала");
            list.Add("Guinea", "Гвинея");
            list.Add("Guinea-Bissau", "Гвинея-Бисау");
            list.Add("Guyana", "Гайана");
            list.Add("Haiti", "Гаити");
            list.Add("Honduras", "Гондурас");
            list.Add("Hungary", "Венгрия");
            list.Add("Iceland", "Исландия");
            list.Add("India", "Индия");
            list.Add("Indonesia", "Индонезия");
            list.Add("Iran", "Иран");
            list.Add("Iraq", "Ирак");
            list.Add("Ireland", "Ирландия");
            list.Add("Israel", "Израиль");
            list.Add("Italy", "Италия");
            list.Add("Jamaica", "Ямайка");
            list.Add("Japan", "Япония");
            list.Add("Jordan", "Иордания");
            list.Add("Kazakhstan", "Казахстан");
            list.Add("Kenya", "Кения");
            list.Add("Kiribati", "Кирибати");
            list.Add("Kuwait", "Кувейт");
            list.Add("Kyrgyzstan", "Киргизия");
            list.Add("Laos", "Лаос");
            list.Add("Latvia", "Латвия");
            list.Add("Lebanon", "Ливан");
            list.Add("Lesotho", "Лесото");
            list.Add("Libertion", "Либерция");
            list.Add("Libya", "Ливия");
            list.Add("Liechtenstein", "Лихтенштейн");
            list.Add("Lithuania", "Литва");
            list.Add("Luxembourg", "Люксембург");
            list.Add("Macedonia", "Македония");
            list.Add("Madagascar", "Мадагаскар");
            list.Add("Malawi", "Малави");
            list.Add("Malaysia", "Малайзия");
            list.Add("Maldives", "Мальдивские Острова");
            list.Add("Mali", "Мали");
            list.Add("Malta", "Мальта");
            list.Add("Marshall Islands", "Маршалловы Острова");
            list.Add("Mauritania", "Мавритания");
            list.Add("Mauritius", "Маврикий");
            list.Add("Mexico", "Мексика");
            list.Add("Moldova", "Молдавия");
            list.Add("Monaco", "Монако");
            list.Add("Mongolia", "Монголия");
            list.Add("Montenegro", "Черногория");
            list.Add("Morocco", "Марокко");
            list.Add("Mozambique", "Мозамбик");
            list.Add("Myanmar", "Мьянма");
            list.Add("Namibia", "Намибия");
            list.Add("Nauru", "Науру");
            list.Add("Nepal", "Непал");
            list.Add("Netherlands", "Нидерланды");
            list.Add("New Zealand", "Новая Зеландия");
            list.Add("Nicaragua", "Никарагуа");
            list.Add("Niger", "Нигер");
            list.Add("Nigeria", "Нигерия");
            list.Add("Norway", "Норвегия");
            list.Add("Oman", "Оман");
            list.Add("Pakistan", "Пакистан");
            list.Add("Palau", "Палау");
            list.Add("Panama", "Панама");
            list.Add("Papua New Guinea", "Папуа - Новая Гвинея");
            list.Add("Paraguay", "Парагвай");
            list.Add("Peru", "Перу");
            list.Add("Philippines", "Филиппины");
            list.Add("Poland", "Польша");
            list.Add("Portugal", "Португалия");
            list.Add("Qatar", "Катар");
            list.Add("Republic of Korea", "Республика Корея");
            list.Add("Romania", "Румыния");
            list.Add("RSA", "ЮАР");
            list.Add("Ruspublika of Congo", "Руспублика Конго");
            list.Add("Russia", "Россия");
            list.Add("Rwanda", "Руанда");
            list.Add("Saint Kitts and Nevis", "Сент-Китс и Невис");
            list.Add("Saint Lucia", "Сент-Люсия");
            list.Add("Saint Vincent and Grenadines", "Сент-Винсент и Гренадины");
            list.Add("Samoa", "Самоа");
            list.Add("San Marino", "Сан-Марино");
            list.Add("Sao Tome and Principe", "Сан-Томе и Принсипи");
            list.Add("Saudi Arabia", "Саудовская Аравия");
            list.Add("Senegal", "Сенегал");
            list.Add("Serbia", "Сербия");
            list.Add("Seychelles", "Сейшельские Острова");
            list.Add("Sierra Leone", "Сьерра-Леоне");
            list.Add("Singapore", "Сингапур");
            list.Add("Slovakia", "Словакия");
            list.Add("Slovenia", "Словения");
            list.Add("Solomon Islands", "Соломоновы Острова");
            list.Add("Somalia", "Сомали");
            list.Add("South Ossetia", "Южная Осетия");
            list.Add("South Sudan", "Южный Судан");
            list.Add("Spain", "Испания");
            list.Add("Sri Lanka", "Шри-Ланка");
            list.Add("State of Palestine", "Государство Палестина");
            list.Add("Sudan", "Судан");
            list.Add("Surinam", "Суринам");
            list.Add("Swaziland", "Свазиленд");
            list.Add("Sweden", "Швеция");
            list.Add("Switzerland", "Швейцария");
            list.Add("Syria", "Сирия");
            list.Add("Tajikistan", "Таджикистан");
            list.Add("Tanzania", "Танзания");
            list.Add("Thailand", "Таиланд");
            list.Add("Togo", "Того");
            list.Add("Tonga", "Тонга");
            list.Add("Trinidad and Tobago", "Тринидад и Тобаго");
            list.Add("Tunisia", "Тунис");
            list.Add("Turkey", "Турция");
            list.Add("Turkmenistan", "Туркмения");
            list.Add("Tuvalu", "Тувалу");
            list.Add("UAE", "ОАЭ");
            list.Add("Uganda", "Уганда");
            list.Add("Ukraine", "Украина");
            list.Add("Uruguay", "Уругвай");
            list.Add("USA", "США");
            list.Add("Uzbekistan", "Узбекистан");
            list.Add("Vanuatu", "Вануату");
            list.Add("Vatican", "Ватикан");
            list.Add("Venezuela", "Венесуэла");
            list.Add("Vietnam", "Вьетнам");
            list.Add("Yemen", "Йемен");
            list.Add("Zambia", "Замбия");
            list.Add("Zimbabwe", "Зимбабве");
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Т И П   П Е Р Е В О Д А");
                    Console.WriteLine("\n1 - Англо-русский");
                    Console.WriteLine("2 - Русско-английский");
                    Console.WriteLine("3 - Выход");
                    Console.Write("\nВаш выбор: ");
                    translationType = Convert.ToInt32(Console.ReadLine());
                    switch (translationType)
                    {
                        case 1:
                            Console.Clear();
                            hasValue = false;
                            Console.Write("Введите название страны на английском: ");
                            countryName = Console.ReadLine();
                            for (int i = 0; i < list.Count; i++)
                                if (list.GetKey(i).Equals(countryName))
                                {
                                    hasValue = true;
                                    Console.WriteLine("Перевод: " + list.GetByIndex(i));
                                    break;
                                }
                            if (!hasValue)
                                Console.WriteLine("Перевод не найден!");
                            Console.ReadKey();
                            break;
                        case 2:
                            Console.Clear();
                            hasValue = false;
                            Console.Write("Введите название страны на русском: ");
                            countryName = Console.ReadLine();
                            for (int i = 0; i < list.Count; i++)
                                if (list.GetByIndex(i).Equals(countryName))
                                {
                                    hasValue = true;
                                    Console.WriteLine("Перевод: " + list.GetKey(i));
                                    break;
                                }
                            if (!hasValue)
                                Console.WriteLine("Перевод не найден!");
                            Console.ReadKey();
                            break;
                        case 3:
                            Console.Clear();
                            Console.WriteLine("Работа завершена!");
                            break;
                        default:
                            Console.WriteLine("\nНеверный выбор!");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("\nОшибка при вводе!");
                    Console.ReadKey();
                }
            }
            while (translationType != 3);
            Console.ReadKey();
        }
    }
}