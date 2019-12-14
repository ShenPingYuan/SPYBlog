using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPY.DB.Model;
using SPY.IRepository;
using SPY.View.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPY.Site.Controllers
{
    public class TagController:Controller
    {
        private readonly ITagManager _tagManager;
        public TagController(ITagManager tagManager)
        {
            _tagManager = tagManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TagList()
        {
            var tags =_tagManager.GetAllEntities().ToList();
            if(tags==null)
            {
                return Json(new { code = 0, count = 0, msg = "失败", data = new { } });
            }
            List<TagViewModel> taglist = new List<TagViewModel>();
            for (int i = 0; i < tags.Count; i++)
            {
                taglist.Add(new TagViewModel
                {
                    Id = tags[i].Id,
                    IsInChina=tags[i].IsInChina,
                    IsOpen=tags[i].IsOpen,
                    Name=tags[i].Name,
                    ShowId=i,
                    Src=tags[i].Src,
                }) ;
            }
            var JsonResult = new { code = 0, count = tags.Count, msg = "成功", data = taglist };
            return Json(JsonResult);
        }
        public IActionResult AddTag(int tagId)
        {
            TagViewModel tagViewModel = new TagViewModel();
            if (tagId == 0)
            {
                return View("AddTag", tagViewModel);
            }
            var tag = _tagManager.LoadEntities(x => x.Id == tagId).FirstOrDefault();
            if(tag!=null)
            {
                tagViewModel.Id = tag.Id;
                tagViewModel.Name = tag.Name;
                tagViewModel.Src = tag.Src;
                tagViewModel.IsInChina = tag.IsInChina;
                tagViewModel.IsOpen = tag.IsOpen;
            }
            return View("AddTag",tagViewModel);
        }
        public IActionResult SwitchOpen(int id, bool isOpen)
        {
            if(id!=0)
            {
                var tag = _tagManager.LoadEntities(x => x.Id == id).FirstOrDefault();
                if(tag!=null)
                {
                    tag.IsOpen = isOpen;
                    var result = _tagManager.EditEntity(tag);
                    if(result)
                    {
                        return Json("成功");
                    }
                }
            }
            return Json("失败");
        }
        [HttpPost]
        public IActionResult AddTag(TagViewModel tag)
        {
            if(tag==null)
            {
                return Json("失败");
            }
            if(tag.Id==0)
            {
                var result = _tagManager.AddEntity(new Tag
                {
                    Name=tag.Name,
                    IsInChina=tag.IsInChina,
                    IsOpen=tag.IsOpen,
                    Src=tag.Src,
                });
                if(result!=null)
                {
                    return Json("添加成功");
                }
                return Json("添加失败");
            }
            else
            {
                var DBtag = _tagManager.LoadEntities(x => x.Id == tag.Id).FirstOrDefault();
                if(DBtag!=null)
                {
                    DBtag.IsInChina = tag.IsInChina;
                    DBtag.IsOpen = tag.IsOpen;
                    DBtag.Name = tag.Name;
                    DBtag.Src = tag.Src;
                }
                var result = _tagManager.EditEntity(DBtag);
                if(result)
                {
                    return Json("修改成功");
                }
            }
            return Json("失败");
        }
        public IActionResult DeleteTag(int tagId)
        {
            var tag = _tagManager.LoadEntities(x => x.Id == tagId).FirstOrDefault();
            if(tag!=null)
            {
                var result = _tagManager.DeleteEntity(tag);
                if(result)
                {
                    return Json("成功");
                }
            }
            return Json("失败");
        }
    }
}
