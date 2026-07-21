using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    public class InventoryManager
    {
        // Primary data structure: Dictionary for O(1) lookup by productId
        private Dictionary<int, Product> _inventoryById;
        
        // Secondary data structure: Dictionary for O(1) lookup by productName
        private Dictionary<string, List<int>> _inventoryByName;
        
        // For maintaining sorted order (optional)
        private List<Product> _inventoryList;

        public InventoryManager()
        {
            _inventoryById = new Dictionary<int, Product>();
            _inventoryByName = new Dictionary<string, List<int>>();
            _inventoryList = new List<Product>();
        }

        // ADD OPERATION - O(1) average time complexity
        public bool AddProduct(Product product)
        {
            if (_inventoryById.ContainsKey(product.ProductId))
            {
                Console.WriteLine($"Product with ID {product.ProductId} already exists");
                return false;
            }

            _inventoryById[product.ProductId] = product;
            
            // Update name-based index
            string name = product.ProductName.ToLower();
            if (!_inventoryByName.ContainsKey(name))
            {
                _inventoryByName[name] = new List<int>();
            }
            _inventoryByName[name].Add(product.ProductId);
            
            // Add to list for iteration
            _inventoryList.Add(product);
            
            Console.WriteLine($"Product added: {product.GetProductDetails()}");
            return true;
        }

        // UPDATE OPERATION - O(1) average time complexity
        public bool UpdateProduct(int productId, string newName, int newQuantity, double newPrice)
        {
            if (!_inventoryById.ContainsKey(productId))
            {
                Console.WriteLine($"Product with ID {productId} not found");
                return false;
            }

            Product product = _inventoryById[productId];
            
            // Update name index if name changed
            if (newName != null && newName != product.ProductName)
            {
                string old_name = product.ProductName.ToLower();
                string new_name = newName.ToLower();
                
                _inventoryByName[old_name].Remove(productId);
                if (!_inventoryByName.ContainsKey(new_name))
                {
                    _inventoryByName[new_name] = new List<int>();
                }
                _inventoryByName[new_name].Add(productId);
            }

            // Update product attributes
            if (newName != null) product.ProductName = newName;
            if (newQuantity >= 0) product.Quantity = newQuantity;
            if (newPrice >= 0) product.Price = newPrice;

            Console.WriteLine($"Product updated: {product.GetProductDetails()}");
            return true;
        }

        // DELETE OPERATION - O(1) average time complexity
        public bool DeleteProduct(int productId)
        {
            if (!_inventoryById.ContainsKey(productId))
            {
                Console.WriteLine($"Product with ID {productId} not found");
                return false;
            }

            Product product = _inventoryById[productId];
            
            // Remove from name index
            string name = product.ProductName.ToLower();
            if (_inventoryByName.ContainsKey(name))
            {
                _inventoryByName[name].Remove(productId);
            }
            
            // Remove from list
            _inventoryList.Remove(product);
            
            // Remove from main dictionary
            _inventoryById.Remove(productId);
            
            Console.WriteLine($"Product deleted: {product.GetProductDetails()}");
            return true;
        }

        // SEARCH OPERATION - O(1) average time complexity
        public Product? SearchProductById(int productId)
        {
            if (_inventoryById.TryGetValue(productId, out Product? product))
            {
                return product;
            }
            Console.WriteLine($"Product with ID {productId} not found");
            return null;
        }

        // SEARCH OPERATION - O(1) average time complexity (returns all matching)
        public List<Product> SearchProductByName(string productName)
        {
            string name = productName.ToLower();
            List<Product> results = new List<Product>();
            
            if (_inventoryByName.ContainsKey(name))
            {
                foreach (int id in _inventoryByName[name])
                {
                    results.Add(_inventoryById[id]);
                }
            }
            
            if (results.Count == 0)
            {
                Console.WriteLine($"No products found with name: {productName}");
            }
            
            return results;
        }

        // GET ALL PRODUCTS - O(n) time complexity
        public List<Product> GetAllProducts()
        {
            return _inventoryList;
        }

        // Get total inventory value - O(n) time complexity
        public double GetTotalInventoryValue()
        {
            double total = 0;
            foreach (Product product in _inventoryList)
            {
                total += product.GetTotalValue();
            }
            return total;
        }

        // Get low stock products (quantity < threshold) - O(n) time complexity
        public List<Product> GetLowStockProducts(int threshold)
        {
            List<Product> lowStock = new List<Product>();
            foreach (Product product in _inventoryList)
            {
                if (product.Quantity < threshold)
                {
                    lowStock.Add(product);
                }
            }
            return lowStock;
        }

        // Get inventory count - O(1) time complexity
        public int GetInventoryCount()
        {
            return _inventoryById.Count;
        }

        // Display all products - O(n) time complexity
        public void DisplayAllProducts()
        {
            Console.WriteLine("\n=== All Products ===");
            Console.WriteLine($"Total Products: {_inventoryList.Count}");
            Console.WriteLine("--------------------");
            
            foreach (Product product in _inventoryList)
            {
                Console.WriteLine(product.GetProductDetails());
            }
            Console.WriteLine("--------------------\n");
        }

        // Alternative: Using List only (for comparison)
        public class InventoryWithList
        {
            private List<Product> _products;

            public InventoryWithList()
            {
                _products = new List<Product>();
            }

            // ADD: O(n) - must check for duplicates
            public bool AddProduct(Product product)
            {
                foreach (Product p in _products)
                {
                    if (p.ProductId == product.ProductId)
                    {
                        Console.WriteLine($"Product with ID {product.ProductId} already exists");
                        return false;
                    }
                }
                _products.Add(product);
                return true;
            }

            // UPDATE: O(n) - must search for product
            public bool UpdateProduct(int productId, string newName, int newQuantity, double newPrice)
            {
                foreach (Product product in _products)
                {
                    if (product.ProductId == productId)
                    {
                        if (newName != null) product.ProductName = newName;
                        if (newQuantity >= 0) product.Quantity = newQuantity;
                        if (newPrice >= 0) product.Price = newPrice;
                        return true;
                    }
                }
                return false;
            }

            // DELETE: O(n) - must search for product
            public bool DeleteProduct(int productId)
            {
                Product? product = _products.FirstOrDefault(p => p.ProductId == productId);
                if (product != null)
                {
                    _products.Remove(product);
                    return true;
                }
                return false;
            }

            // SEARCH: O(n) - must iterate through all products
            public Product? SearchProductById(int productId)
            {
                return _products.FirstOrDefault(p => p.ProductId == productId);
            }

            public int GetCount()
            {
                return _products.Count;
            }
        }

        // Dictionary-based inventory for performance comparison
        public class DictionaryInventory
        {
            private Dictionary<int, Product> _products;

            public DictionaryInventory()
            {
                _products = new Dictionary<int, Product>();
            }

            public bool AddProduct(Product product)
            {
                if (_products.ContainsKey(product.ProductId))
                {
                    Console.WriteLine($"Product with ID {product.ProductId} already exists");
                    return false;
                }

                _products[product.ProductId] = product;
                return true;
            }

            public bool UpdateProduct(int productId, string newName, int newQuantity, double newPrice)
            {
                if (!_products.TryGetValue(productId, out Product? product))
                {
                    return false;
                }

                if (newName != null) product.ProductName = newName;
                if (newQuantity >= 0) product.Quantity = newQuantity;
                if (newPrice >= 0) product.Price = newPrice;
                return true;
            }

            public bool DeleteProduct(int productId)
            {
                return _products.Remove(productId);
            }

            public Product? SearchProductById(int productId)
            {
                _products.TryGetValue(productId, out Product? product);
                return product;
            }
        }
    }
}