<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminDoctorManagement.aspx.cs" Inherits="HospitalSystem.AdminDoctorManagement" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor Management</title>
    <link href="Styles/AdminDoctorManagement.css" rel="stylesheet" />
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="mb-4 text-white">Doctor Management</h1>

                <!-- Form for adding/editing doctor -->
                <div class="card">
                    <div class="card-body">
                        <h5 class="card-title">Add/Edit Doctor</h5>
                        <div class="mb-3">
                            <label for="txtFirstName" class="form-label">First Name</label>
                            <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLastName1" class="form-label">Last Name 1</label>
                            <asp:TextBox ID="txtLastName1" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtLastName2" class="form-label">Last Name 2</label>
                            <asp:TextBox ID="txtLastName2" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtNIC" class="form-label">NIC</label>
                            <asp:TextBox ID="txtNIC" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                           <label for="ddlCivilStatus" class="form-label"> Civil Status</label>
                           <asp:DropDownList ID="ddlCivilStatus" runat="server" CssClass="form-select">
                               <asp:ListItem Text="Choose an option" Value="" Selected="True" disabled></asp:ListItem>
                               <asp:ListItem Text="Married" Value="Married"></asp:ListItem>
                               <asp:ListItem Text="Widowed" Value="Widowed"></asp:ListItem>
                               <asp:ListItem Text="Separated" Value="Separated"></asp:ListItem>
                               <asp:ListItem Text="Divorced" Value="Divorced"></asp:ListItem>
                               <asp:ListItem Text="Single" Value="Single"></asp:ListItem>
                           </asp:DropDownList>
                       </div>
                        <div class="mb-3">
                            <label for="txtBirthDate" class="form-label">Birth Date</label>
                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtPhone" class="form-label">Phone</label>
                            <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtSpecialization" class="form-label">Specialization</label>
                            <asp:TextBox ID="txtSpecialization" runat="server" CssClass="form-control"></asp:TextBox>
                        </div>
                           <div class="mb-3">
                               <label for="txtAddress" class="form-label">Addres</label>
                               <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" ></asp:TextBox>
                           </div>
                        <div>
                            <asp:Button ID="btnAddDoctor" runat="server" Text="Add Doctor" CssClass="btn btn-primary" OnClick="btnAddDoctor_Click" OnClientClick="return confirm('Are you sure you want to add this doctor?');"/>
                            <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-danger ms-2" OnClick="btnBack_Click" OnClientClick="return confirm('Are you sure you want to go back?');"/>
                        </div>
                    </div>
                </div>

                <!-- Bootstrap alerts for notifications -->
                <div id="alertContainer" runat="server">
                    <div id="successAlert" class="alert alert-success mt-3 d-none" role="alert">
                        Operation successful!
                    </div>
                    <div id="errorAlert" class="alert alert-danger mt-3 d-none" role="alert">
                        An error occurred.
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
