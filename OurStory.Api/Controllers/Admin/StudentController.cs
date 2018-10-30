using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Xml;
using OurStory.IService;
using OurStory.Model;
using OurStory.Model.Common;
using OurStory.Service;
using SqlSugar;

namespace OurStory.API.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize(Policy = "Admin")]
    //[ApiController]
    public class StudentController : Controller
    {
        IStudentService studentService;
        private readonly ICapPublisher _capBus;
        public StudentController(IStudentService studentService, ICapPublisher capBus)
        {
            this.studentService = studentService;
            this._capBus = capBus;
        }        
    }
}