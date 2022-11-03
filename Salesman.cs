using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Salesman
    {
        List<Shop> _shops = new List<Shop>();


        public void Add_Shop(Shop shop) => _shops.Add(shop);

        public Salesman(string name)
        {
            _Name = name;
        }

        public string _Name { get; init; }

        public override string ToString()
        {
            return $"{{{nameof(_Name)}={_Name}}}";
        }
    }
}
