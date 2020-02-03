using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace SmallCrm {
    class Program {

        public static List<Product> products = new List<Product>();
        public static List<string> idList = new List<string>();
        public static Dictionary<string, int> mostPopularProducts =
                new Dictionary<string, int>();

        static void Main(string[] args)
        {
            var path = @"/Users/KCA1/devel/SmallCrm/products.csv";
            ReadCsv(path);
            /*
             * Greate the 2 costumers
             */
            var first = new Customer("Stavridis")
            {
                CustId = 1
            };

            var second = new Customer("Keskilidou")
            {
                CustId = 2
            };

            /*
             * Greate two orders
             */
            var order1 = new Order(1, 31513);
            var order2 = new Order(2, 64431);

            /*
             * Fill the 2 product list with random products
             */
            for (var i=0; i<10; i++) {
                order1.ProductList.Add(products[RandomNum(0, 30)]);
                order2.ProductList.Add(products[RandomNum(0, 30)]);
            }

            /*
             * Fill the order lists with the 2 orders
             */
            first.OrderList.Add(order1);
            second.OrderList.Add(order2);

            /*
             * Calculate how much each customer spend
             */
            var sum1 = default(decimal);
            var sum2 = default(decimal);
            for (var i = 0; i < 10; i++) {
                 sum1 = sum1 + first.OrderList[0].ProductList[i].Price;
                 sum2 = sum2 + second.OrderList[0].ProductList[i].Price;
            }

            /*
             * Call a function to print who spent the mosd
             */
            whoSpendMost(sum1, sum2, first, second);

            /*
             * Fill a dictionary with the product id
             * and the times each product is sold
             */
            FillDictionary(order1.ProductList);
            FillDictionary(order2.ProductList);

            /*
             * Sort the dictionary by value
             * and print the 10 most solded products
             */
            var count = 0;
            foreach (var item in mostPopularProducts
                .OrderByDescending(i => i.Value)) {
                Console.WriteLine($" The {count + 1} most popular " +
                    $"product is: {item.Key} with {item.Value} solds");
                count++;
                if (count == 10) {
                    break;
                }
            }
            Console.ReadLine();
        }



        public static void ReadCsv(string path)
        {
            if (path == null) {
                throw new ArgumentNullException("Path cannot be Null", "null");
            }
            using (var reader = File.OpenText(path)) {
                while (!reader.EndOfStream) {
                    var line = reader.ReadLine();
                    var values = line.Split(';');
                    if (values[0] == null || values[1] == null) {
                        throw new Exception("File has null values");
                    }
                    var pr = new Product();
                    var price = RandomNum(1000, 100000);
                    if (price == 0) {
                        throw new Exception("random is not working");
                    }

                    idList.Add(values[0]);

                    if (!IsUniqueId(idList, values[0] )) {
                        pr.Price = price;
                        pr.ProductId = values[0];
                        pr.Description = values[1];
                        products.Add(pr);
                    }
                }

                for (var i = 0; i < products.Count; i++) {
                    Console.WriteLine(products[i].ProductId);
                    Console.WriteLine(products[i].Description);
                    Console.WriteLine(products[i].Price);
                }
            }
        }

        public static int RandomNum(int min, int max)
        {
            // Generate a random number between two numbers 
            if (max <= min) {
                throw new ArgumentNullException(nameof(max), "max must be greater than min");
            }
            Random random = new Random();
            return random.Next(min, max);

        }

        public static bool IsUniqueId(List<string> list ,string id)
        {
            if (list == null) {
                throw new ArgumentNullException(nameof(list), "list is null");
            }
            if (id == null) {
                throw new ArgumentNullException(nameof(id), "Id is null");
            }
            if (!string.IsNullOrWhiteSpace(id)) {
                 list.SingleOrDefault(s => s.Equals(id));
                return false;
            }
            else {
                throw new Exception("Id is not unique");    
            }
        }

        public static void FillDictionary(List <Product> productList)
        {
            if (productList == null) {
                throw new ArgumentNullException(nameof(productList), "product list is null");
            }
            foreach (var p in productList) {
                if (!mostPopularProducts.ContainsKey(p.ProductId)) {
                    mostPopularProducts.Add(p.ProductId, 1);
                } else {
                    mostPopularProducts.TryGetValue(p.ProductId,
                        out int value);
                    mostPopularProducts.Remove(p.ProductId);
                    var newValue = value + 1;
                    mostPopularProducts.Add(p.ProductId, newValue);
                }
            }
        }

        public static void whoSpendMost(decimal sum1, decimal sum2, Customer first, Customer second)
        {
            if (first == null) {
                throw new ArgumentNullException(nameof(first), "product list is null");
            }
            if (second == null) {
                throw new ArgumentNullException(nameof(second), "product list is null");
            }
            if (sum1 == 0) {
                throw new ArgumentNullException(nameof(sum1), "Sum cannot be zero");
            }
            if (sum2 == 0) {
                throw new ArgumentNullException(nameof(sum2), "Sum cannot be zero");
            }
            if (sum1 > sum2) {
                Console.WriteLine($"the {first.LastName} " +
                    $"spend the most: {sum1} Euros");
            } else if (sum1 < sum2) {
                Console.WriteLine($"the {second.LastName} " +
                    $"spend the most: {sum2} Euros");
            } else {
                Console.WriteLine($"They both spend equal amount : {sum1}");
            }
        }

    }
}
