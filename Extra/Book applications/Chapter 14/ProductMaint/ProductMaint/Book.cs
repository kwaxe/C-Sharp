using System;

namespace ProductMaint
{
    public class Book : Product
	{
		private string author;

        public Book()
        {
        }
        
        public Book(string code, string description, string author, 
            decimal price) : base(code, description, price)
        {
            this.Author = author;
        }

        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }

        public override string GetDisplayText(string sep)
        {
            return base.GetDisplayText(sep) + " (" + Author + ")";
        }

	}
}
