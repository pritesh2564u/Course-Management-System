using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class registerForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string city = txtCity.Text.Trim();
            string state = txtState.Text.Trim();
            string mobileNumber = txtMobileNumber.Text.Trim();
            string role = ddlRole.Text.Trim();

            bool success = false ;
            if(role == "Teacher")
            {
                TeacherService.Teacher teacher = new TeacherService.Teacher
                {
                    Username = username,
                    Password = password,
                    City = city,
                    State = state,
                    PhoneNo = mobileNumber  
                };
                TeacherService.TeacherServiceClient client = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
                success = client.AddTeacher(teacher);

            }
            else if(role == "Student")
            {
                StudentService.Student student = new StudentService.Student
                {
                    Username = username,
                    Password = password,
                    City = city,
                    State = state,
                    MobileNumber = mobileNumber
                };
                StudentService.StudentServiceClient client = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
                success = client.AddStudent(student);
            }
            
            if (success)
            {
                successDiv.Visible = true;
            }
            
        }
    }
}