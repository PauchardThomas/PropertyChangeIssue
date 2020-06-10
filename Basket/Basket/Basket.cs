using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Basket
{
    public class Basket : BindableBase
    {
        public Basket()
        {
            Products = new ObservableCollection<Product>();
            MessagingCenter.Subscribe<object>(this, "Hi", (e) =>
            {
                Console.WriteLine("Event triggered");
                RaisePropertyChanged(nameof(Total));
            });
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
              //  if(value > 0 && value < 10)
              //  {
                    SetProperty(ref _Value, value);
                    MessagingCenter.Send<object>(this, "Hi");
              //  }
            }
        }
    }
}
