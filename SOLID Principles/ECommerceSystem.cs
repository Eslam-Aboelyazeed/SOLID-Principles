using System.Collections;

namespace SOLID_Principles
{

    #region Before

    //public class ECommerceSystem
    //{
    //    private List<Product> products = new List<Product>();
    //    private List<Order> orders = new List<Order>();
    //    public void AddProduct(string name, decimal price, int quantity)
    //    {
    //        products.Add(new Product
    //        {
    //            Name = name,
    //            Price = price,
    //            Quantity =
    //        quantity
    //        });
    //    }
    //    public void PlaceOrder(string customerName, List<int> productIds, string
    //    paymentMethod)
    //    {
    //        decimal totalCost = 0;
    //        List<Product> orderedProducts = new List<Product>();
    //        foreach (int productId in productIds)
    //        {
    //            Product product = products.Find(p => p.Id == productId);
    //            if (product != null && product.Quantity > 0)
    //            {
    //                orderedProducts.Add(product);
    //                totalCost += product.Price;
    //                product.Quantity--;
    //            }
    //        }
    //        if (orderedProducts.Count > 0)
    //        {
    //            if (paymentMethod == "CreditCard")
    //            {
    //                ProcessCreditCardPayment(totalCost);
    //            }
    //            else if (paymentMethod == "PayPal")
    //            {
    //                ProcessPayPalPayment(totalCost);
    //            }
    //            Order order = new Order
    //            {
    //                CustomerName = customerName,
    //                Products = orderedProducts,
    //                TotalCost = totalCost
    //            };
    //            orders.Add(order);
    //            SendOrderConfirmationEmail(order);
    //        }
    //    }
    //    private void ProcessCreditCardPayment(decimal amount)
    //    {
    //        // Process credit card payment
    //        Console.WriteLine($"Processing credit card payment of ${amount}");
    //    }
    //    private void ProcessPayPalPayment(decimal amount)
    //    {
    //        // Process PayPal payment
    //        Console.WriteLine($"Processing PayPal payment of ${amount}");
    //    }
    //    private void SendOrderConfirmationEmail(Order order)
    //    {
    //        string message = $"Order confirmation for {order.CustomerName}:\n";
    //        message += $"Total Cost: ${order.TotalCost}\n";
    //        message += "Products:\n";
    //        foreach (Product product in order.Products)
    //        {
    //            message += $"- {product.Name} (${product.Price})\n";
    //        }
    //        // Send email
    //        Console.WriteLine(message);
    //    }
    //}
    //public class Product
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public decimal Price { get; set; }
    //    public int Quantity { get; set; }
    //}
    //public class Order
    //{
    //    public string CustomerName { get; set; }
    //    public List<Product> Products { get; set; }
    //    public decimal TotalCost { get; set; }
    //}

    #endregion

    #region After

    #region Interfaces

    public interface IECommerceSystemProductAdder
    {
        public void AddProduct(string name, decimal price, int quantity);
    }

    public interface IEcommerceSystemOrderPlacer
    {
        public void PlaceOrder(string customerName, List<int> productIds, IPaymentMethod paymentMethod);
    }
    public interface IOrderProductsCreater
    {
        IOrderDetails CreateOrderProducts(List<int> productIds);
    }

    public interface IPaymentMethod
    {
        void ProcessPayment(decimal totalCost);
    }

    public interface IOrderConfirmationEmailSender
    {
        void SendOrderConfirmationEmail(IOrder order);
    }

    #endregion

    #region Model Interfaces

    public interface IOrderDetails
    {
        public IList<IProduct>? OrderProducts { get; set; }
        public decimal TotalCost { get; set; }
    }

    public interface IProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public interface IOrder
    {
        public string? CustomerName { get; set; }
        public IList<IProduct>? Products { get; set; }
        public decimal TotalCost { get; set; }
    }

    #endregion

    #region Models

    public class OrderDetails : IOrderDetails
    {
        public IList<IProduct>? OrderProducts { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class Product : IProduct
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class Order : IOrder
    {
        public string? CustomerName { get; set; }
        public IList<IProduct>? Products { get; set; }
        public decimal TotalCost { get; set; }
    }

    public class Products : List<IProduct>, IList<IProduct>
    {
    }

    public class Orders : List<IOrder>, IList<IOrder>
    {
    }
    #endregion

    #region Classes

    public class ECommerceSystemProductAdder: IECommerceSystemProductAdder
    {
        private readonly IList<IProduct> _products;

        public ECommerceSystemProductAdder(IList<IProduct> products)
        {
            _products = products;
        }

        public void AddProduct(string name, decimal price, int quantity)
        {
            _products.Add(new Product
            {
                Name = name,
                Price = price,
                Quantity = quantity
            });
        }
    }

    public class EcommerceSystemOrderPlacer : IEcommerceSystemOrderPlacer
    {
        private readonly IList<IOrder> orders;
        private readonly IOrderConfirmationEmailSender emailSender;
        private readonly IOrderProductsCreater orderProductsCreater;

        public EcommerceSystemOrderPlacer(IList<IOrder> orders, IOrderConfirmationEmailSender emailSender, IOrderProductsCreater orderProductsCreater)
        {
            this.orders = orders;
            this.emailSender = emailSender;
            this.orderProductsCreater = orderProductsCreater;
        }

        public void PlaceOrder(string customerName, List<int> productIds, IPaymentMethod paymentMethod)
        {

            IOrderDetails orderDetails =  orderProductsCreater.CreateOrderProducts(productIds);

            if (orderDetails.OrderProducts?.Count > 0)
            {
                paymentMethod.ProcessPayment(orderDetails.TotalCost);
                IOrder order = new Order
                {
                    CustomerName = customerName,
                    Products = orderDetails.OrderProducts,
                    TotalCost = orderDetails.TotalCost
                };
                orders.Add(order);
                emailSender.SendOrderConfirmationEmail(order);
            }
        }
    }

    public class OrderProductsCreater : IOrderProductsCreater
    {
        private readonly IList<IProduct> products;

        public OrderProductsCreater(IList<IProduct> products)
        {
            this.products = products;
        }

        public IOrderDetails CreateOrderProducts(List<int> productIds)
        {
            decimal totalCost = 0;
            IList<IProduct> orderedProducts = new Products();
            foreach (int productId in productIds)
            {
                IProduct? product = products.FirstOrDefault(p => p.Id == productId);
                if (product != null && product.Quantity > 0)
                {
                    orderedProducts.Add(product);
                    totalCost += product.Price;
                    product.Quantity--;
                }
            }

            return new OrderDetails { OrderProducts = orderedProducts, TotalCost = totalCost };
        }
    }

    public class CreditCard : IPaymentMethod
    {
        public void ProcessPayment(decimal totalCost)
        {
            throw new NotImplementedException();
        }
    }

    public class PayPal : IPaymentMethod
    {
        public void ProcessPayment(decimal totalCost)
        {
            throw new NotImplementedException();
        }
    }

    public class OrderConfirmationEmailSender : IOrderConfirmationEmailSender
    {
        public void SendOrderConfirmationEmail(IOrder order)
        {
            string message = $"Order confirmation for {order.CustomerName}:\n";
            message += $"Total Cost: ${order.TotalCost}\n";
            message += "Products:\n";
            if (order.Products != null)
            {
                foreach (Product product in order.Products)
                {
                    message += $"- {product.Name} (${product.Price})\n";
                }
                // Send email
                Console.WriteLine(message);
            }
        }
    }

    #endregion

    #endregion
}
