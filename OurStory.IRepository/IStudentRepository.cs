using OurStory.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.IRepository
{
    public interface IStudentRepository
    {
        int Add(StudentModel model);
        bool Delete(StudentModel model);
        bool Update(StudentModel model);
        List<StudentModel> Query(Expression<Func<StudentModel, bool>> whereExpression);
    }
}
