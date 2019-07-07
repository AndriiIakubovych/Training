GO
CREATE PROCEDURE GetWithBooksStudents
AS
SELECT StudentsCards.Student_id, Student_first_name, Student_last_name FROM StudentsCards, Students, Books WHERE In_date IS NULL AND StudentsCards.Student_id = Students.Student_id AND StudentsCards.Book_id = Books.Book_id;
GO
EXECUTE GetWithBooksStudents;
GO
CREATE PROCEDURE GetGenerousLibrarian
AS
GO
CREATE VIEW StudentsBooksCount AS SELECT Librarian_id, COUNT(Book_id) AS Books_count FROM StudentsCards GROUP BY Librarian_id;
GO
CREATE VIEW TeachersBooksCount AS SELECT Librarian_id, COUNT(Book_id) AS Books_count FROM TeachersCards GROUP BY Librarian_id;
GO
SELECT StudentsBooksCount.Librarian_id, Librarian_first_name, Librarian_last_name FROM StudentsBooksCount, TeachersBooksCount, Librarians WHERE StudentsBooksCount.Books_count + TeachersBooksCount.Books_count = (SELECT MAX(StudentsBooksCount.Books_count + TeachersBooksCount.Books_count) FROM StudentsBooksCount, TeachersBooksCount WHERE StudentsBooksCount.Librarian_id = TeachersBooksCount.Librarian_id) AND StudentsBooksCount.Librarian_id = TeachersBooksCount.Librarian_id AND StudentsBooksCount.Librarian_id = Librarians.Librarian_id;
DROP VIEW StudentsBooksCount;
DROP VIEW TeachersBooksCount;
GO
EXECUTE GetGenerousLibrarian;
GO
CREATE PROCEDURE GetFactorial @n INT
AS
DECLARE @i INT, @f INT;
SET @i = 1;
SET @f = 1;
IF (@n != 0)
BEGIN
WHILE @i <= @n
BEGIN
SET @f *= @i;
SET @i = @i + 1;
END
END
IF (@n >= 0)
RETURN @f;
ELSE
RETURN NULL;
GO
DECLARE @f INT;
EXECUTE @f = GetFactorial 5;
SELECT @f AS Factorial_value;
GO
CREATE FUNCTION GetWithoutBooksStudents()
RETURNS INT
AS
BEGIN
DECLARE @c INT, @cb INT;
SELECT @c = COUNT(Student_id) FROM Students;
SELECT @cb = COUNT(DISTINCT StudentsCards.Student_id) FROM StudentsCards;
SET @c -= @cb;
RETURN @c;
END
GO
SELECT dbo.GetWithoutBooksStudents() AS Students_count;
GO
CREATE FUNCTION GetMinValue(@a FLOAT, @b FLOAT, @c FLOAT)
RETURNS FLOAT
AS
BEGIN
DECLARE @m FLOAT;
IF (@a < @b AND @a < @c)
SET @m = @a;
IF (@b < @a AND @b < @c)
SET @m = @b;
IF (@c < @a AND @c < @b)
SET @m = @c;
RETURN @m;
END
GO
SELECT dbo.GetMinValue(18, 26, 9) AS Min_value;
GO
CREATE FUNCTION GetBiggerDigit(@n INT)
RETURNS FLOAT
AS
BEGIN
DECLARE @m INT
IF (@n >= 10 AND @n <= 100)
IF (@n / 10 > @n % 10)
SET @m = @n / 10;
ELSE
SET @m = @n % 10;
ELSE
SET @m = NULL;
RETURN @m;
END
GO
SELECT dbo.GetBiggerDigit(57) AS Bigger_digit;
GO
CREATE FUNCTION GetTakenBooksCount()
RETURNS @booksReaders TABLE (Books_reader_id INT, Books_reader_name VARCHAR(50), Books_count INT)
AS
BEGIN
INSERT @booksReaders SELECT Students.Group_id, Group_name, COUNT(Book_id) FROM StudentsCards, Students, Groups WHERE StudentsCards.Student_id = Students.Student_id AND Students.Group_id = Groups.Group_id GROUP BY Students.Group_id, Group_name;
INSERT @booksReaders SELECT Teachers.Department_id, Department_name, COUNT(Book_id) FROM TeachersCards, Teachers, Departments WHERE TeachersCards.Teacher_id = Teachers.Teacher_id AND Teachers.Department_id = Departments.Department_id GROUP BY Teachers.Department_id, Department_name;
RETURN;
END
GO
SELECT * FROM dbo.GetTakenBooksCount();
GO
CREATE FUNCTION GetBooksList(@authorFirstName VARCHAR(50), @authorLastName VARCHAR(50), @theme VARCHAR(50), @category VARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT Book_id, Book_name, Pages_count, Press_year FROM Books, Authors, Themes, Categories WHERE Author_first_name = @authorFirstName AND Author_last_name = @authorLastName AND Theme_name = @theme AND Category_name = @category AND Books.Author_id = Authors.Author_id AND Books.Theme_id = Themes.Theme_id AND Books.Category_id = Categories.Category_id);
GO
SELECT * FROM GetBooksList('Джеймс', 'Грофф', 'Базы данных', 'Язык SQL');
GO
CREATE FUNCTION GetGivenBooksCount()
RETURNS @librarians TABLE (Librarian_id INT, Librarian_name VARCHAR(50), Books_count INT)
AS
BEGIN
DECLARE @firstTempTable TABLE (Librarian_id INT, Librarian_name VARCHAR(50), Books_count INT);
DECLARE @secondTempTable TABLE (Librarian_id INT, Librarian_name VARCHAR(50), Books_count INT);
INSERT @firstTempTable SELECT StudentsCards.Librarian_id, Librarian_first_name + ' ' + Librarian_last_name, COUNT(Book_id) FROM StudentsCards, Librarians WHERE StudentsCards.Librarian_id = Librarians.Librarian_id GROUP BY StudentsCards.Librarian_id, Librarian_first_name, Librarian_last_name;
INSERT @secondTempTable SELECT TeachersCards.Librarian_id, Librarian_first_name + ' ' + Librarian_last_name, COUNT(Book_id) FROM TeachersCards, Librarians WHERE TeachersCards.Librarian_id = Librarians.Librarian_id GROUP BY TeachersCards.Librarian_id, Librarian_first_name, Librarian_last_name;
INSERT @librarians SELECT ft.Librarian_id, ft.Librarian_name, ft.Books_count + st.Books_count FROM @firstTempTable ft, @secondTempTable st WHERE ft.Librarian_id = st.Librarian_id;
RETURN;
END
GO
SELECT * FROM dbo.GetGivenBooksCount();
GO
CREATE TRIGGER StudentsTakesBooks
ON StudentsCards
FOR INSERT
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM inserted;
UPDATE Books SET Books_count = Books_count - 1 WHERE Book_id = @bookId;
GO
CREATE TRIGGER TeachersTakesBooks
ON TeachersCards
FOR INSERT
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM inserted;
UPDATE Books SET Books_count = Books_count - 1 WHERE Book_id = @bookId;
GO
CREATE TRIGGER UpdateStudentsBooks
ON StudentsCards
FOR UPDATE
AS
DECLARE @deletedBookId INT, @insertedBookId INT;
SELECT @deletedBookId = Book_id FROM deleted;
SELECT @insertedBookId = Book_id FROM inserted;
UPDATE Books SET Books_count = Books_count + 1 WHERE Book_id = @deletedBookId;
UPDATE Books SET Books_count = Books_count - 1 WHERE Book_id = @insertedBookId;
GO
CREATE TRIGGER UpdateTeachersBooks
ON TeachersCards
FOR UPDATE
AS
DECLARE @deletedBookId INT, @insertedBookId INT;
SELECT @deletedBookId = Book_id FROM deleted;
SELECT @insertedBookId = Book_id FROM inserted;
UPDATE Books SET Books_count = Books_count + 1 WHERE Book_id = @deletedBookId;
UPDATE Books SET Books_count = Books_count - 1 WHERE Book_id = @insertedBookId;
GO
CREATE TRIGGER StudentsGivesBooks
ON StudentsCards
FOR DELETE
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM deleted;
UPDATE Books SET Books_count = Books_count + 1 WHERE Book_id = @bookId;
GO
CREATE TRIGGER TeachersGivesBooks
ON TeachersCards
FOR DELETE
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM deleted;
UPDATE Books SET Books_count = Books_count + 1 WHERE Book_id = @bookId;
GO
CREATE TRIGGER StudentsBooksNullCount
ON StudentsCards
FOR INSERT
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM Books WHERE Books_count = 0;
IF (EXISTS(SELECT * FROM inserted WHERE Book_id = @bookId))
BEGIN
raiserror('Данная книга отсутствует в библиотеке!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER TeachersBooksNullCount
ON TeachersCards
FOR INSERT
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM Books WHERE Books_count = 0;
IF (EXISTS(SELECT * FROM inserted WHERE Book_id = @bookId))
BEGIN
raiserror('Данная книга отсутствует в библиотеке!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER UpdateStudentsBooksNullCount
ON StudentsCards
FOR UPDATE
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM Books WHERE Books_count = 0;
IF (EXISTS(SELECT * FROM inserted WHERE Book_id = @bookId))
BEGIN
raiserror('Данная книга отсутствует в библиотеке!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER UpdateTeachersBooksNullCount
ON TeachersCards
FOR UPDATE
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM Books WHERE Books_count = 0;
IF (EXISTS(SELECT * FROM inserted WHERE Book_id = @bookId))
BEGIN
raiserror('Данная книга отсутствует в библиотеке!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER MaxGivenBooksCount
ON StudentsCards
FOR INSERT
AS
DECLARE @studentId INT, @studentsCount INT;
SELECT @studentId = Student_id FROM inserted;
SELECT @studentsCount = COUNT(Student_id) FROM StudentsCards WHERE Student_id = @studentId GROUP BY Student_id;
IF (@studentsCount >= 3)
BEGIN
raiserror('Нельзя выдать более трёх книг одному студенту!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER UpdateMaxGivenBooksCount
ON StudentsCards
FOR UPDATE
AS
DECLARE @studentId INT, @studentsCount INT;
SELECT @studentId = Student_id FROM inserted;
SELECT @studentsCount = COUNT(Student_id) FROM StudentsCards WHERE Student_id = @studentId GROUP BY Student_id;
IF (@studentsCount >= 3)
BEGIN
raiserror('Нельзя выдать более трёх книг одному студенту!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER InsertToDeleted
ON Books
FOR DELETE
AS
DECLARE @bookId INT, @bookName VARCHAR(100), @pagesCount INT, @pressYear INT, @themeId INT, @categoryId INT, @authorId INT, @pressId INT, @comment VARCHAR(50), @booksCount INT;
SELECT @bookId = Book_id, @bookName = Book_name, @pagesCount = Pages_count, @pressYear = Press_year, @themeId = Theme_id, @categoryId = Category_id, @authorId = Author_id, @pressId = Press_id, @comment = Comment, @booksCount = Books_count FROM deleted;
INSERT INTO DeletedBooks VALUES (@bookId, @bookName, @pagesCount, @pressYear, @themeId, @categoryId, @authorId, @pressId, @comment, @booksCount);
GO
CREATE TRIGGER DeleteFromDeleted
ON Books
FOR INSERT
AS
DECLARE @bookId INT;
SELECT @bookId = Book_id FROM inserted;
DELETE FROM DeletedBooks WHERE Book_id = @bookId;