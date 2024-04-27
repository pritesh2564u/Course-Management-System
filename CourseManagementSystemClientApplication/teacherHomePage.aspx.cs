using CourseManagementSystemClientApplication.CourseService;
using CourseManagementSystemClientApplication.TeacherService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace CourseManagementSystemClientApplication
{
    public partial class teacherHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Teacher")
            {
                Response.Redirect("loginForm.aspx");
            }

            CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
            Course[] courseList = client.GetAllCourses();

            DisplayCourses(courseList);

        }

        protected void DisplayCourses(Course[] courses)
        {
            foreach (Course course in courses)
            {
                // Create a new HTML div element for each course
                HtmlGenericControl courseDiv = new HtmlGenericControl("div");
                courseDiv.Attributes["class"] = "flex flex-col justify-between gap-2 bg-white p-4 m-2 rounded-lg shadow-md";

                // Populate the course information
                courseDiv.InnerHtml = $@"
                    <img src='{course.CourseImage}' alt='{course.Name}' class='my-2 max-w-full h-auto' />
                    <h3 class='text-xl font-semibold'>{course.Name}</h3>
                    <p class='text-gray-600'>{course.Description}</p>
                    <p class='text-gray-600'>{course.CourseScope}</p>
                    <p class='text-blue-500'>Payment: {course.Payment}</p>
                ";

                // Add the courseDiv to the cardContainer
                cardContainer.Controls.Add(courseDiv);
            }
        }


        protected void Logout(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["Role"] != null)
            {
                Session["Username"] = null;
                Session["Role"] = null;
                Response.Redirect("teacherHomePage.aspx");
            }
        }
    }
}