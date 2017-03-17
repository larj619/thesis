<?php 
session_start();
if (!isset($_SESSION['user']) || !isset($_SESSION['pass']))
{
	header("location:notloggedin.php");
	die();
}
?>

<?php
include("connect.php");
mysql_query("truncate votetable");
mysql_query("UPDATE candidates SET about='about me' ");

mysql_query("UPDATE user SET status='NOT VOTED'");

mysql_query("UPDATE sy SET syear='0000 - 0000' where ref='1' ");

mysql_query("UPDATE partylist SET Gabay='Party1' WHERE refnum='1'");
mysql_query("UPDATE partylist SET Leaders='Party2' WHERE refnum='1'");
mysql_query("UPDATE partylist SET Third='Party3' WHERE refnum='1'");

mysql_query("UPDATE candidates SET names='President' WHERE position='PRES'");
mysql_query("UPDATE candidates SET names='Vice President' WHERE position='VP'");
mysql_query("UPDATE candidates SET names='Secretary' WHERE position='SEC'");
mysql_query("UPDATE candidates SET names='Treasurer' WHERE position='TREAS'");
mysql_query("UPDATE candidates SET names='Auditor' WHERE position='AUD'");
mysql_query("UPDATE candidates SET names='Business Manager' WHERE position='BUSMan'");
mysql_query("UPDATE candidates SET names='Public Relations Officer' WHERE position='PRO'");

header("location:admin - success.php");
?>

