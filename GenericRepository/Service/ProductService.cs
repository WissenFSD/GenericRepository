using GenericRepository.DMO;
using GenericRepository.Repository;

namespace GenericRepository.Service
{

    public interface IProductService
	{
		public Product GetProductId(int id);

		public List<Product> GetAll();
	}
	public class ProductService : IProductService
	{
		private ProductRepository _repository;
        public ProductService(ProductRepository repository)
        {
            _repository = repository;
        }
        public Product GetProductId(int id)
		{
			var result = _repository.GetById(id);
			return result;
		}
		public List<Product> GetAll()
		{
			
			var result =_repository.GetAll().ToList();
			return result;
		}
	}
}
