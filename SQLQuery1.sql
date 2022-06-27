CREATE DATABASE DBCtuLogistics;

USE DBCtuLogistics;

CREATE TABLE Address
(
	Addressid INT identity(1,1) PRIMARY KEY  NOT NULL,
	ComplexNumber INT not null,
	ComplexName CHAR(50) not null,
	Street VARCHAR(60) null,
	Suburb VARCHAR(50) null,
	City VARCHAR(50) null,
	Province CHAR(50) null,
	Country CHAR(50) null,
	PostalCode VARCHAR(10) null
)
GO

insert into Address values (985435, 'Tshepo', 'Playfair blvd 354', 'CE5', 'Vanderbjlpark', 'Gauteng', 'South Africa', '1911');
insert into Address values (864432, 'Mapule', 'Playfair blvd 354', 'CE5', 'Vanderbjlpark', 'Gauteng', 'South Africa', '1911');


CREATE TABLE Customer
(
	Customerid INT identity(1,1) PRIMARY KEY NOT NULL,
	FullName CHAR(50) null,
	ContactNumber VARCHAR(15) unique not null,
	Email VARCHAR(40) null,
	Addressid INT
)
GO

CREATE TABLE Freight
(
	Freightid INT identity(1,1) PRIMARY KEY NOT NULL,
	Customerid INT unique,
	Height VARCHAR(10) null,
	Length VARCHAR(10) null,
	Weight VARCHAR(10) null,
	DestinationAddressid VARCHAR(50) null,
	OriginAdressid VARCHAR(50) null,
	Statusid VARCHAR(10) null,
	date date null
)
GO

CREATE TABLE Driver
(
	Driverid INT identity(1,1) PRIMARY KEY NOT NULL,
	FullName CHAR(20) unique not null,
	LicenseType VARCHAR(10) null,
	Owner VARCHAR(10) null
)
GO

CREATE TABLE Status
(
	Statusid VARCHAR(10) PRIMARY KEY NOT NULL,
	Status CHAR(10) null,
	DatePickedUp DATE null,
	DateDelivered DATE null,
	Driverid INT FOREIGN KEY REFERENCES Driver(Driverid) null
)
GO

--DROP TABLE Address;
--DROP TABLE Customer;
--DROP TABLE Freight;
--DROP TABLE Driver;
--DROP TABLE Status;