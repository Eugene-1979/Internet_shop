using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Cuctomer
    {
        List<Transaction> lst = new List<Transaction>();
        public string _Name { get; init; }

        public Cuctomer(string name)
        {
            _Name = name;

        }



        public void Sale(Shop shop, Dictionary<Product, int> dict) 
        {
            if (shop == null || dict == null) throw new ArgumentException("no good");
            lst.Add(new Transaction(shop, this, dict));
        }

        public override string ToString()
        {
            return $@"{{{nameof(_Name)}={_Name}}}
Транзакции
{string.Join('\n',lst)}

";
        }
    }
}
