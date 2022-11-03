using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Transaction
    {
      

        public Shop Shop { get; init; }
    
        public Cuctomer cuctomer { get; init; }

        Dictionary<Product,int> _products = new Dictionary<Product,int>();
        StringBuilder sb1=new StringBuilder("");
        public Transaction(Shop shop, Cuctomer cuctomer, Dictionary<Product, int> products)
        {
            Shop = shop;
            foreach (var item in products)
            {

                if (!shop.IsProduct(item.Key.Name)) sb1.Append($"прод { item.Key.Name} нет{Environment.NewLine}");
                int val = shop.Get_Product()[item.Key];
                if (val < item.Value)
                {
                    sb1.Append($"из{item.Value} на складе {val} -недокуплено {item.Value - val}  ");
                    shop.Get_Product()[item.Key] = 0;
                    _products.Add(item.Key, item.Value - val);
                }
                else {
                    _products.Add(item.Key, item.Value);
                    shop.Get_Product()[item.Key] -= val;
                }
            }


          
            this.cuctomer = cuctomer;
            _products = products;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("");
            foreach (var item in _products)
            {
                sb.Append("Product ").
                    Append(item.Key).
                    Append("Amount").
                    Append(item.Value).Append(Environment.NewLine);
            }


            return $"{{{nameof(Shop)}={Shop}, " +
              /*  $" {nameof(cuctomer)}={cuctomer}}}" +*/
                $"{Environment.NewLine}{sb.ToString()}{Environment.NewLine}{sb1.ToString()}";
        }
    }
}
