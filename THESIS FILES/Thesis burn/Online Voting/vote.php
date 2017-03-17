<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">

<head>
<title>TUA-CSC Online Voting System</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=9" />
  <link rel="stylesheet" type="text/css" href="css/style.css" />
  
 
</head>

<body>
  <div id="main">
	

<div id="site_content">		
		<center>
      <div class="slideshow">  
		<ul class="slideshow">
          <li class="show"><img width="900" height="350" src="images/banner.jpg" /></li>
        </ul>  	
	  </div><!--close slideshow-->  	 

</br> </br> </br>
<?php
session_start();
if(!isset($_SESSION['user']) || !isset($_SESSION['pass']))
{
header("location:notloggedin.php");
die();
}



if(!isset($_POST['Pres']) || !isset($_POST['VP']) || !isset($_POST['SEC']) || !isset($_POST['TREAS']) || !isset($_POST['AUD']) || !isset($_POST['BUSMan']) || !isset($_POST['PRO']))
{
echo "<h1>All positions must be voted for!</h1>";
echo "<form action=index.php><input type=submit value='Please Sign In Again'></form> ";
die();
}



$presvote=$_POST['Pres'];
$VPvote=$_POST['VP'];
$SECvote=$_POST['SEC'];
$TREASvote=$_POST['TREAS'];
$AUDvote=$_POST['AUD'];
$BUSmanvote=$_POST['BUSMan'];
$PROvote=$_POST['PRO'];

$dbposition=array('Pres','VP','SEC','TREAS','AUD','BUSMan','PRO');

//session_start();
$user=$_SESSION['user'];
$stnum=$_SESSION['stnum'];
include ("connect.php");
mysql_query("UPDATE user SET status='VOTED' WHERE stud_no='$stnum'");
mysql_query("INSERT INTO votetable (username,votetime,Pres,VP,SEC,TREAS,AUD,BUSman,PRO) values ('$user',NOW(),'$presvote','$VPvote','$SECvote','$TREASvote','$AUDvote','$BUSmanvote','$PROvote')")or die("<h1>You have previously voted!</h1> </br> <form action=logout.php><input type=submit value='Logout'></form>");





echo "<h1>Thank you for voting!</h1> </br> <form action=logout.php><input type=submit value='Logout'></form>";



?>
</div>

  <div id="footer">
	  Copyright &copy; 2013. All Rights Reserved. <a href="http://validator.w3.org/check?uri=referer">Valid XHTML</a>
  </div><!--close footer-->  

