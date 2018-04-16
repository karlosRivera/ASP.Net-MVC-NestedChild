using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NestedChild.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            List<MenuItem> allMenu = new List<MenuItem>
            {
                new MenuItem {Id=1,Name="Parent 1", ParentId=0},
                new MenuItem {Id=2,Name="child 1", ParentId=1},
                new MenuItem {Id=7,Name="child 5", ParentId=6},
                new MenuItem {Id=3,Name="child 2", ParentId=1},
                new MenuItem {Id=4,Name="child 3", ParentId=1},
                new MenuItem {Id=5,Name="Parent 2", ParentId=0},
                new MenuItem {Id=6,Name="child 4", ParentId=4},
                new MenuItem {Id=8,Name="child 6", ParentId=5},
                new MenuItem {Id=9,Name="Parent 3", ParentId=0}

            };


            List<MenuItem> mi = allMenu
            //.Where(e => e.ParentId == 0) /* grab only the root parent nodes */
            .Select(e => new MenuItem
            {
                Id = e.Id,
                Name = e.Name,
                ParentId = e.ParentId,
                //Children = allMenu.Where(x => x.ParentId == e.Id).ToList()
            }).ToList();

            ViewBag.menusList = mi;

            return View();
        }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public virtual List<MenuItem> Children { get; set; }
    }
}