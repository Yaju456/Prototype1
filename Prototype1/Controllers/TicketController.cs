using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;
using Prototype1.ViewModel;

namespace Prototype1.Controllers
{
    public class TicketController : Controller
    {
        IMainRepo _db;
        ApplicationDbConetext _databud;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public TicketController(IMainRepo db, IWebHostEnvironment webHostEnvironment, ApplicationDbConetext databud)
        {
            _db = db;
            _databud = databud;
            _webHostEnvironment = webHostEnvironment;

        }
        public IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetShows()
        {

            List<ShowTIcketsClass> lili = _db.showTickets.GetAll(IncludeProperties: "Show").ToList();

            return Json(new { data = lili });
        }
        public IActionResult EnterShow(int? id = null)
        {
            ShowTicketsVM dada = new ShowTicketsVM();
            IEnumerable<SelectListItem> Showlist = _db.showClass.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString(),
            });
            dada.obj = Showlist;
            dada.tIcketsClass = new ShowTIcketsClass();
            if (id != 0)
            {
                dada.tIcketsClass = _db.showTickets.GetSome(u => u.Id == id);
            }
            return View(dada);
        }

        [HttpPost]
        public IActionResult EnterShow(ShowTicketsVM dada)
        {
            if (dada.tIcketsClass.Id == 0)
            {
                _db.showTickets.Add(dada.tIcketsClass);
            }
            else
            {
                _db.showTickets.update(dada.tIcketsClass);
            }
            _db.save();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var ToDelete = new ShowTIcketsClass();
            ToDelete = _db.showTickets.GetSome(u => u.Id == id);
            if (ToDelete == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while Deleting"
                });
            }
            _db.showTickets.Delete(ToDelete);
            _db.save();
            return Json(new { success = true, message = "Successfully Deleted" });
        }
    }
}
