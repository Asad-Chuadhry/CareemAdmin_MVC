using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareemAdminMVC.Controllers
{
    public class HomeController : Controller
    {
        Models.CareemDBEntities careemEntities = new Models.CareemDBEntities();
        public ActionResult Index()
        {
            if (Session["Email"] != null)
            {
                var fCity = careemEntities.Customers.Select(c => c.city).Distinct().ToList();
                ViewBag.fCity = fCity.ToList();
                var Customer = (from customer in careemEntities.Customers select customer).ToList();
                var Customer10 = (from customer in careemEntities.Customers orderby customer.payment descending select customer).ToList();
                ViewBag.customer10 = Customer10;
                var Driver = (from driver in careemEntities.Drivers select driver).ToList();
                ViewBag.totalCustomer = Customer.Count.ToString();
                ViewBag.totalDriver = Driver.Count.ToString();
                long? rides = 0;
                double? earning = 0;
                foreach (Models.Customer cus in Customer)
                {
                    rides += cus.rides;
                    earning += cus.payment;
                }
                ViewBag.totalRide = rides.ToString();
                ViewBag.totalEarning = earning.ToString();
                return View();
            }
            else return RedirectToRoute("Index");
        }

        public ActionResult City()
        {

            var City = careemEntities.Customers.Select(c => c.city).Distinct().ToList();
            var Customer = (from customer in careemEntities.Customers select customer).ToList();
            //var cityEarnings[City.Count()];
            long?[] Earnings = new long?[City.Count()];
            int i = 0;
            foreach (var city in City)
            {
                Earnings[i] = 0;
                foreach (var customer in Customer)
                {
                    if (customer.city == city && i < 10)
                    {
                        Earnings[i] += customer.payment;
                    }

                }
                i++;
            }
            ViewBag.cityEarning = Earnings;
            ViewBag.city = City;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
       
        public ActionResult Driver()
        {
            if (Session["Email"] != null)
            {
                var data = (from Driver in careemEntities.Drivers select Driver).ToList();
                ViewBag.drivers = data;
                ViewBag.message = "";
                return View();
            }
            else return RedirectToRoute("Index");
        }
        public ActionResult Customer()
        {
            Models.CareemDBEntities entities = new Models.CareemDBEntities();
            return View(from customer in entities.Customers.Take(100)
                        select customer); 
        }
        
        [HttpPost]
        public ActionResult Store(Models.Driver dr)
        {
            ViewBag.delete = "";
            try
            {
                var data = (from Driver in careemEntities.Drivers select Driver).ToList();
                if (ModelState.IsValid)
                {
                    var id = dr.licenseNo;
                    var count = careemEntities.Drivers.Where(s => s.licenseNo.Equals(id)).Count();
                    if (count > 0)
                    {
                        ViewBag.message = "License Number already exists";
                        ViewBag.drivers = data;
                        return View("Driver", dr);
                    }
                    careemEntities.Drivers.Add(dr);
                    careemEntities.SaveChanges();
                    data = (from Driver in careemEntities.Drivers select Driver).ToList();
                    ViewBag.drivers = data;
                    ViewBag.message = "";
                    return View("Driver", dr);

                    //return Json(_post);
                }
                ViewBag.drivers = data;
                ViewBag.message = "Insert failed!";
                return View("Driver");
            }
            catch(Exception ex)
            {
                ViewBag.message = ex.ToString();
                return View("Driver");
            }

        }
        
      //  [HttpGet]
        public ActionResult Delete(int? id)
        {
            
            var dr = careemEntities.Drivers.Where(s => s.id==id).First();
            careemEntities.Drivers.Remove(dr);
            careemEntities.SaveChanges();
            ViewBag.delete = "Driver  " + dr.name + " Removed";
            return RedirectToAction("Driver");
            
        }
        public ActionResult EditDriver(int? id)
        {
            var data = careemEntities.Drivers.Where(s => s.id == id).FirstOrDefault();
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditDriver([Bind(Include = "id,name,status,licenseNo,vichleNo,city,email")] Models.Driver _driver)
        {

            if (ModelState.IsValid)
            {
                var data = careemEntities.Drivers.Find(_driver.id);
                data.name = _driver.name;
                data.status = _driver.status;
                data.licenseNo = _driver.licenseNo;
                data.vichleNo = _driver.vichleNo;
                data.city = _driver.city;
                data.email= _driver.email;
                careemEntities.Entry(data).State = EntityState.Modified;
                careemEntities.SaveChanges();
                // return Json(_post);
                return RedirectToAction("Driver");
            }
            var dataEdit = careemEntities.Drivers.Where(s => s.licenseNo == _driver.licenseNo).FirstOrDefault();
            return View(dataEdit);
        }
        public ActionResult Search(string search)
        {
            var SearchList = from m in careemEntities.Customers
                             select m;
            if (!String.IsNullOrEmpty(search))
            {
                SearchList = SearchList.Where(s => s.name.Contains(search));
                ViewBag.searchList = SearchList;
                return View();
            }

            return RedirectToAction("Index");
        }

    }


}
