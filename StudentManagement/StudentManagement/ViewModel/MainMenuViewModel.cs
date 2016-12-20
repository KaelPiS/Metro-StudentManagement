using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            //if (ST.IsDateRegisters() == 1)
            //    IsDateRegister = true;
            //else
            //    IsDateRegister = false;

        }
    }
}
