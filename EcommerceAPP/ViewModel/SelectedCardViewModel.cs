﻿using EcommerceAPP.Data.Models;
using EcommerceAPP.Message;
using EcommerceAPP.Services.Interfaces;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EcommerceAPP.ViewModel
{
    public class SelectedCardViewModel : ViewModelBase
    {
        public User? User { get; set; } = new();
        public Product? Product { get; set; } = new();
        public ObservableCollection<UserPayment>? Cards { get; set; } = new();
        public bool IsEnabledForPay { get; set; }

        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public SelectedCardViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                var UserProduct = param?.Message as UserProductParameter;
                User = UserProduct?.User;
                Product = UserProduct?.Product;
                if (User != null)
                {
                    using (var context = new EcommerceDbContext())
                    {
                        var cardsFromDb = context.Set<UserPayment>().Where(up => up.User!.Login == User!.Login).ToList();

                        Cards = new ObservableCollection<UserPayment>(cardsFromDb);
                    }
                }
            });
        }

        #region SelectedCard FullProp
        private UserPayment? _selectedCard;
        public UserPayment? SelectedCard
        {
            get => _selectedCard;
            set
            {
                _selectedCard = new();
                _selectedCard = value;
                IsEnabledForPay = true;
            }
        }
        #endregion

        public RelayCommand PayByCardCommand => new(() =>
        {

            MessageBox.Show("Paied");
            IsEnabledForPay = false;

            UserProductParameter userProductParameter = new(User!, Product!);

            _navigationService?.NavigateTo<ProductViewModel>(new ParameterMessage { Message = userProductParameter });
        });

        public RelayCommand BackToProductCommand => new(() =>
        {
            UserProductParameter userProductParameter = new(User!, Product!);

            _navigationService?.NavigateTo<ProductViewModel>(new ParameterMessage { Message = userProductParameter });

        });

    }
}
