<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="百度网盘soso.HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="height: 467px">

    <form id="form1" action="HomePage.aspx"method="post">
<div style="text-align: center;">
<br /><br /><br /><br /><br /><br /><br /><br />
	<img src="images/001.png">
<br/>
        <input id="SearchContent " name="SearchContent" type="text" /><br /><br />
        <input id="Submit1"type="button" value="搜索" onclick="submit()"/>
	<input id="Submit2"type="button" value="Online search" onclick="window.open('submit.html')"/>
        <input type="hidden" name="IsPostBack" value="1" />
  </div>
    </form>
</body>
</html>
