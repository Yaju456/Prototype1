using Microsoft.AspNetCore.Mvc;
using Prototype1.Models;
using Prototype1.Repository.IRepository;
using System.Security.Cryptography;
using System.Text;

namespace Prototype1.Controllers
{
    public class DateController : Controller
    {
        IMainRepo _db;
        public DateController(IMainRepo db)
        {
            _db = db;
        }

        public IActionResult Index()
        { 
            return View(); 
        }
        public IActionResult TicketData(int id)
        {

            IEnumerable<ShowDateClass> classes = new List<ShowDateClass>();
            classes = _db.showDate.GetAll(IncludeProperties: "showTIcketsClass").Where(a=>a.ShowTicketID==id);

            if(!classes.Any()) 
            {
                const int keySize = 64;
                const int iterations = 350  ;
                HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA256;
                for (int i=0; i<120; i++) 
                {

                    ShowDateClass showDate = new ShowDateClass();
                    showDate.ShowTicketID = id;
                    showDate.Ticketno=i.ToString();
                    string lili = showDate.Ticketno + Convert.ToString(showDate.ShowTicketID);
                    byte [] salt = RandomNumberGenerator.GetBytes(64);
                    var hash= Rfc2898DeriveBytes.Pbkdf2(Encoding.ASCII.GetBytes(lili),salt,iterations,hashAlgorithm,keySize);
                    showDate.Qrvalue = Convert.ToHexString(hash);
                    showDate.occupied = 0;
                    _db.showDate.Add(showDate);
                }
                _db.save();
                return RedirectToAction("Index");

            }
            return View(classes);
        }
        public IActionResult getall()
        {
            List<ShowDateClass> Data= _db.showDate.GetAll(IncludeProperties: "showTIcketsClass").ToList();
            return Json(new {data=Data});
        }

        public IActionResult Edit(int? id)
        {
            ShowDateClass dada= new ShowDateClass();
            if (id != null)
            {
                dada= _db.showDate.GetSome(A=>A.TicketId==id);
            }
            else
            {
                return RedirectToAction("Index");
            }
            return View(dada);
        }

        [HttpPost]
        public IActionResult Edit(ShowDateClass dada)
        {
            if(ModelState.IsValid)
            {
                _db.showDate.update(dada);
                _db.save();
                return View("index");
            }
            return View(dada);
        }
    }
}
