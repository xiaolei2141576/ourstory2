using OurStory.IRepository;
using OurStory.IRepository.Base;
using OurStory.Model;
using OurStory.Repository.Base;
using OurStory.Repository.Sugar;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.Repository
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {

    }
}
