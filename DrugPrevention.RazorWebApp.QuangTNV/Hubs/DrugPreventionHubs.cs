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
            _coursesQuangTnvService = coursesQuangTnvService;
        }
        public async Task HubDelete_CoursesQuangTnv(string courseId)
        {
            await Clients.All.SendAsync("Receive_DeleteCourseQuangTNV", courseId);
            await _coursesQuangTnvService.DeleteCourseAsync(courseId);
        }
        public async Task HubCreate_CoursesQuangTnv(string CourseQuangTNVJsonString)
        {
            var item = JsonConvert.DeserializeObject<CoursesQuangTnv>(CourseQuangTNVJsonString);

            await Clients.All.SendAsync("Receive_CreateCourseQuangTNV", item);

            await _coursesQuangTnvService.AddCourseAsync(item);

        }
    }
}
