using AutoMapper;
using Ex.DAL.DO.Objetos;
using Ex.DAL.EF;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = Ex.DAL.DO.Objetos;
using models = Ex.API.DataModels;


namespace Ex.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


        public class AutoresController : Controller
        {
            private readonly NDbContext _context;
            private readonly IMapper _mapper;

            public AutoresController(NDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            // GET: api/Categories
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Autores>>> GetAutores()
            {

                var res = new Ex.BS.Autores(_context).GetAll();
                List<models.Autores> mapaAux = _mapper.Map<IEnumerable<data.Autores>, IEnumerable<models.Autores>>(res).ToList();
                return mapaAux;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<models.Autores>> GetAutores(int id)
            {
                var categories = new Ex.BS.Autores(_context).GetOneById(id);

                if (categories == null)
                {
                    return NotFound();
                }
                models.Autores mapaAux = _mapper.Map<data.Autores, models.Autores>(categories);

                return mapaAux;
            }


            // PUT: api/Categories/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutAutores(int id, models.Autores autores)
            {
                if (id != autores.id)
                {
                    return BadRequest();
                }



                try
                {
                    data.Autores mapaAux = _mapper.Map<models.Autores, data.Autores>(autores);
                    new Ex.BS.Autores(_context).Update(mapaAux);
                }
                catch (Exception ee)
                {
                    if (!AutoresExists(id))
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
            public async Task<ActionResult<Autores>> PostAutores(models.Autores autores)
            {
                try
                {
                    data.Autores mapaAux = _mapper.Map<models.Autores, data.Autores>(autores);
                    new Ex.BS.Autores(_context).Insert(mapaAux);
                }
                catch (Exception)
                {

                    BadRequest();
                }

                return CreatedAtAction("GetCategories", new { id = autores.id }, autores);
            }


            // DELETE: api/Categories/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Autores>> DeleteAutores(int id)
            {
                var autores = new Ex.BS.Autores(_context).GetOneById(id);
                if (autores == null)
                {
                    return NotFound();
                }

                try
                {
                    new Ex.BS.Autores(_context).Delete(autores);
                }
                catch (Exception)
                {

                    BadRequest();
                }
                models.Autores mapaAux = _mapper.Map<data.Autores, models.Autores>(autores);

                return mapaAux;
            }

            private bool AutoresExists(int id)
            {
                return (new Ex.BS.Autores(_context).GetOneById(id) != null);
            }




        }
}
