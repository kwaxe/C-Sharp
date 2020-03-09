using System;
using System.Collections.Generic;

namespace CloneCustomer
{
    public class CustomerList : IEnumerable<Customer>
	{
        private List<Customer> customers = new List<Customer>();

		public int Count
		{
			get
			{
				return customers.Count;
			}
		}

		public Customer this[int i]
		{
			get
			{
				return customers[i];
			}
		}

		public void Add(Customer customer)
		{
			customers.Add(customer);
		}



        public IEnumerator<Customer> GetEnumerator()
        {
            foreach (Customer c in customers)
            {
                yield return c;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
