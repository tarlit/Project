CREATE USER CHAIN_OF_SUPERMARKETS IDENTIFIED BY "delphinium" DEFAULT TABLESPACE "USERS";
GRANT CREATE SESSION, CREATE TABLE, 
CREATE VIEW, CREATE PROCEDURE, CREATE SEQUENCE, 
CREATE TRIGGER, UNLIMITED TABLESPACE TO CHAIN_OF_SUPERMARKETS;

USE CHAIN_OF_SUPERMARKETS
CREATE TABLE MEASURES
(
  ID INT NOT NULL,
  MEASURE_NAME NVARCHAR2(50) NOT NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE VENDORS
(
  ID INT NOT NULL,
  VENDOR_NAME NVARCHAR2(50) NOT NULL,
  PRIMARY KEY(ID)
);

CREATE TABLE PRODUCTS
(
  ID INT NOT NULL,
  VENDOR_ID INT NOT NULL,
  PRODUCT_NAME NVARCHAR2(50) NOT NULL,
  MEASURE_ID INT NOT NULL,
  PRICE FLOAT NOT NULL,
  PRIMARY KEY(ID),
  FOREIGN KEY (VENDOR_ID) REFERENCES VENDORS(ID), 
  FOREIGN KEY (MEASURE_ID) REFERENCES MEASURES(ID)
);