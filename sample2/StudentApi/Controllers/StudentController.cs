using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentApi.Models;

namespace StudentApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        
         private readonly StudentApiContext _context;

         public StudentController(StudentApiContext context){
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Student> GetAll(){
            return _context.Students.ToList();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public IActionResult GetById(long id){
            var item = _context.Students.FirstOrDefault(s => s.id == id);
            if(item== null){
                return NotFound();
            }
            return new ObjectResult(item);
        }
        //Create
        [HttpPost]
        public IActionResult Create([FromBody] Student item){
            if(item == null){
                return BadRequest();
            }
            _context.Students.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetStudent", new {id = item.id} , item);
        }
        //Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] Student item)
        {
            if (item == null || item.id != id)
            {
                return BadRequest();
            }

            var std = _context.Students.FirstOrDefault(t => t.id == id);
            if (std == null)
            {
                return NotFound();
            }
            std.fname = item.fname;
            std.lname = item.lname;
            _context.Students.Update(std);
            _context.SaveChanges();
            return new NoContentResult();
        }
        //Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.Students.FirstOrDefault(t => t.id == id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.Students.Remove(todo);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}