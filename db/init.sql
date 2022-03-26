CREATE DATABASE IF NOT EXISTS projektoop;
USE projektoop;

CREATE TABLE ItemsType(
    Id INT(6) AUTO_INCREMENT NOT NULL,
    TypeName varchar(45) NOT NULL UNIQUE,
    PRIMARY KEY(Id)
);

CREATE TABLE Unit(
    Id INT(6) AUTO_INCREMENT NOT NULL,
    UnitName varchar(45) NOT NULL UNIQUE,
    PRIMARY KEY(Id)
);

CREATE TABLE Items(
    Id INT(6) AUTO_INCREMENT NOT NULL,
    ItemName varchar(45) NOT NULL UNIQUE,
    Count INT(6),
    Value varchar(45) NOT NULL,
    Comment varchar(100),

    TypeID INT(6) NOT NULL,
    UnitID INT(6) NOT NULL,

	  PRIMARY KEY(Id),
    FOREIGN KEY (TypeID) REFERENCES ItemsType(Id),
    FOREIGN KEY (UnitID) REFERENCES Unit(Id)
);
