using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;
using Prototype1.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Prototype1.Controllers
{
    public class ShowController : Controller
    {
        IMainRepo _db;
        ApplicationDbConetext _databud;
        private readonly IWebHostEnvironment _webHostEnvironment;   
        public ShowController(IMainRepo db, IWebHostEnvironment webHostEnvironment, ApplicationDbConetext databud)
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
            List<ShowTIcketsClass> lili =_db.showTickets.GetAll(IncludeProperties: "Show").ToList();
            return Json(new { data = lili });
        }
        public IActionResult Enter(int? id=null)
        {
            ShowClass show= new ShowClass();
            if (id != null)
            {
                show = _db.showClass.GetSome(u => u.Id == id);
            }
            if (show.imgurl==null)
            {
                show.imgurl = "/images/noimage.jpg";
            }
            return View(show); 
        }
        [HttpPost]
        public IActionResult Enter(ShowClass lili, IFormFile? imgfile)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;//for www root folder path

            if (imgfile != null)
            {
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imgfile.FileName);
                string Productpath = Path.Combine(wwwRootPath, @"Images\Drama");
                if (!string.IsNullOrEmpty(lili.imgurl))
                {
                    //delete old image 
                    var oldimage = Path.Combine(wwwRootPath, lili.imgurl.TrimStart('\\'));
                    if (System.IO.File.Exists(oldimage))
                    {
                        System.IO.File.Delete(oldimage);
                    }
                }
                using (var filestream = new FileStream(Path.Combine(Productpath, fileName), FileMode.Create))
                {
                    imgfile.CopyTo(filestream);
                }

                lili.imgurl = @"\Images\Product\" + fileName;
            }

            if (lili.Id== 0)
            {
                _db.showClass.Add(lili);
                _db.save();
                ShowClass lili2 = new ShowClass();
                lili2 = _db.showClass.GetSome(u => u.Name == lili.Name);
                foreach (DateTime day in EachDay(lili.StartDate, lili.EndDate))
                {
                    ShowTIcketsClass dada = new ShowTIcketsClass();
                    dada.TotalTickets = 120;
                    dada.Time = "5:00 pm";
                    dada.ShowDate = day;
                    dada.soldTickets = 0;
                    dada.ShowID = lili2.Id;
                    _db.showTickets.Add(dada);
                }
            }
            else
            {
                _db.showClass.Update(lili);
                _db.save();
                ShowClass lili2 = new ShowClass();
                lili2 = _db.showClass.GetSome(u => u.Name == lili.Name);
                foreach (DateTime day in EachDay(lili.StartDate, lili.EndDate))
                {
                    ShowTIcketsClass dada = new ShowTIcketsClass();
                    dada= _databud.showTickets.AsEnumerable().Where((u)=> {
                        return u.ShowDate == day && u.ShowID == lili2.Id;
                        }).FirstOrDefault();
                    dada.TotalTickets = 120;
                    dada.Time = "5:00 pm";
                    dada.ShowDate = day;
                    dada.soldTickets = 0;
                    dada.ShowID = lili2.Id;
                    _db.showTickets.update(dada);
                }
            }

            _db.save();
            return RedirectToAction("Index", "Home");
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
            if (id != null)
            {
                dada.tIcketsClass= _db.showTickets.GetSome(u => u.Id == id);
            }
            return View(dada);
        }
    }
}
