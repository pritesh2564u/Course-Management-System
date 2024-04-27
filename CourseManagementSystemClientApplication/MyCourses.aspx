<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyCourses.aspx.cs" Inherits="CourseManagementSystemClientApplication.MyCourses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>My Courses</title>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0-beta3/css/all.min.css" />
    <script src="https://cdn.tailwindcss.com"></script>

   <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <script>
        var currentCourseId;

        function showDeleteModal(courseId) {
            currentCourseId = courseId;
            document.getElementById('deleteConfirmationModal').classList.remove('hidden');
            document.getElementById('deleteConfirmationModal').classList.add('block');
        }

        function closeDeleteModal() {
            document.getElementById('deleteConfirmationModal').classList.remove('block');
            document.getElementById('deleteConfirmationModal').classList.add('hidden');
        }

        function confirmDelete() {
            $.ajax({
                type: "POST",
                url: "MyCourses.aspx/DeleteCourse",
                data: JSON.stringify({ courseId: currentCourseId }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onDeleteSuccess,
                error: onDeleteFailure
            });
        }

        function onDeleteSuccess(result) {
            closeDeleteModal();
            location.reload();
        }

        function onDeleteFailure(error) {
            console.error('Delete failed:', error);
        }

        function showEditModal(courseId) {
            currentCourseId = courseId;

            // Show the edit modal
            document.getElementById('editCourseModal').classList.remove('hidden');
            document.getElementById('editCourseModal').classList.add('block');
        }

        function closeEditModal() {
            document.getElementById('editCourseModal').classList.remove('block');
            document.getElementById('editCourseModal').classList.add('hidden');
        }

        function saveEdit() {
            var editName = document.getElementById('editName').value;
            var editDescription = document.getElementById('editDescription').value;
            var editCourseImage = document.getElementById('editCourseImage').value;
            var editCourseScope = document.getElementById('editCourseScope').value;
            var editPayment = document.getElementById('editPayment').value;

            var teacherId = <%= TeacherId %>;

            $.ajax({
                type: "POST",
                url: "MyCourses.aspx/EditCourse",
                data: JSON.stringify({
                    courseId: currentCourseId,
                    courseName: editName,
                    description: editDescription,
                    courseImage: editCourseImage,
                    courseScope: editCourseScope,
                    payment: editPayment,
                    teacherId: teacherId // Replace with the actual teacher ID
                }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: onEditSuccess,
                error: onEditFailure
            });
        }

        function onEditSuccess(result) {
            closeEditModal();
            location.reload();
        }

        function onEditFailure(error) {
            console.error('Edit failed:', error);
        }
    </script>


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
                    <form id="logout" runat="server">
                        <asp:LinkButton ID="lnkLogout" runat="server" Text="Logout" CssClass="bg-blue-500 text-white px-4 py-2 rounded-lg hover:bg-blue-600 transition duration-300" OnClick="Logout" />
                    </form>
                </li>
            </ul>
        </div>
    </nav>
    <asp:Panel ID="cardContainer" runat="server" CssClass="grid grid-cols-4 mt-16 p-4 mb-16">
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
    <div class="fixed z-10 inset-0 overflow-y-auto hidden" id="deleteConfirmationModal">
        <div class="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
        <div class="fixed inset-0 transition-opacity" aria-hidden="true">
            <div class="absolute inset-0 bg-gray-500 opacity-75"></div>
        </div>

        <!-- This element is to trick the browser into centering the modal contents. -->
        <span class="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>

        <div class="inline-block align-bottom bg-white rounded-lg text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full">
            <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
                <div class="sm:flex sm:items-start">
                    <div class="mt-3 text-center sm:mt-0 sm:ml-4 sm:text-left">
                        <h3 class="text-lg leading-6 font-medium text-gray-900" id="modal-title">
                            Confirm Deletion
                        </h3>
                        <div class="mt-2">
                            <p class="text-sm text-gray-500">
                                Are you sure you want to delete this course?
                            </p>
                        </div>
                    </div>
                </div>
            </div>
            <div class="bg-gray-50 px-4 py-3 sm:px-6 sm:flex sm:flex-row-reverse">
                <button type="button" class="w-full inline-flex justify-center rounded-md border border-transparent shadow-sm px-4 py-2 bg-red-600 text-base font-medium text-white hover:bg-red-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-red-500 sm:ml-3 sm:w-auto sm:text-sm" onclick="confirmDelete()">
                    Delete
                </button>
                <button type="button" class="mt-3 w-full inline-flex justify-center rounded-md border border-gray-300 shadow-sm px-4 py-2 bg-white text-base font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 sm:mt-0 sm:ml-3 sm:w-auto sm:text-sm" onclick="closeDeleteModal()">
                    Cancel
                </button>
            </div>
        </div>
    </div>
    </div>

    <div class="fixed z-10 inset-0 overflow-y-auto hidden" id="editCourseModal">
        <div class="flex items-end justify-center min-h-screen pt-4 px-4 pb-20 text-center sm:block sm:p-0">
            <!-- Modal backdrop... -->
            <div class="fixed inset-0 transition-opacity" aria-hidden="true">
                <div class="absolute inset-0 bg-gray-500 opacity-75"></div>
            </div>

            <!-- Modal content... -->
            <span class="hidden sm:inline-block sm:align-middle sm:h-screen" aria-hidden="true">&#8203;</span>

            <div class="inline-block align-bottom bg-white rounded-lg text-left overflow-hidden shadow-xl transform transition-all sm:my-8 sm:align-middle sm:max-w-lg sm:w-full">
                <!-- Edit Course Form -->
                <div class="bg-white px-4 pt-5 pb-4 sm:p-6 sm:pb-4">
                    <h3 class="text-lg leading-6 font-medium text-gray-900" id="modal-title">
                        Edit Course
                    </h3>
                    <div class="mt-2">
                        <!-- Include the necessary form elements for editing -->
                        <div class="mb-4">
                            <label for="editName" class="block text-gray-700 text-sm font-bold mb-2">Course Name:</label>
                            <input type="text" id="editName" class="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" />
                        </div>
                        <div class="mb-4">
                            <label for="editDescription" class="block text-gray-700 text-sm font-bold mb-2">Description:</label>
                            <textarea id="editDescription" class="form-textarea border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" rows="4"></textarea>
                        </div>
                        <div class="mb-4">
                            <label for="editCourseImage" class="block text-gray-700 text-sm font-bold mb-2">Course Image URL:</label>
                            <input type="text" id="editCourseImage" class="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" />
                        </div>
                        <div class="mb-4">
                            <label for="editCourseScope" class="block text-gray-700 text-sm font-bold mb-2">Course Scope:</label>
                            <textarea id="editCourseScope" class="form-textarea border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" rows="4"></textarea>
                        </div>
                        <div class="mb-4">
                            <label for="editPayment" class="block text-gray-700 text-sm font-bold mb-2">Payment:</label>
                            <input type="text" id="editPayment" class="form-input border border-gray-300 w-full px-4 py-2 rounded-lg focus:outline-none focus:ring focus:border-blue-500" />
                        </div>
                    </div>
                </div>
                <div class="bg-gray-50 px-4 py-3 sm:px-6 sm:flex sm:flex-row-reverse">
                    <button type="button" class="w-full inline-flex justify-center rounded-md border border-transparent shadow-sm px-4 py-2 bg-blue-600 text-base font-medium text-white hover:bg-blue-700 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-blue-500 sm:ml-3 sm:w-auto sm:text-sm" onclick="saveEdit()">
                        Save Changes
                    </button>
                    <button type="button" class="mt-3 w-full inline-flex justify-center rounded-md border border-gray-300 shadow-sm px-4 py-2 bg-white text-base font-medium text-gray-700 hover:bg-gray-50 focus:outline-none focus:ring-2 focus:ring-offset-2 focus:ring-indigo-500 sm:mt-0 sm:ml-3 sm:w-auto sm:text-sm" onclick="closeEditModal()">
                        Cancel
                    </button>
                </div>
            </div>
        </div>
    </div>

</body>
</html>
