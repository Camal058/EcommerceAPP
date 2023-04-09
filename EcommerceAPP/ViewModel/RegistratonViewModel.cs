using EcommerceAPP.Data.Models;
using EcommerceAPP.Message;
using EcommerceAPP.Services.Classes;
using EcommerceAPP.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;

namespace EcommerceAPP.ViewModel
{
    public class RegistrationViewModel : ViewModelBase
    {
        public User? user { get; set; } = new();
        public BitmapImage? image { get; set; } = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Images/defUser.png"));

        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public RegistrationViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                user = param?.Message as User;
            });
        }

        public RelayCommand<PasswordBox> RegistrationCommand => new(param =>
        {
            user!.Password = param.Password;
            var a = CheckRegistration.CheckUser(user, param.Password);
            if (a == null)
            {
                using (var context = new EcommerceDbContext())
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage() { Message = user });
                user = new();
                return;
            }
            else MessageBox.Show(a);
        });



        public RelayCommand BackToLoginCommand => new(() =>
        {
            _navigationService?.NavigateTo<LoginViewModel>(new ParameterMessage { Message = user });
        });

    }
}
