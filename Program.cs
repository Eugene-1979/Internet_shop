using System.Text;

namespace Internet_shop
{
    internal class Program
    {
       
      
        static void Main(string[] args)
        {

          


          

            int val = 5;
           /* создаём директора*/
                 Director dir = new Director("Bob");

          /*  создаём перечень категорий*/
                 List<string> cat = new List<string> { "fruit", "clothes", "sport" };


            Shop shop1 = dir.CreateShop(cat, "ATB");

            List<Salesman> salesmen = new List<Salesman>();
            for (int i = 0; i < val; i++)
            {
                salesmen.Add(new Salesman("Salesman" + i));
            }
            

          /*  находим 10 сотрудников на work.ua*/
                 for (int i = 0; i < val; i++)
            {
                dir.Add_Salesman_in_Shop(salesmen[i], shop1, i * 1000);

            }

            /* директор Боб создаёт отделы в своём магаз. 
            Только директор создавший свой магаз может создавать отделы
            .т.е директор и магаз-должні совпадать*/

           

           
                shop1.AddCategory("Fruts", dir);
                shop1.AddCategory("Sport", dir);
                shop1.AddCategory("Shoes", dir);

         




            /* добавляем продукті в магаз Apple по 100 гр -1000шт и т.д*/
            shop1.add_Product(new Product("Fruts", "Apple", 100), 1000, dir);
            shop1.add_Product(new Product("Fruts", "Pear", 50), 1000, dir);
            shop1.add_Product(new Product("sPorts", "Ball", 100), 1000, dir);
            shop1.add_Product(new Product("sportS", "weight", 100), 1000, dir);

            Console.WriteLine(shop1);


           /* товары сравниваются по названию и сама транзакция 
                записывается  в магаз и покупателю*/
            Cuctomer customer = new Cuctomer("Customer");
            customer.Sale(shop1, new Dictionary<Product, int>() {
                { new Product(null, "Apple", 0), 1000 },
                 { new Product(null, "Ball", 0), 1000 }
                      });



            /*После покупки в магаз стало меньше товаров*/
             Console.WriteLine(shop1);


         /*   Смотрим покупатиля со списком транзакций*/
            Console.WriteLine(customer);




            /*Если покупатель заказал больше ,чем в магаз 
                то покупается всё что есть и показ,сколько недокуплено*/
            customer.Sale(shop1, new Dictionary<Product, int>() {
                { new Product(null, "PEAR", 0), 10000 },
                
                      });

            Console.WriteLine(customer);Console.WriteLine(customer);

      
            /*Чтобы показать реализацию от интерфейса сделаю несколько магаз*/
            List<Shop> listShop = new List<Shop>();
            for (int i = 0; i <10; i++)
            {
                listShop.Add(new Shop(dir, cat, "shop" + i));
            }

           /* создадим 2 продавца*/
            Salesman sal2 = new Salesman("new Salesman");

            /*добавим 2 продавца через метод интерфейса IAddSalesman*/
            foreach (var item in listShop)
            {
                if (item is IAddSalesman sal) sal.AddSalesman(dir, sal2, 10000);
            }

            /* смотрим 10 новых магаз*/

            foreach (var item in listShop)
            {
                Console.WriteLine(item);
            }




        }



}
}