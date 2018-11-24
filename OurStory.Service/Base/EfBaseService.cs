using OurStory.IRepository.Base;
using OurStory.IService.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OurStory.Service.Base
{
    public class EfBaseService<TEntity> :IEfBaseService<TEntity> where TEntity : class, new()
    {
        public IEfBaseRepository<TEntity> baseDal;

        /// <summary>
        /// 单表查询 单条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public TEntity Single(Expression<Func<TEntity, bool>> predicate)
        {
            return baseDal.Single(predicate);
        }

        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return baseDal.Query(predicate);
        }

        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames)
        {
            return baseDal.QueryJoin(predicate, tableNames);
        }

        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy)
        {
            return baseDal.QueryOrderBy(predicate, keySelector, isQueryOrderBy);
        }

        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pageSize">一页多少条</param>
        /// <param name="rowCount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="isQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        List<TEntity> QueryByPage<TKey>(int pageIndex, int pageSize, out int rowCount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy)
        {
            return baseDal.QueryByPage(pageIndex, pageSize, out rowCount, predicate, keySelector, isQueryOrderBy);
        }
    }
}
