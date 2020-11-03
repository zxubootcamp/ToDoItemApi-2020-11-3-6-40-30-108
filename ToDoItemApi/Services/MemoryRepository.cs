using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoItemApi.Models;

namespace ToDoItemApi.Services
{
    public class MemoryRepository : IRepository
    {
        private readonly Dictionary<long, ToDoItem> _dic = new Dictionary<long, ToDoItem>();

        public MemoryRepository()
        {
            Init();
        }

        public void Create(ToDoItem toDoItem)
        {
            _dic.Add(toDoItem.Id, toDoItem);
        }

        public List<ToDoItem> GetAll()
        {
            return _dic.Values.ToList();
        }

        public ToDoItem GetById(long id)
        {
            _dic.TryGetValue(id, out var item);
            return item;
        }

        private void Init()
        {
            for (var i = 0; i < 2; i++)
            {
                var item = new ToDoItem()
                {
                    Id = i,
                    Name = $"test item {i}",
                    IsComplete = false,
                };
                _dic[item.Id] = item;
            }
        }
    }
}
