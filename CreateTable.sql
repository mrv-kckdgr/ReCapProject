CREATE TABLE Brands(
Id int primary key identity(1,1),
BrandName varchar(100)
)

CREATE TABLE Colors(
Id int primary key identity(1,1),
ColorName varchar(100)
)


CREATE TABLE Cars(
Id int primary key identity(1,1),
BrandId int,
ColorId int,
ModelYear int,
DailyPrice decimal,
Description varchar(300),

Constraint fk_brand FOREIGN KEY(BrandId) REFERENCES Brands(Id),
Constraint fk_color FOREIGN KEY(ColorId) REFERENCES Colors(Id)
)

