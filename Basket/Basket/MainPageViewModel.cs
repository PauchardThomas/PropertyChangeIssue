using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basket
{
    public class MainPageViewModel : BindableBase
    {
        Basket _Basket;
        public Basket Basket { get => _Basket; set => SetProperty(ref _Basket,value); }
        public MainPageViewModel()
        {
            AddCommand = new DelegateCommand(AddCommandExecute);
            Init();
        }

        private void AddCommandExecute()
        {
            Init();
        }

        private void Init()
        {
            Basket = new Basket();
            Product product1 = new Product(10);
            Product product2 = new Product(5);
            Basket.Products.Add(product1);
            Basket.Products.Add(product2);
        }

        public DelegateCommand AddCommand { get; set; }
    }
}
