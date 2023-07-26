using ContactManagement.Models;
using ContactManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages
{
    public class EditContactModel : PageModel
    {
        private IContactRepository _contactRepository;

        [BindProperty]
        public Contact contact { get; set; }


        public EditContactModel(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public void OnGet(int id)
        {
            contact = _contactRepository.Get(id);

            if (contact == null)
            {
                RedirectToPage("/Index");
            }
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid && contact != null)
            {
                if (_contactRepository.EmailExist(contact))
                {
                    ModelState.AddModelError("contact.Email", "e-mail já cadastrado.");
                    return Page();
                }

                if (_contactRepository.ContatoExist(contact))
                {
                    ModelState.AddModelError("contact.Contato", "Contato já cadastrado.");
                    return Page();

                }
                contact.Id = id;
                _contactRepository.Edit(contact);

                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}