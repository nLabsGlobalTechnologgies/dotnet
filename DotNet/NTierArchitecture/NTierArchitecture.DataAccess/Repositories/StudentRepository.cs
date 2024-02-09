using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.DataAccess.Repositories;
public sealed class StudentRepository(AppDbContext context) : IStudentRepository
{
    public List<Student> GetAll()
    {
        return context.Students!.ToList();
    }

    public void Create(Student student)
    {
        context.Add(student);
        context.SaveChanges();
    }

    public void Update(Student student)
    {
        context.Update(student);
        context.SaveChanges();
    }

    public Student? Get(Guid id)
    {
        Student? student =  context.Students?.FirstOrDefault(p => p.Id == id);
        return student;
    }

    public void Delete(Guid id)
    {
        var student = context.Students?.FirstOrDefault(p => p.Id == id);
        if (student is not null)
        {
            context.Remove(student);
            context.SaveChanges();
        }
    }

    public bool IsIdCardNumberExists(string idCard)
    {
        return context.Students!.Any(p => p.IdCardNumber == idCard);
    }
}
