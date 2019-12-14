using SPY.DB.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.View.Model
{
    public class ArticleViewModel
    {
        public ArticleViewModel()
        {
            Author = new ApplicationIdentityUser();
        }
        /// <summary>
        /// 页面文章序号id
        /// </summary>
        public int id { get; set; }
        /// <summary>
        /// 数据库的文章ID
        /// </summary>
        public int articleID { get; set; }
        /// <summary>
        /// 文章标题
        /// </summary>
        public string articleTitle { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string publishTime { get; set; }
        public string category { get; set; }
        /// <summary>
        /// 发布时间/DateTime类型
        /// </summary>
        public DateTime publishDateTime { get; set; }
        /// <summary>
        /// 文章作者名
        /// </summary>
        public string articleAuthor { get; set; }
        /// <summary>
        /// 文章概要描述
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 文章发布状态
        /// </summary>
        public string articleStatus { get; set; }
        /// <summary>
        /// 文章图片地址连接
        /// </summary>
        public string articleImg { get; set; }
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool isDisplayed { get; set; }
        /// <summary>
        /// 是否置顶，若存在多个置顶的文章，则根据数据库顺序排列这些，
        /// </summary>
        public bool isTop { get; set; }
        /// <summary>
        /// 文章内容
        /// </summary>
        public string articleContent { get; set; }
        /// <summary>
        /// 文章浏览量
        /// </summary>
        public int viewCount { get; set; }
        public int supportCount { get; set; }
        public ApplicationIdentityUser Author { get; set; }
    }
}
