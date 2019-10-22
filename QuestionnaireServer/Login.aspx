<%@ Page Async="true" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="QuestionnaireServer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Questionnaire - Login</title>
    <link rel="shortcut icon" type="image/x-icon" href="Icons/favicon.ico" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" media="screen"/>
    <link href="Content/login.css" rel="stylesheet" media="screen"/>
    <script src="Scripts/jquery-1.9.0.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
</head>
<body>
<div class="container" style="margin-top:40px">
    <div runat="server" class="row" id="divErrorContainer">
    </div>
		<div class="row">
			<div class="col-sm-6 col-md-4 col-md-offset-4">
				<div class="panel panel-default">
					<div class="panel-heading">
						<strong>Questionnaire - Accedi per continuare</strong>
					</div>
					<div class="panel-body">
						<form role="form" action="#" runat="server" id="frmLogin">
							<fieldset>
								<div class="row">
									<div class="center-block">
										<img class="profile-img"
											src="Images/login-icon.png" alt=""/>
									</div>
								</div>
								<div class="row">
									<div class="col-sm-12 col-md-10  col-md-offset-1 ">
										<div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-user" title="Nome"></i>
												</span> 
												<input runat="server" class="form-control" placeholder="Nome" id="txtFirstName" type="text" required="required" autofocus="autofocus"/>
											</div>
										</div>
										<div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-user" title="Cognome"></i>
												</span> 
												<input runat="server" class="form-control" placeholder="Cognome" id="txtSecondName" type="text" required="required" autofocus="autofocus"/>
											</div>
										</div>
                                        <div class="form-group">
											<div class="input-group">
												<span class="input-group-addon">
													<i class="glyphicon glyphicon-calendar" title="Data di nascita"></i>
												</span> 
												<input runat="server" class="form-control" id="calBirthDate" type="date" required="required" autofocus="autofocus"/>
											</div>
										</div>
										<div class="form-group">
											<input runat="server" id="cmdSubmit" type="submit" class="btn btn-lg btn-primary btn-block" value="Accedi"/>
										</div>
									</div>
								</div>
							</fieldset>
						</form>
					</div>
                </div>
			</div>
		</div>
    </div>
</body>
</html>

