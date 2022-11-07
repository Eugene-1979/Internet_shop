using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal interface Interface1
    {
    }
    interface IAddCategory
    {

        void AddCategory(string cat, Director dir);
    }
    interface Iadd_Product {
        void add_Product(Product prod, int val, Director director);


    }
    interface IAddSalesman {
        void AddSalesman(Director dir, Salesman sal, int val);
    };

    interface IaddTtansaction
    { void addTtansaction(Transaction tr); }

    interface IaddCustomer  {
        public void addCustomer(Cuctomer cust);
    }
    interface ISale
        { void Sale(Shop shop, Dictionary<Product, int> dict); }



}
