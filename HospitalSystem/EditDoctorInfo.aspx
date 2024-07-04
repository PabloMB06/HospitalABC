<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditDoctorInfo.aspx.cs" Inherits="HospitalSystem.EditDoctorInfo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Edit Doctor Info</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Styles/DoctorPatientManagement.css" rel="stylesheet" />
    <style>
        body {
            background-color: #0094ff; /* Change the body background color */
        }

        .container {
            margin-top: 50px; /* Adjust top margin of the container */
        }

        .btn-back {
            margin-top: 20px; /* Adjust top margin of the back button */
        }

        /* Style for dropdown menus */
        .form-group .dropdown-menu {
            max-height: 200px; /* Maximum height of the dropdown menu */
            overflow-y: auto; /* Enable vertical scrolling if exceeds maximum height */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container" align="center">
            <h1 class="mb-4 text-center text-dark">Edit Doctor Info</h1>
            <asp:Panel ID="pnlDoctorInfo" runat="server">
                <div class="form-group">
                    <label for="txtFirstName">First Name</label>
                    <asp:TextBox ID="txtFirstName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtLastName">Last Name</label>
                    <asp:TextBox ID="txtLastName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtSpecialization">Specialization</label>
                    <asp:TextBox ID="txtSpecialization" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtEmail">Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtPhone">Phone</label>
                    <asp:TextBox ID="txtPhone" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <label for="txtAddress">Address</label>
                    <asp:TextBox ID="txtAddress" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>
                <br />
                <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Confirm Changes" OnClick="btnSave_Click" OnClientClick="return confirm('Are you sure you want to save changes?');" />
                <asp:Button ID="btnCancel" CssClass="btn btn-danger" runat="server" Text="Cancel" OnClick="btnCancel_Click" OnClientClick="return confirm('Are you sure you want to cancel?');" />
            </asp:Panel>
            <asp:Label ID="lblMessage" runat="server" CssClass="alert alert-success" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
