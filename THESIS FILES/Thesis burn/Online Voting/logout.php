<center>
<font color=ffffff>

<?php
	session_start();
	$_SESSION = array();
	unset($_SESSION['user']);
	unset($_SESSION['pass']);
	session_destroy();
	
	header("location:index.php");
?>

</font>
</center>