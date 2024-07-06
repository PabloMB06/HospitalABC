using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;

namespace HospitalSystem
{
    public partial class AdminDoctorManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initial setup if needed
            }
        }

        protected void btnAddDoctor_Click(object sender, EventArgs e)
        {
            string doctorFilePath = Server.MapPath("~/DB/doctor.txt");

            // Collect data from form fields
            string firstName = txtFirstName.Text.Trim();
            string lastName1 = txtLastName1.Text.Trim();
            string lastName2 = txtLastName2.Text.Trim();
            string nic = txtNIC.Text.Trim();
            string civilStatus = ddlCivilStatus.SelectedValue;
            string birthDate = txtBirthDate.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string specialization = txtSpecialization.Text.Trim();
            string Address = txtAddress.Text.Trim();

            // Prepare doctor data line
            string doctorData = $"{firstName};{lastName1};{lastName2};{nic};{civilStatus};{birthDate};{phone};{email};{specialization};{Address};";

            // Append doctor data to file
            File.AppendAllText(doctorFilePath, Environment.NewLine + doctorData);

            // Clear form fields after adding doctor
            ClearFormFields();

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "showSuccessAlert('Doctor added successfully!');", true);
            Response.Redirect("AdminManageDoctorDashboard.aspx");
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminManageDoctorDashboard.aspx");
        }

        private void ClearFormFields()
        {
            txtFirstName.Text = string.Empty;
            txtLastName1.Text = string.Empty;
            txtLastName2.Text = string.Empty;
            txtNIC.Text = string.Empty;
            ddlCivilStatus.SelectedValue = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSpecialization.Text = string.Empty;
            txtAddress.Text = string.Empty;
        }
    }
}
