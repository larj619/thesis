<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="en">

<?php
if(isset($_POST['submitted']))
{
	include('connect.php');
	
	$user = $_POST['user'];
	$pass = $_POST['pass'];
	
	$sql="SELECT * FROM user WHERE user='$user' and pass='$pass'";
	$result=mysql_query($sql);
	$count=mysql_num_rows($result);
	

	if($count!=0)
		{
		
		Session_start();
		$_SESSION['user'] = $user;
		$_SESSION['pass'] = $pass;
		
		$sql="SELECT * FROM user WHERE user='$user' and pass='$pass' and status='VOTED'";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);
		if($count==1)
		{
		header('Location: previously.php');
		exit;
		}
		
		header('Location: user.php');
		
		$sql="SELECT * FROM user WHERE user='$user' and pass='$pass' and admin='1'";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);
		if($count!=0)
			{
			header('Location: admin.php');
			}
		}
		
		$sql="SELECT * FROM user WHERE stud_no='$user' and lname='$pass'";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);
	

	if($count!=0)
		{
		Session_start();
		$_SESSION['user'] = $user;
		$_SESSION['pass'] = $pass;
		
		$sql="SELECT * FROM user WHERE stud_no='$user' and lname='$pass' and status='VOTED' ";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);
		
		if($count==1)
		{
		header('Location: previously.php');
		exit;
		
		}
		
		header('Location: user.php');
		
		
		$sql="SELECT * FROM user WHERE studno='$user' and lname='$pass' and admin='1'";
		$result=mysql_query($sql);
		$count=mysql_num_rows($result);
		if($count!=0)
			{
			header('Location: admin.php');
			}
		}
		
		

	
}


?>



<head>
<title>TUA-CSC Online Voting System</title>
  <meta http-equiv="content-type" content="text/html; charset=utf-8" />
  <meta http-equiv="X-UA-Compatible" content="IE=9" />
  <link rel="stylesheet" type="text/css" href="css/style.css" />
  
 
</head>

<body>
  <div id="main">
	<div id="site_content">		
		<center>
      <div class="slideshow">  
		<ul class="slideshow">
          <li class="show"><img width="900" height="350" src="images/banner.jpg" /></li>
        </ul>  	
	  </div><!--close slideshow-->  	 
				</br></br>
		<center>
			<table>
				<tr>
				<td>
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
    -webkit-box-shadow:0px -5px 300px #270644;" method="POST" action="index.php">
					<input type="hidden" name="submitted" value="true" />

			<center>
				
					<h2><legend>TUA-CSC </br> Online Voting System</legend></h2>
						</br>
						<h3><label>Username: </br> <input type="text" name="user"  /></label></br></br>
						<label>Password: </br> <input type="password" name="pass" /></label></br></br></h3>
						<br/>
							<input type="submit" value="Submit" />
		</center>
					</form>

		</center>

				</td>
				</tr>
			</table>
		</center>
			</br>
			<?php
if(isset($_POST['submitted']))
{
	include('connect.php');
	
	
	$user = $_POST['user'];
	$pass = $_POST['pass'];
	
	$sql="SELECT * FROM user WHERE user='$user' and pass='$pass'";
	$result=mysql_query($sql);
	$count=mysql_num_rows($result);
	

	if($count==0)
		{
		echo "<font color=red> <h2> <center> Invalid Username or Password </center> </h2> </font>";
		}
	
	
	
}


?>
 
  </div><!--close main-->
  
  <div id="footer">
	  Copyright &copy; 2013. All Rights Reserved. <a href="http://validator.w3.org/check?uri=referer">Valid XHTML</a>
  </div><!--close footer-->  
  
</body>
</html>
