using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Interfaces;
public interface IStudentService
{
    List<Student> GetAll();
    string Create(CreateStudentDto request);
    string Update(UpdateStudentDto request);
    string Delete(Guid id);

}
