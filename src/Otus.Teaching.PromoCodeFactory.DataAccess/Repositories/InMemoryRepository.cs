using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Otus.Teaching.PromoCodeFactory.Core.Abstractions.Repositories;
using Otus.Teaching.PromoCodeFactory.Core.Domain;

namespace Otus.Teaching.PromoCodeFactory.DataAccess.Repositories
{
    public class InMemoryRepository<T>
        : IRepository<T>
        where T: BaseEntity
    {

        private List<T> _data = new List<T>();

        protected IEnumerable<T> Data => _data;

        public InMemoryRepository(IEnumerable<T> data)
        {
            _data.AddRange(data);
        }
        
        public Task<IEnumerable<T>> GetAllAsync()
        {
            return Task.FromResult(Data);
        }

        public Task<T> GetByIdAsync(Guid id)
        {
            return Task.FromResult(Data.FirstOrDefault(x => x.Id == id));
        }

        public Task<int> DeleteAsync(Guid id)
        {
            return Task.FromResult( Delete(id) );
        }

        public Task<int> AddAsync(T item)
        {
            return Task.FromResult(Add(item));
        }

        public Task<int> UpdateAsync(T item)
        {
            return Task.FromResult(Update(item));
        }

        private int Add(T item)
        {
            var savedItem = _data.FirstOrDefault(x => x.Id == item.Id);

            if (savedItem == null)
            {
               _data.Add(item);
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public int Update(T item)
        {
            var savedItem = _data.FirstOrDefault(x => x.Id == item.Id);

            if (savedItem == null)
            {
                return 0;
            }
            else
            {
                savedItem.Update(item);
                return 1;
            }
        }

        private int Delete(Guid id)
        {
            var item = _data.FirstOrDefault(x =>  x.Id == id);

            if (item == null)
            {
                return 0;
            }
            else
            {
                _data.Remove(item);
                return 1;
            }
        }
    }
}