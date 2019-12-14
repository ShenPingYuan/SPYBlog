using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.DB.Model
{
    public class Tag
    {
        /// <summary>
        /// 标签唯一编号
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        [MaxLength(15)]
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 标签路径
        /// </summary>
        [Required]
        public string Src { get; set; }
        /// <summary>
        /// 是否是国内网站
        /// </summary>
        public string IsInChina { get; set; }
        /// <summary>
        /// 是否展示
        /// </summary>
        public bool IsOpen { get; set; }
    }
}
