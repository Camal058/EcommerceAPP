﻿using EcommerceAPP.Data.Models;
using EcommerceAPP.Data.DbContext;
using EcommerceAPP.Services.Interfaces;
using EcommerceAPP.Message;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


namespace EcommerceAPP.ViewModel
{
    public class CardsViewModel : ViewModelBase
    {
        public User? User { get; set; } = new();
        public ObservableCollection<UserPayment>? Cards { get; set; } = new();
        public bool IsEnabledToDelete { get; set; }

        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public CardsViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                User = param?.Message as User;
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
                IsEnabledToDelete = true;
            }
        }
        #endregion

        public RelayCommand DeleteCardCommand => new(() =>
        {
            using (var context = new EcommerceDbContext())
            {
                context.UserPayments.Remove(_selectedCard!);
                context.SaveChanges();
            }
        });

        public RelayCommand AddCardCommand => new(() =>
        {
            _navigationService?.NavigateTo<CardViewModel>(new ParameterMessage { Message = User });
        });

        public RelayCommand BackToHomeCommand => new(() =>
        {
            _navigationService?.NavigateTo<HomeViewModel>(new ParameterMessage { Message = User });
        });

    }
}
