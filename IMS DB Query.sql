-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.6.10-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema ims
--

CREATE DATABASE IF NOT EXISTS ims;
USE ims;

--
-- Definition of table `company`
--

DROP TABLE IF EXISTS `company`;
CREATE TABLE `company` (
  `cpyname` varchar(45) NOT NULL,
  `spocfname` varchar(45) NOT NULL,
  `spoclname` varchar(45) NOT NULL,
  `position` varchar(45) NOT NULL,
  `number` varchar(10) NOT NULL,
  `email` varchar(45) NOT NULL,
  `fax` varchar(10) NOT NULL,
  `city` varchar(45) NOT NULL,
  `country` varchar(45) NOT NULL,
  `zipcode` int(10) unsigned NOT NULL,
  `address` longtext NOT NULL,
  `jobsavail` int(10) unsigned NOT NULL,
  `jobresp` longtext NOT NULL,
  `jobreq` longtext NOT NULL,
  `jobdesc` longtext NOT NULL,
  `cmpid` int(10) unsigned NOT NULL,
  PRIMARY KEY (`cmpid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=FIXED;

--
-- Dumping data for table `company`
--

/*!40000 ALTER TABLE `company` DISABLE KEYS */;
/*!40000 ALTER TABLE `company` ENABLE KEYS */;


--
-- Definition of table `education`
--

DROP TABLE IF EXISTS `education`;
CREATE TABLE `education` (
  `semreg` varchar(45) NOT NULL,
  `studid` int(10) unsigned NOT NULL,
  `fname` varchar(45) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `mname` varchar(45) DEFAULT NULL,
  `email` varchar(50) NOT NULL,
  `number` varchar(10) NOT NULL,
  `status` varchar(25) DEFAULT NULL,
  `degree` longtext,
  `major` longtext,
  `gpa` varchar(45) DEFAULT NULL,
  `college` longtext,
  `place` longtext,
  `year` varchar(50) DEFAULT NULL,
  `compname` varchar(45) DEFAULT NULL,
  `fromdate` longtext,
  `todate` longtext,
  `desig` varchar(45) DEFAULT NULL,
  `duties` longtext,
  `semyr` int(10) unsigned NOT NULL,
  PRIMARY KEY (`studid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=FIXED;

--
-- Dumping data for table `education`
--

/*!40000 ALTER TABLE `education` DISABLE KEYS */;
/*!40000 ALTER TABLE `education` ENABLE KEYS */;


--
-- Definition of table `faculty`
--

DROP TABLE IF EXISTS `faculty`;
CREATE TABLE `faculty` (
  `fname` varchar(45) NOT NULL,
  `lname` varchar(45) NOT NULL,
  `number` varchar(10) NOT NULL,
  `desig` varchar(45) NOT NULL,
  `dept` varchar(45) NOT NULL,
  `extn` varchar(10) NOT NULL,
  `mobile` varchar(10) NOT NULL,
  `email` varchar(45) NOT NULL,
  `notes` longtext NOT NULL,
  `facid` int(10) unsigned NOT NULL,
  PRIMARY KEY (`facid`) USING BTREE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=FIXED;

--
-- Dumping data for table `faculty`
--

/*!40000 ALTER TABLE `faculty` DISABLE KEYS */;
/*!40000 ALTER TABLE `faculty` ENABLE KEYS */;


--
-- Definition of table `interest`
--

DROP TABLE IF EXISTS `interest`;
CREATE TABLE `interest` (
  `studid` int(10) unsigned NOT NULL,
  `fieldlist` longtext NOT NULL,
  `loclist` longtext NOT NULL,
  `comments` longtext NOT NULL,
  PRIMARY KEY (`studid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `interest`
--

/*!40000 ALTER TABLE `interest` DISABLE KEYS */;
/*!40000 ALTER TABLE `interest` ENABLE KEYS */;


--
-- Definition of table `internship`
--

DROP TABLE IF EXISTS `internship`;
CREATE TABLE `internship` (
  `studid` int(10) unsigned NOT NULL,
  `status` varchar(45) NOT NULL,
  `cname` varchar(45) NOT NULL,
  `mgrname` varchar(45) NOT NULL,
  `facname` varchar(45) DEFAULT NULL,
  `title` varchar(45) DEFAULT NULL,
  `size` int(10) unsigned DEFAULT NULL,
  `istatus` varchar(45) DEFAULT NULL,
  `pdesc` longtext,
  PRIMARY KEY (`studid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `internship`
--

/*!40000 ALTER TABLE `internship` DISABLE KEYS */;
/*!40000 ALTER TABLE `internship` ENABLE KEYS */;


--
-- Definition of table `skills`
--

DROP TABLE IF EXISTS `skills`;
CREATE TABLE `skills` (
  `studid` int(10) unsigned NOT NULL,
  `proglist` longtext NOT NULL,
  `cmslist` longtext NOT NULL,
  `oslist` longtext NOT NULL,
  `fieldlist` longtext NOT NULL,
  `langlist` longtext NOT NULL,
  PRIMARY KEY (`studid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=FIXED;

--
-- Dumping data for table `skills`
--

/*!40000 ALTER TABLE `skills` DISABLE KEYS */;
/*!40000 ALTER TABLE `skills` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
