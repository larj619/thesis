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
          <li><a href="admin.php">Admin</a></li>
          <li class="current"><a href="setschool_year.php">Manage School Year</a></li>
          <li><a href="setcandidate.php">Manage Candidates</a></li>
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

<center>

<form style=" width: 250px;
    padding: 20px;
    border: 1px solid #270644;
     
    /*** Adding in CSS3 ***/
 
    /*** Rounded Corners ***/
    -moz-border-radius: 20px;
    -webkit-border-radius: 20px;
 
    /*** Background Gradient - 2 declarations one for Firefox and one for Webkit 
    background:  -moz-linear-gradient(19% 75% 90deg,#4E0085, #963AD6);
    background:-webkit-gradient(linear, 0% 0%, 0% 100%, from(#963AD6), to(#4E0085)); ***/
 
    /*** Shadow behind the box ***/
    -moz-box-shadow:0px -5px 300px #270644;
    -webkit-box-shadow:0px -5px 300px #270644;" action=dbschool_year.php method=POST>



<?php
 include("school_year.php");
 
echo "

<h1>School Year</h1>
<input type=text name='syr' value='".$syr." ' >

";
?>

<input type=submit>

</form>
</br>
<form action=admin.php><input type=submit value='Back to admin switchboard'></form>
	
</center>
</div><!--close main-->

<div id="content_green">
<div class="content_green_container_box">
<div id="">
		
	    <ul id="menu">
          <li><a href="admin.php">Admin</a></li>
          <li class="current"><a href="setschool_year.php">Manage School Year</a></li>
          <li><a href="setcandidate.php">Manage Candidates</a></li>
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
</body>
</html>