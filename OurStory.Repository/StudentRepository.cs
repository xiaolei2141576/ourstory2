using OurStory.IRepository;
using OurStory.Model;
using OurStory.Repository.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<StudentModel> entityDB;

        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public StudentRepository()
        {
            DbContext.Init(BaseDBConfig.ConnectionString);
            context = DbContext.GetDbContext();
            db = context.Db;
            entityDB = context.GetEntityDB<StudentModel>(db);
        }

        public int Add(StudentModel model)
        {
            var i = db.Insertable(model).ExecuteReturnBigIdentity();
            return i.ObjToInt();
        }

        public bool Delete(StudentModel model)
        {
            return db.Deleteable(model).ExecuteCommand() > 0;
        }

        public List<StudentModel> Query(Expression<Func<StudentModel, bool>> whereExpression)
        {
            return entityDB.GetList(whereExpression);
        }

        public bool Update(StudentModel model)
        {
            return db.Updateable(model).ExecuteCommand() > 0;
        }
    }
}
