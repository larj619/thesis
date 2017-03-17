<html>
<head>
<title>TUA-CSC Online Voting System</title>
</head>

<body background="images/TUA @ 50.jpg" style="background-repeat:no-repeat; background-size: 100% 100% ">

<center>

<img src="images/banner.jpg" width="900" height="250">

</img>

</br></br>

<body color=000000>
<font color=ff0000>
<center>

<?php
$candidate_id=$_POST['candidate_id'];
include ("connect.php");

$sql="SELECT * FROM candidates WHERE candidate_id='$candidate_id'";
$result=mysql_query($sql);
$count=mysql_num_rows($result);
echo "<table>";
$row = mysql_fetch_array($result);
if (!$row) { echo "Record with Candidate_ID " . $candidate_id . " does not exist."; } //no record of deluserid
	else { //echos profile info
	echo "<tr><td align=center><font color=ff0000>" . $row['names'] . "</td><td align=center><font color=ff0000>" . $row['position'] . "</td><td align=center><font color=ff0000>" . $row['party'] .  "</td></tr>";

	echo "</table>";

		$sql="DELETE names FROM candidates WHERE candidate_id='$candidate_id'";
		mysql_query($sql);

		//$sql="SELECT * FROM candidates where candidate_id='$candidate_id'";
		//$result=mysql_query($sql);
		//$count=mysql_num_rows($result);

		//$row = mysql_fetch_array($result);
		
		if (!$row) { echo "Deletion Successful!"; }
		
		else { echo "Deletion failed. Record with Candidate_ID '$candidate_id' still exists."; }
		}
	 //end echo profile info
?>
<form action="admin.php" ><input type=submit value="Back to admin control panel"></form>

</center>
</font>
</body>
</html>