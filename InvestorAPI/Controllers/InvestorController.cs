using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Model;
using Entities.Repository;
using Microsoft.EntityFrameworkCore;

namespace InvestorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvestorController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IRepoInvestor _repoInvestor;

        public InvestorController(DataContext context, IRepoInvestor repoInvestor)
        {
            _context = context;
            _repoInvestor = repoInvestor;
        }

        // GET: api/investor
        [HttpGet]
        public IEnumerable<Investor> GetAllInvestors()
        {
            return _repoInvestor.GetAllRecords();
        }
        
        //GET: api/investor/id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInvestor([FromRoute] Guid id)
        {
            const string jsonresponse = "You should give an accurate model..";
            const string jsonresponse3 = "There is no such an investor found for given Id..";
            if (!ModelState.IsValid)
            {
                return BadRequest(jsonresponse);
            }
            var investor = await _repoInvestor.GetFromId(id);
            if (investor == null)
            {
                return BadRequest(jsonresponse3);
            }
            else
            {
                return Ok(investor);
            }
        }
        
        //POST: api/investor
        [HttpPost]
        public async Task<IActionResult> PostInvestor([FromBody] Investor investor)
        {
            const string jsonresponse = "You should give an accurate model..";
            const string jsonresponse2 = "Something went wrong while accessing database or table..";
            if (!ModelState.IsValid)
                return BadRequest(jsonresponse);  //If given model of investor object is not proper (invalid), return Status400 

            try
            {
                await _repoInvestor.Create(investor);   // If model is valid, try to create investor to database 
                
            }
            catch
            {
                return BadRequest(jsonresponse2);  // Return if database or any other problems occur
            }

            return CreatedAtAction("GetInvestor", new {id = investor.Id}, investor);    // If everything is perfect,
            // return a new investor information
            // by invoking GetInvestor() meth. 

        }

        //PUT: api/investor/id 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvestor([FromRoute] Guid id, [FromBody] Investor investor)
        {
            const string jsonresponse = "You should give an accurate investor model..";
            const string jsonresponse2 = "Something went wrong while accessing database or table..";
            const string jsonresponse3 = "There is no such an investor found for given Id..";
            if (!ModelState.IsValid)
            {
                return BadRequest(jsonresponse);  //If model has invalid property, return BadRequest
            }

            if (id != investor.Id) //If there is no id by given input, return BadRequest
            {
                return BadRequest(jsonresponse3);    
            }

            try
            {
                await _repoInvestor.Update(id, investor);  // Update investor by given id and table 
            }
            catch 
            {
                return BadRequest(jsonresponse2);  // If an error occured by database or its table, catch it
            }
            return CreatedAtAction("GetInvestor", new {id = investor.Id}, investor);    //Return updated investor by using its Id
        }

        //DELETE api/investor/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvestor([FromRoute] Guid id)    //Delete investor by given its Id
        {
            const string jsonresponse = "Accurate id please..";
            const string jsonresponse3 = "There is no such an investor found for given Id..";
            if (!ModelState.IsValid)
                return BadRequest(jsonresponse);

            var investor = await _context.Investors.FindAsync(id);
            if (investor == null)
            {
                return NotFound(jsonresponse3);
            }
            else
            {
                _context.Entry(investor).State = EntityState.Detached;
            }
            try
            {
                await _repoInvestor.Delete(id); //Delete given Id from database
            }
            catch
            {
                return BadRequest(ModelState);
            }
            return Ok(investor);
        }
    }
}