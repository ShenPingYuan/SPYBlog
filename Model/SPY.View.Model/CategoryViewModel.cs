﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SPY.View.Model
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string ParentCategoryName { get; set; }
    }
}
