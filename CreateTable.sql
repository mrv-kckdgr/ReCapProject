CREATE TABLE Brands(
Id int primary key identity(1,1),
BrandName varchar(100)
);

CREATE TABLE Colors(
Id int primary key identity(1,1),
ColorName varchar(100)
);


CREATE TABLE Cars(
Id int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice decimal,
Description varchar(300),

CONSTRAINT FK_BRAND FOREIGN KEY(BrandId) REFERENCES Brands(Id),
CONSTRAINT FK_COLOR FOREIGN KEY(ColorId) REFERENCES Colors(Id)
);

CREATE TABLE Users(
Id int primary key identity(1, 1),
FirstName nvarchar(50) not null,
LastName nvarchar(50) not null,
Email varchar(65) not null,
Password_ varchar(20) not null
);


CREATE TABLE Customers(
Id int primary key identity(1,1),
UserId int not null,
CompanyName nvarchar(100) not null,

CONSTRAINT FK_USER FOREIGN KEY(UserId) REFERENCES Users(Id)
);


CREATE TABLE Rentals(
Id int primary key identity(1,1), 
CarId int not null, 
CustomerId int not null, 
RentDate date not null, 
ReturnDate date default null,

CONSTRAINT FK_CAR FOREIGN KEY(CarId) REFERENCES Cars(Id),
CONSTRAINT FK_CUSTOMER FOREIGN KEY(CustomerId) REFERENCES Customers(Id)
);

