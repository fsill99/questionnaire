<%@ Page EnableViewState="true" Language="C#" AutoEventWireup="true" CodeBehind="Questionnaire.aspx.cs" Inherits="QuestionnaireServer.Questionnaire" EnableEventValidation="false" Async="true" %>

<%@ Register Assembly="QuestionnaireServerControl" Namespace="QuestionnaireServerControl" TagPrefix="cc" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Questionnaire - Esaminazione</title>
        <link rel="shortcut icon" type="image/x-icon" href="Icons/favicon.ico" />
        <link href="Content/bootstrap.min.css" rel="stylesheet" media="screen"/>
        <link href="Content/questionnaire.css" rel="stylesheet" />
        <script src="Scripts/jquery-1.9.0.min.js"></script>
        <script src="Scripts/bootstrap.min.js"></script>
        <script src="Scripts/questionnaire.js"></script>
    </head>
    <body>
        <div class="container" runat="server" id="divContainer">
            <div runat="server" class="row" id="divErrorContainer">
            </div>
        </div>
        
        <form runat="server" id="qForm">

        <!--Questions group (container)-->
        <cc:Questionnaire runat="server" ID="ccQuestionnaire" DisplayMode="TEST"></cc:Questionnaire>     
                                
        <!--Button-->                   
        <div class="text-center"> 
        <button type="button" href="#modal-dialog" data-toggle="modal" class="modal-toggle align-center btn btn-default btn-lg">
            <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
            Consegna questionario
        </button>
        </div>  
                                               
        <!--Modal dialog-->                           
        <div id="modal-dialog" class="modal">
	        <div class="modal-dialog">
                <div class="modal-content">
                <div class="modal-header">
                    <a href="#" data-dismiss="modal" aria-hidden="true" class="close">×</a>
                        <h3>Consegna questionario</h3>
                </div>
                <div class="modal-body">
                        <p>Sei sicuro di voler consegnare il questionario? Una volta consegnato le risposte date non potranno pi essere cambiate.</p>
                </div>
                <div class="modal-footer">
                    <a href="#" runat="server" id="cmdConfirm" class="btn confirm">Consegna</a>
                    <a href="#" data-dismiss="modal" aria-hidden="true" class="btn secondary">Annulla</a>
                </div>
                </div>
            </div>
        </div> 
                        
     </form>                        
    </body>
</html>
