﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_demo
{
	public class Customer
	{
		public int CustomerId { get; set; }
		public string Name { get; set; }
		public ICollection<Association> Associations { get; set; }
	}
}
