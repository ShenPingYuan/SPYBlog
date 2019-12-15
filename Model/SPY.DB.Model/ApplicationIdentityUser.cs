using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public ApplicationIdentityUser()
        {
            Articles = new HashSet<Article>();
        }
        //public string UserId { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        [MaxLength(20)]
        public string NickName { get; set; }
        /// <summary>
        /// 用户角色、等级
        /// </summary>
        [MaxLength(20)]
        public string RoleName { get; set; }
        public string Sex { get; set; }
        /// <summary>
        /// 用户状态，是否正在使用
        /// </summary>
        public bool IsInUsing { get; set; }
        /// <summary>
        /// 用户创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// 最后登录时间
        /// </summary>
        public string EndTime { get; set; }
        /// <summary>
        /// 用户简介、描述
        /// </summary>
        [MaxLength(Int32.MaxValue)]
        public string UserDescription { get; set; }
        /// <summary>
        /// 家庭地址/省
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 家庭地址/市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 家庭地址/区
        /// </summary>
        public string Area { get; set; }
        /// <summary>
        /// 真实名字
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public string BirthDate { get; set; }
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string UserFaceImgUrl { get; set; }
        /// <summary>
        /// 该作者的文章
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
        //public virtual ICollection<Comment> Comments { get; set; }
    }
}
