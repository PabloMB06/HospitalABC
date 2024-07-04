using System;
using System.IO;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class EditDoctorInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string doctorId = Request.QueryString["doctorId"]; // Adjust as per your URL structure
                LoadDoctorInfo(doctorId);
            }
        }

        private void LoadDoctorInfo(string doctorId)
        {
            string doctorFilePath = Server.MapPath("~/DB/doctors.txt"); // Adjust path as per your file structure

            if (File.Exists(doctorFilePath))
            {
                string[] lines = File.ReadAllLines(doctorFilePath);
                foreach (string line in lines)
                {
                    string[] doctorData = line.Split(';');
                    if (doctorData.Length > 4 && doctorData[0] == doctorId) // Adjust index and condition based on your data structure
                    {
                        txtFirstName.Text = doctorData[1];
                        txtLastName.Text = doctorData[2];
                        txtSpecialization.Text = doctorData[3];
                        txtEmail.Text = doctorData[4];
                        txtPhone.Text = doctorData[5];
                        txtAddress.Text = doctorData[6];
                        break;
                    }
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string doctorId = Request.QueryString["doctorId"]; // Adjust as per your URL structure
            string doctorFilePath = Server.MapPath("~/DB/doctors.txt"); // Adjust path as per your file structure

            if (File.Exists(doctorFilePath))
            {
                string[] lines = File.ReadAllLines(doctorFilePath);
                using (StreamWriter writer = new StreamWriter(doctorFilePath))
                {
                    foreach (string line in lines)
                    {
                        string[] doctorData = line.Split(';');
                        if (doctorData.Length > 4 && doctorData[0] == doctorId) // Adjust index and condition based on your data structure
                        {
                            string updatedLine = $"{doctorId};{txtFirstName.Text};{txtLastName.Text};{txtSpecialization.Text};{txtEmail.Text};{txtPhone.Text};{txtAddress.Text}";
                            writer.WriteLine(updatedLine);
                        }
                        else
                        {
                            writer.WriteLine(line);
                        }
                    }
                }
                lblMessage.Text = "Doctor info updated successfully.";
                lblMessage.Visible = true;
                Response.Redirect("DoctorList.aspx"); // Redirect to appropriate page
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorList.aspx"); // Redirect to appropriate page
        }
    }
}
