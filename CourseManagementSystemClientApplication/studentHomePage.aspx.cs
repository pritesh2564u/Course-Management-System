using CourseManagementSystemClientApplication.CourseService;
using System;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace CourseManagementSystemClientApplication
{
    public partial class studentHomePage : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null || Session["Role"].ToString() != "Student")
            {
                Response.Redirect("loginForm.aspx");
            }

            username = Session["Username"].ToString();

            // Assuming you have a CourseServiceClient
            CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");

            Course[] allCourses = client.GetAllCourses();

            DisplayCourses(allCourses);
        }

        protected void DisplayCourses(Course[] courses)
        {
            CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
            StudentService.StudentServiceClient studentClient = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");

            int studentId = studentClient.GetStudentByUsername(username).StudentId;
            Course[] enrolledCourses = courseClient.GetAllCourseByStudentId(studentId);

            foreach (Course course in courses)
            {
                HtmlGenericControl courseDiv = new HtmlGenericControl("div");
                courseDiv.Attributes["class"] = "flex flex-col justify-between gap-3 bg-white p-4 m-2 rounded-lg shadow-md course";
                courseDiv.Attributes["data-name"] = course.Name.ToLower();
                courseDiv.Attributes["data-description"] = course.Description.ToLower();

                bool isEnrolled = enrolledCourses.Any(c => c.CourseId == course.CourseId);

                string buttonText = isEnrolled ? "Enrolled" : "Enroll";
                string buttonColor = isEnrolled ? "bg-blue-500" : "bg-green-500";

                courseDiv.InnerHtml = $@"
            <img src='{course.CourseImage}' alt='{course.Name}' class='my-2 max-w-full h-auto' />
            <h3 class='text-xl font-semibold'>{course.Name}</h3>
            <p class='text-gray-600'>{course.Description}</p>
            <p class='text-gray-600'>{course.CourseScope}</p>
            <p class='text-blue-500'>Payment: {course.Payment}</p>
            <button class='{buttonColor} text-white px-4 py-2 rounded-lg hover:{buttonColor}-600 transition duration-300' onclick='openEnrollModal({course.CourseId})'>
                {buttonText}
            </button>
        ";

                cardContainer.Controls.Add(courseDiv);
            }
        }


        private static string GetUsername()
        {
            if (HttpContext.Current.Session["Username"] != null)
            {
                return HttpContext.Current.Session["Username"].ToString();
            }
            return null; // or handle the case where username is not available
        }

        // Change the EnrollStudentInCourse method to be static
        [WebMethod]
        public static bool EnrollStudentInCourse(int courseId)
        {
            // Use the static GetUsername method
            string username = GetUsername();

            if (username != null)
            {
                StudentService.StudentServiceClient studentClient = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");
                int studentId = studentClient.GetStudentByUsername(username).StudentId;

                bool success = false;

                CourseService.CourseServiceClient courseClient = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
                success = courseClient.EnrollStudentInCourse(studentId, courseId);

                return success;
            }

            return false;
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
