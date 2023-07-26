using ContactManagement.Context;
using ContactManagement.Models;
using ContactManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Pages;
public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private IContactRepository _contactRepository;
    public IEnumerable<Contact> contacts { get; private set; }

    public IndexModel(ILogger<IndexModel> logger, IContactRepository contactRepository)
    {
        _logger = logger;
        _contactRepository = contactRepository;
    }

    public void OnGet()
    {
        contacts = _contactRepository.GetContacts();
    }

    public IActionResult OnPostDelete(int id)
    {
        if (id > 0)
        {
            var ct = _contactRepository.Get(id);
            if (ct != null)
            {
               _contactRepository.Delete(ct);              
                return RedirectToPage("/Index");
            }
            
        }
        return Page();
    }
}
