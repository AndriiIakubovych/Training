SELECT DISTINCT Books.Press_id, Press_name, Price FROM Press, Books WHERE New = 1 AND Price > 40 AND Books.Press_id = Press.Press_id;
SELECT Book_name FROM Books, Press, Themes WHERE Press_name LIKE 'BHV%' AND Theme_name LIKE '[Å-Ê]%' AND Books.Press_id = Press.Press_id AND Books.Theme_id = Themes.Theme_id;
SELECT DISTINCT Books.Theme_id, Theme_name FROM Books, Themes WHERE Category_id IS NULL AND Books.Theme_id = Themes.Theme_id;
SELECT Book_name FROM Books, Press WHERE Press_name LIKE '% % % %' AND Books.Press_id = Press.Press_id;
SELECT Book_name FROM Books, Press WHERE LEN(Press_name) - LEN(REPLACE(Press_name, ' ', '')) = 2 AND Books.Press_id = Press.Press_id;