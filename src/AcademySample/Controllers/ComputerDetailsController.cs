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

        public interface IFilteringStrategy
        {
            bool Filter(ComputerDetails dt);
        }

        public class FilterById : IFilteringStrategy
        {
            private readonly string _id;

            public FilterById(string id)
            {
                _id = id;
            }

            public bool Filter(ComputerDetails dt)
            {
                return dt.Name == _id;
            }
        }

        public class FilterByIpAddress : IFilteringStrategy
        {
            private readonly string _ipAddress;

            public FilterByIpAddress(string ipAddress)
            {
                _ipAddress = ipAddress;
            }

            public bool Filter(ComputerDetails dt)
            {
                return dt.IpAddress == _ipAddress;
            }
        }

        [HttpGet]
        [Route("{computerId}", Name = "GetComputerById")]
        public ComputerDetails GetById(string computerId)
        {
            var strategy = new FilterById(computerId);
            return _db.ComputerDetails.SingleOrDefault(c => strategy.Filter(c));
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