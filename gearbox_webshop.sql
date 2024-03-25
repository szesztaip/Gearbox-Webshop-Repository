-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2024. Már 25. 06:54
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
-- Tábla szerkezet ehhez a táblához `besorolas`
--

DROP TABLE IF EXISTS `besorolas`;
CREATE TABLE IF NOT EXISTS `besorolas` (
  `Id` char(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Nev` varchar(999) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  KEY `Id` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `besorolas`
--

INSERT INTO `besorolas` (`Id`, `Nev`) VALUES
('113e047a-9143-4f25-bbec-a1695e395743', 'férfi'),
('46c33419-479b-40a5-9628-ec73a8dbe642', 'női'),
('80671620-c381-453f-b0cc-448feb115cc3', 'gyerek'),
('27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'uniszex');

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `kategoriafajtak`
--

INSERT INTO `kategoriafajtak` (`Id`, `KategoriaNev`) VALUES
(5, 'Cipő'),
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
  `besorolasId` char(36) COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Meret` varchar(5) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Leiras` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Db` int NOT NULL,
  `Ar` int NOT NULL,
  `VanERaktaron` tinyint(1) NOT NULL,
  `Kep` varchar(999) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `KategoriaId` (`KategoriaId`),
  KEY `besorolasId` (`besorolasId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_hungarian_ci;

--
-- A tábla adatainak kiíratása `termek`
--

INSERT INTO `termek` (`Id`, `Nev`, `KategoriaId`, `besorolasId`, `Meret`, `Leiras`, `Db`, `Ar`, `VanERaktaron`, `Kep`) VALUES
('08dc4991-3d88-47b6-8c4b-d0b799ac4813', 'Szűk farmer', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Hereszorító', 20, 5000, 1, 'string'),
('08dc4992-11d5-41e7-861a-606f9c0a018e', 'Nike cipő', 5, '113e047a-9143-4f25-bbec-a1695e395743', 'L', 'Sport cipő', 30, 15000, 1, 'string'),
('08dc4992-97f7-4ab4-8d51-d02009de6721', 'Izompóló', 2, '113e047a-9143-4f25-bbec-a1695e395743', 'XL', 'Kottagépeknek feszítéshez legjobb választás', 60, 17000, 1, 'string'),
('08dc4993-444b-4636-8780-63050bb9d4bf', 'Orosz medveprém téli sapka', 4, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'L', 'Kifejezetten hideg időben tökéletes melegítő, divatos és uniszex', 10, 500000, 1, 'string'),
('08dc4994-1b30-469e-80c0-41a2a27126c8', 'Hypernova First Ascendant', 3, '80671620-c381-453f-b0cc-448feb115cc3', 'XL', 'Extra kényelmes és meleg prémium pamut pulóver vagány reflektív mintákkal', 10, 50000, 1, 'string'),
('08dc4996-908c-4398-8fc5-6bc4fdd9037b', 'Hour Behavior', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'M', 'Túra cipő', 39, 15137, 1, 'string'),
('08dc4997-c841-4b34-85d6-4c0cbe652f52', 'Attorney Father', 3, '80671620-c381-453f-b0cc-448feb115cc3', 'XL', 'Akarod hogy az irodában is tudja mindenki te egy férfi állat vagy?! Ne habozz, ez kell neked', 36, 13267, 1, 'string'),
('08dc4999-3af4-47a5-8f41-e8ae4b52fdf3', 'DarkTurquoise', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'M', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 59, 5130, 1, 'string'),
('08dc4999-84a1-4b75-8d9b-ddf10fa7e9e2', 'Coral', 3, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 29, 95500, 1, 'string'),
('08dc4999-b2da-41ac-8ee5-058d71bc9efa', 'LightBlue', 2, '80671620-c381-453f-b0cc-448feb115cc3', 'XXL', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 65, 6500, 1, 'string'),
('08dc4999-dcb1-406a-85f6-75622653b973', 'SlateBlue', 5, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek', 9, 77000, 1, 'string'),
('08dc499a-0371-4844-8eee-003716365529', 'Thistle', 4, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'XXL', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 87, 12500, 1, 'string'),
('08dc499a-3347-45a6-8927-639616f36f10', 'Tomato', 4, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'L', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 42, 10000, 1, 'string'),
('08dc499a-8403-4507-8234-6eccafaca53a', 'Purple', 2, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 976, 57000, 1, 'string'),
('08dc499a-b4ac-4b6c-8bf2-05fba2cb6cba', 'SeaGreen', 1, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 32, 95000, 1, 'string'),
('08dc499a-d9fd-49c8-87b1-b91062d83d9d', 'Aqua', 1, '80671620-c381-453f-b0cc-448feb115cc3', 'S', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 15, 29000, 1, 'string'),
('08dc499b-0c1d-4d9a-83a9-9a4b64ae80a2', 'Teal', 3, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 92, 33000, 1, 'string'),
('08dc499b-2fcc-4030-8006-328d3cb495bc', 'Magenta', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'S', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 50, 17000, 1, 'string'),
('08dc499b-567b-48ef-8373-502865924164', 'YellowGreen', 4, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'M', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 52, 71000, 1, 'string'),
('08dc499b-826a-43b3-8076-70979de29d59', 'Beige', 2, '46c33419-479b-40a5-9628-ec73a8dbe642', 'L', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 98, 43500, 1, 'string'),
('08dc499b-ac60-4896-8ad6-03acf2de2c0a', 'DarkTurquoise', 3, '80671620-c381-453f-b0cc-448feb115cc3', 'XXL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 38, 61500, 1, 'string'),
('08dc499c-0eab-41d1-8685-10acfa89adf6', 'SkyBlue', 2, '113e047a-9143-4f25-bbec-a1695e395743', 'S', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 61, 95000, 1, 'string'),
('08dc499c-7785-4811-8740-fa5e2dd926ec', 'Cornsilk', 2, '113e047a-9143-4f25-bbec-a1695e395743', 'L', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 38, 47000, 1, 'string'),
('08dc499c-9dc3-4a86-870b-b996eab738c8', 'Olive', 5, '113e047a-9143-4f25-bbec-a1695e395743', 'L', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 86, 30000, 1, 'string'),
('08dc499c-f548-4f14-86ad-ae3759e04d58', 'DarkSalmon', 1, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 86, 30000, 1, 'string'),
('08dc499d-44c6-46da-890e-d92611927cf9', 'Lime', 3, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 77, 14000, 1, 'string'),
('08dc4a4a-7910-4ceb-861f-b82e89bdce2f', 'AliceBlue', 1, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 45, 7300, 1, 'string'),
('08dc4a4a-a26c-4598-8c0f-2c370216cc20', 'Lavender', 1, '80671620-c381-453f-b0cc-448feb115cc3', 'L', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 80, 8000, 1, 'string'),
('08dc4a4a-cb20-44a7-870c-d83de6a0585d', 'MediumAquaMarine', 2, '80671620-c381-453f-b0cc-448feb115cc3', 'L', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 61, 65000, 1, 'string'),
('08dc4a4a-f5c7-41c1-8ff2-89dbc24795d0', 'LightSteelBlue', 3, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'XXL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 12, 32000, 1, 'string'),
('08dc4a4b-99de-4099-8ef8-3805694b940c', 'Green', 3, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'XL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 9, 30000, 1, 'string'),
('08dc4a4b-b261-4843-86f8-9318bf2cda49', 'Purple', 3, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'M', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 20, 70000, 1, 'string'),
('08dc4a4b-ffa0-41c4-8b18-ddc6fa0da2be', 'Blue', 3, '113e047a-9143-4f25-bbec-a1695e395743', 'L', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 75, 76500, 1, 'string'),
('08dc4a4c-48de-4eef-881b-eb9500f47b00', 'AliceBlue', 5, '113e047a-9143-4f25-bbec-a1695e395743', 'XXL', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 90, 45000, 1, 'string'),
('08dc4a4c-6924-42c6-890d-f679a6a13f90', 'Brown', 5, '46c33419-479b-40a5-9628-ec73a8dbe642', 'S', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 30, 81500, 1, 'string'),
('08dc4a4c-9bad-464f-8472-8cb128ad7286', 'HotPink', 2, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XL', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 23, 90000, 1, 'string'),
('08dc4a4c-c673-47fa-8421-615b60fda7d5', 'Lavender', 4, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XL', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 36, 8600, 1, 'string'),
('08dc4a4d-16e0-49b2-8878-f6a557d1dbc8', 'Beige', 2, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XXL', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 91, 54500, 1, 'string'),
('08dc4a4d-4023-439c-80be-2c6c468d88f7', 'RoyalBlue', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'XL', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 8, 66500, 1, 'string'),
('08dc4a4d-a553-4fa4-8d6a-176b86563035', 'AntiqueWhite', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'XXL', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 79, 90000, 1, 'string'),
('08dc4a4d-b9a4-49be-8a9e-1c72dacc4945', 'Ivory', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 98, 86000, 1, 'string'),
('08dc4a4d-dcdc-4747-84ac-3ddd01497ad6', 'MediumSlateBlue', 4, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'M', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 12, 72000, 1, 'string'),
('08dc4a4e-02cc-4829-8b6a-1d4043c78019', 'LightSalmon', 1, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'L', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 30, 67000, 1, 'string'),
('08dc4a4e-2baa-40e5-8f6f-0bba88446e22', 'FireBrick', 5, '27e6f8a9-d7a4-4bef-8dbb-f94c44e93960', 'S', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 15, 28000, 1, 'string'),
('08dc4a4e-4bc2-40de-81a8-5dd663375e7a', 'Linen', 2, '113e047a-9143-4f25-bbec-a1695e395743', 'XL', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 94, 17000, 1, 'string'),
('08dc4a4e-6c4b-44b6-82e1-94bb43b27ada', 'Moccasin', 4, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 85, 90000, 1, 'string'),
('08dc4a4e-87c1-49e4-82b2-5a1ff4013afb', 'DarkCyan', 4, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XL', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 9, 63000, 1, 'string'),
('08dc4a4f-77bc-496c-83c7-f14d840bc1af', 'OliveDrab', 4, '46c33419-479b-40a5-9628-ec73a8dbe642', 'L', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 43, 49000, 1, 'string'),
('08dc4a4f-8b54-458c-8763-1f488441dac0', 'Maroon', 4, '46c33419-479b-40a5-9628-ec73a8dbe642', 'L', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 49, 42000, 1, 'string'),
('08dc4a4f-a73e-44d6-82f8-94ce0ac3a0ce', 'WhiteSmoke', 4, '80671620-c381-453f-b0cc-448feb115cc3', 'S', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 2, 67000, 1, 'string'),
('08dc4a4f-cebb-4b5a-8661-4f2a5c76705b', 'SaddleBrown', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'XXL', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 84, 30500, 1, 'string'),
('08dc4a4f-e62f-40c8-8218-6368c96f6d24', 'DarkGreen', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'S', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 42, 42500, 1, 'string'),
('08dc4a50-172f-4aeb-8a5a-d4622f289b11', 'MediumBlue', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'XL', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 38, 85000, 1, 'string'),
('08dc4a50-37df-4392-86b2-2b2c1c2a0f47', 'MediumSlateBlue', 2, '113e047a-9143-4f25-bbec-a1695e395743', 'S', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 57, 36000, 1, 'string'),
('08dc4a50-6959-43d1-8208-d7285d5bf25d', 'RedHead', 4, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XXL', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 84, 71500, 1, 'string'),
('08dc4a50-8f92-4ef2-813c-c8a03eb2ed78', 'LemonChiffon', 5, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 87, 96500, 1, 'string'),
('08dc4a51-4192-49b4-815d-11d968427e5f', 'Coral', 1, '46c33419-479b-40a5-9628-ec73a8dbe642', 'M', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 28, 93000, 1, 'string'),
('08dc4a51-6122-408a-8e92-517e6426be15', 'PapayaWhip', 5, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 5, 6000, 1, 'string'),
('08dc4a51-8331-4f34-8493-e321b7bb8224', 'PeachPuff', 1, '80671620-c381-453f-b0cc-448feb115cc3', 'XL', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 70, 12000, 1, 'string'),
('08dc4a51-d114-469d-8248-6fcabb2f5d2b', 'Crimson', 2, '80671620-c381-453f-b0cc-448feb115cc3', 'S', 'Egyedi tervezésű póló. Ideális választás a stílus és kényelem kedvelőinek.', 69, 58000, 1, 'string'),
('08dc4a51-f5c6-42ae-8bcb-3452154f7fed', 'Fuchsia', 1, '46c33419-479b-40a5-9628-ec73a8dbe642', 'XL', 'Egyedi tervezésű nadrág. Ideális választás a stílus és kényelem kedvelőinek.', 99, 25500, 1, 'string'),
('08dc4a52-5b35-4323-8b3f-6da6b82aec50', 'Olive', 5, '46c33419-479b-40a5-9628-ec73a8dbe642', 'S', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 55, 68000, 1, 'string'),
('08dc4a52-7d4d-4b85-82e4-a08eda04f240', 'DarkBlue', 4, '113e047a-9143-4f25-bbec-a1695e395743', 'M', 'Egyedi tervezésű sapka. Ideális választás a stílus és kényelem kedvelőinek.', 31, 56000, 1, 'string'),
('08dc4a52-a6f8-4cb5-8109-e201a16e8825', 'LightSteelBlue', 5, '80671620-c381-453f-b0cc-448feb115cc3', 'XXL', 'Egyedi tervezésű cipő. Ideális választás a stílus és kényelem kedvelőinek.', 67, 46000, 1, 'string'),
('08dc4a52-caaa-41d1-80c0-c220715b218f', 'LavenderBlush', 3, '113e047a-9143-4f25-bbec-a1695e395743', 'XL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 70, 54000, 1, 'string'),
('08dc4a52-f391-4634-8abe-4e26a87d1a15', 'MediumSpringGreen', 3, '113e047a-9143-4f25-bbec-a1695e395743', 'XL', 'Egyedi tervezésű pulóver. Ideális választás a stílus és kényelem kedvelőinek.', 42, 40000, 1, 'string'),
('0fc30eb2-e149-11ee-971b-b42e9915be68', 'Stretch Farmer', 1, '113e047a-9143-4f25-bbec-a1695e395743', 'XXL', 'jukhgzbtknumlgbuzkbhlnghjbzfctdrbhjgznfctdrbhjndcrftgehzgbhnkjzgftdrcbgvnhjzftrdcbvnhgzjtfdcfbnvghzftdcbnvghztcbnghmzjftcdngh', 200, 10, 1, '');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `vasalasiadatok`
--

DROP TABLE IF EXISTS `vasalasiadatok`;
CREATE TABLE IF NOT EXISTS `vasalasiadatok` (
  `Id` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `VasarloId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Megye` varchar(999) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `KosarId` char(36) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
  `Telepules` varchar(999) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
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
  `Telefonszam` varchar(15) CHARACTER SET utf8mb4 COLLATE utf8mb4_hungarian_ci NOT NULL,
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
('08dc3391-a15a-427e-8317-764552ad8456', 'FoxySans', '45454', 'string', '$2a$11$PiaD6MaIiQxONa5cKO6oMOZZ.o.KtBtAvTg5MGdnCAmRMBYJPfmya', 1),
('08dc497d-9525-4bc4-8226-f8dec6e7552f', 'string', '13234', 'string@', '$2a$11$UWHIA/ynb2.JDTGH0hXcNuJqSPNg82Lf7AO8YgDSU7pqnRmJp6.Nq', 0),
('08dc4985-4100-459a-8b97-2eee842c23c1', 'sss', '21345', 'sss@sdf', '$2a$11$0O3Y1MOBrdmcw2Hrgg3QDelyZxhsQgx5zmQop/bqH4p05LiVr0FKe', 0),
('08dc4985-a2c4-42f8-8061-a60de4760b77', 'sdafghj', '234567', 'sadfgh@sdfg', '$2a$11$vfy0CttKFSvFQgYltOLN3OBOB5Yw/DszzpZbpKTLjNpxlvYrYau8i', 0),
('08dc498a-8f02-424d-8397-29d7ec5c3b33', 'Kisfaszú', '21345677', 'ambrusk@kkszki.hu', '$2a$11$EA218hkDOIq4S1u8ixPOz.twqN7GNMVqxayn0XQEaS2c82g5R1GhG', 0),
('08dc498b-3d9a-4d77-8df4-b45edb6c1736', 'CsitarA', '1234567', 'csitaria@kkszki.hu', '$2a$11$RFx2sxfNtYtHjxUopqreoeEb0M6fAUIKdHdrUqtKViSUigz1wT02K', 0),
('08dc498b-a49e-46cb-85f2-f9c85b96d2ed', 'asdfghj', '2345', 'sss@ss', '$2a$11$5FRxmqgAorH.k7dyLshKu.RrvpGu1ctQjB52fqO3.Zkxxuv9zwafa', 0);

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
  ADD CONSTRAINT `termek_ibfk_1` FOREIGN KEY (`KategoriaId`) REFERENCES `kategoriafajtak` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `termek_ibfk_2` FOREIGN KEY (`besorolasId`) REFERENCES `besorolas` (`Id`) ON DELETE CASCADE ON UPDATE CASCADE;

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
