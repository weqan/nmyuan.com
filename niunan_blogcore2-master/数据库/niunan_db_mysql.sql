/*
SQLyog Enterprise Trial - MySQL GUI v7.11 
MySQL - 5.5.53 : Database - niunan
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;

CREATE DATABASE /*!32312 IF NOT EXISTS*/`niunan` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `niunan`;

/*Table structure for table `account` */

DROP TABLE IF EXISTS `account`;

CREATE TABLE `account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `accname` varchar(64) DEFAULT NULL,
  `balance` decimal(10,2) NOT NULL DEFAULT '0.00',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `password` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `blog` */

DROP TABLE IF EXISTS `blog`;

CREATE TABLE `blog` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `title` varchar(128) DEFAULT NULL,
  `body` text,
  `body_md` text,
  `visitnum` int(11) NOT NULL,
  `cabh` varchar(64) DEFAULT NULL,
  `caname` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  `sort` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=1204 DEFAULT CHARSET=utf8;

/*Table structure for table `casevideo` */

DROP TABLE IF EXISTS `casevideo`;

CREATE TABLE `casevideo` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `img` text,
  `url` text,
  `body` text,
  `title` text,
  `showdefault` int(11) DEFAULT '0',
  `visitnum` int(11) NOT NULL DEFAULT '0',
  `price` double NOT NULL DEFAULT '0',
  `keyword` text,
  `descn` text,
  `remark` text,
  `xsnum` int(11) NOT NULL DEFAULT '0',
  `sort` double DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `caname` varchar(64) DEFAULT NULL,
  `bh` varchar(64) DEFAULT NULL,
  `pbh` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=55 DEFAULT CHARSET=utf8;

/*Table structure for table `income` */

DROP TABLE IF EXISTS `income`;

CREATE TABLE `income` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `iDate` datetime NOT NULL,
  `iDesc` varchar(1024) DEFAULT NULL,
  `iMoney` decimal(10,2) DEFAULT '0.00',
  `accid` int(11) NOT NULL DEFAULT '0',
  `caid` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `log` */

DROP TABLE IF EXISTS `log`;

CREATE TABLE `log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `type` int(11) NOT NULL,
  `userid` int(11) NOT NULL,
  `username` varchar(64) DEFAULT NULL,
  `remark` varchar(2048) DEFAULT NULL,
  `ip` varchar(1024) DEFAULT NULL,
  `ipaddress` varchar(512) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=6929 DEFAULT CHARSET=utf8;

/*Table structure for table `outlay` */

DROP TABLE IF EXISTS `outlay`;

CREATE TABLE `outlay` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `oDate` datetime NOT NULL,
  `oDesc` varchar(1024) DEFAULT NULL,
  `oMoney` decimal(10,2) DEFAULT '0.00',
  `accid` int(11) NOT NULL DEFAULT '0',
  `caid` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Table structure for table `shuqian` */

DROP TABLE IF EXISTS `shuqian`;

CREATE TABLE `shuqian` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `createdate` datetime NOT NULL,
  `title` varchar(256) DEFAULT NULL,
  `url` varchar(1024) DEFAULT NULL,
  `tag` varchar(128) DEFAULT NULL,
  `isprivate` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=192 DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
