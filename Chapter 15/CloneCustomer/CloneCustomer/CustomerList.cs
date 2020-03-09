using System;
using System.Collections.Generic;

namespace CloneCustomer
{
    public class CustomerList
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

	}
}
