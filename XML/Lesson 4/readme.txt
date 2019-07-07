Вычислить следующие выражения:
book[@style]
author[first-name][3]
author[1]
price/exchange/total
x/y[position() = 1]
x[1]/y[2]
(x/y)[1]
(book/author)[last()]
book[excerpt]
book[excerpt]/author[degree]
author[not(degree or award) and publication]
author[last-name[position() = 1] = "Bob"
degree[@from != "Harvard"]
author[. = "Matthew Bob"]
author[last-name = "Bob" and ../price > 50]
author[* = "Bob"]
author[last-name = "Bob" and first-name = "Joe"]
price[@intl = "Canada"]
degree[position() < 3]
p/text()[2]
ancestor::author[parent::book][1]
author[degree][award]
ancestor-or-self::div
descendant-or-self::para