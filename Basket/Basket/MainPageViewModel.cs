using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Sharpnado.Presentation.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Basket
{
    public class MainPageViewModel : BindableBase, INavigationAware, IInitialize
    {
        Basket _Basket, _Basket1, _Basket2;
        bool _isLoading;
        public Basket Basket { get => _Basket; set => SetProperty(ref _Basket, value); }
        public Basket Basket1 { get => _Basket1; set => SetProperty(ref _Basket1, value); }
        public Basket Basket2 { get => _Basket2; set => SetProperty(ref _Basket2, value); }
        public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }
        readonly BasketReader _basketReader;
        public MainPageViewModel(BasketReader basketReader)
        {
            _basketReader = basketReader;
           // var monbasket = _basketReader.Read("baskets.json");
           // Console.WriteLine(monbasket.Nom);

            var basketA = _basketReader.Read("Basket-A.json");
            Console.WriteLine(basketA.Nom);
            AddCommand = new TaskLoaderCommand(AddCommandExecute);
            ShowBasketCommand = new TaskLoaderCommand<object>(_ => ShowBasket(_));
            Basket1 = new Basket("basket 1");
            Basket2 = new Basket("basket 2");
            //       Loader = new TaskLoaderNotifier<Basket>(() => ShowBasket(null));
            //   Loader.Load(() => ShowBasket(null));
            // ShowBasketCommand.Execute(null);
        }

        private async Task<Basket> ShowBasket(object obj)
        {
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(TimeSpan.FromSeconds(2));
            Basket = Basket?.Nom == Basket2.Nom ? Basket1 : Basket2;
            sw.Stop();
            Console.WriteLine($"Elapsed {sw.Elapsed.TotalSeconds} sec");
            return Basket;
        }

        private async void ShowBasketExecute(object obj)
        {
            IsLoading = true;
            await Task.Run(() =>
            {
                Basket = obj.ToString() == "1" ? Basket1 : Basket2;
                IsLoading = false;
            });
        }


        private async Task AddCommandExecute()
        {
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                Init();
            });
        }

        private void Init()
        {
            List<Product> products = new List<Product>();
            for (int i = 0; i < 150; i++)
            {
                products.Add(new Product(i));
            }
            Device.BeginInvokeOnMainThread(() =>
            {
                products.ForEach(Basket.Products.Add);
            });
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            //
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            ShowBasketCommand.Notifier.Load(() => ShowBasket(null));
        }

        public void Initialize(INavigationParameters parameters)
        {
            // ShowBasketCommand.Notifier.Load(() => ShowBasket(null));
        }

        public TaskLoaderNotifier<Basket> Loader { get; }

        public TaskLoaderCommand AddCommand { get; }
        public TaskLoaderCommand<object> ShowBasketCommand { get; }
    }
}
