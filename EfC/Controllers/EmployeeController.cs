using EfC.Data;
using EfC.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context )
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            // this is for question direct john ra salary lai database ma hal bhanera deko qsn lai yesto  garney .
            //var entry = new Employees
            //{
            //    Name = "John",
            //    Salary = 1200,
            //};
            //context.Employees.Add( entry );
            //context.SaveChanges();
            var data=context.Employees.ToList();
            return View(data);
        }

        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        // this is way to add data to database from form.
        public IActionResult Create(Employees model)

        {
            if (ModelState.IsValid)
            {
                var data = new Employees()
                {
                    Name = model.Name,
                    Salary = model.Salary,

                };
                context.Employees.Add(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }

        }
        public IActionResult Delete(int id)
        {
            var delEmployee = context.Employees.FirstOrDefault(x => x.Id == id);
            context.Employees.Remove(delEmployee); 
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var emp=context.Employees.SingleOrDefault(x => x.Id == id);
            var editEmployee = new Employees()
            {
                Name = emp.Name,
                Salary = emp.Salary,
            };

            return View(editEmployee);

        }
        [HttpPost]
        public IActionResult Edit(Employees model)
        {
            if (ModelState.IsValid)
            {
                var data = new Employees()
                {   
                    Id = model.Id,
                    Name = model.Name,
                    Salary = model.Salary,

                };
                context.Employees.Update(data);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }


            
        }

    }
}

