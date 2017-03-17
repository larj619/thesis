-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generation Time: Jan 29, 2013 at 03:20 AM
-- Server version: 5.5.24-log
-- PHP Version: 5.4.3

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `thesis`
--

-- --------------------------------------------------------

--
-- Table structure for table `candidates`
--

CREATE TABLE IF NOT EXISTS `candidates` (
  `candidate_id` int(11) NOT NULL AUTO_INCREMENT,
  `names` text,
  `about` varchar(100) NOT NULL,
  `position` text,
  `party` varchar(50) DEFAULT NULL,
  `cand_pic` varchar(30) NOT NULL,
  `keyword` varchar(30) NOT NULL,
  PRIMARY KEY (`candidate_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=36 ;

--
-- Dumping data for table `candidates`
--

INSERT INTO `candidates` (`candidate_id`, `names`, `about`, `position`, `party`, `cand_pic`, `keyword`) VALUES
(15, 'President', 'about me', 'PRES', 'Gabay', 'images/candidates/p1.jpg', 'p1'),
(16, 'President', 'about me', 'PRES', 'Leaders', 'images/candidates/p2.jpg', 'p2'),
(17, 'President', 'about me', 'PRES', 'Third', 'images/candidates/p3.jpg', 'p3'),
(18, 'Vice President', 'about me', 'VP', 'Gabay', 'images/candidates/vp1.jpg', 'vp1'),
(19, 'Vice President', 'about me', 'VP', 'Leaders', 'images/candidates/vp2.jpg', 'vp2'),
(20, 'Vice President', 'about me', 'VP', 'Third', 'images/candidates/vp3.jpg', 'vp3'),
(21, 'Secretary', 'about me', 'SEC', 'Gabay', 'images/candidates/sec1.jpg', 'sec1'),
(22, 'Secretary', 'about me', 'SEC', 'Leaders', 'images/candidates/sec2.jpg', 'sec2'),
(23, 'Secretary', 'about me', 'SEC', 'Third', 'images/candidates/sec3.jpg', 'sec3'),
(24, 'Treasurer', 'about me', 'TREAS', 'Gabay', 'images/candidates/treas1.jpg', 'tre1'),
(25, 'Treasurer', 'about me', 'TREAS', 'Leaders', 'images/candidates/treas2.jpg', 'tre2'),
(26, 'Treasurer', 'about me', 'TREAS', 'Third', 'images/candidates/treas3.jpg', 'tre3'),
(27, 'Auditor', 'about me', 'AUD', 'Gabay', 'images/candidates/aud1.jpg', 'aud1'),
(28, 'Auditor', 'about me', 'AUD', 'Leaders', 'images/candidates/aud2.jpg', 'aud2'),
(29, 'Auditor', 'about me', 'AUD', 'Third', 'images/candidates/aud3.jpg', 'aud3'),
(30, 'Business Manager', 'about me', 'BUSMan', 'Gabay', 'images/candidates/bm1.jpg', 'bus1'),
(31, 'Business Manager', 'about me', 'BUSMan', 'Leaders', 'images/candidates/bm2.jpg', 'bus2'),
(32, 'Business Manager', 'about me', 'BUSMan', 'Third', 'images/candidates/bm3.jpg', 'bus3'),
(33, 'Public Relations Officer', 'about me', 'PRO', 'Gabay', 'images/candidates/pro1.jpg', 'pro1'),
(34, 'Public Relations Officer', 'about me', 'PRO', 'Leaders', 'images/candidates/pro2.jpg', 'pro2'),
(35, 'Public Relations Officer', 'about me', 'PRO', 'Third', 'images/candidates/pro3.jpg', 'pro3');

-- --------------------------------------------------------

--
-- Table structure for table `partylist`
--

CREATE TABLE IF NOT EXISTS `partylist` (
  `Gabay` varchar(30) DEFAULT NULL,
  `Leaders` varchar(30) DEFAULT NULL,
  `Third` varchar(50) NOT NULL,
  `refnum` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `partylist`
--

INSERT INTO `partylist` (`Gabay`, `Leaders`, `Third`, `refnum`) VALUES
('Partylist1', 'Partylist2', 'Partylist3', '1');

-- --------------------------------------------------------

--
-- Table structure for table `sy`
--

CREATE TABLE IF NOT EXISTS `sy` (
  `ref` varchar(30) NOT NULL,
  `syear` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `sy`
--

INSERT INTO `sy` (`ref`, `syear`) VALUES
('1', '0000 - 0000');

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL AUTO_INCREMENT,
  `stud_no` int(11) NOT NULL,
  `fname` text NOT NULL,
  `lname` text NOT NULL,
  `college` text NOT NULL,
  `user` text,
  `pass` text,
  `admin` bit(1) DEFAULT NULL,
  `status` varchar(20) DEFAULT 'NOT VOTED',
  PRIMARY KEY (`user_id`),
  UNIQUE KEY `stud_no` (`stud_no`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=19 ;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`user_id`, `stud_no`, `fname`, `lname`, `college`, `user`, `pass`, `admin`, `status`) VALUES
(1, 0, '', '', '', 'admin', '12345', b'1', 'NOT VOTED'),
(5, 563098, 'danyel', 'roque', '', 'gracia', '102588', b'0', 'NOT VOTED'),
(12, 2009300090, 'Maria', 'Belga', 'CED', 'crazyrabbit', '0604hjw', NULL, 'NOT VOTED'),
(13, 2009300520, 'Chato', 'Serrano', 'SLCN', 'purplecha', 'mikomiko', NULL, 'NOT VOTED'),
(14, 2009300714, 'Dyan Patricia', 'Roque', 'CHTM', 'yani07', 'ilovejm', NULL, 'NOT VOTED'),
(15, 2009300978, 'Larry John', 'Pansalin', 'CCIS', 'lilo', 'stitch', NULL, 'NOT VOTED'),
(16, 200947374, 'Arjel', 'Ponce', 'CMT', 'natgeo', 'brown', NULL, 'NOT VOTED'),
(17, 2009300050, 'Bernie', 'Manansala', 'CAS', 'voter', '123456', NULL, 'NOT VOTED'),
(18, 2009300977, 'Cecilia', 'Dela Cruz', 'CAS', 'secret', 'secret', NULL, 'NOT VOTED');

-- --------------------------------------------------------

--
-- Table structure for table `votetable`
--

CREATE TABLE IF NOT EXISTS `votetable` (
  `username` varchar(50) NOT NULL,
  `votetime` varchar(30) DEFAULT NULL,
  `Pres` varchar(50) DEFAULT NULL,
  `VP` varchar(50) DEFAULT NULL,
  `SEC` varchar(50) DEFAULT NULL,
  `TREAS` varchar(50) DEFAULT NULL,
  `AUD` varchar(50) DEFAULT NULL,
  `BUSman` varchar(50) DEFAULT NULL,
  `PRO` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`username`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `votevaulttable`
--

CREATE TABLE IF NOT EXISTS `votevaulttable` (
  `StudentNumb` varchar(50) NOT NULL,
  `CandidatesKeyWord` varchar(50) NOT NULL,
  `VoteNo` decimal(11,0) NOT NULL,
  `Date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `votevaulttable`
--

INSERT INTO `votevaulttable` (`StudentNumb`, `CandidatesKeyWord`, `VoteNo`, `Date`) VALUES
('2009444576', 'p1', '1', '2013-01-27 15:58:57'),
('2009444576', 'vp1', '2', '2013-01-27 15:58:57'),
('2009444576', 'sec1', '3', '2013-01-27 15:58:57'),
('2009444576', 'tre1', '4', '2013-01-27 15:58:57'),
('2009444576', 'aud1', '5', '2013-01-27 15:58:58'),
('2009444576', 'bus1', '6', '2013-01-27 15:58:58'),
('2009444576', 'pro1', '7', '2013-01-27 15:58:58');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
