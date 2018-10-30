﻿using DotNetCore.CAP;
using Newtonsoft.Json;
using OurStory.IRepository;
using OurStory.IService;
using OurStory.IService.Base;
using OurStory.Model;
using OurStory.Repository;
using OurStory.Service.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using OurStory.Model.Common;
using OurStory.Repository.Sugar;

namespace OurStory.Service
{
    public class StudentService : BaseServices<Student>,IStudentService, IStudentSubscriberService, ICapSubscribe
    {
        IStudentRepository dal;
        private readonly string connStr = "";
        public StudentService(IStudentRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
        [CapSubscribe("school.service.show.add")]
        public async Task ConsumeStudentMessage(object message)
        {
            await Console.Out.WriteLineAsync($"[StorageService] Received message : {JsonConvert.SerializeObject(message)}");
            await AddStudent(message.ObjToInt());
        }

        private async Task<bool> AddStudent(int schoolId)
        {
            using (var conn = new SqlConnection(BaseDBConfig.ConnectionString2))
            {
                string sqlCommand = @"INSERT INTO [dbo].[Student](SchoolId,Name) VALUES(@SchoolId,@Name);";
                int count = await conn.ExecuteAsync(sqlCommand, param: new { SchoolId = schoolId, Name = "Cap" });
                return count > 0;
            }
        }
    }
}
