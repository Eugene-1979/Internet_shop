using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Director
    {
        public string Name { get; init; }

        public Director(string name)
        {
            Name = name;
        }

        public void Add_Salesman_in_Shop(Salesman sal,Shop shop,int salary ) {
            shop.AddSalesman(this, sal, salary);
        
        }

        public Shop CreateShop(List<string> cat, string name)
        {
            return new Shop(this, cat, name);
        }


     /*   только директор может добавлять категории*/
        void AddCategory(Shop shop, string category)
        {
            shop.AddCategory(category, this);

        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}}}";
        }

     
    }
}
