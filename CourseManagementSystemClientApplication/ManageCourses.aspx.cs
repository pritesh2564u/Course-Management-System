using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class ManageCourses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }

            if (!IsPostBack)
            {
                BindGridViewCourses();
            }
        }

        protected void BindGridViewCourses()
        {
            CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
            grdCourses.DataSource = client.GetAllCourses();
            grdCourses.DataBind();
        }

        protected void grdCourses_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;
            int courseid = Convert.ToInt32(grdCourses.DataKeys[rowIndex].Value);
            Response.Redirect("UpdateCourse.aspx?courseId=" + courseid);
        }

        protected void grdCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int courseid = Convert.ToInt32(grdCourses.DataKeys[rowIndex].Value);
            CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");

            bool success = client.DeleteCourse(courseid);
            BindGridViewCourses();
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