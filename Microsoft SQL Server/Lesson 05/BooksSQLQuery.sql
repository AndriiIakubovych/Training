GO
CREATE VIEW PressProgrammBooks AS SELECT Press_id, COUNT(Press_id) AS Press_programm_books_count FROM Books, Themes WHERE Theme_name LIKE '%программирование%' AND Books.Theme_id = Themes.Theme_id GROUP BY Press_id;
GO
SELECT PressProgrammBooks.Press_id, Press_name, Press_programm_books_count FROM PressProgrammBooks, Press WHERE Press_programm_books_count = (SELECT MAX(Press_programm_books_count) FROM PressProgrammBooks) AND PressProgrammBooks.Press_id = Press.Press_id;
DROP VIEW PressProgrammBooks;
GO
CREATE VIEW ThemePagesCount AS SELECT Theme_id, SUM(Pages_count) AS Theme_pages_count_sum FROM Books GROUP BY Theme_id HAVING SUM(Pages_count) <> 0;
GO
SELECT ThemePagesCount.Theme_id, Theme_name, Theme_pages_count_sum FROM ThemePagesCount, Themes WHERE Theme_pages_count_sum = (SELECT MIN(Theme_pages_count_sum) FROM ThemePagesCount) AND ThemePagesCount.Theme_id = Themes.Theme_id;
DROP VIEW ThemePagesCount;
SELECT Book_id, Book_name, Price, Press.Press_name FROM Books, Press WHERE Price = (SELECT MAX(Price) FROM Books, Press WHERE Press_name LIKE 'BHV%' AND Books.Press_id = Press.Press_id) AND Books.Press_id = Press.Press_id;
SELECT * FROM Books WHERE Pages_count > (SELECT AVG(Pages_count) FROM Books);