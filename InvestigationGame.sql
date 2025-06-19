CREATE DATABASE IF NOT EXISTS Investigation_Game;

USE Investigation_Game;

CREATE TABLE IF NOT EXISTS Users (
    `ID` INT PRIMARY KEY AUTO_INCREMENT,
    `UserName` VARCHAR(10) UNIQUE NOT NULL CHECK (CHAR_LENGTH(`UserName`) >= 2 ),
    `Password` VARCHAR(15) NOT NULL
);

CREATE TABLE IF NOT EXISTS UserData (
    `ID` INT PRIMARY KEY AUTO_INCREMENT,
    `User_Id` INT,
    FOREIGN KEY (`User_Id`) REFERENCES `Users`(`ID`),
    `Level_Agent` INT,
    `Mount_Turns` INT,
    `Num_Mistake` INT,
    `Score` FLOAT,
    `Status` VARCHAR(10),
    `Timestamp` DATETIME DEFAULT NOW()
);