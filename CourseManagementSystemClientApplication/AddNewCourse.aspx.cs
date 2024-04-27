using System;
using System.Data.SqlClient;
using System.Configuration;
using CourseManagementSystemClientApplication.CourseService;
using CourseManagementSystemClientApplication.TeacherService;

namespace CourseManagementSystemClientApplication
{
    public partial class AddNewCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            
                string courseName = txtName.Text.Trim();
                string description = txtDescription.Text.Trim();
                string courseImage = txtCourseImage.Text.Trim();
                string courseScope = txtCourseScope.Text.Trim();
                decimal paymentAmount = Decimal.Parse(txtPayment.Text.Trim());

                TeacherService.TeacherServiceClient teacher = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");
                string username = Session["Username"].ToString();
                int teacherId = teacher.GetTeacherByUsername(username).TeacherId;

                Console.WriteLine(teacherId);

                bool success = false;

                CourseService.Course course = new CourseService.Course
                {
                    Name = courseName,
                    Description = description,
                    CourseImage = courseImage,
                    CourseScope = courseScope,
                    Payment = paymentAmount,
                    TeacherId = teacherId,
            };

                CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
                success = client.AddCourse(course);

                if (success)
                {
                    successDiv.Visible = true;
                }

            
        }
    }
}
