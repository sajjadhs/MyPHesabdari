using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyPHesabdari.Model;

namespace MyPHesabdari.Controllers
{
    public class DBController : Controller
    {
        readonly MyDbContext dbContext;

        public DBController(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            await dbContext.Database.MigrateAsync();
            return Json(true);
        }
    }
}
