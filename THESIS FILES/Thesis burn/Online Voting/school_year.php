<?php

mysql_connect("localhost","root");
mysql_select_db("thesis");

$name=mysql_query("SELECT * FROM sy");
while($r=mysql_fetch_array($name))
{
$syr=$r['syear'];
}

?>