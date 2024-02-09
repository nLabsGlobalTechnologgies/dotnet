using FluentValidation.Results;
using NTierArchitecture.Business.Interfaces;
using NTierArchitecture.Business.Validators;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.Entities.DTOs;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.Business.Services;
public class StudentService(IStudentRepository studentRepository) : IStudentService
{
    public List<Student> GetAll()
    {
        return studentRepository.GetAll();
    }

    public string Create(CreateStudentDto request)
    {
        CreateStudentDtoValidator validator = new();
        ValidationResult result = validator.Validate(request);
        if (!result.IsValid)
        {
            throw new ArgumentException(string.Join(" ", result.Errors));
        }

        var isExists = studentRepository.IsIdCardNumberExists(request.IdCardNumber);
        if (isExists)
        {
            throw new Exception("TC numarası daha önce kaydedilmiş!");
        }

        Student student = new()
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Number = request.Number,
            ClassNumber = request.ClassNumber
        };
        studentRepository.Create(student);

        return "Kayıt başarılı";
    }

    public string Update(UpdateStudentDto request)
    {
        throw new NotImplementedException();
    }

    public string Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}
