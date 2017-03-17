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


<!--<font color=#ffffff>-->
<center>

<?php
include ("connect.php");

$sql="SELECT * FROM user";
$result=mysql_query($sql);
$count=mysql_num_rows($result);

echo "<table border = 1 width = 900>
<tr>
<td align=center><font color=#ffffff>User ID</td>
<td align=center><font color=#ffffff>Student Number</td>
<td align=center><font color=#ffffff>First Name</td>
<td align=center><font color=#ffffff>Last Name</td>
<td align=center><font color=#ffffff>Username</td>
<td align=center><font color=#ffffff>Password</td>
<td align=center><font color=#ffffff>Update</td>
<td align=center><font color=#ffffff>Delete</td>
<td align=center><font color=#ffffff>Status</td>
</tr>";

while($row = mysql_fetch_array($result))
{ //echos profile info
echo "
<tr>
<td align=center><font color=#ffffff>" . $row['user_id'] . "</td>
<td align=center><font color=#ffffff>" . $row['stud_no'] . "</td>
<td align=center><font color=#ffffff>" . $row['fname'] . "</td>
<td align=center><font color=#ffffff>" . $row['lname'] . "</td>
<td align=center><font color=#ffffff>" . $row['user'] . "</td>
<td align=center><font color=#ffffff>" . $row['pass'] . "</td>
<td align=center><font color=#ffffff><form action=update-record.php method=POST><input type='submit' value='Update'><input type='hidden' name='user_id' value=" . $row['user_id'] . "></form></td>
<td align=center><font color=#ffffff><form action=dbdeleterecord.php method=POST><input type='submit' value='Delete'><input type='hidden' name='deluser_id' value=" . $row['user_id'] . "></form></td>
<td align=center><font color=#ffffff>".$row['status']."</td>
</tr>";
} //end echo profile info
echo "</table>";
?>

</br>
<font color=#ffffff>There are <?php echo $count ?> Records.
</br></br>
<form action=admin.php><input type=submit value='Back to admin switchboard'></form>

</center>
</font>

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