using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StudentManagement.ViewModel
{
    class ScheduleViewModel : ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        SpeechSynthesizer warningAudio = new SpeechSynthesizer();
        int[] Period = { 1, 2, 3, 4 };
        private ObservableCollection<GetScheduleForDetail1_Result> _Monday;

        public ObservableCollection<GetScheduleForDetail1_Result> Monday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Monday == null)
                {
                    _Monday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Monday"));
                    AddEmpty(_Monday);
                }
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
        private ObservableCollection<GetScheduleForDetail1_Result> _Tuesday;

        public ObservableCollection<GetScheduleForDetail1_Result> Tuesday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Tuesday == null)
                {
                    _Tuesday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Tuesday"));
                    AddEmpty(_Tuesday);
                }
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

        private ObservableCollection<GetScheduleForDetail1_Result> _Wednesday;

        public ObservableCollection<GetScheduleForDetail1_Result> Wednesday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Wednesday == null)
                {
                    _Wednesday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Wednesday"));
                    AddEmpty(_Wednesday);
                }
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
                        GetScheduleForDetail1_Result IconEmpty = new GetScheduleForDetail1_Result() { Period = Child - 1, Credits = (5 * 43 - Credits) };
                        Day.Insert(int.Parse(IconEmpty.Period.ToString()), IconEmpty);
                    }
                }
            }
        }
        private ObservableCollection<GetScheduleForDetail1_Result> _Thursday;

        public ObservableCollection<GetScheduleForDetail1_Result> Thursday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Thursday == null)
                {
                    _Thursday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Thursday"));
                    AddEmpty(_Thursday);
                }
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
        private ObservableCollection<GetScheduleForDetail1_Result> _Friday;

        public ObservableCollection<GetScheduleForDetail1_Result> Friday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Friday == null)
                {
                    _Friday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Friday"));
                    AddEmpty(_Friday);
                }
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


        private ObservableCollection<GetScheduleForDetail1_Result> _Saturday;

        public ObservableCollection<GetScheduleForDetail1_Result> Saturday
        {
            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                var thisUser = DialogLogginViewModel.Users[0];

                if (_Saturday == null)
                {
                    _Saturday = new ObservableCollection<GetScheduleForDetail1_Result>(ST.GetScheduleForDetail1(thisUser.ID, data.SemesterName, "Saturday"));
                    AddEmpty(_Saturday);
                }
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


    }
}
