using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    class ScheduleViewModel : ViewModelBase
    {
        int i = 0;
        StudentDBEntities ST = new StudentDBEntities();
        SpeechSynthesizer warningAudio = new SpeechSynthesizer();
        int[] Period = { 1, 2, 3, 4 };
        #region Monday
        private ObservableCollection<GetScheduleForDetail1_Result> _Monday;

        public ObservableCollection<GetScheduleForDetail1_Result> Monday
        {
            get
            {

                return _Monday;
            }
            set
            {
                if (_Monday != value)
                {
                    _Monday = value; OnPropertyChanged("Monday");
                }
            }
        }
        #endregion
        #region Tuesday
        private ObservableCollection<GetScheduleForDetail1_Result> _Tuesday;

        public ObservableCollection<GetScheduleForDetail1_Result> Tuesday
        {
            get
            {

                return _Tuesday;
            }
            set
            {
                if (_Tuesday != value)
                {
                    _Tuesday = value; OnPropertyChanged("Tuesday");
                }
            }
        }
        #endregion
        #region Wednesday
        private ObservableCollection<GetScheduleForDetail1_Result> _Wednesday;

        public ObservableCollection<GetScheduleForDetail1_Result> Wednesday
        {
            get
            {

                return _Wednesday;
            }
            set
            {
                if (_Wednesday != value)
                {
                    _Wednesday = value; OnPropertyChanged("Wednesday");
                }
            }
        }
        #endregion
        #region Ads emptys
        void AddEmpty(ObservableCollection<GetScheduleForDetail1_Result> Day)
        {
            foreach (int Child in Period)
            {
                int Credits = 0;
                foreach (GetScheduleForDetail1_Result Schedule in Day)
                {
                    if (Child == Schedule.Period)
                    {
                        Credits = 1;
                        break;
                    }
                }

                if (Credits == 0)
                {
                    for (int Schedule = 0; Schedule < Day.Count; Schedule++)
                    {
                        if (Child + 1 == Day[Schedule].Period)
                        {
                            Credits = int.Parse(Day[Schedule].Credits.ToString()); break;
                        }
                        if (Child == 4 && Child - 1 == Day[Schedule].Period && Day[Day.Count - 1].DepartmentID != null) { Credits = int.Parse(Day[Schedule].Credits.ToString()); break; }
                    }
                    if (Credits != 0)
                    {
                        GetScheduleForDetail1_Result IconEmpty = new GetScheduleForDetail1_Result() { Period = Child - 1, Credits = (5 * Height - Credits) };
                        Day.Insert(int.Parse(IconEmpty.Period.ToString()), IconEmpty);
                    }
                }
            }
        }
        #endregion
        #region Thursday
        private ObservableCollection<GetScheduleForDetail1_Result> _Thursday;

        public ObservableCollection<GetScheduleForDetail1_Result> Thursday
        {
            get
            {

                return _Thursday;
            }
            set
            {
                if (_Thursday != value)
                {
                    _Thursday = value; OnPropertyChanged("Thursday");
                }
            }
        }
        #endregion
        #region Friday
        private ObservableCollection<GetScheduleForDetail1_Result> _Friday;

        public ObservableCollection<GetScheduleForDetail1_Result> Friday
        {
            get
            {

                return _Friday;
            }
            set
            {
                if (_Friday != value)
                {
                    _Friday = value; OnPropertyChanged("Friday");
                }
            }
        }

        #endregion
        #region Saturday

        private ObservableCollection<GetScheduleForDetail1_Result> _Saturday;

        public ObservableCollection<GetScheduleForDetail1_Result> Saturday
        {
            get
            {

                return _Saturday;
            }
            set
            {
                if (_Saturday != value)
                {
                    _Saturday = value; OnPropertyChanged("Saturday");
                }
            }
        }
        #endregion

        private double _Height;
        private double _Width = 193;
        public ICommand GetHeightALesson { get; set; }

        public double Height
        {
            get
            {
                return _Height;
            }

            set
            {
                _Height = value;
                OnPropertyChanged("Height");
            }
        }

        public double Width
        {
            get
            {
                return _Width;
            }

            set
            {
                _Width = value;
                OnPropertyChanged("Width");
            }
        }


        private string _GetModule = "Module 1";
        public string GetModule
        {
            get
            {
                return _GetModule;
            }

            set
            {
                _GetModule = value;
                OnPropertyChanged("GetModule");
            }
        }

        private string _GetYear = "Year 1";
        public string GetYear
        {
            get
            {
                return _GetYear;
            }

            set
            {
                _GetYear = value;
                OnPropertyChanged("GetYear");
            }
        }

        private ICommand _CmbChangeCommand;
        public ICommand CmbChangeCommand
        {
            get
            {
                if (_CmbChangeCommand == null)
                {
                    _CmbChangeCommand = new RelayCommand<object>((p) => true, OnCmbChangeCommand);
                }
                return _CmbChangeCommand;
            }
        }
        void OnCmbChangeCommand(object parameters)
        {
            var thisUser = DialogLogginViewModel.Users[0];
            var values = (object[])parameters;
            ComboBox Cmb_Module = values[0] as ComboBox;
            ComboBox Cmb_Year = values[1] as ComboBox;
            Grid GrdContain = values[2] as Grid;
            GetModule = ((ComboBoxItem)Cmb_Module.SelectedItem).Content.ToString();
            GetYear = ((ComboBoxItem)Cmb_Year.SelectedItem).Content.ToString();
            OnGetHeightALesson(GrdContain);
        }


        private void OnGetHeightALesson(Grid Grd)
        {

            var thisUser = DialogLogginViewModel.Users[0];
            Height = Math.Round(Grd.ActualHeight / 11 - 1, 0);
            Width = Math.Round(Grd.ActualWidth / 6.5, 0);
            Monday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Monday", Height, Width));
            Tuesday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Tuesday", Height, Width));
            Wednesday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Wednesday", Height, Width));
            Thursday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Thursday", Height, Width));
            Friday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Friday", Height, Width));
            Saturday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, GetModule, GetYear, "Saturday", Height, Width));
            AddEmpty(Monday);
            AddEmpty(Tuesday);
            AddEmpty(Wednesday);
            AddEmpty(Thursday);
            AddEmpty(Friday);
            AddEmpty(Saturday);
        }



        public ScheduleViewModel()
        {
            GetHeightALesson = new RelayCommand<Grid>((p) => true, OnGetHeightALesson);



        }



    }
}
