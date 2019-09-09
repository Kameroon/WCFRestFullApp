using System.Collections.Generic;

namespace ReposotoryProject.Contracts
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetByName(string name);
        void AddNew(TEntity item);
        bool Delete(int id);
        bool Update(TEntity item);
    }
}
