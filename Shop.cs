using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Shop
    {
        readonly Director _Director;

        Dictionary<Product, int> _Product= new Dictionary<Product, int>();

       

        public bool IsProduct(string str) {
       
            return _Product.ContainsKey(new Product(null, str, 0));
                
         
        }

        public Dictionary<Product, int> Get_Product() {
            return _Product;
        }

        public void add_Product(Product prod, int val, Director director) {
            if (prod == null || director == null || val < 1) throw new ArgumentException();

            if (director == _Director) {
                if (_Product.ContainsKey(prod))  _Product[prod] += val;
                else  _Product.Add(prod, val);          
            }
        
        }


        public Shop(Director director, List<string>? category_List, string name)
        {
            

            _Director = director;
            Category_List = category_List;
            Name = name;
        }

public string Name { get; init; }
        
       public Dictionary<Salesman, int> _salesmans 
            = new Dictionary<Salesman, int>();
        

        private List<string>? Category_List { get; init; } 
            = new List<string>();


        /* Добавление сотрудника c ЗП,чтобы только директор этогот магаз мог добавить категории*/
        public void AddSalesman(Director dir,Salesman sal, int val)
        {
            if (dir == _Director)
            {
                _salesmans?.Add(sal, val);
                sal.Add_Shop(this);
            }


        }


        /* Добавление категории,чтобы только директор этогот магаз мог добавить категории*/
        public void AddCategory(string cat,Director dir ) {
            if (dir==_Director) Category_List?.Add(cat.ToUpper());

             
        }

        public override string ToString()
        { 
            StringBuilder salesmanSB=new StringBuilder("");
            foreach (var item in _salesmans)
            {
                salesmanSB.Append(item.Key).Append("  ").Append(item.Value).
                    Append(Environment.NewLine);
            }
            StringBuilder productSB=new StringBuilder("");
            foreach (var item in _Product)
            {
                productSB.Append(item.Key).Append("  ").Append(item.Value).
                    Append(Environment.NewLine);
            }





            return $@"{{{nameof(Name)}={Name}}} 
Director{_Director} 
Продавецы
{salesmanSB.ToString()}
Продукты
{productSB.ToString()}
";


        }
    }
}
