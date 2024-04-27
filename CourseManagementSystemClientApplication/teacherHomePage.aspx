<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="teacherHomePage.aspx.cs" Inherits="CourseManagementSystemClientApplication.teacherHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script src="https://cdn.tailwindcss.com"></script>
</head>
<body class="bg-gray-200">
    <nav class="fixed top-0 left-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16 w-full fixed top-0">
        <div class="flex justify-between items-center h-full px-4">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <ul class="flex space-x-4">
                <li>
                    <a href="AddNewCourse.aspx" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Add New Course</a>
                </li>
                <li>
                    <a href="MyCourses.aspx" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">My Courses</a>
                </li>
                <li>
                    <form id="logout3" runat="server">
                        <asp:LinkButton ID="lnkLogout" runat="server" Text="Logout" CssClass="cursor-pointer bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300" OnClick="Logout" />
                    </form>
                </li>
            </ul>
        </div>
    </nav>
    <asp:Panel ID="cardContainer" runat="server" CssClass="grid grid-cols-4 mt-16 mb-16 p-4">
    </asp:Panel>
    <footer class="bg-gradient-to-r from-blue-500 to-blue-700 py-4 mt-4 w-full fixed bottom-0">
        <div class="flex justify-between items-center px-4 text-white">
            <p>Course Management System &copy; 2024</p>
            <ul class="flex space-x-4">
                <li>
                    <a href="#" class="hover:text-gray-300">Privacy Policy</a>
                </li>
                <li>
                    <a href="#" class="hover:text-gray-300">Terms of Service</a>
                </li>
                <li>
                    <a href="#" class="hover:text-gray-300">Contact Us</a>
                </li>
            </ul>
        </div>
    </footer>
</body>
</html>
