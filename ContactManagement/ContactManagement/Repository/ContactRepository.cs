using ContactManagement.Context;
using ContactManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Repository;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _context;

    public ContactRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Add(Contact contact)
    {
        try
        {
            _context.contacts.Add(contact);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool ContatoExist(Contact contact)
    {
        try
        {
            var contactBd = _context.contacts.FirstOrDefault(x => x.Contato == contact.Contato);
            if (contactBd == null)
            {
                return false;
            }
            return true;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Delete(Contact contact)
    {
        try
        {
            var existingContact = _context.contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existingContact == null)
            {
                throw new InvalidOperationException("O contato não foi encontrado no banco de dados.");
            }

            existingContact.IsDeleted = true;
            // Indique que a entidade foi modificada e precisa ser atualizada no banco de dados
            _context.Entry(existingContact).State = EntityState.Modified;

            // Salve as alterações no banco de dados
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Edit(Contact contact)
    {
        try
        {
            var existingContact = _context.contacts.FirstOrDefault(c => c.Id == contact.Id);

            if (existingContact == null)
            {
                throw new InvalidOperationException("O contato não foi encontrado no banco de dados.");
            }

            // Atualize as propriedades do contato existente com os novos valores
            existingContact.Name = contact.Name;
            existingContact.Contato = contact.Contato;
            existingContact.Email = contact.Email;

            // Indique que a entidade foi modificada e precisa ser atualizada no banco de dados
            _context.Entry(existingContact).State = EntityState.Modified;

            // Salve as alterações no banco de dados
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public bool EmailExist(Contact contact)
    {
        try
        {
            var contactBd = _context.contacts.FirstOrDefault(x => x.Email == contact.Email);
            if (contactBd == null)
            {
               return false;
            }
            return true;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public Contact Get(int id)
    {
        try
        {
            var contact = _context.contacts.FirstOrDefault(x => x.Id == id);
            if (contact == null) {
                throw new Exception("Contato não encontrado.");
            }
            return contact;


        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public List<Contact> GetContacts()
    {
        try
        {
            return _context.contacts.Where(ct => ct.IsDeleted == false).ToList();
        }catch (Exception ex) {
            throw ex;
        }
    }
}