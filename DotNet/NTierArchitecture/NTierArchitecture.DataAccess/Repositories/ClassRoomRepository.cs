using NTierArchitecture.DataAccess.Context;
using NTierArchitecture.DataAccess.Interfaces;
using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.DataAccess.Repositories;
public sealed class ClassRoomRepository(AppDbContext context) : IClassRoomRepository
{
    public List<ClassRoom> GetAll()
    {
        var result = context.ClassRooms!.ToList();
        return result;
    }

    public void Create(ClassRoom classRoom)
    {
        context.Add(classRoom);
        context.SaveChanges();
    }

    public void Update(ClassRoom classRoom)
    {
        context.Update(classRoom);
    }

    public ClassRoom? Get(Guid id)
    {
        ClassRoom? classRoom = context.ClassRooms?.FirstOrDefault(p => p.Id == id);
        return classRoom;
    }

    public void Delete(Guid id)
    {
        var classRoom = context.ClassRooms?.FirstOrDefault(p => p.Id == id);
        if (classRoom is null)
        {
            throw new ArgumentException("Not Found");
        }

        context.Remove(classRoom);
    }

    public bool IsNameExists(string name)
    {
        return context.ClassRooms.Any(p => p.Name == name);
    }
}
