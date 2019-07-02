CREATE TABLE Bands (Band_id INTEGER NOT NULL PRIMARY KEY, Band_name VARCHAR(255) NOT NULL, Band_year INTEGER);
CREATE TABLE Formats (Format_id INTEGER NOT NULL PRIMARY KEY, Format_name VARCHAR(50) NOT NULL);
CREATE TABLE Sellers (Seller_id INTEGER NOT NULL PRIMARY KEY, Seller_name VARCHAR(50) NOT NULL);
CREATE TABLE CD (CD_id INTEGER NOT NULL PRIMARY KEY, CD_name VARCHAR(255) NOT NULL, CD_date DATETIME NOT NULL, Band_id INTEGER NOT NULL REFERENCES Bands ON UPDATE CASCADE ON DELETE CASCADE, Format_id INTEGER NOT NULL REFERENCES Formats ON UPDATE CASCADE ON DELETE CASCADE);
CREATE TABLE Sellings (Selling_id INTEGER NOT NULL PRIMARY KEY, Seller_id INTEGER NOT NULL REFERENCES Sellers ON UPDATE CASCADE ON DELETE CASCADE, CD_id INTEGER NOT NULL REFERENCES CD ON UPDATE CASCADE ON DELETE CASCADE);

INSERT INTO Bands VALUES (1, 'Сборники', NULL);
INSERT INTO Bands VALUES (2, 'ВИА ГРА', 2002);
INSERT INTO Bands VALUES (3, 'Ария', 1984);
INSERT INTO Bands VALUES (4, 'Валерий Меладзе', 1995);
INSERT INTO Bands VALUES (5, 'Игорь Тальков', 1984);
INSERT INTO Bands VALUES (6, 'Наутилус Помпилиус', 1983);

INSERT INTO Formats VALUES (1, 'Audio');
INSERT INTO Formats VALUES (2, 'MP3');

INSERT INTO Sellers VALUES (1, 'Фёдоров Максим');
INSERT INTO Sellers VALUES (2, 'Орлов Александр');

INSERT INTO CD VALUES (1, 'Союз 28', 2004, 1, 1);
INSERT INTO CD VALUES (2, 'Стоп, снято', 2002, 2, 1);
INSERT INTO CD VALUES (3, 'Крещенье огнём', 2003, 3, 1);
INSERT INTO CD VALUES (4, 'Все альбомы', 2005, 4, 2);
INSERT INTO CD VALUES (5, 'Все альбомы', 2005, 5, 2);
INSERT INTO CD VALUES (6, 'Лучшие песни', 2005, 3, 2);
INSERT INTO CD VALUES (7, 'Атлантида', 1997, 6, 2);
INSERT INTO CD VALUES (8, 'Атлантида', 1997, 6, 1);
INSERT INTO CD VALUES (9, 'Крылья', 1997, 6, 1);

INSERT INTO Sellings VALUES (1, 1, 1);
INSERT INTO Sellings VALUES (2, 1, 2);
INSERT INTO Sellings VALUES (3, 1, 3);
INSERT INTO Sellings VALUES (4, 1, 4);
INSERT INTO Sellings VALUES (5, 1, 5);
INSERT INTO Sellings VALUES (6, 2, 6);
INSERT INTO Sellings VALUES (7, 2, 1);
INSERT INTO Sellings VALUES (8, 2, 7);
INSERT INTO Sellings VALUES (9, 1, 8);
INSERT INTO Sellings VALUES (10, 2, 9);

SELECT Selling_id, Sellers.Seller_id, Seller_name, CD.CD_id, CD_name, CD_year, Bands.Band_id, Band_name, Formats.Format_id, Format_name FROM Sellings, Sellers, CD, Bands, Formats WHERE Sellings.Seller_id = Sellers.Seller_id AND Sellings.CD_id = CD.CD_id AND CD.Band_id = Bands.Band_id AND CD.Format_id = Formats.Format_id;
SELECT Bands.Band_id, Band_name, COUNT(Sellings.CD_id) AS Band_sold_CD_count FROM Sellings, CD, Bands WHERE Sellings.CD_id = CD.CD_id AND CD.Band_id = Bands.Band_id GROUP BY Bands.Band_id, Band_name;
GO
CREATE VIEW BandSoldCD AS SELECT Bands.Band_id, COUNT(Sellings.CD_id) AS Band_sold_CD_count FROM Sellings, CD, Bands WHERE Sellings.CD_id = CD.CD_id AND CD.Band_id = Bands.Band_id GROUP BY Bands.Band_id;
GO
SELECT BandSoldCD.Band_id, Bands.Band_name FROM BandSoldCD, Bands WHERE Band_sold_CD_count = (SELECT MAX(Band_sold_CD_count) FROM BandSoldCD) AND BandSoldCD.Band_id = Bands.Band_id;
DROP VIEW BandSoldCD;