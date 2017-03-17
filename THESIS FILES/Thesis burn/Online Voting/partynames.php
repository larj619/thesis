<?php

mysql_connect("localhost","root");
mysql_select_db("thesis");

$name=mysql_query("SELECT * FROM partylist WHERE refnum=1");
while($r=mysql_fetch_array($name))
{
$party1=$r['Gabay'];
$party2=$r['Leaders'];
$party3=$r['Third'];
}

?>