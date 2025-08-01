using YumBlazor.Data;

namespace YumBlazor.Utility
{
    public static class SD
    {
        public static readonly string Role_Admin = "Admin";
        public static readonly string Role_Customer = "Customer";

        public static readonly string StatusPending = "Pending";
        public static readonly string StatusReadyForPickup = "ReadyForPickup";
        public static readonly string StatusCompleted = "Completed";
        public static readonly string StatusCancelled = "Cancelled";

        public static List<OrderDetail> ConvertShoppingCartListToOrderDetail(List<ShoppingCart> shoppingCarts)
        {
            List<OrderDetail> orderDetails = [];

            foreach (var cart in shoppingCarts)
            {
                OrderDetail orderDetail = new()
                {
                    ProductId = cart.ProductId,
                    Count = cart.Count,
                    Price = Convert.ToDouble(cart.Product!.Price),
                    ProductName = cart.Product.Name
                };

                orderDetails.Add(orderDetail);
            }

            return orderDetails;
        }
    }
}
