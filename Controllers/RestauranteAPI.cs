using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app_restaurante.Models;   
using Microsoft.EntityFrameworkCore;   
using Microsoft.AspNetCore.Http;  

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace app_restaurante.Controllers
{
    [Produces("application/json")]
    [Route("api/RestauranteAPI")]
    [ResponseCache(Location = ResponseCacheLocation.None, NoStore = true, Duration = -1)]
    public class RestauranteAPI : Controller
    {
        private readonly RestauranteContext _context;
        //injeta o contexto do banco de dados no controller
        public RestauranteAPI(RestauranteContext context)
        {
            _context = context;
        }
        // GET: api/<controller>

            //obter itens do banco de dados
        [HttpGet]
        //[Route("Restaurante")]
        public IEnumerable<dynamic> Get()
        {
            return _context.Restaurante.ToList();
        }

        //adiciona novo resturante com nome recebido no corpo da pagina
        [HttpPost]
        public string Post([FromBody] Restaurante restaurante)
        {
            Response.StatusCode = 200;

            try
            {
                app_restaurante.Models.Restaurante novoRestaurante = new Restaurante();
                novoRestaurante.RestauranteNome = restaurante.RestauranteNome;
                _context.Restaurante.Add(novoRestaurante);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return e.ToString();
            }
            return "OK";
        }

        //Edita restaurante
        [HttpPut("{RestauranteNome}")]
        public IActionResult Update(string restauranteNome, [FromBody] Restaurante restaurante)
        {
            if (restaurante == null || restaurante.RestauranteNome != restauranteNome)
            {
                return BadRequest();
            }

            var rest = _context.Restaurante.FirstOrDefault(t => t.RestauranteNome == restauranteNome );
            if (rest == null)
            {
                return NotFound();
            }

            rest.IsComplete = restaurante.IsComplete;
            rest.RestauranteNome = restaurante.RestauranteNome;

            _context.Restaurante.Update(rest);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //exclui um restaurante
        [HttpDelete("{RestauranteNome}")]
        public IActionResult Delete(string restauranteNome)
        {
            var rest = _context.Restaurante.FirstOrDefault(t => t.RestauranteNome == restauranteNome);
            if (rest == null)
            {
                return NotFound();
            }

            _context.Restaurante.Remove(rest);
            _context.SaveChanges();
            return new NoContentResult();
        }
        
    }
}

