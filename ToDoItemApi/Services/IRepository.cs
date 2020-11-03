using ToDoItemApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoItemApi.Services
{
    public interface IRepository
    {
        void Create(ToDoItem toDoItem);

        List<ToDoItem> GetAll();

        ToDoItem GetById(long id);
    }
}