using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class adminPage : System.Web.UI.Page
    {
        [Obsolete]
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"]  == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }
        }

        protected void Logout(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["Role"] != null)
            {
                Session["Username"] = null;
                Session["Role"] = null;
                Response.Redirect("adminPage.aspx");
            }
        }
    }
}