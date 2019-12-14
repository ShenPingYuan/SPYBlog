using Microsoft.EntityFrameworkCore;
using SPY.Data;
using SPY.DB.Model;
using SPY.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SPY.Repository.SqlServer
{
    /// <summary>
    /// 文章的增删改查的具体实现类
    /// </summary>
    public class ArticleManager : BaseManager<Article>, IArticleManager
    {
        private readonly ApplicationDbContext _dbContext;
        public ArticleManager(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Article> LoadEntities<S>(int topCount, out int totalCount, Expression<Func<Article, bool>> whereLambdaExpression, Expression<Func<Article, S>> orderByLambdaExpression, bool isAsc)
        {
            var articles = _dbContext.Set<Article>().Where(whereLambdaExpression);
            totalCount = articles.Count();
            if(isAsc)
            {
                articles = articles.OrderBy(orderByLambdaExpression).Take(topCount);
            }
            else
            {
                articles = articles.OrderBy(orderByLambdaExpression).Take(topCount);
            }
            return articles;
        }
    }
}
