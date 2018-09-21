/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50715
Source Host           : localhost:3306
Source Database       : test

Target Server Type    : MYSQL
Target Server Version : 50715
File Encoding         : 65001

Date: 2016-11-07 14:32:40
*/
DROP DATABASE IF EXISTS rmyh;
CREATE DATABASE rmyh;
USE rmyh;
SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for alarmeventlog
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog`;
CREATE TABLE `alarmeventlog` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2165478 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog0
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog0`;
CREATE TABLE `alarmeventlog0` (
  `ID` varchar(255) NOT NULL,
  `strIndex` varchar(255) DEFAULT NULL,
  `strBeginDate` varchar(255) DEFAULT NULL,
  `strEndDate` varchar(255) DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  `strUniqueTime` varchar(255) DEFAULT NULL,
  `AppendInfo` varchar(255) DEFAULT NULL,
  `nLevel` varchar(255) DEFAULT NULL,
  `strSrcID` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm`;
CREATE TABLE `alarmeventlog_jkm` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=5932 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_all
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_all`;
CREATE TABLE `alarmeventlog_jkm_all` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `remark` varchar(1) DEFAULT NULL,
  `jkm_startEnd_ID` int(11) DEFAULT NULL,
  `jkm_ID` int(11) DEFAULT NULL,
  `intervaltime` datetime DEFAULT NULL,
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=460 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_all_falsealarm
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_all_falsealarm`;
CREATE TABLE `alarmeventlog_jkm_all_falsealarm` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `remark` varchar(1) DEFAULT '1',
  `jkm_all_ID` int(11) DEFAULT NULL,
  `jkm_ID` int(11) DEFAULT NULL,
  `intervaltime` datetime DEFAULT NULL,
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  `thisduration` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=62 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_all_result
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_all_result`;
CREATE TABLE `alarmeventlog_jkm_all_result` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `remark` varchar(1) DEFAULT NULL,
  `jkm_all_ID` int(11) DEFAULT NULL,
  `jkm_ID` int(11) DEFAULT NULL,
  `intervaltime` datetime DEFAULT NULL,
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  `thisduration` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=338 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_all_result_1
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_all_result_1`;
CREATE TABLE `alarmeventlog_jkm_all_result_1` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `duration` datetime DEFAULT NULL,
  `aresult_ID` int(11) DEFAULT NULL,
  `ajkm_ID` int(11) DEFAULT NULL,
  `bresult_ID` int(11) DEFAULT NULL,
  `bjkm_ID` int(11) DEFAULT NULL,
  `astrBeginDate` datetime DEFAULT NULL,
  `bstrEndDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=163 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_all_result_2
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_all_result_2`;
CREATE TABLE `alarmeventlog_jkm_all_result_2` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `duration` datetime DEFAULT NULL,
  `aresult_ID` int(11) DEFAULT NULL,
  `ajkm_ID` int(11) DEFAULT NULL,
  `bresult_ID` int(11) DEFAULT NULL,
  `bjkm_ID` int(11) DEFAULT NULL,
  `astrBeginDate` datetime DEFAULT NULL,
  `bstrEndDate` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=162 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_end
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_end`;
CREATE TABLE `alarmeventlog_jkm_end` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `jkm_ID` int(11) DEFAULT NULL,
  `remark` varchar(1) DEFAULT '1',
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  `thisEnd_nextStart` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=236 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for alarmeventlog_jkm_start
-- ----------------------------
DROP TABLE IF EXISTS `alarmeventlog_jkm_start`;
CREATE TABLE `alarmeventlog_jkm_start` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `jkm_ID` int(11) DEFAULT NULL,
  `remark` varchar(1) DEFAULT '0',
  `strBeginDate` datetime DEFAULT NULL,
  `strEndDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  `thisStart_preEnd` datetime DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=225 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for dataprocessing
-- ----------------------------
DROP TABLE IF EXISTS `dataprocessing`;
CREATE TABLE `dataprocessing` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mwt` varchar(255) DEFAULT NULL,
  `mawt` varchar(255) DEFAULT NULL,
  `awt` varchar(255) DEFAULT NULL,
  `aawt` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for doorlog
-- ----------------------------
DROP TABLE IF EXISTS `doorlog`;
CREATE TABLE `doorlog` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `inDate` datetime DEFAULT NULL,
  `outDate` datetime DEFAULT NULL,
  `strText` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for info
-- ----------------------------
DROP TABLE IF EXISTS `info`;
CREATE TABLE `info` (
  `rowAutoID` varchar(255) NOT NULL,
  `serialNumber` varchar(255) DEFAULT NULL,
  `personID` varchar(255) DEFAULT NULL,
  `name` varchar(255) DEFAULT NULL,
  `englishName` varchar(255) DEFAULT NULL,
  `sex` varchar(255) DEFAULT NULL,
  `birthday` varchar(255) DEFAULT NULL,
  `identityType` varchar(255) DEFAULT NULL,
  `identityID` varchar(255) DEFAULT NULL,
  `deptID` varchar(255) DEFAULT NULL,
  `deptName` varchar(255) DEFAULT NULL,
  `inID` varchar(255) DEFAULT NULL,
  `inName` varchar(255) DEFAULT NULL,
  `jobLevelID` varchar(255) DEFAULT NULL,
  `jobPositionID` varchar(255) DEFAULT NULL,
  `category` varchar(255) DEFAULT NULL,
  `educational` varchar(255) DEFAULT NULL,
  `nation` varchar(255) DEFAULT NULL,
  `place` varchar(255) DEFAULT NULL,
  `people` varchar(255) DEFAULT NULL,
  `specialty` varchar(255) DEFAULT NULL,
  `inaugurationDate` varchar(255) DEFAULT NULL,
  `leaveJobDate` varchar(255) DEFAULT NULL,
  `enableDate` varchar(255) DEFAULT NULL,
  `disableDate` varchar(255) DEFAULT NULL,
  `HealthStatus` varchar(255) DEFAULT NULL,
  `interest` varchar(255) DEFAULT NULL,
  `introducer` varchar(255) DEFAULT NULL,
  `salaryCategory` varchar(255) DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `phone` varchar(255) DEFAULT NULL,
  `zip` varchar(255) DEFAULT NULL,
  `registerAddress` varchar(255) DEFAULT NULL,
  `registerPhone` varchar(255) DEFAULT NULL,
  `registerZip` varchar(255) DEFAULT NULL,
  `school` varchar(255) DEFAULT NULL,
  `department` varchar(255) DEFAULT NULL,
  `urgentContact` varchar(255) DEFAULT NULL,
  `urgentPhone` varchar(255) DEFAULT NULL,
  `marriage` varchar(255) DEFAULT NULL,
  `spouse` varchar(255) DEFAULT NULL,
  `spousePhone` varchar(255) DEFAULT NULL,
  `modifyTime` varchar(255) DEFAULT NULL,
  `operator` varchar(255) DEFAULT NULL,
  `pinyin` varchar(255) DEFAULT NULL,
  `cardType` varchar(255) DEFAULT NULL,
  `cardTypeDesc` varchar(255) DEFAULT NULL,
  `subSystem` varchar(255) DEFAULT NULL,
  `useCategory` varchar(255) DEFAULT NULL,
  `useStatus` varchar(255) DEFAULT NULL,
  `groupID` varchar(255) DEFAULT NULL,
  `timeGroup` varchar(255) DEFAULT NULL,
  `cardNumber` varchar(255) DEFAULT NULL,
  `note` varchar(255) DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `password` varchar(255) DEFAULT NULL,
  `cardCategory` varchar(255) DEFAULT NULL,
  `reserve3` varchar(255) DEFAULT NULL,
  `reserve4` varchar(255) DEFAULT NULL,
  `reserveChar1` varchar(255) DEFAULT NULL,
  `reserveChar2` varchar(255) DEFAULT NULL,
  `reserveChar3` varchar(255) DEFAULT NULL,
  `reserveChar4` varchar(255) DEFAULT NULL,
  `reserveChar5` varchar(255) DEFAULT NULL,
  `reserveChar6` varchar(255) DEFAULT NULL,
  `userLevel` varchar(255) DEFAULT NULL,
  `userID` varchar(255) DEFAULT NULL,
  `superPassword` varchar(255) DEFAULT NULL,
  `reserveChar7` varchar(255) DEFAULT NULL,
  `reserveChar8` varchar(255) DEFAULT NULL,
  `cardStatus` varchar(255) DEFAULT NULL,
  `reserve1` varchar(255) DEFAULT NULL,
  `reserve2` varchar(255) DEFAULT NULL,
  `gradeName` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Procedure structure for procedure1
-- ----------------------------
DROP PROCEDURE IF EXISTS `procedure1`;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `procedure1`()
BEGIN

TRUNCATE TABLE alarmeventlog;
INSERT INTO alarmeventlog (
		strBeginDate,
		strEndDate,
		strText
	) SELECT DISTINCT
		strBeginDate,
		strEndDate,
		strText
	FROM
		alarmeventlog0
	WHERE
		strEndDate <> '';

TRUNCATE TABLE alarmeventlog_jkm;
INSERT INTO alarmeventlog_jkm (
	strBeginDate,
	strEndDate,
	strText
) SELECT 
	strBeginDate,
	strEndDate,
	strText
FROM
	alarmeventlog
WHERE
	strText LIKE '%金库大门%';


TRUNCATE TABLE alarmeventlog_jkm_start;
INSERT INTO alarmeventlog_jkm_start (
	thisStart_preEnd,
	jkm_ID,
	strBeginDate,
	strEndDate,
	strText
) SELECT 
	TIMEDIFF(
		a.strBeginDate,
		b.strEndDate
	) AS 'thisStart-preEnd',
	a.ID,
	a.strBeginDate,
	a.strEndDate,
	a.strText
FROM
	alarmeventlog_jkm a,
	alarmeventlog_jkm b
WHERE
	b.id = a.id - 1
AND TIMESTAMPDIFF(
	MINUTE,
	b.strEndDate,
	a.strBeginDate
) > 10;


TRUNCATE TABLE alarmeventlog_jkm_end;
INSERT INTO alarmeventlog_jkm_end (
	thisEnd_nextStart,
	jkm_ID,
	strBeginDate,
	strEndDate,
	strText
) SELECT
	TIMEDIFF(
		b.strBeginDate,
		a.strEndDate
	) AS 'tthisEnd_nextStart',
	a.ID,
	a.strBeginDate,
	a.strEndDate,
	a.strText
FROM
	alarmeventlog_jkm a,
	alarmeventlog_jkm b
WHERE
	b.id = a.id + 1
AND TIMESTAMPDIFF(
	MINUTE,
	a.strBeginDate,
	b.strEndDate
) > 10;


TRUNCATE TABLE alarmeventlog_jkm_all;
INSERT alarmeventlog_jkm_all (
	jkm_startEnd_ID,
	jkm_ID,
	remark,
	strBeginDate,
	strEndDate,
	strText,
	intervaltime
) SELECT
	*
FROM
	alarmeventlog_jkm_start
UNION
	SELECT
		*
	FROM
		alarmeventlog_jkm_end
	ORDER BY
		jkm_ID;


TRUNCATE TABLE alarmeventlog_jkm_all_falsealarm;
INSERT alarmeventlog_jkm_all_falsealarm (
	jkm_all_ID,
	remark,
	jkm_ID,
	intervaltime,
	strBeginDate,
	strEndDate,
	strText,
	thisduration
) SELECT
	a.ID,
	a.remark,
	a.jkm_ID,
	a.intervaltime,
	a.strBeginDate,
	a.strEndDate,
	a.strText,
	TIMEDIFF(
		a.strEndDate,
		a.strBeginDate
	)
FROM
	alarmeventlog_jkm_all a,
	alarmeventlog_jkm_all b
WHERE
	a.id + 1 = b.id
AND a.jkm_ID = b.jkm_ID;


TRUNCATE TABLE alarmeventlog_jkm_all_result;
INSERT alarmeventlog_jkm_all_result (
	jkm_all_ID,
	remark,
	jkm_ID,
	intervaltime,
	strBeginDate,
	strEndDate,
	strText,
	thisduration
) SELECT
	a.ID,
	a.remark,
	a.jkm_ID,
	a.intervaltime,
	a.strBeginDate,
	a.strEndDate,
	a.strText,
	TIMEDIFF(
		a.strEndDate,
		a.strBeginDate
	)
FROM
	alarmeventlog_jkm_all a
WHERE
	a.jkm_ID NOT IN (
		SELECT
			b.jkm_id
		FROM
			alarmeventlog_jkm_all_falsealarm b
	);


TRUNCATE TABLE alarmeventlog_jkm_all_result_1;
INSERT `alarmeventlog_jkm_all_result_1` (
	astrBeginDate,
	aresult_ID,
	ajkm_ID,
	bstrEndDate,
	bresult_ID,
	bjkm_ID
) SELECT
	a.strBeginDate,
	a.ID,
	a.jkm_ID,
	b.strEndDate,
	b.ID,
	b.jkm_ID
FROM
	alarmeventlog_jkm_all_result a,
	alarmeventlog_jkm_all_result b
WHERE
	a.remark = 0
AND b.id = a.id + 1;

update alarmeventlog_jkm_all_result_1 set duration=TIMEDIFF(bstrEndDate,astrBeginDate);

TRUNCATE TABLE alarmeventlog_jkm_all_result_2;
INSERT `alarmeventlog_jkm_all_result_2` (
	duration,
	astrBeginDate,
	aresult_ID,
	ajkm_ID,
	bstrEndDate,
	bresult_ID,
	bjkm_ID
) SELECT
	duration,
	astrBeginDate,
	aresult_ID,
	ajkm_ID,
	bstrEndDate,
	bresult_ID,
	bjkm_ID
FROM
	alarmeventlog_jkm_all_result_1
WHERE
	time(duration) > "00:01:00";

END
;;
DELIMITER ;
