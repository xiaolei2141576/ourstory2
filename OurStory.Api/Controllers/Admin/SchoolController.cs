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

        private readonly ISchoolService schoolService;
        private readonly ICapPublisher _capBus;
        private IDbConnection _dbConnection;

        public SchoolController(ISchoolService service, ICapPublisher capBus, IDbConnection dbConnection)
        {
            this.schoolService = service;
            this._capBus = capBus;
            this._dbConnection = dbConnection;
        }

        [HttpPost(Name = "Add")]
        public async Task<bool> Add()
        {
            int count = 0;
            using (var trans = _dbConnection.BeginTransaction(_capBus, autoCommit : true))
            {

            }
            using (var conn = new SqlConnection(BaseDBConfig.ConnectionString))
            {
                using (var trans = conn.BeginTransaction(_capBus, autoCommit: true))
                {
                    string sqlCommand = @"INSERT INTO [dbo].[School](Name) VALUES(@Name);";
                    sqlCommand += "SELECT CAST(SCOPE_IDENTITY() as int)";
                    count = await conn.ExecuteAsync(sqlCommand, param: new { Name = "misA丶" }, transaction: trans);
                    //var sh = new School() { Name = "misA"};
                    //schoolId = await schoolService.Add(sh);
                    await _capBus.PublishAsync("school.service.show.add", count);
                    //trans.Commit();
                }
            }
            return count > 0;
        }
    }
}