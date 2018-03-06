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
    [Route("api/[controller]")]
    public class PratosAPI : Controller
    {
        private readonly PratosContext _context;
        //injeta o contexto do banco de dados no controller
        public PratosAPI(PratosContext context)
        {
            _context = context;
        }
        // GET: api/<controller>

        //obter pratos do banco de dados
        [HttpGet]
        public IEnumerable<Pratos> GetAll()
        {
            return _context.Pratos.ToList();
        }

        //adiciona novo prato com nome recebido no corpo da pagina
        [HttpPost]
        public string Post([FromBody] Pratos prato)
        {
            Response.StatusCode = 200;

            try
            {
                app_restaurante.Models.Pratos novoPrato = new Pratos();
                novoPrato.Nome = prato.Nome;
                novoPrato.Preco = prato.Preco;
                _context.Pratos.Add(novoPrato);
                _context.SaveChanges();

            }
            catch (Exception e)
            {
                Response.StatusCode = 400;
                return e.ToString();
            }
            return "OK";
        }

        //Edita prato
        [HttpPut("{Nome}")]
        public IActionResult Update(string nome, [FromBody] Pratos prato)
        {
            if (prato == null || prato.Nome != nome)
            {
                return BadRequest();
            }

            var prat = _context.Pratos.FirstOrDefault(t => t.Nome == nome);
            if (prat == null)
            {
                return NotFound();
            }

            prat.IsComplete = prat.IsComplete;
            prat.Nome = prato.Nome;
            prat.Preco = prato.Preco;

            _context.Pratos.Update(prat);
            _context.SaveChanges();
            return new NoContentResult();
        }

        //exclui um restaurante
        [HttpDelete("{Nome}")]
        public IActionResult Delete(string nome)
        {
            var prat = _context.Pratos.FirstOrDefault(t => t.Nome == nome);
            if (prat == null)
            {
                return NotFound();
            }

            _context.Pratos.Remove(prat);
            _context.SaveChanges();
            return new NoContentResult();
        }
    }
}
