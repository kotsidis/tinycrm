using System.Collections.Generic;

namespace SmallCrm {
    class Order 
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public decimal TotalAmount { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Product> ProductList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="amount"></param>
        public Order(int id, decimal amount)
        {
            Id = id;
            TotalAmount = amount;
            ProductList = new List<Product>();
        }
    }
}
