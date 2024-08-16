CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    ALTER DATABASE CHARACTER SET utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetRoles` (
        `Id` varchar(255) CHARACTER SET utf8 NOT NULL,
        `Discriminator` longtext CHARACTER SET utf8 NOT NULL,
        `Name` varchar(256) CHARACTER SET utf8 NULL,
        `NormalizedName` varchar(256) CHARACTER SET utf8 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8 NULL,
        CONSTRAINT `PK_AspNetRoles` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetUsers` (
        `Id` varchar(255) CHARACTER SET utf8 NOT NULL,
        `Discriminator` longtext CHARACTER SET utf8 NOT NULL,
        `Password` longtext CHARACTER SET utf8 NULL,
        `UserName` varchar(256) CHARACTER SET utf8 NULL,
        `NormalizedUserName` varchar(256) CHARACTER SET utf8 NULL,
        `Email` varchar(256) CHARACTER SET utf8 NULL,
        `NormalizedEmail` varchar(256) CHARACTER SET utf8 NULL,
        `EmailConfirmed` tinyint(1) NOT NULL,
        `PasswordHash` longtext CHARACTER SET utf8 NULL,
        `SecurityStamp` longtext CHARACTER SET utf8 NULL,
        `ConcurrencyStamp` longtext CHARACTER SET utf8 NULL,
        `PhoneNumber` longtext CHARACTER SET utf8 NULL,
        `PhoneNumberConfirmed` tinyint(1) NOT NULL,
        `TwoFactorEnabled` tinyint(1) NOT NULL,
        `LockoutEnd` datetime(6) NULL,
        `LockoutEnabled` tinyint(1) NOT NULL,
        `AccessFailedCount` int NOT NULL,
        CONSTRAINT `PK_AspNetUsers` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `BlogsTag` (
        `BlogsTagId` int NOT NULL AUTO_INCREMENT,
        `BlogsTagName` varchar(50) CHARACTER SET utf8 NOT NULL,
        CONSTRAINT `PK_BlogsTag` PRIMARY KEY (`BlogsTagId`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `Categories` (
        `CategoryId` int NOT NULL AUTO_INCREMENT,
        `CategoryName` varchar(50) CHARACTER SET utf8 NOT NULL,
        `CategoryDescription` varchar(200) CHARACTER SET utf8 NULL,
        `ProductId` int NOT NULL,
        CONSTRAINT `PK_Categories` PRIMARY KEY (`CategoryId`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `Image` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NULL,
        `ImageUrl` longtext CHARACTER SET utf8 NULL,
        `EntityType` int NOT NULL,
        CONSTRAINT `PK_Image` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `Information` (
        `InfoId` int NOT NULL AUTO_INCREMENT,
        `HeaderTitle` varchar(100) CHARACTER SET utf8 NULL,
        `HeaderDescription` varchar(2500) CHARACTER SET utf8 NULL,
        `InfoTitle` varchar(100) CHARACTER SET utf8 NULL,
        `InfoBody` varchar(2500) CHARACTER SET utf8 NULL,
        `InfoMapsUrl` varchar(250) CHARACTER SET utf8 NULL,
        CONSTRAINT `PK_Information` PRIMARY KEY (`InfoId`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetRoleClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `RoleId` varchar(255) CHARACTER SET utf8 NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8 NULL,
        `ClaimValue` longtext CHARACTER SET utf8 NULL,
        CONSTRAINT `PK_AspNetRoleClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetRoleClaims_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetUserClaims` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `UserId` varchar(255) CHARACTER SET utf8 NOT NULL,
        `ClaimType` longtext CHARACTER SET utf8 NULL,
        `ClaimValue` longtext CHARACTER SET utf8 NULL,
        CONSTRAINT `PK_AspNetUserClaims` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_AspNetUserClaims_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetUserLogins` (
        `LoginProvider` varchar(255) CHARACTER SET utf8 NOT NULL,
        `ProviderKey` varchar(255) CHARACTER SET utf8 NOT NULL,
        `ProviderDisplayName` longtext CHARACTER SET utf8 NULL,
        `UserId` varchar(255) CHARACTER SET utf8 NOT NULL,
        CONSTRAINT `PK_AspNetUserLogins` PRIMARY KEY (`LoginProvider`, `ProviderKey`),
        CONSTRAINT `FK_AspNetUserLogins_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetUserRoles` (
        `UserId` varchar(255) CHARACTER SET utf8 NOT NULL,
        `RoleId` varchar(255) CHARACTER SET utf8 NOT NULL,
        CONSTRAINT `PK_AspNetUserRoles` PRIMARY KEY (`UserId`, `RoleId`),
        CONSTRAINT `FK_AspNetUserRoles_AspNetRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `AspNetRoles` (`Id`) ON DELETE CASCADE,
        CONSTRAINT `FK_AspNetUserRoles_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `AspNetUserTokens` (
        `UserId` varchar(255) CHARACTER SET utf8 NOT NULL,
        `LoginProvider` varchar(255) CHARACTER SET utf8 NOT NULL,
        `Name` varchar(255) CHARACTER SET utf8 NOT NULL,
        `Value` longtext CHARACTER SET utf8 NULL,
        CONSTRAINT `PK_AspNetUserTokens` PRIMARY KEY (`UserId`, `LoginProvider`, `Name`),
        CONSTRAINT `FK_AspNetUserTokens_AspNetUsers_UserId` FOREIGN KEY (`UserId`) REFERENCES `AspNetUsers` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `Products` (
        `ProductId` int NOT NULL AUTO_INCREMENT,
        `Title` varchar(150) CHARACTER SET utf8 NOT NULL,
        `Description` longtext CHARACTER SET utf8 NULL,
        `CategoryId` int NULL,
        `Price` double NULL,
        `IsStock` tinyint(1) NOT NULL,
        `Date_Of_Adjustment` datetime(6) NOT NULL,
        CONSTRAINT `PK_Products` PRIMARY KEY (`ProductId`),
        CONSTRAINT `FK_Products_Categories_CategoryId` FOREIGN KEY (`CategoryId`) REFERENCES `Categories` (`CategoryId`)
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `Blog` (
        `BlogId` int NOT NULL AUTO_INCREMENT,
        `BlogTitle` varchar(100) CHARACTER SET utf8 NULL,
        `BlogAltTitle` varchar(1000) CHARACTER SET utf8 NULL,
        `BlogDescription` longtext CHARACTER SET utf8 NULL,
        `BlogsTagId` int NULL,
        `Date_Time` datetime(6) NOT NULL,
        `ImageId` int NOT NULL,
        CONSTRAINT `PK_Blog` PRIMARY KEY (`BlogId`),
        CONSTRAINT `FK_Blog_BlogsTag_BlogsTagId` FOREIGN KEY (`BlogsTagId`) REFERENCES `BlogsTag` (`BlogsTagId`),
        CONSTRAINT `FK_Blog_Image_ImageId` FOREIGN KEY (`ImageId`) REFERENCES `Image` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `CarouselMain` (
        `CarouselMainId` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NULL,
        `Description` longtext CHARACTER SET utf8 NULL,
        `BtnTitle` longtext CHARACTER SET utf8 NULL,
        `BtnUrl` longtext CHARACTER SET utf8 NULL,
        `ImageId` int NOT NULL,
        CONSTRAINT `PK_CarouselMain` PRIMARY KEY (`CarouselMainId`),
        CONSTRAINT `FK_CarouselMain_Image_ImageId` FOREIGN KEY (`ImageId`) REFERENCES `Image` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `ContainerMarketing` (
        `ContainerMarketingId` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NULL,
        `Description` longtext CHARACTER SET utf8 NULL,
        `ImageId` int NOT NULL,
        CONSTRAINT `PK_ContainerMarketing` PRIMARY KEY (`ContainerMarketingId`),
        CONSTRAINT `FK_ContainerMarketing_Image_ImageId` FOREIGN KEY (`ImageId`) REFERENCES `Image` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `FeaturetteMain` (
        `FeaturetteMainId` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NULL,
        `Description` longtext CHARACTER SET utf8 NULL,
        `ImageId` int NOT NULL,
        CONSTRAINT `PK_FeaturetteMain` PRIMARY KEY (`FeaturetteMainId`),
        CONSTRAINT `FK_FeaturetteMain_Image_ImageId` FOREIGN KEY (`ImageId`) REFERENCES `Image` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `SocialMedia` (
        `SocialMediaId` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NOT NULL,
        `Link` longtext CHARACTER SET utf8 NOT NULL,
        `ImageId` int NOT NULL,
        CONSTRAINT `PK_SocialMedia` PRIMARY KEY (`SocialMediaId`),
        CONSTRAINT `FK_SocialMedia_Image_ImageId` FOREIGN KEY (`ImageId`) REFERENCES `Image` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE TABLE `ProductImage` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8 NULL,
        `ImageUrl` longtext CHARACTER SET utf8 NULL,
        `ProductId` int NOT NULL,
        CONSTRAINT `PK_ProductImage` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_ProductImage_Products_ProductId` FOREIGN KEY (`ProductId`) REFERENCES `Products` (`ProductId`) ON DELETE CASCADE
    ) CHARACTER SET=utf8;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_AspNetRoleClaims_RoleId` ON `AspNetRoleClaims` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE UNIQUE INDEX `RoleNameIndex` ON `AspNetRoles` (`NormalizedName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_AspNetUserClaims_UserId` ON `AspNetUserClaims` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_AspNetUserLogins_UserId` ON `AspNetUserLogins` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_AspNetUserRoles_RoleId` ON `AspNetUserRoles` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `EmailIndex` ON `AspNetUsers` (`NormalizedEmail`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE UNIQUE INDEX `UserNameIndex` ON `AspNetUsers` (`NormalizedUserName`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_Blog_BlogsTagId` ON `Blog` (`BlogsTagId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_Blog_ImageId` ON `Blog` (`ImageId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_CarouselMain_ImageId` ON `CarouselMain` (`ImageId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_ContainerMarketing_ImageId` ON `ContainerMarketing` (`ImageId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_FeaturetteMain_ImageId` ON `FeaturetteMain` (`ImageId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_ProductImage_ProductId` ON `ProductImage` (`ProductId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_Products_CategoryId` ON `Products` (`CategoryId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    CREATE INDEX `IX_SocialMedia_ImageId` ON `SocialMedia` (`ImageId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240804185031_deneme23') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240804185031_deneme23', '7.0.20');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetRoleClaims`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetUserClaims`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetUserLogins`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetUserRoles`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetUserTokens`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetRoles`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    DROP TABLE `AspNetUsers`;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20240809204404_exceptidentity') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20240809204404_exceptidentity', '7.0.20');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

