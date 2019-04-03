using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using OurStory.IService;
using OurStory.Model;
using OurStory.Model.Common;
using OurStory.Repository.Sugar;

namespace OurStory.API.Controllers.Admin
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class SchoolController : Controller
    {        
        private readonly ICapPublisher _capBus;

        public SchoolController(ISchoolService service, ICapPublisher capBus)
        {
            this._capBus = capBus;
        }

        [HttpPost(Name = "Add")]
        public async Task<bool> Add()
        {
            long count = 0;
            using (var conn = new SqlConnection(BaseDBConfig.ConnectionString))
            {
               using (var trans = conn.BeginTransaction(_capBus, autoCommit: false))
               {
                   string sqlCommand = @"INSERT INTO [dbo].[School](Name) VALUES(@Name);";
                   count = await conn.ExecuteAsync(sqlCommand, param: new { Name = "misA丶" }, transaction: trans);
                   await _capBus.PublishAsync("school.service.show.add", count);
                   trans.Commit();
               }
            }
            return count > 0;
        }
    }
}