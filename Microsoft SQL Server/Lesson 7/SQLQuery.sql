GO
CREATE INDEX PeoplesNames ON People (Person_name ASC);
GO
CREATE TRIGGER CouplesRepetition
ON Couples
FOR INSERT
AS
DECLARE @firstPersonId INT, @secondPersonId INT;
SELECT @firstPersonId = First_person_id, @secondPersonId = Second_person_id FROM inserted;
IF (EXISTS(SELECT * FROM Couples WHERE First_person_id = @secondPersonId AND Second_person_id = @firstPersonId))
BEGIN
raiserror('Повторяющиеся значения недопустимы!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER UpdateCouplesRepetition
ON Couples
FOR UPDATE
AS
DECLARE @firstPersonId INT, @secondPersonId INT;
SELECT @firstPersonId = First_person_id, @secondPersonId = Second_person_id FROM inserted;
IF (EXISTS(SELECT * FROM Couples WHERE First_person_id = @secondPersonId AND Second_person_id = @firstPersonId))
BEGIN
raiserror('Повторяющиеся значения недопустимы!', 0, 1);
ROLLBACK TRANSACTION;
END
GO
CREATE TRIGGER AddCouple
ON Couples
FOR INSERT
AS
DECLARE @firstPersonId INT, @secondPersonId INT;
SELECT @firstPersonId = First_person_id, @secondPersonId = Second_person_id FROM inserted;
UPDATE People SET Status = 'Нашёл' WHERE Person_id = @firstPersonId OR Person_id = @secondPersonId;
GO
CREATE TRIGGER UpdateCouple
ON Couples
FOR INSERT
AS
DECLARE @deletedFirstPersonId INT, @deletedSecondPersonId INT, @insertedFirstPersonId INT, @insertedSecondPersonId INT;
SELECT @deletedFirstPersonId = First_person_id, @deletedSecondPersonId = Second_person_id FROM deleted;
SELECT @insertedFirstPersonId = First_person_id, @insertedSecondPersonId = Second_person_id FROM inserted;
UPDATE People SET Status = 'В поиске' WHERE Person_id = @deletedFirstPersonId OR Person_id = @deletedSecondPersonId;
UPDATE People SET Status = 'Нашёл' WHERE Person_id = @insertedFirstPersonId OR Person_id = @insertedSecondPersonId;
GO
CREATE TRIGGER DeleteCouple
ON Couples
FOR DELETED
AS
DECLARE @firstPersonId INT, @secondPersonId INT;
SELECT @firstPersonId = First_person_id, @secondPersonId = Second_person_id FROM deleted;
UPDATE People SET Status = 'В поиске' WHERE Person_id = @firstPersonId OR Person_id = @secondPersonId;
GO
CREATE PROCEDURE GetCouplesFromCountry @countryName VARCHAR(50)
AS
SELECT First_person_id, a.Person_name, e.Country_name, Second_person_id, b.Person_name, f.Country_name FROM Couples, People a, People b, Cities c, Cities d, Countries e, Countries f WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.City_id = c.City_id AND b.City_id = d.City_id AND c.Country_id = e.Country_id AND d.Country_id = f.Country_id AND e.Country_name = @countryName AND f.Country_name = @countryName;
GO
EXECUTE GetCouplesFromCountry 'Украина';
GO
CREATE PROCEDURE GetCouplesBySalary @minSalary MONEY, @maxSalary MONEY
AS
SELECT First_person_id, a.Person_name, Second_person_id, b.Person_name, a.Salary + b.Salary AS General_salary FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.Salary + b.Salary >= @minSalary AND a.Salary + b.Salary <= @maxSalary;
GO
EXECUTE GetCouplesBySalary 1000, 8000;
GO
CREATE PROCEDURE GetCouplesByHeight @minFirstHeight FLOAT, @maxFirstHeight FLOAT, @minSecondHeight FLOAT, @maxSecondHeight FLOAT
AS
SELECT First_person_id, a.Person_name, a.Height, Second_person_id, b.Person_name, b.Height FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.Height >= @minFirstHeight AND a.Height <= @maxFirstHeight AND b.Height >= @minSecondHeight AND b.Height <= @maxSecondHeight;
GO
EXECUTE GetCouplesByHeight 170, 180, 150, 170;
GO
CREATE PROCEDURE GetCouplesByWeight @minFirstWeight FLOAT, @maxFirstWeight FLOAT, @minSecondWeight FLOAT, @maxSecondWeight FLOAT
AS
SELECT First_person_id, a.Person_name, a.Weight, Second_person_id, b.Person_name, b.Weight FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.Weight >= @minFirstWeight AND a.Weight <= @maxFirstWeight AND b.Weight >= @minSecondWeight AND b.Weight <= @maxSecondWeight;
GO
EXECUTE GetCouplesByWeight 90, 100, 50, 60;
GO
CREATE PROCEDURE GetCouplesByHairColor @firstHairColor VARCHAR(50), @secondHairColor VARCHAR(50)
AS
SELECT First_person_id, a.Person_name, a.Hair_color, Second_person_id, b.Person_name, b.Hair_color FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.Hair_color >= @firstHairColor AND b.Hair_color = @secondHairColor;
GO
EXECUTE GetCouplesByHairColor 'Чёрный', 'Белый';
GO
CREATE PROCEDURE GetCouplesByEyesColor @firstEyesColor VARCHAR(50), @secondEyesColor VARCHAR(50)
AS
SELECT First_person_id, a.Person_name, a.Eyes_color, Second_person_id, b.Person_name, b.Eyes_color FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND a.Eyes_color >= @firstEyesColor AND b.Eyes_color = @secondEyesColor;
GO
EXECUTE GetCouplesByEyesColor 'Карие', 'Голубые';
GO
CREATE PROCEDURE GetCouplesByParameters @minFirstHeight FLOAT, @maxFirstHeight FLOAT, @minSecondHeight FLOAT, @maxSecondHeight FLOAT, @minFirstWeight FLOAT, @maxFirstWeight FLOAT, @minSecondWeight FLOAT, @maxSecondWeight FLOAT, @firstHairColor VARCHAR(50), @secondHairColor VARCHAR(50), @firstEyesColor VARCHAR(50), @secondEyesColor VARCHAR(50)
AS
SELECT First_person_id, a.Person_name, a.Height, a.Weight, a.Hair_color, a.Eyes_color, Second_person_id, b.Person_name, b.Height, b.Weight, b.Hair_color, b.Eyes_color FROM Couples, People a, People b WHERE First_person_id = a.Person_id AND Second_person_id = b.Person_id AND Second_person_id = b.Person_id AND a.Height >= @minFirstHeight AND a.Height <= @maxFirstHeight AND b.Height >= @minSecondHeight AND b.Height <= @maxSecondHeight AND a.Weight >= @minFirstWeight AND a.Weight <= @maxFirstWeight AND b.Weight >= @minSecondWeight AND b.Weight <= @maxSecondWeight AND a.Hair_color >= @firstHairColor AND b.Hair_color = @secondHairColor AND a.Eyes_color >= @firstEyesColor AND b.Eyes_color = @secondEyesColor;
GO
EXECUTE GetCouplesByParameters 170, 180, 150, 170, 90, 100, 50, 60, 'Чёрный', 'Белый', 'Карие', 'Голубые';