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

namespace OurStory.Service
{
    public class StudentService : BaseServices<Student>,IStudentService
    {

    }
}
