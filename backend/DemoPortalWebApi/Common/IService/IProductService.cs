using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IProductService
    {
        public Task<List<ProductDetails>> ProductListAsync();
        public Task<ProductDetails> GetProductDetailByIdAsync(string productId);
        public Task AddProductAsync(ProductDetails productDetails);
        public Task UpdateProductAsync(string productId, ProductDetails productDetails);
        public Task DeleteProductAsync(String productId);
    }
}
