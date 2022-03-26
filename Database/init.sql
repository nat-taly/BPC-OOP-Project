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
    Id INT NOT NULL AUTO_INCREMENT,
    ItemName varchar(45) NOT NULL UNIQUE,
    Count INT NOT NULL,
    Value varchar(45) NOT NULL,
    Comment varchar(100),

    TypeID INT NOT NULL,
    UnitID INT NOT NULL,

	  PRIMARY KEY(Id),

    FOREIGN KEY (TypeID) REFERENCES ItemsType(Id),
    FOREIGN KEY (UnitID) REFERENCES Unit(Id)
);
