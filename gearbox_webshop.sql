-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2024. Jan 18. 08:26
-- Kiszolgáló verziója: 8.0.31
-- PHP verzió: 8.0.26

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `gearbox_webshop`
--
CREATE DATABASE IF NOT EXISTS `gearbox_webshop` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci;
USE `gearbox_webshop`;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `jogosultsagok`
--

DROP TABLE IF EXISTS `jogosultsagok`;
CREATE TABLE IF NOT EXISTS `jogosultsagok` (
  `Id` int NOT NULL,
  `Nev` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kosar`
--

DROP TABLE IF EXISTS `kosar`;
CREATE TABLE IF NOT EXISTS `kosar` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TermekId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `TermekNev` varchar(65) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Db` int NOT NULL,
  `TermekAr` int NOT NULL,
  `KosarId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `TermekId` (`TermekId`),
  KEY `VasarloId` (`KosarId`),
  KEY `KosarId` (`KosarId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kosarkapcsolat`
--

DROP TABLE IF EXISTS `kosarkapcsolat`;
CREATE TABLE IF NOT EXISTS `kosarkapcsolat` (
  `Id` char(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `VasarloId` char(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `VasarloId` (`VasarloId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `termek`
--

DROP TABLE IF EXISTS `termek`;
CREATE TABLE IF NOT EXISTS `termek` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Nev` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Kategoria` varchar(999) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Leiras` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Db` int NOT NULL,
  `Ar` int NOT NULL,
  `VanERaktaron` tinyint(1) NOT NULL,
  `Kep` blob NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlo`
--

DROP TABLE IF EXISTS `vasarlo`;
CREATE TABLE IF NOT EXISTS `vasarlo` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `FelhasznaloNev` varchar(65) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Telefonszam` int NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(65) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogosultsag` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Email` (`Email`),
  KEY `Jogosultsag` (`Jogosultsag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `kosar`
--
ALTER TABLE `kosar`
  ADD CONSTRAINT `kosar_ibfk_4` FOREIGN KEY (`KosarId`) REFERENCES `kosarkapcsolat` (`Id`),
  ADD CONSTRAINT `kosar_ibfk_5` FOREIGN KEY (`TermekId`) REFERENCES `termek` (`Id`);

--
-- Megkötések a táblához `kosarkapcsolat`
--
ALTER TABLE `kosarkapcsolat`
  ADD CONSTRAINT `kosarkapcsolat_ibfk_1` FOREIGN KEY (`VasarloId`) REFERENCES `vasarlo` (`Id`);

--
-- Megkötések a táblához `vasarlo`
--
ALTER TABLE `vasarlo`
  ADD CONSTRAINT `vasarlo_ibfk_1` FOREIGN KEY (`Jogosultsag`) REFERENCES `jogosultsagok` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
