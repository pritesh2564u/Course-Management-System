using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace CourseManagementSystemClientApplication
{
    public partial class UpdateStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["studentId"] != null)
                {
                    int studentid = Convert.ToInt32(Request.QueryString["studentId"]);

                    StudentService.StudentServiceClient client = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
                    StudentService.Student student = client.GetStudentById(studentid);

                    txtUsername.Text = student.Username;
                    txtPassword.Text = student.Password;
                    txtCity.Text = student.City;
                    txtState.Text = student.State;
                    txtMobileNumber.Text = student.MobileNumber;
                }
            }
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string mobileNumber = txtMobileNumber.Text;

            StudentService.StudentServiceClient client = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
            StudentService.Student student = new StudentService.Student
            {
                StudentId = Convert.ToInt32(Request.QueryString["studentId"]),
                Username = username,
                Password = password,
                City = city,
                State = state,
                MobileNumber = mobileNumber
            };

            bool success = client.UpdateStudent(student);

            Response.Redirect("ManageStudents.aspx");

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