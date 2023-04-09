using EcommerceAPP.Data.Models;
using EcommerceAPP.Message;
using EcommerceAPP.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EcommerceAPP.ViewModel
{
    public class ProductViewModel : ViewModelBase
    {
        public int Quantity { get; set; } = 1;
        public bool IsEnabledToQuantityDown { get; set; }
        public User? User { get; set; } = new();
        public Product? Product { get; set; } = new();
        public BitmapImage? image { get; set; } = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/no_product.jpg"));


        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public ProductViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                var UserProduct = param?.Message as UserProductParameter;
                User = UserProduct?.User;
                Product = UserProduct?.Product;

                if (Product?.Image != null) image = new BitmapImage(new Uri(Product?.Image!));

            });
        }


        public RelayCommand BuyProductCommand => new(() =>
        {
            using (var context = new EcommerceDbContext())
            {
                Order? Order = new() { UserId = User!.ID, Quantity = Quantity, Date = DateTime.Now, TotalPrice = Product!.Price * Quantity };
                User?.Orders?.Add(Order);

                context.Orders.Add(Order);
                context.SaveChanges();

                OrderProduct orderProduct = new() { OrderId = Order.ID, ProductId = Product!.Id };
                context.OrderProducts.Add(orderProduct);
                context.SaveChanges();
            }

            UserProductParameter userProductParameter = new(User!, Product);
            _navigationService?.NavigateTo<SelectedCardViewModel>(new ParameterMessage { Message = userProductParameter });

        });


        #region Quantities RelayCommands
        public RelayCommand BackToShopCommand => new(() =>
        {
            _navigationService?.NavigateTo<HomeViewModel>(new ParameterMessage { Message = User });
        });

        public RelayCommand DownQuantityCommand => new(() =>
        {
            if (Quantity > 1)
            {
                if (Quantity == 2) IsEnabledToQuantityDown = false;
                Quantity -= 1;
            }
        });

        public RelayCommand UpQuantityCommand => new(() =>
        {
            Quantity += 1;
            IsEnabledToQuantityDown = true;
        });
        #endregion
    }
}
