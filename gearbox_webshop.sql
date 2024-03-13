-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2024. Már 13. 18:03
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

--
-- A tábla adatainak kiíratása `jogosultsagok`
--

INSERT INTO `jogosultsagok` (`Id`, `Nev`) VALUES
(0, 'User'),
(1, 'Admin');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `kategoriafajtak`
--

DROP TABLE IF EXISTS `kategoriafajtak`;
CREATE TABLE IF NOT EXISTS `kategoriafajtak` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `KategoriaNev` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `KategoriaNev` (`KategoriaNev`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `kategoriafajtak`
--

INSERT INTO `kategoriafajtak` (`Id`, `KategoriaNev`) VALUES
(1, 'Nadrág'),
(2, 'Póló'),
(3, 'Pulóver'),
(4, 'Sapka');

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
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `VasarloId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
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
  `KategoriaId` int NOT NULL,
  `Meret` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Leiras` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Db` int NOT NULL,
  `Ar` int NOT NULL,
  `VanERaktaron` tinyint(1) NOT NULL,
  `Kep` varchar(999) COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `KategoriaId` (`KategoriaId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek`
--

INSERT INTO `termek` (`Id`, `Nev`, `KategoriaId`, `Meret`, `Leiras`, `Db`, `Ar`, `VanERaktaron`, `Kep`) VALUES
('0fc30eb2-e149-11ee-971b-b42e9915be68', 'Stretch Farmer', 1, 'XXL', 'jukhgzbtknumlgbuzkbhlnghjbzfctdrbhjgznfctdrbhjndcrftgehzgbhnkjzgftdrcbgvnhjzftrdcbvnhgzjtfdcfbnvghzftdcbnvghztcbnghmzjftcdngh', 200, 10, 1, '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasalasiadatok`
--

DROP TABLE IF EXISTS `vasalasiadatok`;
CREATE TABLE IF NOT EXISTS `vasalasiadatok` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `VasarloId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Megye` varchar(999) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `KosarId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Telepules` varchar(999) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `UtcaHazszam` varchar(999) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `VasarloId` (`VasarloId`),
  KEY `KosarId` (`KosarId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasarlo`
--

DROP TABLE IF EXISTS `vasarlo`;
CREATE TABLE IF NOT EXISTS `vasarlo` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `FelhasznaloNev` varchar(65) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Telefonszam` varchar(15) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Email` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `HASH` varchar(65) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Jogosultsag` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Email` (`Email`),
  KEY `Jogosultsag` (`Jogosultsag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `vasarlo`
--

INSERT INTO `vasarlo` (`Id`, `FelhasznaloNev`, `Telefonszam`, `Email`, `HASH`, `Jogosultsag`) VALUES
('08dc1cd7-4cf7-40d1-8ab0-63e8a6edddf3', 'Faszfej', '23453', 'string@string.string', '$2a$11$n77v2nsaHP848Ki55zR0PeULNqwn4ZB2DZQdfnromd2gSlElGkrYq', 0),
('08dc1cdb-d095-4505-8a8e-b701f486ce16', 'Paph Rika', '23456', 'email@email.email', '$2a$11$q88Dxnagdgq7Sk0Z6Xi8GebnYk8FNWNPDnpEflue0dTPlcLANizKC', 0),
('08dc1cdc-b4fa-45cf-88dd-c3b0fa71e5cd', '0', '0', '0', '$2a$11$4TShGLAANEwl1aMYTeEjNu.PzCS0PGteK9V/w.Iijgr5DqE8YN4Zq', 0),
('08dc1cdd-3a9f-4131-8ba8-d56f6a611124', 'Névvel Jánosh', '23456', 'Névvel@gmail.com', '$2a$11$dCLF7BNm4Dol5FX2d.Vrs.K4Mt10Gxd1gW/6gYPnC6PTdz7odMpoG', 0),
('08dc3391-a15a-427e-8317-764552ad8456', 'FoxySans', '45454', 'string', '$2a$11$PiaD6MaIiQxONa5cKO6oMOZZ.o.KtBtAvTg5MGdnCAmRMBYJPfmya', 1);

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `kosar`
--
ALTER TABLE `kosar`
  ADD CONSTRAINT `kosar_ibfk_6` FOREIGN KEY (`KosarId`) REFERENCES `kosarkapcsolat` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `kosar_ibfk_7` FOREIGN KEY (`TermekId`) REFERENCES `termek` (`Id`);

--
-- Megkötések a táblához `kosarkapcsolat`
--
ALTER TABLE `kosarkapcsolat`
  ADD CONSTRAINT `kosarkapcsolat_ibfk_1` FOREIGN KEY (`VasarloId`) REFERENCES `vasarlo` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `termek`
--
ALTER TABLE `termek`
  ADD CONSTRAINT `termek_ibfk_1` FOREIGN KEY (`KategoriaId`) REFERENCES `kategoriafajtak` (`Id`) ON DELETE CASCADE;

--
-- Megkötések a táblához `vasalasiadatok`
--
ALTER TABLE `vasalasiadatok`
  ADD CONSTRAINT `vasalasiadatok_ibfk_1` FOREIGN KEY (`VasarloId`) REFERENCES `vasarlo` (`Id`),
  ADD CONSTRAINT `vasalasiadatok_ibfk_2` FOREIGN KEY (`KosarId`) REFERENCES `kosar` (`Id`);

--
-- Megkötések a táblához `vasarlo`
--
ALTER TABLE `vasarlo`
  ADD CONSTRAINT `vasarlo_ibfk_1` FOREIGN KEY (`Jogosultsag`) REFERENCES `jogosultsagok` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
