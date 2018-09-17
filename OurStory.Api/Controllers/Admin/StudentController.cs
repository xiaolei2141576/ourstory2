using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Xml;
using OurStory.IService;
using OurStory.Model;
using OurStory.Service;

namespace OurStory.API.Controllers.Admin
{
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    [ApiController]
    public class StudentController : Controller
    {
        [HttpGet("{id}",Name = "Get")]
        public async Task<Student> Get(int id)
        {
            IStudentService service = new StudentService();

            return await service.QueryById(id);
        }
    }
}