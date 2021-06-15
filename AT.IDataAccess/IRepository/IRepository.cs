using System.Collections.Generic;
namespace AT.IDataAccess.IRepository {
    public interface IRepository<IEntity> {
        IEnumerable<IEntity> GetAll ();
        IEntity GetById (int id);
        IEntity Create (IEntity entity);
        IEntity Update (IEntity entity);
        bool Delete (int id);

    }
}