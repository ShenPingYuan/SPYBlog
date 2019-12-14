using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPY.IRepository
{
    /// <summary>
    /// 评论管理接口
    /// </summary>
    public interface ICommentManager:IBaseRepository<Comment>
    {
        IQueryable<Comment> LoadEntities<S>(int topCount, out int totalCount,
           System.Linq.Expressions.Expression<Func<Comment, bool>> whereLambdaExpression,
           System.Linq.Expressions.Expression<Func<Comment, S>> orderByLambdaExpression, bool isAsc);
    }
}
