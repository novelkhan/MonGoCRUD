using MonGoCRUD.Models;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MonGoCRUD.Interfaces
{
    public interface IStudentRepository
    {
        Task<ObjectId> Create(Student student);
        Task<Student> Get(ObjectId objectId);
        Task<IEnumerable<Student>> GetAll();
        Task<IEnumerable<Student>> GetByName(string name);
        Task<bool> Update(ObjectId objectId, Student student);
        Task<bool> Delete(ObjectId objectId);
    }
}
