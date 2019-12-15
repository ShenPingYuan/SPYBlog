using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SPY.DB.Model
{
    public partial class Article
    {
        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Int32 Id { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Category { get; set; }

        /// <summary>
        /// 文章标题
        /// </summary>
        [Required]
        [MaxLength(128)]
        public string Title { get; set; }
        /// <summary>
        /// 文章概要描述
        /// </summary>
        public string description { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        [MaxLength(128)]
        public string ImageUrl { get; set; }

        /// <summary>
        /// 文章内容
        /// </summary>
        [MaxLength(2147483647)]
        public string Content { get; set; }

        /// <summary>
        /// 浏览次数
        /// </summary>
        [Required]
        [MaxLength(10)]
        public int ViewCount { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Sort { get; set; }

        /// <summary>
        /// 作者
        /// </summary>
        //[MaxLength(50)]
        public string UserId { get; set; }

        /// <summary>
        /// 来源
        /// </summary>
        [MaxLength(128)]
        public string Source { get; set; }

        ///// <summary>
        ///// SEO标题
        ///// </summary>
        //[MaxLength(128)]
        //public string SeoTitle { get; set; }

        ///// <summary>
        ///// SEO关键字
        ///// </summary>
        //[MaxLength(256)]
        //public string SeoKeyword { get; set; }

        ///// <summary>
        ///// SEO描述
        ///// </summary>
        //[MaxLength(512)]
        //public string SeoDescription { get; set; }

        ///// <summary>
        ///// 添加人ID
        ///// </summary>
        //[Required]
        //[MaxLength(10)]
        //public int AddManagerId { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Required]
        [MaxLength(23)]
        public DateTime AddTime { get; set; }

        ///// <summary>
        ///// 修改人ID
        ///// </summary>
        //[MaxLength(10)]
        //public Int32? ModifyManagerId { get; set; }

        ///// <summary>
        ///// 修改时间
        ///// </summary>
        //[MaxLength(23)]
        //public DateTime? ModifyTime { get; set; }

        /// <summary>
        /// 是否置顶
        /// </summary>
        [Required]
        [MaxLength(1)]
        public bool IsTop { get; set; }

        ///// <summary>
        ///// 是否轮播显示
        ///// </summary>
        //[Required]
        //[MaxLength(1)]
        //public Boolean IsSlide { get; set; }

        /// <summary>
        /// 是否热门
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsRed { get; set; }

        /// <summary>
        /// 是否发布
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsPublish { get; set; }
        public int SupportCounts { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        [MaxLength(1)]
        public Boolean IsDeleted { get; set; }
        /// <summary>
        /// 这篇文章的评论
        /// </summary>
        public List<Comment> Comments { get; set; }
        public ApplicationIdentityUser Author { get; set; }
    }
}