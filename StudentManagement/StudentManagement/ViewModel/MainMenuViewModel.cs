using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace StudentManagement.ViewModel
{
    class MainMenuViewModel : ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        private readonly DispatcherTimer _timer;
       


        private int _second = 0;
        private int _minute = 0;
        private int _hour = 0;
        //This class just hold the Main Menu Model, see detail in MainWindow.xaml

        private ObservableCollection<IsDateRegister_Result> _IsDateRegister;

        public ObservableCollection<IsDateRegister_Result> IsDateRegister
        {
            get
            {
                if (_IsDateRegister == null)
                {
                    _IsDateRegister = new ObservableCollection<IsDateRegister_Result>(ST.IsDateRegister().ToList());
                    CheckDateRegister = bool.Parse(ST.IsDateRegister().ToList()[0].IsDateRegister.ToString());
                }
                return _IsDateRegister;
            }

            set
            {
                _IsDateRegister = value;
                OnPropertyChanged("IsDateRegister");
            }
        }

        private bool _CheckDateRegister;
        private string _RegisterOpenHour = "00";

        public string RegisterOpenHour
        {
            get
            {
                return _RegisterOpenHour;
            }

            set
            {
                if (_RegisterOpenHour == value)
                    return;
                _RegisterOpenHour = value;
                OnPropertyChanged("RegisterOpenHour");
            }
        }

        private string _RegisterOpenMinute = "00";

        public string RegisterOpenMinute
        {
            get
            {
                return _RegisterOpenMinute;
            }

            set
            {
                if (_RegisterOpenMinute == value)
                    return;
                _RegisterOpenMinute = value;
                OnPropertyChanged("RegisterOpenMinute");
            }
        }

        private string _RegisterOpenSecond = "00";

        public string RegisterOpenSecond
        {
            get
            {
                return _RegisterOpenSecond;
            }

            set
            {
                if (_RegisterOpenSecond == value)
                    return;
                _RegisterOpenSecond = value;
                OnPropertyChanged("RegisterOpenSecond");
            }
        }

        public  bool IsOpenRegisterUnit
        {
            get
            {
                return _IsOpenRegisterUnit;
            }

            set
            {
                _IsOpenRegisterUnit = value;
                OnPropertyChanged("IsOpenRegisterUnit");
            }
        }

        public bool IsOpenTimeRegisterUnit
        {
            get
            {
                return _IsOpenTimeRegisterUnit;
            }

            set
            {
                _IsOpenTimeRegisterUnit = value;
                OnPropertyChanged("IsOpenTimeRegisterUnit");
            }
        }

      
        private bool _IsOpenRegisterUnit = false;
        private bool _IsOpenTimeRegisterUnit = true;
        public MainMenuViewModel()
        {
            CheckDateRegister = bool.Parse(ST.IsDateRegister().ToList()[0].IsDateRegister.ToString());
            try
            {
                _hour = Int32.Parse(ST.GetDateRegisterUnit().ToList()[0].Hour.ToString());
                _minute = Int32.Parse(ST.GetDateRegisterUnit().ToList()[0].Minute.ToString());
                _second = Int32.Parse(ST.GetDateRegisterUnit().ToList()[0].Second.ToString());
            }
            catch { }
            _timer = new DispatcherTimer(DispatcherPriority.Normal);
            _timer.Interval = TimeSpan.FromSeconds(1);

            _timer.Tick += Timer_Tick;
            _timer.Start();
            //event close register
            UpdateCloseTimeRegister.OnMessageTransmitted += OnCloseTimeRegisterUnit;


        }
   
      
        private void UpdateTime()
        {
            if (_second < 10)
            {
                RegisterOpenSecond = "0" + _second.ToString();
            }
            else
            {
                RegisterOpenSecond = _second.ToString();
            }

            if (_minute < 10)
            {
                RegisterOpenMinute = "0" + _minute.ToString();
            }
            else
            {
                RegisterOpenMinute = _minute.ToString();
            }

            if (_hour < 10)
            {
                RegisterOpenHour = "0" + _hour.ToString();
            }
            else
            {
                RegisterOpenHour = _hour.ToString();
            }


        }
        

        private void Timer_Tick(object sender, EventArgs e)
        {

            if (_second == 00)
            {
                if (_minute != 0)
                {
                    _second = 59;
                    _minute = _minute - 1;
                }
            }

            if (_minute == 00)
            {
                if (_hour != 0)
                {
                    _minute = 59;
                    _hour = _hour - 1;
                }
               
            }

            UpdateTime();
            if(_second!=0)
            _second--;
            if (_hour == 0 && _minute == 0 && _second == 0)
            {
                _timer.Stop();
                IsOpenRegisterUnit = true;
                IsOpenTimeRegisterUnit = false;              
            }
        }

       

        public bool CheckDateRegister
        {
            get
            {
                
                return _CheckDateRegister;
            }

            set
            {
                _CheckDateRegister = value;
                OnPropertyChanged("CheckDateRegister");
            }
        }

        

        private void OnCloseTimeRegisterUnit(bool Message)
        {
           
            CheckDateRegister = Message;
           
            
        }

    }
}
