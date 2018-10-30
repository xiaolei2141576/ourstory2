using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurStory.Model
{
    public class School
    {
        /// <summary>
        /// Id
        /// </summary>
        [SugarColumn(IsPrimaryKey = true)]
        public int Id { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
    }
}
