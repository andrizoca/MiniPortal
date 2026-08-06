using Microsoft.AspNetCore.Mvc;
using MiniPortal.Exceptions;
using MiniPortal.Models;
using MiniPortal.Services;

namespace MiniPortal.Controllers;

public class TicketsController : Controller
{
    private readonly TicketService _ticketService;

    public TicketsController(TicketService ticketService)
    {
        _ticketService = ticketService;
    }

    public IActionResult Index()
    {
        var tickets = _ticketService.GetAll();
        return View(tickets);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(); 
    }

    [HttpPost]
    public IActionResult Create(Ticket ticket)
    {
        _ticketService.Add(ticket);
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Delete(int id)
    {
        _ticketService.Delete(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        try
        {
            var ticket = _ticketService.GetById(id);
            return View(ticket);
        }
        catch(TicketNotFoundException)
        {
            return NotFound();
        }
    }
}
