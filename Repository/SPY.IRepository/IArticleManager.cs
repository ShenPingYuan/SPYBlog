using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPY.IRepository
{
    /// <summary>
    /// 用于对文章进行增删改查等管理操作的接口
    /// </summary>
    public interface IArticleManager:IBaseRepository<Article>
    {//定义自己特有的方法
        IQueryable<Article> LoadEntities<S>(int topCount,out int totalCount,
           System.Linq.Expressions.Expression<Func<Article, bool>> whereLambdaExpression,
           System.Linq.Expressions.Expression<Func<Article, S>> orderByLambdaExpression, bool isAsc);
    }
}
