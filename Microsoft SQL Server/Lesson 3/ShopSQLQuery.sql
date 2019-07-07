INSERT INTO Categories (Category_id, Category_name) VALUES (1, 'Мебель');
INSERT INTO Categories (Category_id, Category_name) VALUES (2, 'Бытовая техника');
INSERT INTO Categories (Category_id, Category_name) VALUES (3, 'Компьютерная техника');

INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (1, 'Андрей', 'Петров', 36, '+380678325435');
INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (2, 'Иван', 'Середенко', 23, '+380675435291');
INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (3, 'Виталий', 'Ганеев', 38, '+380636767844');
INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (4, 'Владимир', 'Крюкин', 32, '+380982456410');
INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (5, 'Елена', 'Василенко', 28, '+380972223456');
INSERT INTO Sellers (Seller_id, Seller_first_name, Seller_last_name, Age, Telephone) VALUES (6, 'Анна', 'Островская', 31, '+380677778234');

INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (1, 'Шкаф', 240.65, 10, 1, 3, 6);
INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (2, 'Диван', 310.28, 15, 1, 2, 8);
INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (3, 'Процессор Intel(R) Celeron(R) CPU E3400 2.60 GHz', 1100.15, 18, 3, 1, 16);
INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (4, 'Обогреватель', 1500.11, 12, 2, 4, 7);
INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (5, 'Видеокарта GeForce GTX 460', 2000.38, 11, 3, 1, 10);
INSERT INTO Products (Product_id, Product_name, Price, Product_count, Category_id, Seller_id, Seller_sold_count) VALUES (6, 'Кресло', 115.32, 5, 1, 6, 2);

SELECT Product_name, Price, Product_count, Category_name, Seller_first_name, Seller_last_name, Age, Telephone, Seller_sold_count FROM Products, Categories, Sellers WHERE Products.Category_id = Categories.Category_id AND Products.Seller_id = Sellers.Seller_id;
SELECT * FROM Sellers;