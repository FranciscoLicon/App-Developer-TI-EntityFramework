CREATE TABLE users(
    id_user INT PRIMARY KEY IDENTITY(1,1),
	firstName VARCHAR(30),
	lastName VARCHAR(30),
	userName VARCHAR(30),
    gender VARCHAR(30),
    registerDate DATETIME,
);


INSERT INTO users values('Francisco','Licon','FLicon','male','27/02/2021');
SELECT * FROM users;