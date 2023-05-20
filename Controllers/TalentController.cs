using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimpleHire.Models;

namespace SimpleHire.Controllers
{
    public class TalentController : Controller
    {
        private InfoContext context { get; set; }
        public TalentController(InfoContext ctx)
        {
            this.context = ctx;
        }

        public IActionResult Index()
        {
            var talent = context.Information
                .Include(t => t.Job)
                .OrderBy(i => i.Name)
                .ToList();
           
            return View(talent);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Jobs = context.Jobs.OrderBy(g => g.Name).ToList();
            var model = new Info();
            return View("AddEdit", model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Jobs = context.Jobs.OrderBy(g => g.Name).ToList();
            var model = context.Information.Find(id);
            return View("AddEdit", model);
        }
        [HttpPost]
        public IActionResult Save(Info info)
        {
            if (ModelState.IsValid)
            {
                if (info.InfoId == 0)
                {
                    context.Information.Add(info);
                }
                else
                {
                    context.Information.Update(info);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Talent");
            }
            else
            {
                ViewBag.Action = (info.InfoId == 0) ? "Add" : "Edit";
                ViewBag.Jobs = context.Jobs.OrderBy(g => g.Name).ToList();
                return View("AddEdit", info);
            }
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = context.Information.Find(id);
            return View("Delete", model);
        }
        [HttpPost]
        public IActionResult Delete(Info info)
        {
            context.Information.Remove(info);
            context.SaveChanges();
            return RedirectToAction("Index", "Talent");
        }

    }
}
