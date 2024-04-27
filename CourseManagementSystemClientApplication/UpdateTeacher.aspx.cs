using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class UpdateTeacher : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["teacherId"] != null)
                {
                    int teacherid = Convert.ToInt32(Request.QueryString["teacherId"]);

                    TeacherService.TeacherServiceClient client = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
                    TeacherService.Teacher teacher = client.GetTeacherById(teacherid);

                    txtUsername.Text = teacher.Username;
                    txtPassword.Text = teacher.Password;
                    txtCity.Text = teacher.City;
                    txtState.Text = teacher.State;
                    txtPhoneNo.Text = teacher.PhoneNo;

                }
            }
        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string city = txtCity.Text;
            string state = txtState.Text;
            string mobileNumber = txtPhoneNo.Text;

            TeacherService.TeacherServiceClient client = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
            TeacherService.Teacher teacher = new TeacherService.Teacher
            {
                TeacherId = Convert.ToInt32(Request.QueryString["teacherId"]),
                Username = username,
                Password = password,
                City = city,
                State = state,
                PhoneNo = mobileNumber
            };

            bool success = client.UpdateTeacher(teacher);

            Response.Redirect("ManageTeachers.aspx");

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