﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
namespace StudentManagement.ViewModel
{
    class DialogLogginViewModel
    {
        StudentDBEntities St = new StudentDBEntities();

        #region User, which holds all the infomation abount User account
        private static ObservableCollection<GetUser_Result> _Users;
        public static ObservableCollection<GetUser_Result> Users
        {
            get
            {
                return _Users;
            }

            set
            {
                _Users = value;
            }
        }
        #endregion

        MetroWindow metroWindow = (Application.Current.MainWindow as MetroWindow); 

        #region LoginCommand, which displays the login form and do some stuffs 
        public ICommand LoginCommand { get; set; }
        
        private void OnLoginCommand()
        {
            LoginCommand = new RelayCommand<MetroWindow>((p) => true, ShowLoginDialogWithRememberCheckBox);
        }

        #endregion

        #region LogginDialog with Remember Check Box

        public async void ShowLoginDialogWithRememberCheckBox(object obj)
        {
            LoginDialogSettings settings = new LoginDialogSettings
            {
                ColorScheme = metroWindow.MetroDialogOptions.ColorScheme,
                RememberCheckBoxVisibility = System.Windows.Visibility.Visible,
                NegativeButtonVisibility = System.Windows.Visibility.Visible,
                InitialPassword = "6",
                InitialUsername="63500"
            };

            LoginDialogData result = await metroWindow.ShowLoginAsync("Authentication", "Enter your password", settings);

            if (result==null)
            {
                MessageDialogResult messageResult = await metroWindow.ShowMessageAsync("Authentication Information", String.Format("You have canceled"));
            }
            else
            {
                Users =new ObservableCollection<GetUser_Result>(St.GetUser(result.Username, result.Password).ToList());
                if (Users.Count() != 0)
                {
                    MessageDialogResult messageResult = await metroWindow.ShowMessageAsync("Authentication Information", String.Format("Log in successfully.."));
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).cmbChangeUC.SelectedIndex = 1;
                            (window as MainWindow).WindowState = System.Windows.WindowState.Maximized;
                            (window as MainWindow).Account.Visibility = System.Windows.Visibility.Visible;
                         
                        }
                    }
                }
                else
                {
                    MessageDialogResult messageResult = await metroWindow.ShowMessageAsync("Authentication Information", String.Format("Valid Username or Password.."));
                }
            }
          
        }
        #endregion

        public DialogLogginViewModel()
        {
            OnLoginCommand();
        }

    }
}
