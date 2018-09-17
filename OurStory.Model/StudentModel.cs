using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurStory.Model
{
    public class Student
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// 学校id
        /// </summary>
        public int SchoolId { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
