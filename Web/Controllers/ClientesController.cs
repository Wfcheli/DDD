using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class ClientesController : Controller
    {

        private IBaseService<Cliente> _baseService;

        public ClientesController(
            IBaseService<Cliente> baseService)
        {
            _baseService = baseService;
        }

        private IActionResult Execute(Func<object> func)
        {
            try
            {
                var resultado = func();
                return Ok(resultado);
            } catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        private ClienteViewModel Parse(Cliente cliente)
        {
            return new ClienteViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Email = cliente.Email,
                Cpf = cliente.Cpf
            };
        }

        private Cliente Parse(ClienteViewModel clienteViewModel)
        {
            return new Cliente()
            {
                Id = clienteViewModel.Id,
                Nome = clienteViewModel.Nome,
                Email = clienteViewModel.Email,
                Cpf = clienteViewModel.Cpf
            };
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            var dados = from cliente in
                            (Execute(() => _baseService.Listar()) as OkObjectResult).Value
                            as List<Cliente>
                        select Parse(cliente);
            return View(dados);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            ClienteViewModel cliente = 
                    Parse((Execute(() => _baseService.ListarPorId(id)) as OkObjectResult).Value
                            as Cliente);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Nome, Email, Cpf")] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                _baseService.Inserir<ClienteValidator>(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Parse(cliente));
            }
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            ClienteViewModel cliente =
                    Parse((Execute(() => _baseService.ListarPorId(id)) as OkObjectResult).Value
                            as Cliente);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id, Nome, Email, Cpf")] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                _baseService.Alterar<ClienteValidator>(cliente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Parse(cliente));
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            ClienteViewModel cliente =
                    Parse((Execute(() => _baseService.ListarPorId(id)) as OkObjectResult).Value
                            as Cliente);
            if (cliente == null)
                return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, [Bind("Id, Nome, Email, Cpf")] Cliente cliente)
        {
            try
            {
                if (cliente == null)
                    return NotFound();
                _baseService.Excluir(cliente.Id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(Parse(cliente));
            }
        }
    }
}
