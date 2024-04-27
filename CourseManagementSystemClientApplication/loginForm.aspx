<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginForm.aspx.cs" Inherits="CourseManagementSystemClientApplication.loginForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" integrity="sha384-gKT3ykyNtYyI+YIj2NJvoa5CCz4XV7g/PRCpAAzFfDkYY0aN1OcJ8EdE7C8YjlCN" crossorigin="anonymous">


    <script src="https://cdn.tailwindcss.com"></script>
    <script>
        function togglePasswordVisibility() {
            var passwordInput = document.getElementById("password");
            passwordInput.type === "password" ? passwordInput.type = "text" : passwordInput.type = "password";
        }
    </script>
</head>
<body class="bg-gray-200">
    <nav class="fixed top-0 left-0 w-full bg-gradient-to-r from-blue-500 to-blue-700 shadow-lg h-16">
        <div class="container mx-auto px-4 py-2 flex justify-between items-center h-full">
            <a href="#" class="text-xl font-bold text-white hover:text-gray-100 transition duration-300">Course Management System</a>
            <ul class="flex space-x-4">
                <li>
                    <a href="#" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Login</a>
                </li>
                <li>
                    <a href="registerForm.aspx" class="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300">Register</a>
                </li>
            </ul>
        </div>
    </nav>
    <div class="pt-20 flex justify-center items-center">
        <div class="bg-white shadow-md rounded-lg px-8 py-10 max-w-md w-full">
            <h2 class="text-center text-3xl font-bold text-gray-800 mb-8"> Login </h2>
            <form id="studentRegistrationForm" runat="server">
                <div class="mb-4">
                    <label for="txtUsername" class="block text-gray-700 text-sm font-bold mb-2">Username:</label>
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your username" required />
                </div>
                <div class="mb-4">
                    <label for="txtPassword" class="block text-gray-700 text-sm font-bold mb-2">Password:</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-input w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300" Placeholder="Enter your password" required />
                </div>
                <div class="mb-4">
                    <label for="ddlRole" class="block text-gray-700 text-sm font-bold mb-2">Role:</label>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500 border border-gray-300">
                        <asp:ListItem Text="Admin" Value="Admin" />
                        <asp:ListItem Text="Student" Value="Student" />
                        <asp:ListItem Text="Teacher" Value="Teacher" />
                    </asp:DropDownList>
                </div>

                <div class="flex justify-center">
                    <asp:Button ID="BtnLogin" runat="server" Text="Login" CssClass="cursor-pointer bg-gradient-to-r from-blue-500 to-blue-700 hover:from-blue-700 hover:to-blue-900 text-white px-6 py-3 rounded-lg shadow-lg focus:outline-none focus:ring focus:border-blue-500 transition-all duration-300 ease-in-out" OnClick="BtnLogin_click" />
                </div>
            </form>
            <div class="flex justify-center mt-2">
                <span>Don't have an account? <a href="registerForm.aspx" class="text-blue-800">Register now</a></span>
            </div>
            <div runat="server" id="errorDiv" class="error-message bg-red-200 text-red-800 border border-red-500 px-4 py-2 rounded-lg mt-4 mb-4" visible="false">
                <span>Incorrect username or password</span>
            </div>
        </div>
    </div>
    <footer class="bg-gradient-to-r from-blue-500 to-blue-700 py-4 mt-4">
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
