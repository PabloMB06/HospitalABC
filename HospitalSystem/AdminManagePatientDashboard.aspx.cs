using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalSystem
{
    public partial class AdminManagePatientDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGoAddPatient_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPatientManagement.aspx");
        }

        protected void btnPatientList_Click(object sender, EventArgs e)
        {
            Response.Redirect("FileList.aspx");
        }
    }
}