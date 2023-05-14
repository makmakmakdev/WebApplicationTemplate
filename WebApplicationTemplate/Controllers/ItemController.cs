using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using WebApplicationTemplate.Models;

namespace WebApplicationTemplate.Controllers
{
    [Route("Admin/Item")]
    public class ItemController : Controller
    {
        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<ItemModel> items = new List<ItemModel> { new ItemModel { ItemCode = "123456", ItemName = "Name", ItemDescription = "Description" } };

            return View("~/Views/Admin/Item/Index.cshtml", items);
        }

        [Route("Create")]
        [HttpGet]
        public IActionResult Create()
        {
            return View("~/Views/Admin/Item/Create.cshtml");
        }

        [Route("Edit")]
        [HttpGet]
        public IActionResult Edit(string itemCode)
        {
            ItemModel item = new ItemModel
            {
                ItemCode = itemCode,
                ItemName = "Name",
                ItemDescription = "Description",
            };

            return View("~/Views/Admin/Item/Edit.cshtml", item);
        }

        [Route("Store")]
        [HttpPost]
        public IActionResult Store()
        {
            return RedirectToAction("Index");
        }
    }
}
