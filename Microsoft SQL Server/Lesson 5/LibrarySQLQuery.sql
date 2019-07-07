GO
CREATE VIEW StudentsBooksCount AS SELECT Book_id, COUNT(Book_id) AS Books_count From StudentsCards GROUP BY Book_id;
GO
SELECT Books.Author_id, Author_first_name, Author_last_name FROM Books, Authors WHERE Book_id = (SELECT Book_id FROM StudentsBooksCount WHERE Books_count = (SELECT MAX(Books_count) FROM StudentsBooksCount)) AND Books.Author_id = Authors.Author_id;
DROP VIEW StudentsBooksCount;
GO
CREATE VIEW TeachersBooksCount AS SELECT Teachers.Department_id, COUNT(Book_id) AS Books_count FROM TeachersCards, Teachers WHERE TeachersCards.Teacher_id = Teachers.Teacher_id GROUP BY Department_id;
GO
SELECT TeachersBooksCount.Department_id, Department_name FROM TeachersBooksCount, Departments WHERE Books_count = (SELECT MAX(Books_count) FROM TeachersBooksCount) AND TeachersBooksCount.Department_id = Departments.Department_id;
DROP VIEW TeachersBooksCount;
GO
CREATE VIEW TeachersThemesCount AS SELECT Books.Theme_id, COUNT(TeachersCards.Book_id) AS Books_count FROM TeachersCards, Books WHERE TeachersCards.Book_id = Books.Book_id GROUP BY Books.Theme_id;
GO
SELECT TeachersThemesCount.Theme_id, Theme_name FROM TeachersThemesCount, Themes WHERE Books_count = (SELECT MAX(Books_count) FROM TeachersThemesCount) AND TeachersThemesCount.Theme_id = Themes.Theme_id;
DROP VIEW TeachersThemesCount;