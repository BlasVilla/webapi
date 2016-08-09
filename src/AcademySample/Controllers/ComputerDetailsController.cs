using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AcademySample.Models;
using Microsoft.AspNetCore.Mvc;

namespace AcademySample.Controllers
{
    [Route("api/computers")]
    public class ComputerDetailsController : Controller
    {
        private readonly ComputerDbContext _db;

        public ComputerDetailsController(ComputerDbContext db)
        {
            if (db == null)
            {
                throw new ArgumentNullException(nameof(db));
            }

            _db = db;
        }

        [HttpGet]
        [Route("", Name = "GetAllComputerDetails")]
        public ComputerDetails[] GetAll()
        {
            return _db.ComputerDetails.ToArray();
        }

        [HttpGet]
        [Route("{computerId}", Name = "GetComputerById")]
        public ComputerDetails GetById(string computerId)
        {
            return _db.ComputerDetails.SingleOrDefault(c => c.Name == computerId);
        }

        [HttpPost]
        [Route("")]
        public IActionResult Add([FromBody] ComputerDetails computerDetails)
        {
            _db.ComputerDetails.Add(computerDetails);

            _db.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        [Route("{computerId}")]
        public IActionResult Delete(string computerId)
        {
            var computer = _db.ComputerDetails.SingleOrDefault(c => c.Name == computerId);

            if (computer != null)
            {
                _db.ComputerDetails.Remove(computer);

                _db.SaveChanges();
            }

            return Ok();
        }
    }

    public class DummyData
    {
        public static IList<ComputerDetails> Computers { get; }

        static DummyData()
        {
            Computers = new List<ComputerDetails>(new [] { new ComputerDetails { Name = "computer 1" },
                new ComputerDetails { Name = "computer 2" }});
        }
    }
}