using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Internet_shop
{
    internal class Product : IEquatable<Product?>

    {
        public Product(string categor, string name, int price)
        {
            _Categor = categor?.ToUpper();
            Name = name.ToLower();
            Price = price;
        }

        public string _Categor { get; init; }
        public string Name { get; init; }
        public int Price { get; init; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as Product);
        }

        public bool Equals(Product? other)
        {
            return other is not null &&
                   Name == other.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override string ToString()
        {
            return $"{{{nameof(_Categor)}={_Categor}, {nameof(Name)}={Name}, {nameof(Price)}={Price.ToString()}}}";
        }

        public static bool operator ==(Product? left, Product? right)
        {
            return EqualityComparer<Product>.Default.Equals(left, right);
        }

        public static bool operator !=(Product? left, Product? right)
        {
            return !(left == right);
        }
    }
}
