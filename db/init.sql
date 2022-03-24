CREATE TABLE item_type(
    id INT(6) AUTO_INCREMENT NOT NULL,
    type_name varchar(45) NOT NULL UNIQUE,
    PRIMARY KEY(id)
);

CREATE TABLE item(
    id INT(6) AUTO_INCREMENT NOT NULL,
    item_name varchar(45) NOT NULL UNIQUE,
    price varchar(45) NOT NULL UNIQUE,
    type_id INT(6) NOT NULL,
	PRIMARY KEY(id),
    FOREIGN KEY (type_id) REFERENCES item_type(id)
);
