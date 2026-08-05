using Microsoft.AspNetCore.Mvc;
using MiniPortal.Models;
using MiniPortal.Services;

namespace MiniPortal.Controllers;

public class ChamadosController : Controller
{
    private readonly ChamadoService _chamadoService;

    public ChamadosController(ChamadoService chamadoService)
    {
        _chamadoService = chamadoService;
    }

    public IActionResult Index()
    {
        var chamados = _chamadoService.ObterTodos();
        return View(chamados);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public IActionResult Create(Chamado chamado)
    {
        _chamadoService.Adicionar(chamado);
        return RedirectToAction("Index");
    }
}