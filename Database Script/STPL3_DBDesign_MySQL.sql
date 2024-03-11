CREATE DATABASE stpl3;

USE stpl3;

CREATE TABLE `tb_device` (
  `id` int NOT NULL AUTO_INCREMENT,
  `device_id` varchar(20) NOT NULL,
  `device_type` varchar(45) DEFAULT NULL,
  `device_name` varchar(45) DEFAULT NULL,
  `group_id` varchar(45) DEFAULT NULL,
  `modifiedby` varchar(45) DEFAULT NULL,
  `modifiedon` datetime DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tb_recordtransaction` (
  `trans_id` int NOT NULL AUTO_INCREMENT,
  `requestor_ip` varchar(20) DEFAULT NULL,
  `deviceid` INT NOT NULL,
  `created_datetime` datetime DEFAULT NULL,
  `request_timestramp` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`trans_id`),  
  KEY `deviceid` (`deviceid`),
  CONSTRAINT `tb_recordtrans_ibfk_1` FOREIGN KEY (`deviceid`) REFERENCES `tb_device` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `tb_recorddata` (
  `data_type` varchar(20) NOT NULL,
  `recordtrans_id` int NOT NULL,
  `IsfullPowerMode` bit(1) DEFAULT NULL,
  `IsactivePowerControl` bit(1) DEFAULT NULL,
  `firmware_Version` int DEFAULT NULL,
  `temperature` int DEFAULT NULL,
  `humidity` int DEFAULT NULL,
  `version` int DEFAULT NULL,
  `message_type` varchar(45) DEFAULT NULL,
  `occupancy` bit(1) DEFAULT NULL,
  `state_changed` int DEFAULT NULL,
  KEY `recordtrans_id` (`recordtrans_id`),
  CONSTRAINT `tb_recorddata_ibfk_1` FOREIGN KEY (`recordtrans_id`) REFERENCES `tb_recordtransaction` (`trans_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

