using ContactManagement.Models;

namespace ContactManagement.Repository;

public interface IContactRepository
{
    void Add(Contact contact);
    List<Contact> GetContacts();
    Contact Get(int id);
    void Edit(Contact contact);
    void Delete(Contact contact);
    bool EmailExist(Contact contact);
    bool ContatoExist(Contact contact);
}
