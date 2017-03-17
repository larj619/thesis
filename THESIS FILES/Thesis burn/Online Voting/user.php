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
	

<div id="site_content">		
		<center>
      <div class="slideshow">  
		<ul class="slideshow">
          <li class="show"><img width="900" height="350" src="images/banner.jpg" /></li>
        </ul>  	
	  </div><!--close slideshow-->  	 
</br></br></br>

<table style=" width: 250px;
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
    -webkit-box-shadow:0px -5px 300px #270644;"  width=25%>

<tr>
<td><center><h2>
</br>
<?php
$user=$_SESSION['user'];
include ("connect.php");

$fetchgabay=mysql_query("SELECT * FROM candidates WHERE party='Gabay'");
$fetchleaders=mysql_query("SELECT * FROM candidates WHERE party='Leaders'");
$gabaynames=array('');
$leadersnames=array('');
$gabaycounter=0;
$leaderscounter=0;
while($r=mysql_fetch_array($fetchgabay))
{
$gabaynames[$gabaycounter]=$r['names'];
$gabaycounter++;
}
while($r=mysql_fetch_array($fetchleaders))
{
$leadersnames[$leaderscounter]=$r['names'];
$leaderscounter++;
}

$res=mysql_query("SELECT * FROM user WHERE user='$user' OR stud_no='$user' ");
while($r=mysql_fetch_array($res))
{
$name= $r['fname'] . " " . $r['lname'];
$stnum=$r['stud_no'];
}
$_SESSION['user']=$name;
$_SESSION['stnum']=$stnum;
?>

<?php
include ("connect.php");
$sy=mysql_query("SELECT * FROM sy ");
while($r=mysql_fetch_array($sy))
{
$syr=$r['syear'];
}
?>


<?php echo " <h1> SY: ". $syr ." </h1>" ; ?><h2>
<?php echo $name; ?></br>
&nbsp;&nbsp;&nbsp;<?php echo $stnum; ?></h2></center></br>

<center>

<form action=logout.php><input type=submit value='Logout'></form>
</center>

</td>
</tr>

<!--<tr>
<td>

<h3></br>&nbsp;&nbsp;&nbsp;  Rules:</h3>
<ul>
<h4>
&nbsp;<li> To vote, just check the box below the name of your desired candidate.</li>
&nbsp;<li> One vote only!</li>
</h4>
</ul>
</td>
</tr>-->


</table>

</br> </br> </br>
<form action="vote.php" method=POST>
<!--<table border="1" width="900" style="background-color: #F2F2F2 "> -->
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

	

echo "
</br></br>
<center>
<table border=1 style='text-align:center; border:ridge #222222;' width=60%>

<tr> <td colspan=4><font color=ffffff>".$displayposition[$c]."</td></tr>
<tr>";
if($gnames!='') echo "<td> <font color=ffffff>".$party1."<br/> <img src=".$gpics." height=110 width=110> </br> " . $gnames . "</br>"  .$gabout. "<br/>".$displayposition[$c]."<br/><input type=radio name=".$dbposition[$c]." value=Gabay></td>";
if($lnames!='') echo "<td> <font color=ffffff>".$party2."<br/> <img src=".$lpics." height=110 width=110> </br> " . $lnames .  "</br>"  .$labout.  "<br/>".$displayposition[$c]."<br/><input type=radio name=".$dbposition[$c]." value=Leaders></td>";
if($tnames!='') echo "<td><font color=ffffff>".$party3."<br/> <img src=".$tpics." height=110 width=110> </br>" . $tnames .  "</br>"  .$tabout.  "<br/>".$displayposition[$c]."<br/><input type=radio name=".$dbposition[$c]." value=Third></td>";
echo "<td> <font color=ffffff>ABSTAIN<br/><input type=radio name=".$dbposition[$c]." value=Abstain></td>
</tr>
</table>
<br/><br/>
</center>";
$c++; 
$leaderscounter++;
$gabaycounter++;
$thirdcounter++;

} 



?>

</td>
</tr>

<tr>
<td>
<center>
<input type=submit value="SUBMIT VOTE">
</center>
</td>
</tr>

</table>
</form>
</br>

</div>

  <div id="footer">
	  Copyright &copy; 2013. All Rights Reserved. <a href="http://validator.w3.org/check?uri=referer">Valid XHTML</a>
  </div><!--close footer-->  

</body>
</html>