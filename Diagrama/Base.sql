-- MySQL Script generated by MySQL Workbench
-- Tue Aug 16 01:17:48 2022
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema blazor1
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema blazor1
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `blazor1` DEFAULT CHARACTER SET utf8 ;
USE `blazor1` ;

-- -----------------------------------------------------
-- Table `blazor1`.`usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blazor1`.`usuario` (
  `Codigo` VARCHAR(15) NOT NULL,
  `Nombre` VARCHAR(45) NOT NULL,
  `Clave` VARCHAR(45) NULL,
  `Rol` VARCHAR(45) NULL,
  `EstaActivo` TINYINT NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `blazor1`.`aerolinea`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `blazor1`.`aerolinea` (
  `Codigo` VARCHAR(30) NOT NULL,
  `Fecha` DATETIME NULL,
  `Origen` VARCHAR(45) NULL,
  `Destino` VARCHAR(100) NULL,
  `Avion` VARCHAR(45) NULL,
  `Cantidad` INT NULL,
  `Piloto` VARCHAR(45) NULL,
  PRIMARY KEY (`Codigo`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;