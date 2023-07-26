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
    [MaxLength(9)]
    public string Name { get; set; }
    [Required]
    public string Contato { get; set; }
    [Required]
    public string Email { get; set; }

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
