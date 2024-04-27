using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class ManageTeachers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }

            if (!IsPostBack)
            {
                BindGridViewStudents();
            }
        }

        protected void BindGridViewStudents()
        {
            TeacherService.TeacherServiceClient client = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
            grdTeachers.DataSource = client.getAllTeachers();
            grdTeachers.DataBind();
        }

        protected void grdTeachers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;
            int teacherid = Convert.ToInt32(grdTeachers.DataKeys[rowIndex].Value);
            Response.Redirect("UpdateTeacher.aspx?teacherId=" + teacherid);
        }

        protected void grdTeachers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int teacherid = Convert.ToInt32(grdTeachers.DataKeys[rowIndex].Value);
            TeacherService.TeacherServiceClient client = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
            TeacherService.Teacher teacher = client.GetTeacherById(teacherid);

            bool success = client.DeleteTeacher(teacher);
            BindGridViewStudents();
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