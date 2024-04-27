using CourseManagementSystemClientApplication.CourseService;
using System;
using System.Linq;
using System.Web.ModelBinding;
using System.Web.Services;
using System.Web.UI.HtmlControls;

namespace CourseManagementSystemClientApplication
{
    public partial class MyCourses : System.Web.UI.Page
    {
        string teacherUsername, studentUsername;

        int teacherId, studentId;
        public int TeacherId
        {
            get { return teacherId; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null && Session["Role"].ToString() == "Teacher")
            {
                teacherUsername = Session["Username"].ToString();

                CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
                TeacherService.TeacherServiceClient teacherClient = new TeacherService.TeacherServiceClient("NetTcpBinding_ITeacherService");

                teacherId = teacherClient.GetTeacherByUsername(teacherUsername).TeacherId;

                Course[] teacherCourses = client.GetAllCourses().Where(c => c.TeacherId == teacherClient.GetTeacherByUsername(teacherUsername).TeacherId).ToArray();

                DisplayCourses(teacherCourses);
            }
            else if (Session["Username"] != null && Session["Role"].ToString() == "Student")
            {
                studentUsername = Session["Username"].ToString();

                CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");
                StudentService.StudentServiceClient studentClient = new StudentService.StudentServiceClient("NetTcpBinding_IStudentService");

                studentId = studentClient.GetStudentByUsername(studentUsername).StudentId;

                Course[] studentCourses = client.GetAllCourseByStudentId(studentId).ToArray();

                DisplayStudentCourses(studentCourses);
            }
            else
            {
                Response.Redirect("loginForm.aspx");
            }
        }

        protected void DisplayStudentCourses(Course[] courses)
        {
            foreach (Course course in courses)
            {
                HtmlGenericControl courseDiv = new HtmlGenericControl("div");
                courseDiv.Attributes["class"] = "flex flex-col gap-3 bg-white p-4 m-2 rounded-lg shadow-md";

                courseDiv.InnerHtml = $@"
            <img src='{course.CourseImage}' alt='{course.Name}' class='my-2 max-w-full h-auto' />
            <h3 class='text-xl font-semibold'>{course.Name}</h3>
            <p class='text-gray-600'>{course.Description}</p>
            <p class='text-gray-600'>{course.CourseScope}</p>
            <p class='text-blue-500'>Payment: {course.Payment}</p>
        ";

                courseDiv.InnerHtml += $@"
            <button class='bg-red-500 text-white px-4 py-2 rounded-lg hover:bg-red-600 transition duration-300' onclick='enrollCourse({course.CourseId})'>
                Unenroll
            </button>
        ";

                cardContainer.Controls.Add(courseDiv);
            }
        }


        protected void DisplayCourses(Course[] courses)
        {
            bool isTeacher = Session["Role"].ToString() == "Teacher";

            foreach (Course course in courses)
            {
                HtmlGenericControl courseDiv = new HtmlGenericControl("div");
                courseDiv.Attributes["class"] = "flex flex-col justify-between gap-3 bg-white p-4 m-2 rounded-lg shadow-md";

                courseDiv.InnerHtml = $@"
                    <img src='{course.CourseImage}' alt='{course.Name}' class='my-2 max-w-full h-auto' />
                    <h3 class='text-xl font-semibold'>{course.Name}</h3>
                    <p class='text-gray-600'>{course.Description}</p>
                    <p class='text-gray-600'>{course.CourseScope}</p>
                    <p class='text-blue-500'>Payment: {course.Payment}</p>
                ";

                if (isTeacher)
                {
                    courseDiv.InnerHtml += $@"
                        <div class='flex gap-2'>
                            <button class='bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300' onclick='showEditModal({course.CourseId})'>Edit</button>
                            <button class='mt-3 w-full inline-flex justify-center rounded-md border border-red-600 shadow-sm px-4 py-2 bg-red-600 text-base font-medium text-white hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500 sm:mt-0 sm:ml-3 sm:w-auto sm:text-sm' onclick='showDeleteModal({course.CourseId})'>
                                Delete
                            </button>
                        </div>
                    ";
                }

                cardContainer.Controls.Add(courseDiv);
            }
        }


        [WebMethod]
        public static bool DeleteCourse(int courseId)
        {
            try
            {
                CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");

                bool success = client.DeleteCourse(courseId);

                return success;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [WebMethod]
        public static bool EditCourse(int courseId, string courseName, string description, string courseImage, string courseScope, decimal payment, int teacherId)
        {
            try
            {
                CourseService.CourseServiceClient client = new CourseService.CourseServiceClient("NetTcpBinding_ICourseService");

                Course existingCourse = client.GetCourseById(courseId);

                existingCourse.Name = courseName;
                existingCourse.Description = description;
                existingCourse.CourseImage = courseImage;
                existingCourse.CourseScope = courseScope;
                existingCourse.Payment = payment;
                existingCourse.TeacherId = teacherId;

                bool updateResult = client.UpdateCourse(existingCourse);

                return updateResult;
            }
            catch (Exception ex)
            {
                return false;
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
