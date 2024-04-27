<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminPage.aspx.cs" Inherits="CourseManagementSystemClientApplication.adminPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha384-gKT3ykyNtYyI+YIj2NJvoa5CCz4XV7g/PRCpAAzFfDkYY0aN1OcJ8EdE7C8YjlCN" crossorigin="anonymous">


     <script src="https://cdn.tailwindcss.com"></script>
</head>
<body>
    <nav class="bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
        <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <ul class="flex space-x-4">
                <li>
                    <a href="AddNewCourse.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Courses</a>
                </li>
                <li>
                    <a href="ManageStudents.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Students</a>
                </li>
                <li>
                    <a href="ManageTeachers.aspx" runat="server" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Manage Teachers</a>
                </li>
                <li>
                    <form id="logout" runat="server">
                        <asp:LinkButton ID="lnkLogout" runat="server" Text="Logout" CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300" OnClick="Logout" />
                    </form>
                </li>
            </ul>
        </div>
    </nav>

    <footer class="bg-gradient-to-r fixed bottom-0 from-blue-500 to-blue-700 py-4 mt-4">
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
</body>
</html>
