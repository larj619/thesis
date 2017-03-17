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


<form action=about_cand.php method=POST>
<center>
<!--<table border=1 style="width:900px; text-align:center;">-->


<?php include("partynames.php"); ?>
<tr>
<td>
<?php
$displayposition=array('President','Vice President','Secretary','Treasurer','Auditor','Business Manager','Public Relations Officer');
$dbposition=array('Pres','VP','SEC','TREAS','AUD','BUSMan','PRO');
$c=0;
$gabaycounter=0;
$leaderscounter=0;
$thirdcounter=0;
while($c<7)
{

	$gname=mysql_query("SELECT * FROM candidates WHERE party='Gabay' AND position='".$dbposition[$c]."'");
	while($gn=mysql_fetch_array($gname))
	{
	$gnames=$gn['names'];
	$gpics=$gn['cand_pic'];
	$gabout=$gn['about'];
	}

	$lname=mysql_query("SELECT * FROM candidates WHERE party='Leaders' AND position='".$dbposition[$c]."'");
	while($ln=mysql_fetch_array($lname))
	{
	$lnames=$ln['names'];
	$lpics=$ln['cand_pic'];
	$labout=$ln['about'];
	}
	
	$tname=mysql_query("SELECT * FROM candidates WHERE party='Third' AND position='".$dbposition[$c]."'");
	while($tn=mysql_fetch_array($tname))
	{
	$tnames=$tn['names'];
	$tpics=$tn['cand_pic'];
	$tabout=$tn['about'];
	}

		$yc='Year-Level,Course';

echo "
</br></br>
<center>
<table border=1 style='text-align:center; border:ridge #222222;' width=60%>

<tr> <td colspan=4><font color=ffffff>".$displayposition[$c]."</td></tr>
<tr>";
if($gnames!='') echo "<td> <font color=ffffff>".$party1."<br/> <img src=".$gpics." height=110 width=110> </br> " . $gnames .  "<input type=text value= '".$gabout."'  name='gabay".$dbposition[$c]."' > </br>".$displayposition[$c]."</br></td>";
if($lnames!='') echo "<td> <font color=ffffff>".$party2."<br/> <img src=".$lpics." height=110 width=110> </br> " . $lnames . "<input type=text value= '".$labout."'  name='leaders".$dbposition[$c]."' ></br>".$displayposition[$c]."</br></td>";
if($tnames!='') echo "<td><font color=ffffff>".$party3."<br/> <img src=".$tpics." height=110 width=110> </br>" . $tnames . "<input type=text value= '".$tabout."'  name='third".$dbposition[$c]."' ></br>".$displayposition[$c]."</br></td>";
//echo "<td> <font color=ffffff>ABSTAIN<br/><input type=radio name=".$dbposition[$c]." value=Abstain></td>";
echo "</tr>
</table>
<br/><br/>
</center>";
$c++; 
$leaderscounter++;
$gabaycounter++;
$thirdcounter++;

} 



?>



</br>

<td colspan=4><input type=submit></td>

</form>


</br></br>
<form action=admin.php><input type=submit value='Back to admin switchboard'></form>
</center>

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