using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.DB.Model
{
    /// <summary>
    /// 1、多对多关系模型
    /// </summary>
    public class RelationShip
    {
        public int ChildID { get; set; }

        public Child Child { get; set; }

        public int ParentID { get; set; }

        public Parent Parent { get; set; }
    }
}
