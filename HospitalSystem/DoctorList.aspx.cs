using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class DoctorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadDoctorList();
            }
        }

        private void LoadDoctorList()
        {
            try
            {
                string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

                if (File.Exists(doctorFilePath))
                {
                    string[] lines = File.ReadAllLines(doctorFilePath);
                    foreach (string line in lines)
                    {
                        string[] doctorData = line.Split(';');
                        if (doctorData.Length >= 8)
                        {
                            string doctorName = $"{doctorData[0]} {doctorData[1]} {doctorData[2]}";
                            TableRow row = new TableRow();

                            // Doctor name cell with a hyperlink
                            TableCell nameCell = new TableCell();
                            HyperLink doctorLink = new HyperLink
                            {
                                Text = doctorName,
                                NavigateUrl = $"AdminDoctorList.aspx?doctorId={doctorData[3]}" // Redirects to DoctorPatientList.aspx with doctor ID
                            };
                            nameCell.Controls.Add(doctorLink);
                            row.Cells.Add(nameCell);

                            // Edit button cell
                            TableCell editCell = new TableCell();
                            Button editButton = new Button
                            {
                                Text = "Edit",
                                CssClass = "btn btn-warning",
                                PostBackUrl = $"EditDoctorInfo.aspx?doctorId={doctorData[3]}" // Redirects to EditDoctorInfo.aspx with doctor ID
                            };
                            editCell.Controls.Add(editButton);
                            row.Cells.Add(editCell);

                            // Delete all info button cell
                            TableCell deleteAllCell = new TableCell();
                            Button deleteAllButton = new Button
                            {
                                Text = "Delete",
                                CssClass = "btn btn-danger",
                                OnClientClick = $"showDeleteModal('{doctorData[3]}'); return false;"
                            };
                            deleteAllCell.Controls.Add(deleteAllButton);
                            row.Cells.Add(deleteAllCell);

                            tblPatientList.Rows.Add(row);
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Doctor data file is missing.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while loading doctor list: {ex.Message}");
            }
        }

        private void DeleteDoctor(string doctorId)
        {
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");
            if (File.Exists(doctorFilePath))
            {
                var lines = File.ReadAllLines(doctorFilePath);
                var newLines = new List<string>();

                foreach (var line in lines)
                {
                    var doctorData = line.Split(';');
                    if (doctorData.Length >= 4 && doctorData[3].Trim() != doctorId.Trim()) // Exact comparison of doctor ID
                    {
                        newLines.Add(line);
                    }
                }

                File.WriteAllLines(doctorFilePath, newLines);
            }
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            string doctorId = hfDoctorIdToDelete.Value;
            if (!string.IsNullOrEmpty(doctorId))
            {
                DeleteDoctor(doctorId);
                LoadDoctorList();
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageDoctorDashboard.aspx");
        }

        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }
    }
}
