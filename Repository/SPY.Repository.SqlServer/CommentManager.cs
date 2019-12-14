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
    public class CommentManager : BaseManager<Comment>, ICommentManager
    {
        private readonly ApplicationDbContext _dbContext;
        public CommentManager(ApplicationDbContext dbContext):base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Comment> LoadEntities<S>(int topCount, out int totalCount, Expression<Func<Comment, bool>> whereLambdaExpression, Expression<Func<Comment, S>> orderByLambdaExpression, bool isAsc)
        {
            var comments = _dbContext.Set<Comment>().Where(whereLambdaExpression);
            totalCount = comments.Count();
            if (isAsc)
            {
                comments = comments.OrderBy(orderByLambdaExpression).Take(topCount);
            }
            else
            {
                comments = comments.OrderBy(orderByLambdaExpression).Take(topCount);
            }
            return comments;
        }
    }
}
