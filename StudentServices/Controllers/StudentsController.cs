using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Shared;
using StudentServices.Services;


namespace StudentServices.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        StudentsServices studentsServices;
        public StudentsController(StudentsServices _studentsServices)
        {
             studentsServices = _studentsServices;
        }

        [HttpGet]
        public async Task<Students[]> StudentsList() 
        {
            var lst =  await studentsServices.StudentsList();

            return lst.ToArray();
        }
    }
}
