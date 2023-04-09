using EcommerceAPP.Data.Models;
using EcommerceAPP.Services.Interfaces;
using EcommerceAPP.Message;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace EcommerceAPP.ViewModel
{
    public class CardViewModel : ViewModelBase
    {
        public UserPayment? UserPayment { get; set; } = new();
        public User? User { get; set; } = new();

        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public CardViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                User = param?.Message as User;
                UserPayment = new();
            });
        }

        public RelayCommand BackCommand => new(() =>
        {
            _navigationService?.NavigateTo<HomeViewModel>(new ParameterMessage { Message = User });
        });


        public RelayCommand AddCardCommand => new(() =>
        {
            using (var context = new EcommerceDbContext())
            {
                var FoundUserPayment = context.UserPayments.SingleOrDefault(u => u.SixteenDigitCode == UserPayment!.SixteenDigitCode);
                if (FoundUserPayment == null)
                {
                    if (UserPayment != null && User != null)
                    {
                        UserPayment.UserId = User.ID;
                        context.UserPayments.Add(UserPayment);
                        context.SaveChanges();
                        MessageBox.Show("Your card has been add");

                        _navigationService?.NavigateTo<CardsViewModel>(new ParameterMessage { Message = User });
                    }
                }
                else MessageBox.Show("This card already exist");
            }
        });

    }
}
