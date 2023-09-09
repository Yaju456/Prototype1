using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prototype1.Models;
using Prototype1.Repository;
using Prototype1.Repository.IRepository;
using Prototype1.ViewModel;

namespace Prototype1.Controllers
{
    public class BuyController : Controller
    {
        IMainRepo _db;
        public BuyController(IMainRepo db)
        {
            _db = db;
        }
        public IActionResult Index(int? id)
        {
            List<ShowTIcketsClass> data= _db.showTickets.GetAll().ToList();
            if(id!=null) 
            {
                List<ShowTIcketsClass> showdata= data.Where(A=>A.ShowID == id.Value).ToList();
				IEnumerable<SelectListItem> Showlist = showdata.Select(u => new SelectListItem
				{
					Text = u.ShowDate.ToString().Substring(0, u.ShowDate.ToString().IndexOf(" ")) +"  "+ u.Time,
					Value = (u.TotalTickets-u.soldTickets).ToString() +" "+ u.Id.ToString(),
				});
                BuyTicketVM Buydata = new BuyTicketVM();
                Buydata.obj = Showlist;
            
                if(showdata.Count>0) 
                {
					return View(Buydata);
				}
                
            }
            return RedirectToAction(controllerName:"Home", actionName: "Index");
        }
    }
}
