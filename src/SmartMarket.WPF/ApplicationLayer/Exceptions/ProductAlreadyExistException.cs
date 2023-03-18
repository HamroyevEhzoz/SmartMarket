using System;

namespace SmartMarket.WPF.ApplicationLayer.Exceptions
{
    public class ProductAlreadyExistException : Exception
    {
        private const string _message = "This Product Already Exist in Our Database!";

        public ProductAlreadyExistException()
            : base(_message)
        {
        }
    }
}
