
using GenericRepository.DMO;

namespace GenericRepository.Repository
{

	// TEntity tipi ancak Baseentity sınıfından kalıtılacak
	public class GenericRepository<TEntity> : IRepository<TEntity>where TEntity : BaseEntity
	{
		private AdventureWorks2019Context _context;
        public GenericRepository(AdventureWorks2019Context context)
        {
            _context = context;
        }
        public void Create(TEntity entity)
		{
			_context.Set<TEntity>().Add(entity);

			_context.SaveChanges();
		}

		public void Delete(int id)
		{
			var result = GetById(id); 

			_context.Set<TEntity>().Remove(result);
		}
		public IQueryable<TEntity> GetAll()
		{
			return _context.Set<TEntity>().AsQueryable();
		}
		public TEntity GetById(int id)
		{
			return _context.Find<TEntity>(id);
		}

		public void Update(int id, TEntity entity)
		{
			_context.Set<TEntity>().Update(entity);
			// değişikliklerin kaydedilmesi için

			_context.SaveChanges();
		}
	}
}
