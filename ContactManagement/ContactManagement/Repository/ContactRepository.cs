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
            _context.Add(contact);
            _context.SaveChanges();
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
            _context.Remove(contact);
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
            _context.Update(contact);
            _context.SaveChanges();
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
            return _context.contacts.ToList();
        }catch (Exception ex) {
            throw ex;
        }
    }
}