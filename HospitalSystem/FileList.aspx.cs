using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class FileList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadPatientList();
            }
        }

        private void LoadPatientList()
        {
            try
            {
                string patientFilePath = Server.MapPath("~/DB/patient.txt");

                if (File.Exists(patientFilePath))
                {
                    string[] lines = File.ReadAllLines(patientFilePath);
                    foreach (string line in lines)
                    {
                        string[] patientData = line.Split(';');
                        if (patientData.Length >= 9)
                        {
                            string patientName = $"{patientData[0]} {patientData[1]} {patientData[2]}";
                            TableRow row = new TableRow();

                            // Patient name cell with a hyperlink
                            TableCell nameCell = new TableCell();
                            HyperLink patientLink = new HyperLink
                            {
                                Text = patientName,
                                NavigateUrl = $"DoctorPatientList.aspx?patientId={patientData[3]}" // Redirects to DoctorPatientList.aspx with patient ID
                            };
                            nameCell.Controls.Add(patientLink);
                            row.Cells.Add(nameCell);

                            // Edit button cell
                            TableCell editCell = new TableCell();
                            Button editButton = new Button
                            {
                                Text = "Edit",
                                CssClass = "btn btn-warning",
                                PostBackUrl = $"EditPatientInfo.aspx?patientId={patientData[3]}" // Redirects to EditPatientInfo.aspx with patient ID
                            };
                            editCell.Controls.Add(editButton);
                            row.Cells.Add(editCell);

                            // Delete all info button cell
                            TableCell deleteAllCell = new TableCell();
                            Button deleteAllButton = new Button
                            {
                                Text = "Delete",
                                CssClass = "btn btn-danger",
                                OnClientClick = $"showDeleteModal('{patientData[3]}'); return false;"
                            };
                            deleteAllCell.Controls.Add(deleteAllButton);
                            row.Cells.Add(deleteAllCell);

                            tblPatientList.Rows.Add(row);
                        }
                        else
                        {
                            ShowErrorMessage($"Invalid patient data: {line}");
                        }
                    }
                }
                else
                {
                    ShowErrorMessage("Patient data file is missing.");
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"An error occurred while loading patient list: {ex.Message}");
            }
        }

        private void DeletePatient(string patientId)
        {
            string patientFilePath = Server.MapPath("~/DB/patient.txt");
            if (File.Exists(patientFilePath))
            {
                var lines = File.ReadAllLines(patientFilePath);
                var newLines = new List<string>();

                foreach (var line in lines)
                {
                    var patientData = line.Split(';');
                    if (patientData.Length >= 4 && patientData[3].Trim() != patientId.Trim()) // Exact comparison of patient ID
                    {
                        newLines.Add(line);
                    }
                }

                File.WriteAllLines(patientFilePath, newLines);
            }
        }

        protected void btnConfirmDelete_Click(object sender, EventArgs e)
        {
            string patientId = hfPatientIdToDelete.Value;
            if (!string.IsNullOrEmpty(patientId))
            {
                DeletePatient(patientId);
                LoadPatientList();
            }
        }
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManagePatientDashboard.aspx");
        }
        private void ShowErrorMessage(string message)
        {
            // Implement your error message display logic here, e.g., using a Label or Literal control.
            lblErrorMessage.Text = message;
        }
    }
}
