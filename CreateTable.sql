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

CREATE TABLE Users (
    Id        INT           IDENTITY (1, 1) NOT NULL,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email     VARCHAR (65)  NOT NULL,
    PasswordHash BINARY(500)  NOT NULL,
    PasswordSalt BINARY(500) NOT NULL, 
    Status BIT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE OperationClaim
(
	Id INT NOT NULL PRIMARY KEY IDENTITY, 
    Name VARCHAR(250) NOT NULL
)

CREATE TABLE UserOperationClaims
(
    Id INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [OperationClaim] INT NOT NULL, 
    
    CONSTRAINT FK_UserOperationClaims_User FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_UserOperationClaims_OperationClaims FOREIGN KEY (OperationClaim) REFERENCES OperationClaims(Id)
)

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


CREATE TABLE CarImages(
Id int primary key identity(1, 1),
CarId int,
ImagePath varchar(100),
Date datetime not null default getdate(),

CONSTRAINT FK_CarId FOREIGN KEY(CarId) REFERENCES Cars(Id)
); 
