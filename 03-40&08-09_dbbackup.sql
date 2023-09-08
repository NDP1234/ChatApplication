-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               8.1.0 - MySQL Community Server - GPL
-- Server OS:                    Win64
-- HeidiSQL Version:             12.5.0.6677
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Dumping database structure for chatbot
CREATE DATABASE IF NOT EXISTS `chatbot` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `chatbot`;

-- Dumping structure for table chatbot.inductionusers
CREATE TABLE IF NOT EXISTS `inductionusers` (
  `inductionuserid` int NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `email` varchar(255) NOT NULL,
  `IsDelete` tinyint(1) DEFAULT '0',
  `CreatorId` int DEFAULT NULL,
  `ModificationId` int DEFAULT NULL,
  `DeletorId` int DEFAULT NULL,
  `ModificationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `inductionuserGUID` binary(16) NOT NULL,
  PRIMARY KEY (`inductionuserGUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table chatbot.inductionusers: ~10 rows (approximately)
INSERT INTO `inductionusers` (`inductionuserid`, `first_name`, `last_name`, `phone_number`, `email`, `IsDelete`, `CreatorId`, `ModificationId`, `DeletorId`, `ModificationTime`, `CreationTime`, `inductionuserGUID`) VALUES
	(1, 'John', 'Doe', '+91-9876543210', 'john.doe@example.com', 0, 1, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f5ddd4e0411eebe56047c16d134cb),
	(2, 'Jane', 'Smith', '+91-9876543211', 'jane.smith@example.com', 0, 2, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f62214e0411eebe56047c16d134cb),
	(3, 'Amit', 'Kumar', '+91-9876543212', 'amit.kumar@example.com', 0, 3, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f62c94e0411eebe56047c16d134cb),
	(4, 'Sneha', 'Verma', '+91-9876543213', 'sneha.verma@example.com', 0, 4, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f633e4e0411eebe56047c16d134cb),
	(5, 'Rajesh', 'Sharma', '+91-9876543214', 'rajesh.sharma@example.com', 0, 5, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f63aa4e0411eebe56047c16d134cb),
	(6, 'Priya', 'Patel', '+91-9876543215', 'priya.patel@example.com', 0, 6, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f64124e0411eebe56047c16d134cb),
	(7, 'Naveen', 'Reddy', '+91-9876543216', 'naveen.reddy@example.com', 0, 7, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f647f4e0411eebe56047c16d134cb),
	(8, 'Anjali', 'Singh', '+91-9876543217', 'anjali.singh@example.com', 0, 8, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f64fb4e0411eebe56047c16d134cb),
	(9, 'Kiran', 'Mishra', '+91-9876543218', 'kiran.mishra@example.com', 0, 9, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f655f4e0411eebe56047c16d134cb),
	(10, 'Arun', 'Gupta', '+91-9876543219', 'arun.gupta@example.com', 0, 10, NULL, NULL, '2023-09-08 05:26:24', '2023-09-05 10:46:48', _binary 0x7b6f65c94e0411eebe56047c16d134cb);

-- Dumping structure for table chatbot.smsmsgtoinductionuser
CREATE TABLE IF NOT EXISTS `smsmsgtoinductionuser` (
  `Id` int NOT NULL,
  `InductionUserId` binary(16) DEFAULT NULL,
  `Sms` text NOT NULL,
  `IsDelete` tinyint(1) NOT NULL DEFAULT '0',
  `CreatorId` binary(16) NOT NULL,
  `ModificationId` binary(16) DEFAULT NULL,
  `DeletorId` binary(16) DEFAULT NULL,
  `ModificationTime` timestamp NULL DEFAULT NULL,
  `CreationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `inductionUserMsgGUID` binary(16) NOT NULL,
  PRIMARY KEY (`inductionUserMsgGUID`),
  KEY `FK1_CREATOR_INDUCTION` (`CreatorId`),
  KEY `FK2_MODIFICATION_INDUCTION` (`ModificationId`),
  KEY `FK3_DELETION_INDUCTION` (`DeletorId`),
  KEY `FK4_INDUCTION_USER` (`InductionUserId`),
  CONSTRAINT `FK1_CREATOR_INDUCTION` FOREIGN KEY (`CreatorId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK2_MODIFICATION_INDUCTION` FOREIGN KEY (`ModificationId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK3_DELETION_INDUCTION` FOREIGN KEY (`DeletorId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK4_INDUCTION_USER` FOREIGN KEY (`InductionUserId`) REFERENCES `inductionusers` (`inductionuserGUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table chatbot.smsmsgtoinductionuser: ~4 rows (approximately)
INSERT INTO `smsmsgtoinductionuser` (`Id`, `InductionUserId`, `Sms`, `IsDelete`, `CreatorId`, `ModificationId`, `DeletorId`, `ModificationTime`, `CreationTime`, `inductionUserMsgGUID`) VALUES
	(0, _binary 0x7b6f62214e0411eebe56047c16d134cb, 'Good Afternoon Smith', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-08 08:54:21', _binary 0x1fbf2bf17da3524a9f21f642d2254e9c),
	(2, _binary 0x7b6f5ddd4e0411eebe56047c16d134cb, 'Hi John', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 05:26:51', _binary 0xa4db0a254e0711eebe56047c16d134cb),
	(3, _binary 0x7b6f5ddd4e0411eebe56047c16d134cb, 'Hello', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 06:51:04', _binary 0xa4db0c8e4e0711eebe56047c16d134cb),
	(4, _binary 0x7b6f5ddd4e0411eebe56047c16d134cb, 'Good Afternoon!!', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 07:00:21', _binary 0xa4db0d274e0711eebe56047c16d134cb),
	(5, _binary 0x7b6f62214e0411eebe56047c16d134cb, 'Hi Smith', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 07:22:07', _binary 0xa4db0d944e0711eebe56047c16d134cb),
	(0, _binary 0x7b6f65c94e0411eebe56047c16d134cb, 'Hi Arun', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-08 10:06:32', _binary 0xaba958766dc9ba4d89757300158420e4);

-- Dumping structure for table chatbot.smsmsgtousers
CREATE TABLE IF NOT EXISTS `smsmsgtousers` (
  `Id` int NOT NULL,
  `UserId` binary(16) NOT NULL,
  `Sms` text NOT NULL,
  `IsDelete` tinyint(1) NOT NULL DEFAULT '0',
  `CreatorId` binary(16) NOT NULL,
  `ModificationId` binary(16) DEFAULT NULL,
  `DeletorId` binary(16) DEFAULT NULL,
  `ModificationTime` timestamp NULL DEFAULT NULL,
  `CreationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `usermsgGUID` binary(16) NOT NULL,
  PRIMARY KEY (`usermsgGUID`),
  KEY `FK1_CREATOR` (`CreatorId`),
  KEY `FK2_Modifier` (`ModificationId`),
  KEY `FK3_DELETOR` (`DeletorId`),
  KEY `FK4_USER_REF` (`UserId`),
  CONSTRAINT `FK1_CREATOR` FOREIGN KEY (`CreatorId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK2_Modifier` FOREIGN KEY (`ModificationId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK3_DELETOR` FOREIGN KEY (`DeletorId`) REFERENCES `users` (`userGUID`),
  CONSTRAINT `FK4_USER_REF` FOREIGN KEY (`UserId`) REFERENCES `users` (`userGUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table chatbot.smsmsgtousers: ~17 rows (approximately)
INSERT INTO `smsmsgtousers` (`Id`, `UserId`, `Sms`, `IsDelete`, `CreatorId`, `ModificationId`, `DeletorId`, `ModificationTime`, `CreationTime`, `usermsgGUID`) VALUES
	(0, _binary 0x948f617f4dfd11eebe56047c16d134cb, 'Good afternoon', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-08 10:05:55', _binary 0x1b99a8ed35d64d4cb52b4155b2e65a90),
	(0, _binary 0x948f64614dfd11eebe56047c16d134cb, 'hello', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-08 08:30:39', _binary 0x2cf59e004946df42bcf29a9f363a5a83),
	(1, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'Hi Amit', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 07:45:04', _binary 0x7442fad04e0611eebe56047c16d134cb),
	(2, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'hello', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 07:47:08', _binary 0x7442fe7b4e0611eebe56047c16d134cb),
	(3, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'How are you?', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 07:48:26', _binary 0x7442ff154e0611eebe56047c16d134cb),
	(4, _binary 0x948f60844dfd11eebe56047c16d134cb, 'xyz', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 07:49:53', _binary 0x7442ff834e0611eebe56047c16d134cb),
	(5, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'amit', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 08:11:33', _binary 0x7442ffeb4e0611eebe56047c16d134cb),
	(6, _binary 0x948f62f84dfd11eebe56047c16d134cb, 'Hi Pooja', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 08:15:16', _binary 0x7443004c4e0611eebe56047c16d134cb),
	(7, _binary 0x948f5c894dfd11eebe56047c16d134cb, 'I am Fine Rajesh, How are you?', 0, _binary 0x948f5fd64dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:08:35', _binary 0x744300b24e0611eebe56047c16d134cb),
	(8, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'I am also fine...', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:09:29', _binary 0x744301264e0611eebe56047c16d134cb),
	(9, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'Have a good day ahead.', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:10:59', _binary 0x744301864e0611eebe56047c16d134cb),
	(10, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'Bye', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:12:36', _binary 0x744301ec4e0611eebe56047c16d134cb),
	(11, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'I will meet you tommorow.', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:15:02', _binary 0x744302554e0611eebe56047c16d134cb),
	(12, _binary 0x948f60844dfd11eebe56047c16d134cb, 'How are you Sneha?', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:15:24', _binary 0x744302b74e0611eebe56047c16d134cb),
	(13, _binary 0x948f5c894dfd11eebe56047c16d134cb, 'OK', 0, _binary 0x948f5fd64dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:33:06', _binary 0x744303254e0611eebe56047c16d134cb),
	(14, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'ok sure', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 09:42:04', _binary 0x7443039a4e0611eebe56047c16d134cb),
	(15, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'Bye', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 10:18:42', _binary 0x744304004e0611eebe56047c16d134cb),
	(16, _binary 0x948f60844dfd11eebe56047c16d134cb, 'demo message', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 10:29:38', _binary 0x744304614e0611eebe56047c16d134cb),
	(17, _binary 0x948f617f4dfd11eebe56047c16d134cb, 'hi ankit', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-05 10:33:28', _binary 0x744304c54e0611eebe56047c16d134cb),
	(18, _binary 0x948f5fd64dfd11eebe56047c16d134cb, 'hello', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 04:29:10', _binary 0x744305284e0611eebe56047c16d134cb),
	(19, _binary 0x948f64614dfd11eebe56047c16d134cb, 'Hi Umang', 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, NULL, '2023-09-06 07:06:05', _binary 0x744305864e0611eebe56047c16d134cb);

-- Dumping structure for table chatbot.users
CREATE TABLE IF NOT EXISTS `users` (
  `userid` int NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `phone_number` varchar(20) NOT NULL,
  `email` varchar(255) NOT NULL,
  `username` varchar(50) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `IsActive` tinyint(1) DEFAULT '1',
  `IsDelete` tinyint(1) DEFAULT '0',
  `CreatorId` binary(16) NOT NULL,
  `ModificationId` binary(16) DEFAULT NULL,
  `DeletorId` binary(16) DEFAULT NULL,
  `ModificationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CreationTime` timestamp NULL DEFAULT CURRENT_TIMESTAMP,
  `DeletionTime` timestamp NULL DEFAULT NULL,
  `userGUID` binary(16) NOT NULL,
  PRIMARY KEY (`userGUID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Dumping data for table chatbot.users: ~10 rows (approximately)
INSERT INTO `users` (`userid`, `first_name`, `last_name`, `phone_number`, `email`, `username`, `password`, `IsActive`, `IsDelete`, `CreatorId`, `ModificationId`, `DeletorId`, `ModificationTime`, `CreationTime`, `DeletionTime`, `userGUID`) VALUES
	(1, 'Rajesh', 'Kumar', '1234567890', 'rajesh@example.com', 'rajesh123', 'password123', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:02', '2023-09-04 09:27:36', NULL, _binary 0x948f5c894dfd11eebe56047c16d134cb),
	(2, 'Amit', 'Sharma', '9876543210', 'amit@example.com', 'amit456', 'securepass', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:02', '2023-09-04 09:27:36', NULL, _binary 0x948f5fd64dfd11eebe56047c16d134cb),
	(3, 'Sneha', 'Patel', '8765432109', 'sneha@example.com', 'sneha789', 'mypassword', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:01', '2023-09-04 09:27:36', NULL, _binary 0x948f60844dfd11eebe56047c16d134cb),
	(4, 'Priya', 'Singh', '7654321098', 'priya@example.com', 'priya101', 'mypwd123', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:01', '2023-09-04 09:27:36', NULL, _binary 0x948f61064dfd11eebe56047c16d134cb),
	(5, 'Ankit', 'Verma', '6543210987', 'ankit@example.com', 'ankit2022', 'pass1234', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:01', '2023-09-04 09:27:36', NULL, _binary 0x948f617f4dfd11eebe56047c16d134cb),
	(6, 'Neha', 'Gupta', '5432109876', 'neha@example.com', 'neha567', 'mypwd5678', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:00', '2023-09-04 09:27:36', NULL, _binary 0x948f61f54dfd11eebe56047c16d134cb),
	(7, 'Suresh', 'Rajput', '4321098765', 'suresh@example.com', 'suresh22', 'pwd9876', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:00', '2023-09-04 09:27:36', NULL, _binary 0x948f62814dfd11eebe56047c16d134cb),
	(8, 'Pooja', 'Yadav', '3210987654', 'pooja@example.com', 'pooja2023', 'secure123', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:00', '2023-09-04 09:27:36', NULL, _binary 0x948f62f84dfd11eebe56047c16d134cb),
	(9, 'Arun', 'Mishra', '2109876543', 'arun@example.com', 'arun45', 'password456', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:00', '2023-09-04 09:27:36', NULL, _binary 0x948f636d4dfd11eebe56047c16d134cb),
	(10, 'Manish', 'Thakur', '1098765432', 'manish@example.com', 'manish007', 'pass4567', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:57:59', '2023-09-04 09:27:36', NULL, _binary 0x948f63e64dfd11eebe56047c16d134cb),
	(51, 'Umang', 'Vyas', '1234567890', 'umang@example.com', 'umang111', 'vyas111', 1, 0, _binary 0x948f5c894dfd11eebe56047c16d134cb, NULL, NULL, '2023-09-08 09:58:04', '2023-09-05 10:22:13', NULL, _binary 0x948f64614dfd11eebe56047c16d134cb);

-- Dumping structure for trigger chatbot.SetUserGUIDOnInsert
SET @OLDTMP_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';
DELIMITER //
CREATE TRIGGER `SetUserGUIDOnInsert` BEFORE INSERT ON `users` FOR EACH ROW BEGIN
  SET NEW.`userGUID` = UUID_TO_BIN(UUID());
END//
DELIMITER ;
SET SQL_MODE=@OLDTMP_SQL_MODE;

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
