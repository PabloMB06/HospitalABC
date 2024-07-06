<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DoctorList.aspx.cs" Inherits="HospitalSystem.DoctorList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Doctor List</title>
    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous" />
    <link href="Styles/DoctorList.css" rel="stylesheet" />
    <style>
        body {
            background-color: #f8f9fa; /* Change the body background color */
        }

        .container {
            margin-top: 50px; /* Adjust top margin of the container */
        }

        .btn-back {
            margin-top: 20px; /* Adjust top margin of the back button */
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2 class="mb-4 text-center text-dark">Doctor List</h2>
            <asp:Label ID="lblErrorMessage" runat="server" CssClass="text-danger"></asp:Label>
            <asp:Table ID="tblPatientList" runat="server" CssClass="table table-striped">
                <asp:TableHeaderRow>
                    <asp:TableHeaderCell>Doctor Name</asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
            <asp:Button ID="btnBack" runat="server" Text="Go Back" CssClass="btn btn-danger ms-2" OnClick="btnBack_Click" />
        </div>

        <!-- Modal for delete confirmation -->
        <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="deleteModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="deleteModalLabel">Confirm Delete</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        Are you sure you want to delete all information for this doctor?
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnConfirmDelete" runat="server" Text="Yes" CssClass="btn btn-danger" OnClick="btnConfirmDelete_Click" />
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">No</button>
                    </div>
                </div>
            </div>
        </div>

        <asp:HiddenField ID="hfDoctorIdToDelete" runat="server" />
    </form>
    <script type="text/javascript">
        function showDeleteModal(doctorId) {
            $('#<%= hfDoctorIdToDelete.ClientID %>').val(doctorId);
            $('#deleteModal').modal('show');
        }
    </script>
</body>
</html>
