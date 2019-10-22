<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="QuestionnaireServer.Result" Async="true" %>

<%@ Register Assembly="QuestionnaireServerControl" Namespace="QuestionnaireServerControl" TagPrefix="cc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questionnaire - Risultato</title>
    <link rel="shortcut icon" type="image/x-icon" href="Icons/favicon.ico" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" media="screen"/>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form runat="server">
        <cc:Questionnaire ID="ccQuestionnaire" DisplayMode="CORRECTION" runat="server"></cc:Questionnaire>
    </form>
</body>
</html>