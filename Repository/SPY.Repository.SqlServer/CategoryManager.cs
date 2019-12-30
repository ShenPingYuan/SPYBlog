using SPY.Data;
using SPY.DB.Model;
using SPY.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.Repository.SqlServer
{
    public class CategoryManager : BaseManager<Category>, ICategoryManager
    {
        public CategoryManager(ApplicationDbContext dbContext) : base(dbContext) { }
    }
}