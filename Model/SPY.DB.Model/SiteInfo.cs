using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class SiteInfo
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 栏目数
        /// </summary>
        public int ColumnCount { get; set; }
        /// <summary>
        /// 评论数
        /// </summary>
        public int CommentCount { get; set; }
        /// <summary>
        /// 文章数
        /// </summary>
        public int ArticleCount { get; set; }
        /// <summary>
        /// 标签数
        /// </summary>
        public int TagCount { get; set; }
        /// <summary>
        /// 访问量
        /// </summary>
        public int Views { get; set; }
        /// <summary>
        /// 中间标题
        /// </summary>
        [MaxLength(100)]
        public string CenterTitle { get; set; }
        /// <summary>
        /// 我的格言
        /// </summary>
        [MaxLength(50)]
        public string Motto { get; set; }
    }
}
