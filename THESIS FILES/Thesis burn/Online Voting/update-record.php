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
include ("connect.php");

$sql="SELECT * FROM user where user_id='$user_id'";
$result=mysql_query($sql);



echo "<form action=dbupdate.php method=POST><table border=1>";

while($row = mysql_fetch_array($result))
{ //echos profile info
echo "<tr><td align=right><font color=white>New First Name: <input type=text name=newfname value=" . $row['fname'] . "></td></tr>
<tr><td align=right><font color=white>New Last Name: <input type=text name=newlname value=" . $row['lname'] . "></td></tr>
<tr><td align=right><font color=white>New username: <input type=text name=newusername value=" . $row['user'] . "></td></tr>
<tr><td align=right><font color=white>New password: <input type=text name=newpassword value=" . $row['pass'] . "></td></tr>
<tr><td align=center><font color=white><form action=dbupdate.php method=POST><input type='submit' value='Update'><input type=hidden name=user_id value=" . $user_id . "</form></td></tr>";
} //end echo profile info
echo "</table></form>";
?>
</br>
<form action=view-records.php><input type=submit value='Back to View Records'></form>
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