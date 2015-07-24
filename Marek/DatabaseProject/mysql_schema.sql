DROP DATABASE IF EXISTS `chain_of_supermarkets`;
CREATE DATABASE IF NOT EXISTS `chain_of_supermarkets` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `chain_of_supermarkets`;

DROP TABLE IF EXISTS `measures`;
CREATE TABLE `measures` (
	`id` int NOT NULL AUTO_INCREMENT,
	`name` nvarchar(50) NOT NULL,
	PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `vendors`;
CREATE TABLE `vendors` (
	`id` int NOT NULL AUTO_INCREMENT,
	`name` nvarchar(50) NOT NULL,
	PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

DROP TABLE IF EXISTS `products`;
CREATE TABLE `products` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` nvarchar(50) NOT NULL,
  `price` decimal(18,2) NOT NULL,
  `vendor_id` int NOT NULL,
  `measure_id` int NOT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`vendor_id`) REFERENCES `vendors` (`id`),
  FOREIGN KEY (`measure_id`) REFERENCES `measures` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;