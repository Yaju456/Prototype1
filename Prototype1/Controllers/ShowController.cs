using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Prototype1.Data;
using Prototype1.Models;
using Prototype1.Repository.IRepository;
using Prototype1.Utility;
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
        public IActionResult MainShow()
        {
            List<ShowClass> lili= _db.showClass.GetAll().ToList();

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
            if (ModelState.IsValid)
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

                lili.imgurl = @"\Images\Drama\" + fileName;
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
            _db.save();
            return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(lili);
            }
            
          
        }

        public IActionResult Delete(int id)
        {
            var ToDelete = new ShowClass();
            ToDelete = _db.showClass.GetSome(u => u.Id == id);
            if (ToDelete == null)
            {
                return Json(new
                {
                    success = false,
                    message = "Error while Deleting"
                });
            }

            IQueryable<ShowTIcketsClass> lili = _db.showTickets.GetAll(IncludeProperties: "Show").AsQueryable();
            List<ShowDateClass> Showlist = _db.showDate.GetAll().ToList();
            lili = lili.Where(x=>x.ShowID == ToDelete.Id);
            List<ShowDateClass> Todel = new List<ShowDateClass>(); 
            foreach(var l in lili) 
            {
                Todel.AddRange(Showlist.Where(A=>A.ShowTicketID==l.Id));
            }
            _databud.ShowDate.RemoveRange(Todel);
            _databud.showTickets.RemoveRange(lili);
            _db.showClass.Delete(ToDelete);
            _db.save();
            return Json(new { success = true, message = "Successfully Deleted" });
        }
    }
}
