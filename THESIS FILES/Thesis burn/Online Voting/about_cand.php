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


<center>

<?php
$displayposition=array('President','Vice President','Secretary','Treasurer','Auditor','Business Manager','Public Relations Officer');
$dbposition=array('Pres','VP','SEC','TREAS','AUD','BUSMan','PRO');
$c=0;

mysql_connect("localhost","root");
mysql_select_db("thesis");
include("partynames.php");
include("connect.php");

while ($c<7)
{

$_POST['leaders'.$dbposition[$c]]=strip_tags($_POST['leaders'.$dbposition[$c]]);
$_POST['leaders'.$dbposition[$c]]=stripslashes($_POST['leaders'.$dbposition[$c]]);
$_POST['leaders'.$dbposition[$c]]=mysql_real_escape_string($_POST['leaders'.$dbposition[$c]]);
$_POST['gabay'.$dbposition[$c]]=strip_tags($_POST['gabay'.$dbposition[$c]]);
$_POST['gabay'.$dbposition[$c]]=stripslashes($_POST['gabay'.$dbposition[$c]]);
$_POST['gabay'.$dbposition[$c]]=mysql_real_escape_string($_POST['gabay'.$dbposition[$c]]);
$_POST['third'.$dbposition[$c]]=strip_tags($_POST['third'.$dbposition[$c]]);
$_POST['third'.$dbposition[$c]]=stripslashes($_POST['third'.$dbposition[$c]]);
$_POST['third'.$dbposition[$c]]=mysql_real_escape_string($_POST['third'.$dbposition[$c]]);

if (!isset($_POST['leaders'.$dbposition[$c]]) || !isset($_POST['gabay'.$dbposition[$c]]) || !isset($_POST['third'.$dbposition[$c]]) ) { echo $displayposition[$c]." name not set!<br/>"; }
else {
$leadersabout=$_POST['leaders'.$dbposition[$c]];
$gabayabout=$_POST['gabay'.$dbposition[$c]];
$thirdabout=$_POST['third'.$dbposition[$c]];
mysql_query("UPDATE candidates SET about='$leadersabout' WHERE party='Leaders' AND position='$dbposition[$c]'")or die("Query failed");
mysql_query("UPDATE candidates SET about='$gabayabout' WHERE party='Gabay' AND position='$dbposition[$c]'")or die("Query failed"); 
mysql_query("UPDATE candidates SET about='$thirdabout' WHERE party='Third' AND position='$dbposition[$c]'")or die("Query failed"); 
echo "
<html>
<body>
<h4>Year-Level and course for position ".$displayposition[$c]." has been added! Happy election!</h4>
</body>
</html>
";
}
$c++;
error_reporting(E_ALL ^ E_NOTICE);
}
?>
</br></br>
<form action=admin.php><input type=submit value='Back to admin switchboard'></form>

</div>

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

</body>
</html>
