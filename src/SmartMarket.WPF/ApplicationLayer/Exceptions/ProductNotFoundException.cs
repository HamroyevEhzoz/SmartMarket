using System;

namespace SmartMarket.WPF.ApplicationLayer.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        private const string _message = "Product Not Found!";
        public ProductNotFoundException()
            : base(_message)
        {
        }
    }
}
