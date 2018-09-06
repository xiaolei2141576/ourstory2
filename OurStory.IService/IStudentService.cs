using OurStory.Entity;
using OurStory.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.IService
{
    public interface IStudentService
    {
        #region 基础方法
        int Add(StudentModel model);
        bool Delete(StudentModel model);
        bool Update(StudentModel model);
        List<StudentModel> Query(Expression<Func<StudentModel, bool>> whereExpression);
        #endregion

        #region 扩展方法
        #endregion
    }
}
