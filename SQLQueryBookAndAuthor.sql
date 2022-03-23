use first_db


CREATE TABLE Authors(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(100),
Mobile VARCHAR(100),
Email VARCHAR(100)
)

SELECT * FROM Authors;
SELECT * FROM Books;
CREATE TABLE Books(
Id INT PRIMARY KEY IDENTITY,
Title VARCHAR(100),
Price Money,
Quantity INT,
Published_On VARCHAR(100),
Author_Id INT FOREIGN KEY REFERENCES Authors(Id)
)

INSERT INTO Authors(Name,Mobile,Email)
VALUES('Asif',8417889169,'asif@gmail.com'),
('Chetan',88774455,'chetan@gmail.com'),
('Monu',9988774455,'monu@gmail.com')
INSERT INTO Books (Title,Price,Quantity,Published_On,Author_Id)
VALUES('XYZ',55,2,GETDATE(),1),
('Man Can',525,1,GETDATE(),2),
('Ek Ka Dum',25,3,GETDATE(),2),
('Mom',5,5,GETDATE(),3),
('Lalu',55,4,GETDATE(),3),
('Ek Tha Tiger',55,11,GETDATE(),1)
