using MVC.AX.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace MVC.AX.Controllers
{
    public class PeopleController : Controller {
        // GET: People
        //public ActionResult Index()
        //{
        //    return View();
        //}
        
        public ActionResult Index(string searchtext = null) {
            var peps = people
                        .OrderBy(p => p.Name)
                        .Where(p => searchtext == null || p.Name.StartsWith(searchtext, StringComparison.InvariantCultureIgnoreCase))
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };

            return View(model);
        }

        // GET: People/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: People/Create
        public ActionResult Create() {
            return View();
        }

        // POST: People/Create
        [HttpPost]
        public ActionResult Create(Person person) {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid) {
                    people.Add(
                        new Person {
                            Name = person.Name,
                            Phonenumber = person.Phonenumber,
                            City = person.City
                        });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult EditPeople(string id) {
            if (Request.IsAjaxRequest()) {
                //Session["times"] = Convert.ToInt32(Session["times"]) + 1;
                //return Content("AJAX" + Session["times"]);

                Person match = people.Find(p => p.Name == id);
                return PartialView("_EditPerson", match);
            }
            else {
                return RedirectToAction("Index");
            }
        }

        // GET: People/Edit/5
        public ActionResult Edit(int id) {            

            return View();
        }

        

        // POST: People/Edit/5
        //[HttpPost]
        //public ActionResult Edit(string id, FormCollection collection) {            

        //    try
        //    {
        //         TODO: Add update logic here
        //        if (ModelState.IsValid) {
        //            Console.WriteLine("HEJ");
        //        }


        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        public ActionResult Edit([Bind(Include = "Name, City, Phonenumber")]Person person) {
            try {

                if (ModelState.IsValid) {

                    Person match = people.Find(p => p.Name == person.Name);

                    if (people.Contains(match)) {
                        match.Phonenumber = person.Phonenumber;
                        match.City = person.City;

                        return PartialView("_ListPeople", match);
                    }
                }

                return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest, "Missing data");
            }
            catch (Exception ex) {

                return View();
            }
        }

        // GET: People/Delete/5
        public ActionResult Delete(string id) {
            Person match = people.Find(p => p.Name == id);
            if(match != null && people.Contains(match)) {
                people.Remove(match);
            }

            var peps = people
                        .OrderBy(p => p.Name)
                        .Select(p => p);

            var model = new PersonViewModel { People = peps };
            return PartialView("Index", model);
        }

        // POST: People/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private static List<Person> people = new List<Person>() {
            new Person {
                Name = "Mordark The Grim",
                Phonenumber = 050123456,
                City = "Tristram"
            },
            new Person {
                Name = "Carl Sagan",
                Phonenumber = 050234567,
                City = "Mordor"
            },
            new Person {
                Name = "Jon Snow",
                Phonenumber = 050345678,
                City = "Castle Black"
            },
            new Person {
                Name = "Dovahkiin Loudmouth",
                Phonenumber = 050456789,
                City = "Whiterun"
            },
            new Person {
                Name = "Johan Johansson",
                Phonenumber = 050567890,
                City = "Stockholm"
            },
            new Person {
                Name = "Sauron Edgelord",
                Phonenumber = 050678901,
                City = "Black Tower"
            },
            new Person {
                Name = "Grim the Reaper",
                Phonenumber = 050789012,
                City = "Death"
            },
            new Person {
                Name = "Tingle Bell",
                Phonenumber = 050890123,
                City = "HEY LISTEN!"
            },
            new Person {
                Name = "Grumdar Orcboss",
                Phonenumber = 050901234,
                City = "Waaagh Rock"
            },
            new Person {
                Name = "Hobbit Hobinsson",
                Phonenumber = 051011121,
                City = "Dirt"
            },
            new Person {
                Name = "Sephiroth",
                Phonenumber = 051112131,
                City = "Brooding Town"
            },
            new Person {
                Name = "Kratos Veryangry",
                Phonenumber = 051213141,
                City = "Everywhere"
            },
            new Person {
                Name = "Inquisitor Jonson",
                Phonenumber = 051314151,
                City = "Everythingisheresy"
            },
            new Person {
                Name = "Per Svensson",
                Phonenumber = 051415161,
                City = "Örebro"
            }
        };
    }
}
