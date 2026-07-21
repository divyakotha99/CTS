namespace EcommerceSearchExample
{
    public class Product
    {
        private int _productId;
        private string _productName;
        private string _category;
        private double _price;

        public Product(int productId, string productName, string category, double price)
        {
            _productId = productId;
            _productName = productName;
            _category = category;
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

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string GetProductDetails()
        {
            return $"ID: {_productId}, Name: {_productName}, Category: {_category}, Price: ${_price}";
        }
    }
}