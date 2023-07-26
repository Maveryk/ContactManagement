using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace ContactManagement.Models;

public class Contact
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required]
    [MinLength(5)]    
    public string Name { get; set; }
    [Required]
    [StringLength(9, MinimumLength= 9, ErrorMessage = "O número de contato deve ter 9 dígitos")]
    [RegularExpression("^[0-9]{9}$", ErrorMessage = "O número de contato deve ter 9 dígitos numéricos.")]
    public string Contato { get; set; }
    [Required]
    public string Email { get; set; }

    public bool IsDeleted { get; set; }

    public Contact()
    {
    }

    public Contact(int id, string name, string contato, string email)
    {
        Id = id;
        Name = name;
        Contato = contato;
        Email = email;
    }

    public bool emailValido()
    {
        try
        {
            MailAddress mailAddress;

            if (!string.IsNullOrEmpty(Email))
            {

                mailAddress = new MailAddress(Email);
                return true;
            }
            else
            {
                return false;
            }

        }
        catch (Exception)
        {
            Console.WriteLine($"Email inválido {Email}");
            return false;
        }
    }
}
