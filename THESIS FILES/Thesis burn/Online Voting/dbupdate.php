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


<?php
$user_id=$_POST['user_id'];
$fname=$_POST['newfname'];
$lname=$_POST['newlname'];
$user=$_POST['newusername'];
$pass=$_POST['newpassword'];

include ("connect.php");

$sql="UPDATE user SET fname='$fname', lname='$lname', user='$user', pass='$pass' where user_id='$user_id'";
mysql_query($sql, $con);
?>
<center>
<font color=ff0000>
<h2>
Record updated!
</h2>
<table border=1>
<tr><td align=center><font color=white>Your First Name is now <?php echo $fname; ?></font></td></tr>
<tr><td align=center><font color=white>Your Last Name is now <?php echo $lname; ?></font></td></tr>
<tr><td align=center><font color=white>Your Username is now <?php echo $user; ?></font></td></tr>
<tr><td align=center><font color=white>Your Password is now <?php echo $pass; ?></font></td></tr>
</table>
</font>
</br>
<form action=view-records.php ><input type=submit value="Back to View Records"></form>
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