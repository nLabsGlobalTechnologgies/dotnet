using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.DataAccess.Interfaces;
public interface IStudentRepository
{
    void Create(Student student);
    void Update(Student student);
    void Delete(Guid id);
    List<Student> GetAll();
    Student? Get(Guid id);
    bool IsIdCardNumberExists(string idCard);
}
