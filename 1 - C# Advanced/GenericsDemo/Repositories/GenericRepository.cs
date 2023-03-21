﻿using System;
using System.Collections.Generic;
using System.Linq;
using GenericsDemo.Entities;

namespace GenericsDemo.Repositories {
    public delegate void PreSave<T>();
    public delegate void PostSave<T>();
    public class GenericRepository<T> where T : IEntity {
        private readonly List<T> _items = new();
        private readonly PreSave<T> _preSave;
        private readonly PostSave<T> _postSave;

        public GenericRepository(PreSave<T> preSave, PostSave<T> postSave) {
            _preSave = preSave;
            _postSave = postSave;
        }

        public GenericRepository() { }

        public void Add(T item) {
            item.Id = _items.Count + 1;
            _items.Add(item);
        }

        public void Save() {
            if (_preSave!= null)
            {
                _preSave();
            }
            
            foreach (var item in _items) {
                Console.WriteLine(item);
            }

            if (_postSave!= null)
            {
                _postSave();
            }
        }

        // TODO: De adaugat o metoda noua care imi va returna un obiect dupa ID
        public T GetById(int id) {
            return _items.Find(x => x.Id == id);
        }
    }
}
