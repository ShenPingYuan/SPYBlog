using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class Comment
    {
        [Key]
        [Required]
        public int CommentId { get; set; }
        [Required]
        [MaxLength(11)]
        public string QQ { get; set; }
        [Required]
        public string HeadImageUrl { get; set; }
        public string Content { get; set; }
        [Required]
        [MaxLength(20)]
        public string NickName { get; set; }
        public DateTime CommentDateTime { get; set; }
        public string CommentTime { get; set; }
        /// <summary>
        /// 点赞数
        /// </summary>
        public int Supports { get; set; }
        [Required]
        public int ArticleId { get; set; }
        public virtual ICollection<CommentReply> CommentReplies { get; set; }
        public Article Article { get; set; }
    }
}
