using ContactManagement.Models;
using ContactManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages
{
    public class AddContactModel : PageModel
    {
        private IContactRepository _contactRepository;

        [BindProperty]
        public Contact contact { get; set; }

        public AddContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult OnGet(int id)
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid && contact.emailValido())
            {                
                _contactRepository.Add(contact);

                return RedirectToPage("/Index");
            }
            else
            {                
                ModelState.AddModelError("contact.Email", "O e-mail n�o � v�lido.");
            }
            return Page();
        }
    }
}