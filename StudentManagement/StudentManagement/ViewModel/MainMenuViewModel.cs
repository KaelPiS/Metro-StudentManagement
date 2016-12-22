using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    class MainMenuViewModel : ViewModelBase
    {
        //This class just hold the Main Menu Model, see detail in MainWindow.xaml
        StudentDBEntities ST = new StudentDBEntities();
        private bool _IsDateRegister;

        public bool IsDateRegister
        {
            get
            {

                return _IsDateRegister;
            }

            set
            {
                _IsDateRegister = value;
                OnPropertyChanged("IsDateRegister");
            }
        }

        public MainMenuViewModel()
        {
            var a = ST.IsDateRegister().ToList();
            if (a[0].IsDateRegister==true)
                IsDateRegister = true;
            else
                IsDateRegister = false;

        }
    }
}
