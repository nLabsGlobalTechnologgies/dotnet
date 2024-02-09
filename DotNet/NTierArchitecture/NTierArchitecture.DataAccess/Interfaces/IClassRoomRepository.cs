using NTierArchitecture.Entities.Models;

namespace NTierArchitecture.DataAccess.Interfaces;
public interface IClassRoomRepository
{
    void Create(ClassRoom classRoom);
    void Update(ClassRoom classRoom);
    void Delete(Guid id);
    List<ClassRoom> GetAll();
    ClassRoom? Get(Guid id);
    bool IsNameExists(string name);
}
