<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">

<head>
<title>TUA-CSC Online Voting System</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=9" />
  <link rel="stylesheet" type="text/css" href="css/style.css" />
  
 
</head>

<?php 
session_start();
if (!isset($_SESSION['user']) || !isset($_SESSION['pass']))
{
	header("location:notloggedin.php");
	die();
}
?>

<body>
  <div id="main">
	<div id="menubar">
	  <div id="welcome">
	    <h1><a href="#">Admin Page</a></h1>
	  </div><!--close welcome-->
      <div id="menu_items">
	    <ul id="menu">
          <li ><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
          <li class="current"><a href="setcandidate.php">Manage Candidates</a></li>
		<div id="menu_items">
	    <ul id="menu">
          <li><a href="view-records.php">Manage Users</a></li>
		  <li><a href="reset.php" onclick="return confirm('Are you sure you want to reset')" >Reset </a></li>
		  <li><a href="logout.php">Logout</a></li>
        </ul>
	 </div><!--close menu-->
    </div><!--close menubar-->	

<div id="site_content">		
		<center>
      <div class="slideshow">  
		<ul class="slideshow">
          <li class="show"><img width="900" height="350" src="images/banner.jpg" /></li>
        </ul>  	
	  </div><!--close slideshow-->  	 
</br></br></br>
</center>


<form action=dbcandidates.php method=POST>
<center>
<table border=1 style="width:900px; text-align:center;">


<?php
 include("partynames.php");
 
echo "
<tr>
<td><font color=ffffff>Party</td>
<td><input type=text name='part1' value='".$party1."' > </td>
<td><input type=text name='part2' value='".$party2."'> </td>
<td><input type=text name='part3' value='".$party3."'> </td>
</tr>

";
?>

<?php

include ("connect.php");

$displayposition=array('President','Vice President','Secretary','Treasurer','Auditor','Business Manager','Public Relations Officer');
$dbposition=array('Pres','VP','SEC','TREAS','AUD','BUSMan','PRO');

$c=0;
while ($c<7)
{

	$gname=mysql_query("SELECT * FROM candidates WHERE party='Gabay' AND position='".$dbposition[$c]."'");
	while($gn=mysql_fetch_array($gname))
	{
	$gnames=$gn['names'];
	}

	$lname=mysql_query("SELECT * FROM candidates WHERE party='Leaders' AND position='".$dbposition[$c]."'");
	while($ln=mysql_fetch_array($lname))
	{
	$lnames=$ln['names'];
	}
	
	$tname=mysql_query("SELECT * FROM candidates WHERE party='Third' AND position='".$dbposition[$c]."'");
	while($tn=mysql_fetch_array($tname))
	{
	$tnames=$tn['names'];
	}

echo "
<tr>
<td><font color=ffffff>".$displayposition[$c]."</td>
<td><input type=text name='gabay".$dbposition[$c]."' value='".$gnames."'></td>
<td><input type=text name='leaders".$dbposition[$c]."' value='".$lnames."'></td>
<td><input type=text name='third".$dbposition[$c]."' value='".$tnames."'></td>

</tr>
";

$c++; 
} 

?>
</center>
</table>
</br>

<td colspan=4><input type=submit></td>

</form>
<form action=about.php><input type=submit value='About the candidates'></form>

</br></br>

<form action=admin.php><input type=submit value='Back to admin switchboard'></form>


</center>
</div><!--close main-->

<div id="content_green">
<div class="content_green_container_box">
<div id="">
		
	    <ul id="menu">
          <li><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
          <li class="current"><a href="setcandidate.php">Manage Candidates</a></li>
          <li><a href="view-records.php">Manage Users</a></li>
		  <li><a href="reset.php" onclick="return confirm('Are you sure you want to reset')" >Reset </a></li>
		  <li><a href="logout.php">Logout</a></li>
        </ul>
		
	 </div><!--close menu-->
	 </div><!--close content_green_container_box-->
<br style="clear:both"/>
    </div><!--close content_green-->   
  
  <div id="footer">
	  Copyright &copy; 2013. All Rights Reserved. <a href="http://validator.w3.org/check?uri=referer">Valid XHTML</a>
  </div><!--close footer-->  

</center>
</body>
</html>