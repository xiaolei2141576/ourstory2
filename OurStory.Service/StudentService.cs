using OurStory.Entity;
using OurStory.IRepository;
using OurStory.IService;
using OurStory.Model;
using OurStory.Repository;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.Service
{
    public class StudentService : IStudentService
    {
        public IStudentRepository dal = new StudentRepository();

        public int Add(StudentModel model)
        {
            return dal.Add(model);
        }

        public bool Delete(StudentModel model)
        {
            return dal.Delete(model);
        }

        public List<StudentModel> Query(Expression<Func<StudentModel, bool>> whereExpression)
        {
            return dal.Query(whereExpression);

        }

        public bool Update(StudentModel model)
        {
            return dal.Update(model);
        }
    }
}
