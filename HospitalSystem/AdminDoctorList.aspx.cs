using HospitalSystem.Objects;
using System;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminDoctorList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verifica si se proporcionó un ID de doctor válido en la URL
                if (!string.IsNullOrEmpty(Request.QueryString["doctorId"]))
                {
                    string doctorId = Request.QueryString["doctorId"];
                    LoadDoctorData(doctorId);
                }
                else
                {
                    // Si no se proporciona un ID de doctor, redirige a AdminDashboard.aspx
                    Response.Redirect("AdminManageDoctorDashboard.aspx");
                }
            }
        }

        private void LoadDoctorData(string doctorId)
        {
            try
            {
                string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

                if (File.Exists(doctorFilePath))
                {
                    string[] doctorData = File.ReadAllLines(doctorFilePath);

                    foreach (string line in doctorData)
                    {
                        string[] doctorFields = line.Split(';');
                        if (doctorFields.Length >= 10 && doctorFields[3] == doctorId) // assuming the NIC is the unique identifier (doctorId)
                        {
                            Doctor doctor = new Doctor
                            {
                                Name = doctorFields[0],
                                LastName1 = doctorFields[1],
                                LastName2 = doctorFields[2],
                                NIC = doctorFields[3],
                                CivilStatus = doctorFields[4],
                                BirthDate = doctorFields[5],
                                Phone = doctorFields[6],
                                Email = doctorFields[7],
                                Specialty = doctorFields[8],
                                Address = doctorFields[9]
                            };

                            CreateTable(doctor);
                            return;
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
                ShowErrorMessage($"An error occurred while loading doctor data: {ex.Message}");
            }

            // Si no se encuentra el doctor con el ID proporcionado, muestra un mensaje de error
            ShowErrorMessage("Doctor not found.");
        }

        private void CreateTable(Doctor doctor)
        {
            Table table = new Table { CssClass = "table table-bordered mb-4" };

            AddTableRow(table, "Name", doctor.Name);
            AddTableRow(table, "Last Name 1", doctor.LastName1);
            AddTableRow(table, "Last Name 2", doctor.LastName2);
            AddTableRow(table, "NIC", doctor.NIC);
            AddTableRow(table, "Civil Status", doctor.CivilStatus);
            AddTableRow(table, "Birth Date", doctor.BirthDate);
            AddTableRow(table, "Phone", doctor.Phone);
            AddTableRow(table, "Email", doctor.Email);
            AddTableRow(table, "Specialty", doctor.Specialty);
            AddTableRow(table, "Residency", doctor.Address);

            phDoctorTable.Controls.Add(table);
        }

        private void AddTableRow(Table table, string header, string value)
        {
            TableRow row = new TableRow();
            TableCell cellHeader = new TableCell { Text = header, CssClass = "fw-bold" };
            TableCell cellValue = new TableCell { Text = value };

            row.Cells.Add(cellHeader);
            row.Cells.Add(cellValue);
            table.Rows.Add(row);
        }

        private void ShowErrorMessage(string message)
        {
            phDoctorTable.Controls.Add(new LiteralControl($"<p class='text-danger'>{message}</p>"));
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageDoctorDashboard.aspx");
        }
    }
}
