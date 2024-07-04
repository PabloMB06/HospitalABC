using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminManageDoctorDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoAddDoctor_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminDoctorManagement.aspx");
        }

        protected void btnDoctorList_Click(object sender, EventArgs e)
        {
            Response.Redirect("DoctorList.aspx");
        }
    }
}