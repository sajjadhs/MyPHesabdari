using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPHesabdari.Model;

namespace MyPHesabdari.Controllers
{
    [Route("[controller]")]
    public class DBController : Controller
    {
        readonly MyDbContext dbContext;

        public DBController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> force()
        {
            await dbContext.Database.MigrateAsync();
            return Json(true);
        }
    }
}
