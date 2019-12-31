using AutoMapper;
using SPY.DB.Model;
using SPY.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPY.Admin.Profiles
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryViewModel>().ForMember(des => des.CategoryName, opt => opt.MapFrom(src => src.CategoryName));
        }
    }
}
