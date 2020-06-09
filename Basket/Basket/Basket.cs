using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Basket
{
    public class Basket : BindableBase
    {
        public Basket()
        {
            Products = new ObservableCollection<Product>();
        }
        ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products { get => _Products; set => SetProperty(ref _Products, value); }

        public int Total { get => GetTotal(); }

        public int GetTotal()
        {
            var total = 0;
            foreach (var product in Products)
            {
                total += product.Value;
            }
            return total;
        }
    }

    public class Product : BindableBase
    {
        public Product(int value)
        {
            Value = value;
        }
        int _Value;
        public int Value
        {
            get => _Value; set
            {
                SetProperty(ref _Value, value);
            }
        }
    }
}
