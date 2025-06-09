using DrugPrevention.Repositories.QuangTNV.Models;
using DrugPrevention.Services.QuangTNV;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using NuGet.Packaging.Rules;
using System.Runtime.InteropServices;

namespace DrugPrevention.RazorWebApp.QuangTNV.Hubs
{
    public class DrugPreventionHubs : Hub
    {
        private readonly ICoursesQuangTnvService _coursesQuangTnvService;
        public DrugPreventionHubs(ICoursesQuangTnvService coursesQuangTnvService)
        {
            _coursesQuangTnvService = coursesQuangTnvService;        }
          public async Task HubDelete_CoursesQuangTnv(string courseId)
        {
            try
            {
                Console.WriteLine($"[HUB] Attempting to delete course: {courseId}");
                
                // Validate courseId
                if (string.IsNullOrEmpty(courseId))
                {
                    Console.WriteLine($"[HUB] Invalid courseId: {courseId}");
                    await Clients.Caller.SendAsync("Receive_DeleteError", "Invalid course ID");
                    return;
                }

                // Parse string to int
                if (!int.TryParse(courseId, out int courseIdInt))
                {
                    Console.WriteLine($"[HUB] Cannot parse courseId to int: {courseId}");
                    await Clients.Caller.SendAsync("Receive_DeleteError", "Invalid course ID format");
                    return;
                }

                // Delete from database first
                var success = await _coursesQuangTnvService.DeleteCourseAsync(courseIdInt);
                
                if (success)
                {
                    Console.WriteLine($"[HUB] Successfully deleted course: {courseId}");
                    // Only send signal if deletion was successful
                    await Clients.All.SendAsync("Receive_DeleteCourseQuangTNV", courseId);
                }
                else
                {
                    Console.WriteLine($"[HUB] Failed to delete course: {courseId}");
                    // Send error signal if deletion failed
                    await Clients.Caller.SendAsync("Receive_DeleteError", "Failed to delete course");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[HUB] Error deleting course {courseId}: {ex.Message}");
                // Send error signal if exception occurred
                await Clients.Caller.SendAsync("Receive_DeleteError", ex.Message);
            }
        }
        public async Task HubCreate_CoursesQuangTnv(string CourseQuangTNVJsonString)
        {
            var item = JsonConvert.DeserializeObject<CoursesQuangTnv>(CourseQuangTNVJsonString);
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "CourseQuangTNVJsonString cannot be null or empty.");
            }

            await Clients.All.SendAsync("Receive_CreateCourseQuangTNV", item);

            await _coursesQuangTnvService.AddCourseAsync(item);

        }
    }
}
