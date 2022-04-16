CREATE DATABASE IF NOT EXISTS projektoop;
USE projektoop;

CREATE TABLE ItemType(
    Id INT AUTO_INCREMENT NOT NULL,
    TypeName varchar(50) NOT NULL UNIQUE,
    PRIMARY KEY(Id)
);

CREATE TABLE Unit(
    Id INT AUTO_INCREMENT NOT NULL,
    UnitName varchar(50) NOT NULL UNIQUE,
    PRIMARY KEY(Id)
);

CREATE TABLE Item(
    Id INT NOT NULL AUTO_INCREMENT,
    ItemName varchar(50) NOT NULL UNIQUE,
    Count INT NOT NULL,
    Value varchar(10) NOT NULL,
    Comment varchar(100),

    TypeID INT NOT NULL,
    UnitID INT NOT NULL,

	PRIMARY KEY(Id),

    FOREIGN KEY (TypeID) REFERENCES ItemType(Id),
    FOREIGN KEY (UnitID) REFERENCES Unit(Id)
);
