﻿using OurStory.EfRepository.Ef;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace OurStory.EfRepository.Base
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private EfDbContext _dbContext = null;
        DbSet<TEntity> _dbSet;

        public GenericRepository(EfDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        #region 查询
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<TEntity> Query(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames)
        {
            if (tableNames == null && tableNames.Any() == false)
            {
                throw new Exception("缺少连表名称");
            }

            IQueryable<TEntity> query = _dbSet.AsQueryable();

            foreach (var table in tableNames)
            {
                query = query.Include(table);
            }

            return query.Where(predicate).ToList();
        }

        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        public List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy)
        {
            if (isQueryOrderBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).ToList();
            }
            return _dbSet.Where(predicate).OrderByDescending(keySelector).ToList();

        }

        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="rowcount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="isQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        public List<TEntity> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy)
        {
            rowcount = _dbSet.Count(predicate);
            if (isQueryOrderBy)
            {
                return _dbSet.Where(predicate).OrderBy(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            }
            else
            {
                return _dbSet.Where(predicate).OrderByDescending(keySelector).Skip((pageIndex - 1) * pagesize).Take(pagesize).ToList();
            }
        }
        #endregion

        #region 编辑
        /// <summary>
        /// 通过传入的model加需要修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        public bool Edit(TEntity model, string[] propertys)
        {
            if (model == null)
            {
                throw new Exception("实体不能为空");
            }

            if (propertys.Any() == false)
            {
                throw new Exception("要修改的属性至少要有一个");
            }

            //将model追击到EF容器
            EntityEntry entry = _dbContext.Entry(model);

            entry.State = EntityState.Unchanged;

            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
            
            return entry.State == EntityState.Modified;
            //关闭EF对于实体的合法性验证参数
            //_dbContext.Configuration. = false;
        }

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public bool Edit(TEntity model)
        {
            return _dbContext.Entry(model).State == EntityState.Modified;
        }
        #endregion

        #region 删除
        public bool Delete(TEntity model, bool isadded)
        {
            if (!isadded)
            {
                _dbSet.Attach(model);
            }
            return _dbSet.Remove(model).State == EntityState.Deleted;
        }
        #endregion

        #region 新增
        public bool Add(TEntity model)
        {
            return _dbSet.Add(model).State == EntityState.Added;
        }
        #endregion

        #region 统一提交
        public int SaverChanges()
        {
            return _dbContext.SaveChanges();
        }
        #endregion

        #region 调用存储过程返回一个指定的TResult
        //public List<TResult> RunProc<TResult>(string sql, params object[] pamrs)
        //{
        //    return _dbContext.Database.<TResult>(sql, pamrs).ToList();
        //}
        #endregion
    }

    public interface IRepository<TEntity> where TEntity : class
    {
        #region 查询
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<TEntity> Query(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// 多表关联查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        List<TEntity> QueryJoin(Expression<Func<TEntity, bool>> predicate, string[] tableNames);
        /// <summary>
        /// 升序查询还是降序查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="keySelector"></param>
        /// <param name="isQueryOrderBy"></param>
        /// <returns></returns>
        List<TEntity> QueryOrderBy<TKey>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy);

        /// <summary>
        /// 升序分页查询还是降序分页
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="pageIndex">第几页</param>
        /// <param name="pagesize">一页多少条</param>
        /// <param name="rowcount">返回共多少条</param>
        /// <param name="predicate">查询条件</param>
        /// <param name="keySelector">排序字段</param>
        /// <param name="isQueryOrderBy">true为升序 false为降序</param>
        /// <returns></returns>
        List<TEntity> QueryByPage<TKey>(int pageIndex, int pagesize, out int rowcount, Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, TKey>> keySelector, bool isQueryOrderBy);
        #endregion

        #region 编辑
        /// <summary>
        /// 通过传入的model加需要修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        bool Edit(TEntity model, string[] propertys);

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        bool Edit(TEntity model);
        #endregion

        #region 删除
        bool Delete(TEntity model, bool isadded);
        #endregion

        #region 新增
        bool Add(TEntity model);
        #endregion

        #region 统一提交
        int SaverChanges();
        #endregion

        #region 调用存储过程返回一个指定的TResult
        //List<TResult> RunProc<TResult>(string sql, params object[] pamrs);
        #endregion
    }
}
