﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo.Shared;

namespace Todo.API.DataProvider
{
    public class TodosProvider : ITodosProvider
    {
        private List<ToDoItem> _items = GetInitialList();

        public Task<ToDoItem[]> GetTodos()
        {
            return Task.FromResult(_items.ToArray());
        }

        public Task Add(ToDoItem item)
        {
            item.Id = Guid.NewGuid();
            _items.Add(item);
            return Task.CompletedTask;
        }

        public async Task Edit(ToDoItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var itemToEdit = await GetTodo(item.Id.Value);
            itemToEdit.Title = item.Title;
            itemToEdit.IsDone = item.IsDone;
            itemToEdit.Description = item.Description;
        }

        public async Task Remove(Guid todoId)
        {
            var item = await GetTodo(todoId);
            _items.Remove(item);
        }

        public Task<ToDoItem> GetTodo(Guid todoId)
        {
            var item = _items.FirstOrDefault(t => t.Id == todoId);
            if (item == null)
            {
                //TODO: use Result instead of throwing exception
                //https://josef.codes/my-take-on-the-result-class-in-c-sharp/
                throw new Exception($"Cannot find todo with id {todoId}");
            }
            return Task.FromResult(item);
        }

        private static List<ToDoItem> GetInitialList()
        {
            return new List<ToDoItem>
            {
                new ToDoItem(Guid.NewGuid(), "Read from a book", "Dracula", false),
                new ToDoItem(Guid.NewGuid(), "Hit the gym", "SweatIT", false),
                new ToDoItem(Guid.NewGuid(), "Meeting at Cegeka Academy", "9:30", false)
            };
        }

        
    }
}
