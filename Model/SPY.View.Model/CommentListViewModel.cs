using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.View.Model
{
    public class CommentListViewModel
    {
        
        public int ArticleId { get; set; }
        public List<Comment> List = new List<Comment>(); 
    }
}
