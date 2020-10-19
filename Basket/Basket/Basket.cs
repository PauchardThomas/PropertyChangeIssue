using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace Basket
{
    public class Basket : BindableBase/*, IDestructible*/
    {
        public Basket(string nom)
        {
            Products = new ObservableCollection<Product>();
            Nom = nom;
           /* MessagingCenter.Subscribe<object>(this, "Hi", (e) =>
            {
                Console.WriteLine("Event triggered");
                RaisePropertyChanged(nameof(Total));
            });*/
        }
        ObservableCollection<Product> _Products;
        public ObservableCollection<Product> Products { get => _Products; set => SetProperty(ref _Products, value); }
        private string _Nom;
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }

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

       /* public void Destroy()
        {
            MessagingCenter.Unsubscribe<object>(this, "Hi");
        }*/
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
                 //   MessagingCenter.Send<object>(this, "Hi");
              //  }
            }
        }
    }
}
