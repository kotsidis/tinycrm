using System;

namespace SmallCrm {
    class Customer : Person {
        /// <summary>
        /// 
        /// </summary>
        public int CustId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<Order> OrderList { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        public Customer(string last)
            : base(last)
        {
        OrderList = new List<Order>();
        }
    }
}
