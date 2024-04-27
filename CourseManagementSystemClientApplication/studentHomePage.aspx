<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="studentHomePage.aspx.cs" Inherits="CourseManagementSystemClientApplication.studentHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script src="https://cdn.tailwindcss.com"></script>

    <script>
        function filterCourses() {
            var searchInput = document.getElementById('searchInput').value.toLowerCase();
            var courses = document.getElementsByClassName('course');

            for (var i = 0; i < courses.length; i++) {
                var course = courses[i];
                var courseName = course.getAttribute('data-name').toLowerCase();
                var courseDescription = course.getAttribute('data-description').toLowerCase();

                if (courseName.includes(searchInput) || courseDescription.includes(searchInput)) {
                    course.style.display = 'flex';
                } else {
                    course.style.display = 'none';
                }
            }
        }
    </script>

</head>
<body class="bg-gray-200">
    <nav class="fixed top-0 left-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
        <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <div class="flex items-center gap-1 rounded-full px-4 bg-white text-gray-800 focus:outline-none focus:ring-2 focus:ring-blue-500">
                <i class="fa-solid fa-magnifying-glass"></i>
                <input type="text" id="searchInput" class="w-full rounded-full h-full p-2 border-none outline-none" placeholder="Search Courses..." oninput="filterCourses()" />
            </div>
            <ul class="flex space-x-4">
                <li>
                    <a href="MyCourses.aspx" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">My Courses</a>
                </li>
                <li>
                    <form id="logout" runat="server">
                        <asp:LinkButton ID="lnkLogout" runat="server" Text="Logout" CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300" OnClick="Logout" />
                    </form>
                </li>
            </ul>
        </div>
    </nav>

    <asp:Panel ID="cardContainer" runat="server" CssClass="grid grid-cols-4 mt-16 mb-16 p-4">
    </asp:Panel>

    <footer class="fixed bottom-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 py-4 mt-4">
     <div class="container mx-auto px-4">
         <div class="flex justify-between items-center">
             <p class="text-white">Course Management System &copy; 2024</p>
             <ul class="flex space-x-4">
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Privacy Policy</a>
                 </li>
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Terms of Service</a>
                 </li>
                 <li>
                     <a href="#" class="text-white hover:text-gray-300 transition duration-300">Contact Us</a>
                 </li>
             </ul>
         </div>
     </div>
    </footer>

    <!-- Add this modal at the end of the <body> tag -->
    <div id="enrollModal" class="fixed hidden inset-0 bg-black bg-opacity-50 flex items-center justify-center">
        <div class="bg-white p-8 rounded-lg">
            <span class="absolute top-4 right-4 cursor-pointer text-gray-600" onclick="closeEnrollModal">&times;</span>
            <h2 class="text-2xl font-bold mb-4">Confirm Enrollment</h2>
            <p class="mb-4">Are you sure you want to enroll in this course?</p>
            <button class="bg-green-500 text-white px-4 py-2 rounded-lg hover:bg-green-600 transition duration-300" onclick="enrollCourseConfirmation()">Enroll</button>
        </div>
    </div>

    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>


    <!-- Inside the <head> tag -->
    <script>
        var currentCourseId; // Variable to store the current course ID

        function openEnrollModal(courseId) {
            currentCourseId = courseId;
            document.getElementById('enrollModal').style.display = 'flex';
        }

        function closeEnrollModal() {
            document.getElementById('enrollModal').style.display = 'none';
        }

        function enrollCourseConfirmation() {
            // Call your enroll method here, passing the currentCourseId as a parameter
            enrollCourse(currentCourseId);

            // Close the modal after enrollment
            closeEnrollModal();
        }

        // Function to enroll the student in the course
        function enrollCourse(courseId) {
            $.ajax({
                type: "POST",
                url: "studentHomePage.aspx/EnrollStudentInCourse",
                data: JSON.stringify({ courseId: courseId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onEnrollSuccess,
                error: onEnrollFailure
            });
        }

        function onEnrollSuccess(result) {
            // Handle success, e.g., show a success message
            console.log('Enrollment successful');
        }

        function onEnrollFailure(error) {
            // Handle failure, e.g., show an error message
            console.error('Enrollment failed:', error);
        }
    </script>

</body>
</html>
