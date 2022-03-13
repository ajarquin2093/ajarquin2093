using AutoMapper;
using BE.DAL.DO.Objetos;
using BE.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = BE.DAL.DO.Objetos;
using models = BE.API.DataModels;

namespace BE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerDemographicsController : Controller
    {
        private readonly NDbContext _context;
        private readonly IMapper _mapper;
        public CustomerDemographicsController(NDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.CustomerDemographics>>> GetCustomerDemographics()
        {
           
            var res = new BE.BS.CustomerDemographics(_context).GetAll();
            List<models.CustomerDemographics> mapaAux = _mapper.Map<IEnumerable<data.CustomerDemographics>, IEnumerable<models.CustomerDemographics>>(res).ToList();
            return mapaAux;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<models.CustomerDemographics>> GetCustomerDemographics(string id)
        {
            var CDemographics = new BE.BS.CustomerDemographics(_context).GetOneById(id);

            if (CDemographics == null)
            {
                return NotFound();
            }
            models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(CDemographics);

            return mapaAux;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerDemographics(string id, models.CustomerDemographics CDemographics)
        {
            if (id != CDemographics.CustomerTypeId)
            {
                return BadRequest();
            }



            try
            {
                data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(CDemographics);
                new BE.BS.CustomerDemographics(_context).Update(mapaAux);
            }
            catch (Exception ee)
            {
                if (!CustomerDemographicsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Categories
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CustomerDemographics>> PostCustomerDemographics(models.CustomerDemographics CDemographics)
        {
            try
            {
                data.CustomerDemographics mapaAux = _mapper.Map<models.CustomerDemographics, data.CustomerDemographics>(CDemographics);
                new BE.BS.CustomerDemographics(_context).Insert(mapaAux);
            }
            catch (Exception)
            {

                BadRequest();
            }

            return CreatedAtAction("GetCustomerDemographics", new { id = CDemographics.CustomerTypeId }, CDemographics);
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.CustomerDemographics>> DeleteCustomerDemographics(string id)
        {
            var categories = new BE.BS.CustomerDemographics(_context).GetOneById(id);
            if (categories == null)
            {
                return NotFound();
            }

            try
            {
                new BE.BS.CustomerDemographics(_context).Delete(categories);
            }
            catch (Exception)
            {

                BadRequest();
            }
            models.CustomerDemographics mapaAux = _mapper.Map<data.CustomerDemographics, models.CustomerDemographics>(categories);

            return mapaAux;
        }

        private bool CustomerDemographicsExists(string id)
        {
            return (new BE.BS.CustomerDemographics(_context).GetOneById(id) != null);
        }
    }
}
