using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MLI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _dbContext;
        public DepartmentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET: DepartmentController
        [HttpGet("get-all")]
        public ActionResult Index()
        {
            return View(_dbContext.Departments.ToList());
        }

        // GET: DepartmentController/Details/5
        [HttpGet("get-Detalis")]
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        [HttpGet("get-Create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost("post-Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            try
            {
                _dbContext.Departments.Add(department);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Edit/5
        [HttpGet("get-edit")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
        [HttpPost("post-Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Department department)
        {
            try
            {
                _dbContext.Entry(department).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: DepartmentController/Delete/5
        [HttpGet("get-delete")]
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: DepartmentController/Delete/5
        [HttpPost("post-delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Department department)
        {
            try
            {
                var _Dep = _dbContext.Departments.FirstOrDefault(n => n.Id == id);
                _dbContext.Remove(_Dep);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
