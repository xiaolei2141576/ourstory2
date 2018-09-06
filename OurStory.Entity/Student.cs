using System;
using System.Collections.Generic;
using System.Text;

namespace OurStory.Entity
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Id
        /// </summary>
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
