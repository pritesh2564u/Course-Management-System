using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class UpdateCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("loginForm.aspx");
            }

            if (!IsPostBack)
            {
                if (Request.QueryString["courseId"] != null)
                {
                    int courseid = Convert.ToInt32(Request.QueryString["courseId"]);

                    CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
                    CourseService.Course course = client.GetCourseById(courseid);

                    txtName.Text = course.Name;
                    txtDescription.Text = course.Description;
                    txtCourseImage.Text = course.CourseImage;
                    txtCourseScope.Text = course.CourseScope;
                    txtPayment.Text = course.Payment.ToString();
                    txtTeacherId.Text = course.TeacherId.ToString();
                }
            }
        }

        protected void btnUpdateCourse_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string description = txtDescription.Text;
            string courseImage = txtCourseImage.Text;
            string courseScope = txtCourseScope.Text;

            decimal payment = Decimal.Parse(txtPayment.Text.Trim());

            int teacherid = Convert.ToInt32(txtTeacherId.Text);

            CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
            CourseService.Course course = new CourseService.Course
            {
                Name = name,
                Description = description,
                CourseImage = courseImage,
                CourseScope = courseScope,
                Payment = payment,
                TeacherId = teacherid
            };

            bool success = client.UpdateCourse(course);

            Response.Redirect("ManageCourses.aspx");

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