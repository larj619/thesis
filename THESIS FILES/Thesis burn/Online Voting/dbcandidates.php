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

$_POST['part1']=strip_tags($_POST['part1']);
$_POST['part1']=stripslashes($_POST['part1']);
$_POST['part1']=mysql_real_escape_string($_POST['part1']);

$_POST['part2']=strip_tags($_POST['part2']);
$_POST['part2']=stripslashes($_POST['part2']);
$_POST['part2']=mysql_real_escape_string($_POST['part2']);

$_POST['part3']=strip_tags($_POST['part3']);
$_POST['part3']=stripslashes($_POST['part3']);
$_POST['part3']=mysql_real_escape_string($_POST['part3']);

$party1=$_POST['part1'];
$party2=$_POST['part2'];
$party3=$_POST['part3'];

mysql_query("UPDATE partylist SET Gabay = '$party1' WHERE refnum = '1' ")or die("Query failed");
mysql_query("UPDATE partylist SET Leaders = '$party2' WHERE refnum = '1' ")or die("Query failed");
mysql_query("UPDATE partylist SET Third = '$party3' WHERE refnum = '1' ")or die("Query failed");


echo"
<h4>Partylist1 has been changed! Happy election!</h4>
<h4>Partylist2 has been changed! Happy election!</h4>
<h4>Partylist3 has been changed! Happy election!</h4>
";

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
$leadersname=$_POST['leaders'.$dbposition[$c]];
$gabayname=$_POST['gabay'.$dbposition[$c]];
$thirdname=$_POST['third'.$dbposition[$c]];
mysql_query("UPDATE candidates SET names='$leadersname' WHERE party='Leaders' AND position='$dbposition[$c]'")or die("Query failed");
mysql_query("UPDATE candidates SET names='$gabayname' WHERE party='Gabay' AND position='$dbposition[$c]'")or die("Query failed"); 
mysql_query("UPDATE candidates SET names='$thirdname' WHERE party='Third' AND position='$dbposition[$c]'")or die("Query failed"); 
echo "
<html>
<body>
<h4>Candidate for ".$displayposition[$c]." added! Happy election!</h4>
</body>
</html>
";
}
$c++;

}
?>
</br></br>
<form action=about.php><input type=submit value='About the candidates'></form>
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
