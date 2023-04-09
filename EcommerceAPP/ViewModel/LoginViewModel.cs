﻿using EcommerceAPP.Data.Models;
using EcommerceAPP.Services.Interfaces;
using EcommerceAPP.Message;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Windows;

namespace EcommerceAPP.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        public User? user { get; set; } = new();

        private readonly INavigationService? _navigationService;

        private readonly IMessenger? _messenger;

        public LoginViewModel(INavigationService navigationService, IMessenger messenger)
        {
            _navigationService = navigationService;
            _messenger = messenger;
            _messenger.Register<ParameterMessage>(this, param =>
            {
                user = param?.Message as User;
            });
        }
        public RelayCommand RegistrationCommand => new(() =>
        {
            _navigationService?.NavigateTo<RegistrationViewModel>(new ParameterMessage { Message = user });
        });

        public RelayCommand<PasswordBox> LoginCommand => new((pass) =>
        {
            using (var context = new EcommerceDbContext())
            {
                var FoundUser = context.Users.SingleOrDefault(u => u.Login == user!.Login);
                if (FoundUser != null)
                {
                    if (FoundUser?.Password == pass.Password)
                    {
                        _navigationService?.NavigateTo<HomeViewModel>(new ParameterMessage { Message = FoundUser });
                    }
                    else if (FoundUser!.IsAdmin && pass.Password == "admin")
                    {
                        //_navigationService?.NavigateTo<AdminViewModel>(new UsersMessage { SendedUser = FoundUser });
                    }
                    else MessageBox.Show("Password is not correct");
                }
                else MessageBox.Show("You aren't a user!");
            }
        });

    }
}
