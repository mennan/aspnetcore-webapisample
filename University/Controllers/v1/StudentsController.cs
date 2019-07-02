using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using University.Controllers.v1;
using University.Models;

namespace University.Controllers
{
    public class StudentsController : BaseV1Controller
    {
        // GET api/values
        [HttpGet]
        public ActionResult<ApiReturn<IEnumerable<StudentModel>>> Get()
        {
            var returnData = new ApiReturn<IEnumerable<StudentModel>>
            {
                Code = 200,
                Success = true,
                Message = "Students listed successfully.",
                Data = Students
            };

            return returnData;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<ApiReturn<StudentModel>> Get(int id)
        {
            var student = Students.FirstOrDefault(a => a.Id == id);
            ApiReturn<StudentModel> returnData;

            if (student == null)
            {
                returnData = new ApiReturn<StudentModel>
                {
                    Code = 404,
                    Success = false,
                    Message = "Student not found!",
                    Data = null
                };

                return NotFound(returnData);
            }

            returnData = new ApiReturn<StudentModel>
            {
                Code = 200,
                Success = true,
                Message = "Student found successfully.",
                Data = student
            };

            return returnData;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] StudentModel value)
        {
            Students.Add(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] StudentModel value)
        {
            var student = Students.FirstOrDefault(a => a.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            Students.Remove(student);
            Students.Add(value);

            return true;
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            var student = Students.FirstOrDefault(a => a.Id == id);

            if (student == null)
            {
                return NotFound();
            }

            Students.Remove(student);

            return true;
        }
    }
}
