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
	<div id="menubar">
	  <div id="welcome">
	    <h1><a href="#">Admin Page</a></h1>
	  </div><!--close welcome-->
      <div id="menu_items">
	    <ul id="menu">
          <li><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
          <li><a href="setcandidate.php">Manage Candidates</a></li>
		<div id="menu_items">
	    <ul id="menu">
          <li class="current"><a href="view-records.php">Manage Users</a></li>
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
<center>

<?php
$deluser_id=$_POST['deluser_id'];
include ("connect.php");

$sql="SELECT * FROM user where user_id='$deluser_id'";
$result=mysql_query($sql);
$count=mysql_num_rows($result);

$row = mysql_fetch_array($result);
if (!$row) { echo "<font color=white>Record with user_id " . $deluser_id . " does not exist.</br></br>"; } //no record of deluserid
	else { //echos profile info
	echo "<table>";
	echo "<tr> <td align=center><font color= white>" . $row['user_id'] . "</td> <td align=center><font color=ff0000>" . $row['fname'] . "</td> <td align=center><font color=ff0000>" . $row['lname'] . "</td> <td align=center><font color=ff0000>" . $row['user'] . "</td> <td align=center><font color=ff0000>" . $row['pass'] . "</td><td align=center><font color=ff0000>" . $row['admin'] . "</td></tr>";

	echo "</table>";

	if ($row['admin']==1)
		{
		echo "Admin account cannot be deleted! </br> </br>";
		}
		else
		{
		$sql="DELETE FROM user WHERE user_id='$deluser_id'";
		mysql_query($sql);

		$sql="SELECT * FROM user where user_id='$deluser_id'";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);

		$row = mysql_fetch_array($result);
		if (!$row) { echo "<font color= white>Deletion Successful! </br>"; }
		else { echo "Deletion failed. Record with userid number '$deluser_id' still exists."; }
		}
	} //end echo profile info
?>
<form action="admin.php" ><input type=submit value="Back to admin control panel"></form>

</center>
</div>

<div id="content_green">
<div class="content_green_container_box">
<div id="">
		
	    <ul id="menu">
          <li><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
          <li><a href="setcandidate.php">Manage Candidates</a></li>
          <li class="current"><a href="view-records.php">Manage Users</a></li>
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
  
</body>
</html>