using ContactManagement.Context;
using ContactManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContactManagement.Controllers;
public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext contexto)
    {
        _context = contexto;
    }

    public IActionResult Index()
    {
        List<Contact> listContacts = _context.contacts.ToList();

        return View(listContacts);
    }
}
