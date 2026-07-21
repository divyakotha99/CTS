namespace InventoryManagementSystem
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private int _quantity;
        private double _price;

        public Product(int productId, string productName, int quantity, double price)
        {
            _productId = productId;
            _productName = productName;
            _quantity = quantity;
            _price = price;
        }

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public double GetTotalValue()
        {
            return _quantity * _price;
        }

        public string GetProductDetails()
        {
            return $"ID: {_productId}, Name: {_productName}, Qty: {_quantity}, Price: ${_price}, Total: ${GetTotalValue()}";
        }
    }
}