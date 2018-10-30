using OurStory.IRepository;
using OurStory.IService;
using OurStory.Model;
using OurStory.Service.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurStory.Service
{
    public class SchoolService : BaseServices<School>, ISchoolService
    {
        ISchoolRepository dal;
        public SchoolService(ISchoolRepository dal)
        {
            this.dal = dal;
            base.baseDal = dal;
        }
    }
}
