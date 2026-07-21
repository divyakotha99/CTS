namespace SortingCustomerOrders
{
    public class Order
    {
        private int _orderId;
        private string _customerName;
        private double _totalPrice;

        public Order(int orderId, string customerName, double totalPrice)
        {
            _orderId = orderId;
            _customerName = customerName;
            _totalPrice = totalPrice;
        }

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; }
        }

        public string GetOrderDetails()
        {
            return $"Order ID: {_orderId}, Customer: {_customerName}, Total: ${_totalPrice:F2}";
        }
    }
}