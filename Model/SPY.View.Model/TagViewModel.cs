using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SPY.View.Model
{
    public class TagViewModel
    {
        /// <summary>
        /// 标签唯一编号
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 展示Id
        /// </summary>
        public int ShowId { get; set; }
        /// <summary>
        /// 标签名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 标签路径
        /// </summary>
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
