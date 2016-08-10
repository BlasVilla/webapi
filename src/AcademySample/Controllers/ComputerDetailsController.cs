using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AcademySample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("{computerId}/data")]
        public UsageData[] GetUsageDataByComputerId(string computerId)
        {
            return _db.UsageData.Where(u => u.ComputerName == computerId).ToArray();
        }

        [HttpPost]
        [Route("{computerId}/data")]
        public IActionResult AddUsageData(string computerId, [FromBody] UsageData usageData)
        {
            usageData.ComputerName = computerId;

            usageData.ComputerDetails = null;

            var computer = _db.ComputerDetails.Include(cd => cd.UsageData).SingleOrDefault(cd => cd.Name == computerId);

            if (computer != null)
            {
                computer.UsageData.Add(usageData);

                _db.SaveChanges();
            }
            
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
}