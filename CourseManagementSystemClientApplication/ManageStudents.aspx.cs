using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class ManageStudents : System.Web.UI.Page
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
            StudentService.StudentServiceClient client = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
            grdStudents.DataSource = client.GetAllStudents();
            grdStudents.DataBind();
        }

        protected void grdStudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int rowIndex = e.NewEditIndex;
            int studentid = Convert.ToInt32(grdStudents.DataKeys[rowIndex].Value);
            Response.Redirect("UpdateStudent.aspx?studentId=" + studentid);
        }

        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int studentid = Convert.ToInt32(grdStudents.DataKeys[rowIndex].Value);
            StudentService.StudentServiceClient client = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
            StudentService.Student student = client.GetStudentById(studentid);

            bool success = client.DeleteStudent(student);
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