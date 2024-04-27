using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;
using System.Security.Policy;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;

namespace CourseManagementSystem
{
    public class AdminService : IAdminService
    {
        string connection = "Data Source=DESKTOP-MK54KU3;Initial Catalog=CourseManagementSystem;Integrated Security=True";
        public Admin GetAdminByUsername(string username)
        {
            Admin admin = null;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select  * from Admin where Username = @Username", con);

                cmd.Parameters.AddWithValue("@Username", username);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    admin = new Admin
                    {
                        AdminId = Convert.ToInt32(reader["AdminId"]),
                        Username = Convert.ToString(reader["Username"]),
                        Password = Convert.ToString(reader["Password"])
                    };

                }
            }

            return admin;
        }

        public List<Admin> GetAllAdmins()
        {
            List<Admin> admins = new List<Admin>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Admin", con);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Admin admin = new Admin
                    {
                        AdminId = Convert.ToInt32(reader["AdminId"]),
                        Username = Convert.ToString(reader["Username"]),
                        Password = Convert.ToString(reader["Password"])
                    };

                    admins.Add(admin);
                }
            }

            return admins;
        }

        public bool LoginAdmin(string username, string password)
        {
            bool adminLogin = false;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select count(*) from Admin where Username = @Username and Password = @Password", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                int result = Convert.ToInt32(cmd.ExecuteScalar());
                if (result > 0)
                {
                    adminLogin = true;
                }
            }

            return adminLogin;
        }

    }

    public class CourseService : ICourseService
    {
        string connection = "Data Source=DESKTOP-MK54KU3;Initial Catalog=CourseManagementSystem;Integrated Security=True";

        public Course GetCourseById(int id)
        {
            Course course = null;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE CourseId = @CourseId", con))
                {
                    cmd.Parameters.AddWithValue("@CourseId", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            course = new Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CourseImage = reader["CourseImage"].ToString(),
                                CourseScope = reader["CourseScope"].ToString(),
                                Payment = Convert.ToDecimal(reader["Payment"]),
                                TeacherId = Convert.ToInt32(reader["TeacherId"])
                            };
                        }
                    }
                }
            }
            return course;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Course", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CourseImage = reader["CourseImage"].ToString(),
                                CourseScope = reader["CourseScope"].ToString(),
                                Payment = Convert.ToDecimal(reader["Payment"]),
                                TeacherId = Convert.ToInt32(reader["TeacherId"])
                            };
                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;
        }

        public List<Course> GetAllCourseByTeacherId(int teacherId)
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Course WHERE TeacherId = @TeacherId", con))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CourseImage = reader["CourseImage"].ToString(),
                                CourseScope = reader["CourseScope"].ToString(),
                                Payment = Convert.ToDecimal(reader["Payment"]),
                                TeacherId = Convert.ToInt32(reader["TeacherId"])
                            };

                            courses.Add(course);
                        }
                    }
                }
            }
            return courses;

        }

        public List<Course> GetAllCourseByStudentId(int studentId)
        {
            List<Course> courses = new List<Course>();

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = @"SELECT c.*
                        FROM Course c
                        INNER JOIN StudentCourse cs ON c.CourseId = cs.CourseId
                        WHERE cs.StudentId = @StudentId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Course course = new Course
                            {
                                CourseId = Convert.ToInt32(reader["CourseId"]),
                                Name = reader["Name"].ToString(),
                                Description = reader["Description"].ToString(),
                                CourseImage = reader["CourseImage"].ToString(),
                                CourseScope = reader["CourseScope"].ToString(),
                                Payment = Convert.ToDecimal(reader["Payment"]),
                                TeacherId = Convert.ToInt32(reader["TeacherId"])
                            };

                            courses.Add(course);
                        }
                    }
                }
            }

            return courses;
        }
        
        public bool AddCourse(Course course)
        {
            bool teacherExist = false;


            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = @"INSERT INTO Course (Name, Description, CourseImage, CourseScope, Payment, TeacherId)
                             VALUES (@Name, @Description, @CourseImage, @CourseScope, @Payment, @TeacherId)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", course.Name);
                    cmd.Parameters.AddWithValue("@Description", course.Description);
                    cmd.Parameters.AddWithValue("@CourseImage", course.CourseImage);
                    cmd.Parameters.AddWithValue("@CourseScope", course.CourseScope);
                    cmd.Parameters.AddWithValue("@Payment", course.Payment);
                    cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);

                    cmd.ExecuteNonQuery();
                    teacherExist = true;
                }
            }
            return teacherExist;
        }

        private bool TeacherExists(int teacherId, string connection)
        {
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Teacher WHERE TeacherId = @TeacherId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", teacherId);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public bool UpdateCourse(Course course)
        {
            bool updatedCourse = false;
            if (CourseExists(course.CourseId, connection))
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    string query = @"UPDATE Course 
                             SET Name = @Name, 
                                 Description = @Description, 
                                 CourseImage = @CourseImage, 
                                 CourseScope = @CourseScope, 
                                 Payment = @Payment, 
                                 TeacherId = @TeacherId 
                             WHERE CourseId = @CourseId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Name", course.Name);
                        cmd.Parameters.AddWithValue("@Description", course.Description);
                        cmd.Parameters.AddWithValue("@CourseImage", course.CourseImage);
                        cmd.Parameters.AddWithValue("@CourseScope", course.CourseScope);
                        cmd.Parameters.AddWithValue("@Payment", course.Payment);
                        cmd.Parameters.AddWithValue("@TeacherId", course.TeacherId);
                        cmd.Parameters.AddWithValue("@CourseId", course.CourseId);

                        cmd.ExecuteNonQuery();
                        updatedCourse = true;
                    }
                }
            }
            return updatedCourse;
        }

        private bool CourseExists(int courseId, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Course WHERE CourseId = @CourseId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@CourseId", courseId);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public bool DeleteCourse(int courseId)
        {
            bool deletedCourse = false;

            if (CourseExists(courseId, connection))
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    string query = "DELETE FROM Course WHERE CourseId = @CourseId";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@CourseId", courseId);

                        cmd.ExecuteNonQuery();
                        deletedCourse = true;
                    }
                }
            }

            return deletedCourse;
        }

        private bool StudentExists(int studentId, string connectionString)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT COUNT(*) FROM Student WHERE StudentId = @StudentId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

        public bool EnrollStudentInCourse(int studentId, int courseId)
        {
            bool studentenrolled = false;

            if (StudentExists(studentId, connection) && CourseExists(courseId, connection))
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();

                    string insertQuery = "INSERT INTO StudentCourse (StudentId, CourseId) VALUES (@StudentId, @CourseId)";

                    using (SqlCommand cmdInsert = new SqlCommand(insertQuery, con))
                    {
                        cmdInsert.Parameters.AddWithValue("@StudentId", studentId);
                        cmdInsert.Parameters.AddWithValue("@CourseId", courseId);

                        cmdInsert.ExecuteNonQuery();
                        studentenrolled = true;
                    }
                }
            }
            return studentenrolled;
            
        }



    }

    public class StudentService : IStudentService
    {
        string connection = "Data Source=DESKTOP-MK54KU3;Initial Catalog=CourseManagementSystem;Integrated Security=True";
        public bool AddStudent(Student student)
        {
            bool registeredStudent = false;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("insert into Student(Username, Password, City , State , MobileNumber) values (@Username, @Password, @City, @State, @MobileNumber)", con))
                {
                    cmd.Parameters.AddWithValue("@Username", student.Username);
                    cmd.Parameters.AddWithValue("@Password", student.Password);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@State", student.State);
                    cmd.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);

                    int result = cmd.ExecuteNonQuery();

                    registeredStudent = (result > 0) ; 
                }
            }

            return registeredStudent;
        }

        public bool DeleteStudent(Student student)
        {
            bool deletestudent = false ;
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Student where StudentId = @StudentId", con))
                {

                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if(rowsAffected == 1)
                    {
                        deletestudent = true;
                    }
                }
            }
            return deletestudent;
        }

        public Student GetStudentByUsername(string username)
        {
            Student student = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT * FROM Student WHERE Username = @Username";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                Username = Convert.ToString(reader["Username"]),
                                City = Convert.ToString(reader["City"]),
                                State = Convert.ToString(reader["State"]),
                                MobileNumber = Convert.ToString(reader["MobileNumber"])
                            };
                        }
                    }
                }
            }

            return student;
        }

        public Student GetStudentById(int studentId)
        {
            Student student = null;
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                string query = "SELECT * FROM Student WHERE StudentId = @studentId";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@studentId", studentId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            student = new Student
                            {
                                StudentId = Convert.ToInt32(reader["StudentId"]),
                                Username = Convert.ToString(reader["Username"]),
                                City = Convert.ToString(reader["City"]),
                                State = Convert.ToString(reader["State"]),
                                MobileNumber = Convert.ToString(reader["MobileNumber"])
                            };
                        }
                    }
                }
            }

            return student;
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using(SqlCommand cmd = new SqlCommand("select * from Student", con))
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Student student = new Student
                        {
                            StudentId = Convert.ToInt32(reader["StudentId"]),
                            Username = Convert.ToString(reader["Username"]),
                            City = Convert.ToString(reader["City"]),
                            State = Convert.ToString(reader["State"]),
                            MobileNumber = Convert.ToString(reader["MobileNumber"])
                        };

                        students.Add(student);
                    }
                }
            }

            return students;
        }

        public bool LoginStudent(string username, string password)
        {

            bool loginStudent = false;

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from Student where Username = @Username and Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());
                    if (result == 1)
                    {
                        loginStudent = true;
                    }
                    else
                    {
                        loginStudent = false;
                    }
                }
            }

            return loginStudent;
        }

        public bool UpdateStudent(Student student)
        {
            bool updateStudent = true;

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Student SET Username = @Username, Password = @Password, City = @City, State = @State, MobileNumber = @MobileNumber WHERE StudentId = @StudentId", con))
                {

                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@Username", student.Username);
                    cmd.Parameters.AddWithValue("@Password", student.Password);
                    cmd.Parameters.AddWithValue("@City", student.City);
                    cmd.Parameters.AddWithValue("@State", student.State);
                    cmd.Parameters.AddWithValue("@MobileNumber", student.MobileNumber);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        updateStudent = false;
                    }
                }
            }
            return updateStudent;
        }
    }

    public class TeacherService : ITeacherService
    {
        string connection = "Data Source=DESKTOP-MK54KU3;Initial Catalog=CourseManagementSystem;Integrated Security=True";

        public bool AddTeacher(Teacher teacher)
        {
            bool registeredTeacher = false;

            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO Teacher(Username, Password, City, State, PhoneNo) VALUES (@Username, @Password, @City, @State, @PhoneNo)", con))
                    {
                        cmd.Parameters.AddWithValue("@Username", teacher.Username);
                        cmd.Parameters.AddWithValue("@Password", teacher.Password);
                        cmd.Parameters.AddWithValue("@City", teacher.City);
                        cmd.Parameters.AddWithValue("@State", teacher.State);
                        cmd.Parameters.AddWithValue("@PhoneNo", teacher.PhoneNo);

                        int result = cmd.ExecuteNonQuery();

                        registeredTeacher = (result == 1);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Not able to add Teacher: ",ex.Message);
                registeredTeacher=false;
            }
            
            return registeredTeacher;
        }

        public List<Teacher> getAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Teacher", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Teacher teacher = new Teacher
                            {
                                TeacherId = Convert.ToInt32(reader["TeacherId"]),
                                Username = reader["Username"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PhoneNo = reader["PhoneNo"].ToString()
                            };

                            teachers.Add(teacher);
                        }
                    }
                }
            }
            return teachers;
        }

        public bool DeleteTeacher(Teacher teacher)
        {
            bool deleteTeacher = false;

            using(SqlConnection con = new SqlConnection())
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("delete from Teacher where TeacherId = @TeacherId", con))
                {

                    cmd.Parameters.AddWithValue("@TeacherId", teacher.TeacherId);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if(rowsAffected == 1)
                    {
                        deleteTeacher = true;
                    }
                }
            }
            return deleteTeacher;
        }

        public Teacher GetTeacherByUsername(string username)
        {
            Teacher teacher = null;

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select  * from Teacher where Username = @Username", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacher = new Teacher
                            {
                                TeacherId = Convert.ToInt32(reader["TeacherId"]),
                                Username = reader["Username"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PhoneNo = reader["PhoneNo"].ToString()
                            };

                        }
                    }
                }
            }

            return teacher;
        }

        public Teacher GetTeacherById(int teacherId)
        {
            Teacher teacher = null;

            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select  * from Teacher where TeacherId = @teacherId", con))
                {
                    cmd.Parameters.AddWithValue("@teacherId", teacherId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            teacher = new Teacher
                            {
                                TeacherId = Convert.ToInt32(reader["TeacherId"]),
                                Username = reader["Username"].ToString(),
                                City = reader["City"].ToString(),
                                State = reader["State"].ToString(),
                                PhoneNo = reader["PhoneNo"].ToString()
                            };

                        }
                    }
                }
            }

            return teacher;
        }

        public bool LoginTeacher(string username, string password)
        {
            bool teacherLogin = false;
            
            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Teacher WHERE Username = @Username AND Password = @Password", con))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    int result = Convert.ToInt32(cmd.ExecuteScalar());

                    if (result > 0)
                    {
                        teacherLogin = true;
                    }
                }
            }
            return teacherLogin;
        }

        public bool UpdateTeacher(Teacher teacher)
        {
            bool updatedTeacher = true;

            using(SqlConnection con = new SqlConnection(connection))
            {
                con.Open();

                using (SqlCommand cmd = new SqlCommand("UPDATE Teacher SET Username = @Username, Password = @Password, City = @City, State = @State, MobileNumber = @MobileNumber WHERE TeacherId = @TeacherId", con))
                {
                    cmd.Parameters.AddWithValue("@TeacherId", teacher.TeacherId);
                    cmd.Parameters.AddWithValue("@Username", teacher.Username);
                    cmd.Parameters.AddWithValue("@Password", teacher.Password); // Consider security implications
                    cmd.Parameters.AddWithValue("@City", teacher.City);
                    cmd.Parameters.AddWithValue("@State", teacher.State);
                    cmd.Parameters.AddWithValue("@MobileNumber", teacher.PhoneNo);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        updatedTeacher = true;
                    }
                }
            }
            return updatedTeacher;
        }
    }
}


