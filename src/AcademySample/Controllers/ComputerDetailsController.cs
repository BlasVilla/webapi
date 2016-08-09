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

        [HttpGet]
        [Route("", Name = "GetAllComputerDetails")]
        public ComputerDetails[] GetAll()
        {
            return DummyData.Computers.ToArray();
        }

        [HttpGet]
        [Route("{computerId}", Name = "GetComputerById")]
        public ComputerDetails GetById(string computerId)
        {
            return DummyData.Computers.SingleOrDefault(c => c.Name == computerId);
        }

        [HttpDelete]
        [Route("{computerId}")]
        public IActionResult Delete(string computerId)
        {
            var computer = DummyData.Computers.SingleOrDefault(c => c.Name == computerId);

            if (computer != null)
            {
                DummyData.Computers.Remove(computer);
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