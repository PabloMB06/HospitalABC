﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorMedicineInventory.aspx.cs" Inherits="HospitalSystem.DoctorMedicineInventory" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor Medicine Inventory</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous"/>
    <link href="Styles/DoctorMedicineInventory.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="background">
            <div class="container mt-5">
                <h1 class="text-center mb-4 text-white">Medicine Inventory</h1>
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <div class="mb-3">
                            <asp:TextBox ID="txtNewMedicine" runat="server" CssClass="form-control" placeholder="Enter medicine name"></asp:TextBox>
                        </div>
                        <div class="mb-3 text-center">
                            <asp:Button ID="btnAddMedicine" runat="server" Text="Add Medicine" CssClass="btn btn-primary" OnClick="btnAddMedicine_Click" />
                            <asp:Button ID="btnDeleteMedicine" runat="server" Text="Delete Medicine" CssClass="btn btn-danger" OnClick="btnDeleteMedicine_Click" />
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-md-10">
                        <asp:PlaceHolder ID="phMedicineTable" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz" crossorigin="anonymous"></script>
</body>
</html>
