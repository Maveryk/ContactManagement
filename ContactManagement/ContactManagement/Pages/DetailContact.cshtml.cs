using ContactManagement.Models;
using ContactManagement.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContactManagement.Pages
{
    public class DetailContactModel : PageModel
    {
        private IContactRepository _contactRepository;

        [BindProperty]
        public Contact contact { get; set; }

        public DetailContactModel(IContactRepository contactRepository) => _contactRepository = contactRepository;

        public void OnGet(int id)
        {
            contact = _contactRepository.Get(id);

            if (contact == null)
            {
                RedirectToPage("/Index");
            }

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
}
