using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCrm {
    class Person 
    {
        /// <summary>
        /// 
        /// </summary>
        private int age_;
        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Age
        {
            get
            {
                return age_;
            }
            set
            {
                if (value > 0 && value < 120) {
                    age_ = value;
                } else {
                    throw new ArgumentOutOfRangeException(
                                        "age", "age must be between 1 and 120");
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="last"></param>
        public Person(string last)
        {
            if (string.IsNullOrWhiteSpace(last)) {
                throw new ArgumentNullException(
                    nameof(last), "lastname is null or white space");
            } else {
                LastName = last;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool IsAdult()
        {
            return Age >= 18;
        }
    }
}
