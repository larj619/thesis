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
else
{
	if ($_SESSION['user']!="admin" && $_SESSION['pass']!="12345") 
	{
	header("location:notloggedin.php");
	die(); 
	}
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
          <li class="current"><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
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
				</br></br>
<?php
include ("connect.php");

//Pres
$GabayPres = mysql_query("SELECT * FROM votetable where Pres='Gabay'");
$LeadersPres = mysql_query("SELECT * FROM votetable where Pres='Leaders'");
$ThirdPres = mysql_query("SELECT * FROM votetable where Pres='Third'");
$absPres = mysql_query("SELECT * FROM votetable where Pres='abstain'");
//vp
$GabayVP = mysql_query("SELECT * FROM votetable where VP='Gabay'");
$LeadersVP = mysql_query("SELECT * FROM votetable where VP='Leaders'");
$ThirdVP = mysql_query("SELECT * FROM votetable where VP='Third'");
$absVP = mysql_query("SELECT * FROM votetable where VP='abstain'");
//sec
$GabaySEC = mysql_query("SELECT * FROM votetable where SEC='Gabay'");
$LeadersSEC = mysql_query("SELECT * FROM votetable where SEC='Leaders'");
$ThirdSEC = mysql_query("SELECT * FROM votetable where SEC='Third'");
$absSEC = mysql_query("SELECT * FROM votetable where SEC='abstain'");
//TREAS
$GabayTREAS = mysql_query("SELECT * FROM votetable where TREAS='Gabay'");
$LeadersTREAS= mysql_query("SELECT * FROM votetable where TREAS='Leaders'");
$ThirdTREAS = mysql_query("SELECT * FROM votetable where TREAS='Third'");
$absTREAS = mysql_query("SELECT * FROM votetable where TREAS='abstain'");
//AUD
$GabayAUD = mysql_query("SELECT * FROM votetable where AUD='Gabay'");
$LeadersAUD = mysql_query("SELECT * FROM votetable where AUD='Leaders'");
$ThirdAUD = mysql_query("SELECT * FROM votetable where AUD='Third'");
$absAUD = mysql_query("SELECT * FROM votetable where AUD='abstain'");
//BUSMan
$GabayBUSMan = mysql_query("SELECT * FROM votetable where BUSMan='Gabay'");
$LeadersBUSMan = mysql_query("SELECT * FROM votetable where BUSMan='Leaders'");
$ThirdBUSMan = mysql_query("SELECT * FROM votetable where BUSMan='Third'");
$absBUSMan = mysql_query("SELECT * FROM votetable where BUSMan='abstain'");
//TREAS
$GabayPRO = mysql_query("SELECT * FROM votetable where PRO='Gabay'");
$LeadersPRO = mysql_query("SELECT * FROM votetable where PRO='Leaders'");
$ThirdPRO = mysql_query("SELECT * FROM votetable where PRO='Third'");
$absPRO = mysql_query("SELECT * FROM votetable where PRO='abstain'");

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

$GabayPres=mysql_num_rows($GabayPres);
$LeadersPres=mysql_num_rows($LeadersPres);
$ThirdPres=mysql_num_rows($ThirdPres);
$absPres=mysql_num_rows($absPres);

$GabayVP=mysql_num_rows($GabayVP);
$LeadersVP=mysql_num_rows($LeadersVP);
$ThirdVP=mysql_num_rows($ThirdVP);
$absVP=mysql_num_rows($absVP);


$GabaySEC=mysql_num_rows($GabaySEC);
$LeadersSEC=mysql_num_rows($LeadersSEC);
$ThirdSEC=mysql_num_rows($ThirdSEC);
$absSEC=mysql_num_rows($absSEC);

$GabayPRO=mysql_num_rows($GabayPRO);
$LeadersPRO=mysql_num_rows($LeadersPRO);
$ThirdPRO=mysql_num_rows($ThirdPRO);
$absPRO=mysql_num_rows($absPRO);


$GabayTREAS=mysql_num_rows($GabayTREAS);
$LeadersTREAS=mysql_num_rows($LeadersTREAS);
$ThirdTREAS=mysql_num_rows($ThirdTREAS);
$absTREAS=mysql_num_rows($absTREAS);

$GabayBUSMan=mysql_num_rows($GabayBUSMan);
$LeadersBUSMan=mysql_num_rows($LeadersBUSMan);
$ThirdBUSMan=mysql_num_rows($ThirdBUSMan);
$absBUSMan=mysql_num_rows($absBUSMan);


$GabayAUD=mysql_num_rows($GabayAUD);
$LeadersAUD=mysql_num_rows($LeadersAUD);
$ThirdAUD=mysql_num_rows($ThirdAUD);
$absAUD=mysql_num_rows($absAUD);

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

$prestotal=$GabayPres+$LeadersPres+$absPres+$ThirdPres;
$VPtotal=$GabayVP+$LeadersVP+$absVP+$ThirdVP;
$SECtotal=$GabaySEC+$LeadersSEC+$absSEC+$ThirdSEC;
$TREAStotal=$GabayTREAS+$LeadersTREAS+$absTREAS+$ThirdTREAS;
$AUDtotal=$GabayAUD+$LeadersAUD+$absAUD+$ThirdAUD;
$BUSMantotal=$GabayBUSMan+$LeadersBUSMan+$absBUSMan+$ThirdBUSMan;
$PROtotal=$GabayPRO+$LeadersPRO+$absPRO+$ThirdPRO;

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


include ("partynames.php");
include ("connect.php");

$presGabay = mysql_query("SELECT names FROM candidates WHERE position='PRES' AND party='Gabay'");
$presGabay_row=mysql_fetch_array($presGabay);
$presLeaders = mysql_query("SELECT names FROM candidates WHERE position='PRES' AND party='Leaders'");
$presLeaders_row=mysql_fetch_array($presLeaders);
$presThird = mysql_query("SELECT names FROM candidates WHERE position='PRES' AND party='Third'");
$presThird_row=mysql_fetch_array($presThird);

$vpGabay = mysql_query("SELECT names FROM candidates WHERE position='VP' AND party='Gabay'");
$vpGabay_row=mysql_fetch_array($vpGabay);
$vpLeaders = mysql_query("SELECT names FROM candidates WHERE position='VP' AND party='Leaders'");
$vpLeaders_row=mysql_fetch_array($vpLeaders);
$vpThird = mysql_query("SELECT names FROM candidates WHERE position='VP' AND party='Third'");
$vpThird_row=mysql_fetch_array($vpLeaders);

$secGabay = mysql_query("SELECT names FROM candidates WHERE position='SEC' AND party='Gabay'");
$secGabay_row=mysql_fetch_array($secGabay);
$secLeaders = mysql_query("SELECT names FROM candidates WHERE position='SEC' AND party='Leaders'");
$secLeaders_row=mysql_fetch_array($secLeaders);
$secThird = mysql_query("SELECT names FROM candidates WHERE position='SEC' AND party='Third'");
$secThird_row=mysql_fetch_array($secThird);

$treasGabay = mysql_query("SELECT names FROM candidates WHERE position='TREAS' AND party='Gabay'");
$treasGabay_row=mysql_fetch_array($treasGabay);
$treasLeaders = mysql_query("SELECT names FROM candidates WHERE position='TREAS' AND party='Leaders'");
$treasLeaders_row=mysql_fetch_array($treasLeaders);
$treasThird = mysql_query("SELECT names FROM candidates WHERE position='TREAS' AND party='Third'");
$treasThird_row=mysql_fetch_array($treasThird);

$audGabay = mysql_query("SELECT names FROM candidates WHERE position='AUD' AND party='Gabay'");
$audGabay_row=mysql_fetch_array($audGabay);
$audLeaders = mysql_query("SELECT names FROM candidates WHERE position='AUD' AND party='Leaders'");
$audLeaders_row=mysql_fetch_array($audLeaders);
$audThird = mysql_query("SELECT names FROM candidates WHERE position='AUD' AND party='Third'");
$audThird_row=mysql_fetch_array($audThird);

$busmanGabay = mysql_query("SELECT names FROM candidates WHERE position='BUSMan' AND party='Gabay'");
$busmanGabay_row=mysql_fetch_array($busmanGabay);
$busmanLeaders = mysql_query("SELECT names FROM candidates WHERE position='BUSMan' AND party='Leaders'");
$busmanLeaders_row=mysql_fetch_array($busmanLeaders);
$busmanThird = mysql_query("SELECT names FROM candidates WHERE position='BUSMan' AND party='Third'");
$busmanThird_row=mysql_fetch_array($busmanThird);

$proGabay = mysql_query("SELECT names FROM candidates WHERE position='PRO' AND party='Gabay'");
$proGabay_row=mysql_fetch_array($proGabay);
$proLeaders = mysql_query("SELECT names FROM candidates WHERE position='PRO' AND party='Leaders'");
$proLeaders_row=mysql_fetch_array($proLeaders);
$proThird = mysql_query("SELECT names FROM candidates WHERE position='PRO' AND party='Third'");
$proThird_row=mysql_fetch_array($proThird);

?>



<h2> As of  

<script type="text/javascript">
<!--
	var currentDate = new Date()
	var day = currentDate.getDate()
	var month = currentDate.getMonth() + 1
	var year = currentDate.getFullYear()
	document.write("<b>" + day + "/" + month + "/" + year + "</b>")
//-->
</script>
,
<script type="text/javascript">
<!--
	var currentTime = new Date()
	var hours = currentTime.getHours()
	var minutes = currentTime.getMinutes()

	if (minutes < 10)
	minutes = "0" + minutes

	var suffix = "AM";
	if (hours >= 12) {
	suffix = "PM";
	hours = hours - 12;
	}
	if (hours == 0) {
	hours = 12;
	}

	document.write("<b>" + hours + ":" + minutes + " " + suffix + "</b>")
//-->
</script>

</h2>


<div id="print">

<?php

echo "</br> </br><table border=1 width = 900 ><font color=ffffff>";
echo "";
echo "<tr>";
echo "<td  align='center' ><font color=ffffff>" ."PRESIDENT"."</td>";
echo "<td align='center'><font color=ffffff>".$party1. "<br/>" .$presGabay_row['names']."</td>";
echo "<td align='center'><font color=ffffff>" .$GabayPres."<br/>"; if($prestotal>0) { echo round((($GabayPres/$prestotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'><font color=ffffff>".$party2." <br/>" .$presLeaders_row['names']."</td>";
echo "<td align='center'><font color=ffffff>" .$LeadersPres."<br/>"; if($prestotal>0) { echo round((($LeadersPres/$prestotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'><font color=ffffff>".$party3." <br/>" .$presThird_row['names']."</td>";
echo "<td align='center'><font color=ffffff>" .$ThirdPres."<br/>"; if($prestotal>0) { echo round((($ThirdPres/$prestotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'><font color=ffffff>" ."ABSTAIN <br/> President"."</td>";
echo "<td align='center'><font color=ffffff>" .$absPres."<br/>"; if($prestotal>0) { echo round((($absPres/$prestotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."VICE PRESIDENT"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>".$vpGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabayVP."<br/>"; if($VPtotal>0) { echo round((($GabayVP/$VPtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>".$vpLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersVP."<br/>"; if($VPtotal>0) { echo round((($LeadersVP/$VPtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>".$vpThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdVP."<br/>"; if($VPtotal>0) { echo round((($ThirdVP/$VPtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Vice President"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absVP."<br/>"; if($VPtotal>0) { echo round((($absVP/$VPtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."SECRETARY"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>" .$secGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabaySEC."<br/>"; if($SECtotal>0) { echo round((($GabaySEC/$SECtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>" .$secLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersSEC."<br/>"; if($SECtotal>0) { echo round((($LeadersSEC/$SECtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>" .$secThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdSEC."<br/>"; if($SECtotal>0) { echo round((($ThirdSEC/$SECtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Secretary"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absSEC."<br/>"; if($SECtotal>0) { echo round((($absSEC/$SECtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."TREASURER"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>" .$treasGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabayTREAS."<br/>"; if($TREAStotal>0) { echo round((($GabayTREAS/$TREAStotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>" .$treasLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersTREAS."<br/>"; if($TREAStotal>0) { echo round((($LeadersTREAS/$TREAStotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>" .$treasThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdTREAS."<br/>"; if($TREAStotal>0) { echo round((($ThirdTREAS/$TREAStotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Treasurer"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absTREAS."<br/>"; if($TREAStotal>0) { echo round((($absTREAS/$TREAStotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."AUDITOR"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>" .$audGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabayAUD."<br/>"; if($AUDtotal>0) { echo round((($GabayAUD/$AUDtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>" .$audLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersAUD."<br/>"; if($AUDtotal>0) { echo round((($LeadersAUD/$AUDtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>" .$audThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdAUD."<br/>"; if($AUDtotal>0) { echo round((($ThirdAUD/$AUDtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Auditor"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absAUD."<br/>"; if($AUDtotal>0) { echo round((($absAUD/$AUDtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."BUSINESS MANAGER"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>" .$busmanGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabayBUSMan."<br/>"; if($BUSMantotal>0) { echo round((($GabayBUSMan/$BUSMantotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>" .$busmanLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersBUSMan."<br/>"; if($BUSMantotal>0) { echo round((($LeadersBUSMan/$BUSMantotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>" .$busmanThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdBUSMan."<br/>"; if($BUSMantotal>0) { echo round((($ThirdBUSMan/$BUSMantotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Business Manager"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absBUSMan."<br/>"; if($BUSMantotal>0) { echo round((($absBUSMan/$BUSMantotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "<tr>";
echo "<td align='center'> <font color=ffffff>" ."PUBLIC RELATIONS OFFICERS"."</td>";
echo "<td align='center'> <font color=ffffff>".$party1. "<br/>" .$proGabay_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$GabayPRO."<br/>"; if($PROtotal>0) { echo round((($GabayPRO/$PROtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party2." <br/>" .$proLeaders_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$LeadersPRO."<br/>"; if($PROtotal>0) { echo round((($LeadersPRO/$PROtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>".$party3." <br/>" .$proThird_row['names']."</td>";
echo "<td align='center'> <font color=ffffff>" .$ThirdPRO."<br/>"; if($PROtotal>0) { echo round((($ThirdPRO/$PROtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "<td align='center'> <font color=ffffff>" ."ABSTAIN <br/> Public Realations Officer"."</td>";
echo "<td align='center'> <font color=ffffff>" .$absPRO."<br/>"; if($PROtotal>0) { echo round((($absPRO/$PROtotal)*100),1); } else { echo "0"; }echo "%</td>";
echo "</tr>";

echo "</table>";

?>



<script type="text/javascript">
<!--
function printContent(id){
str=document.getElementById(id).innerHTML
newwin=window.open('','printwin','left=300,top=50,width=800,height=600')
newwin.document.write('<HTML>\n<HEAD>\n')
newwin.document.write('<TITLE>RESULT</TITLE>\n')
newwin.document.write('<script>\n')
newwin.document.write('function chkstate(){\n')
newwin.document.write('if(document.readyState=="complete"){\n')
newwin.document.write('window.close()\n')
newwin.document.write('}\n')
newwin.document.write('else{\n')
newwin.document.write('setTimeout("chkstate()",2000)\n')
newwin.document.write('}\n')
newwin.document.write('}\n')
newwin.document.write('function print_win(){\n')
newwin.document.write('window.print();\n')
newwin.document.write('chkstate();\n')
newwin.document.write('}\n')
newwin.document.write('<\/script>\n')
newwin.document.write('</HEAD>\n')
newwin.document.write('<BODY onload="print_win()">\n')
newwin.document.write(str)
newwin.document.write('</BODY>\n')
newwin.document.write('</HTML>\n')
newwin.document.close()
}
//-->
</script>

<?php

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

$sql="SELECT * FROM user WHERE admin = '0' ";
$result=mysql_query($sql);
$count=mysql_num_rows($result);

echo "  </br> <h2>The total number of votes was ".$prestotal."  out of   ".$count." records </h2> ";

$total=(($count*0.35)*0.50)+1;

if ($prestotal>$total){

echo " <h2>The election was successful</h2>";

}

////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

echo " <h3> ";

$ccis="SELECT * FROM user WHERE college='CCIS'  and status= 'voted' ";
	$result=mysql_query($ccis);
	$count=mysql_num_rows($result);
echo " CCIS = ".$count."  &nbsp; ";

$cba="SELECT * FROM user WHERE college='CBA'  and status= 'voted' ";
	$result=mysql_query($cba);
	$count=mysql_num_rows($result);
echo " CBA = ".$count." &nbsp; ";	

$ced="SELECT * FROM user WHERE college='CED'  and status= 'voted' ";
	$result=mysql_query($ced);
	$count=mysql_num_rows($result);
echo " CED = ".$count." &nbsp; ";

$slcn="SELECT * FROM user WHERE college='SLCN'  and status= 'voted' ";
	$result=mysql_query($slcn);
	$count=mysql_num_rows($result);
echo " SLCN = ".$count." &nbsp; ";

$chtm="SELECT * FROM user WHERE college='CHTM'  and status= 'voted' ";
	$result=mysql_query($chtm);
	$count=mysql_num_rows($result);
echo " CHTM = ".$count." &nbsp; ";

$cmt="SELECT * FROM user WHERE college='CMT'  and status= 'voted' ";
	$result=mysql_query($cmt);
	$count=mysql_num_rows($result);
echo " CMT =  ".$count." &nbsp; ";

$cas="SELECT * FROM user WHERE college='CAS'  and status= 'voted' ";
	$result=mysql_query($cas);
	$count=mysql_num_rows($result);
echo " CAS =  ".$count." </br>";



echo " </h3> ";	
echo "</div>";
echo "</br>";
?>

<div class="button_small">
<a href="#" onclick="printContent('print')">PRINT</a>
</div>
</br>
</div><!--close main-->
<div id="content_green">
<div class="content_green_container_box">
<div id="">
		
	    <ul id="menu">
          <li class="current"><a href="admin.php">Admin</a></li>
          <li><a href="setschool_year.php">Manage School Year</a></li>
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