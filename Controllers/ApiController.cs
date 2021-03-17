using Microsoft.AspNetCore.Mvc;
using TaskManager.Models;

using System.Linq;
using System.Collections.Generic;


namespace TaskManager.Controllers
{
    public class ApiController : Controller
    {
        private DataContext dbContext;
        public ApiController(DataContext db)
        {
            //Im the constructor
            dbContext = db;

        }

        [HttpGet]
        public IActionResult Test()
        {
            string name = "Nick";
            return Json(name);
        }
        
        [HttpGet]
        public IActionResult GetTask() 
        {
            // read the database
            var tasks = dbContext.Tasks.ToList();
            return Json(tasks);
        }
          
        [HttpPost]
        public IActionResult PostTask([FromBody]Task theTask)
    
        {
            // send theTask to database
            dbContext.Tasks.Add(theTask);
            dbContext.SaveChanges();

            
            // return the object 
            return Json(theTask);

        }


    }

}
