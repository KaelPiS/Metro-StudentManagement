using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace StudentManagement.ViewModel
{
    class RegisterStudyUnitViewModel : ViewModelBase
    {

        StudentDBEntities ST = new StudentDBEntities();
        SpeechSynthesizer warningAudio = new SpeechSynthesizer();
        private int _second = 10;
        private int _minute = 10;
        private int _hour = 10;
        private string _Header;
        private readonly DispatcherTimer _timer;
        public string Header
        {

            get
            {
                var data = ST.IsDateRegister().ToList()[0];
                if (_Header == null)
                {
                    _Header = string.Format("Register Study Unit {0} Open on {1}", data.SemesterName, data.DateRegister);
                }
                return _Header;
            }
            set
            {
                _Header = value; OnPropertyChanged("Header");
            }
        }

        public string Info
        {
            get
            {
                var thisUser = DialogLogginViewModel.Users[0];
                var data = ST.IsDateRegister().ToList()[0];
                var InfoStudent = ST.GetStudentsInfoByID(thisUser.ID).ToList()[0];
                if (_Info == null)
                {
                    _Info = string.Format(" Full Name     {0} {1} {2} \n Student ID    {3}\n School          {4}\n Class            {5}", InfoStudent.LastName, InfoStudent.MiddleName, InfoStudent.Name, InfoStudent.StudentID, InfoStudent.FacultyID, InfoStudent.ClassID);
                }
                return _Info;
            }
            set
            {
                _Info = value; OnPropertyChanged("Info");
            }

        }


        private string _ReplaceSpaceToEnter;
        public string ReplaceSpaceToEnter
        {
            get
            {
                return _ReplaceSpaceToEnter;
            }

            set
            {
                if (value.Contains(' ') == false)
                    _ReplaceSpaceToEnter = value;
                else
                {
                    _ReplaceSpaceToEnter = value.Replace(' ', '\n');
                }



                OnPropertyChanged("ReplaceSpaceToEnter");
            }
        }
        private string _Info;


        public ICommand RegisterCommand { get; set; }

        private ObservableCollection<GetInfoRegistered_Result> _ListRegistered;
        public ObservableCollection<GetInfoRegistered_Result> ListRegistered
        {
            get
            {
                var thisUser = DialogLogginViewModel.Users[0];
                if (_ListRegistered == null)
                {
                    _ListRegistered = new ObservableCollection<GetInfoRegistered_Result>(ST.GetInfoRegistered(thisUser.ID).ToList());
                }
                return _ListRegistered;
            }

            set
            {
                if (_ListRegistered != value)
                {
                    _ListRegistered = value; OnPropertyChanged("ListRegistered");
                }
            }
        }


        private ObservableCollection<GetInfoDiscipline_Result> _ListDiscipline;
        public ObservableCollection<GetInfoDiscipline_Result> ListDiscipline
        {
            get
            {

                if (_ListDiscipline == null)
                {
                    _ListDiscipline = new ObservableCollection<GetInfoDiscipline_Result>(ST.GetInfoDiscipline().ToList());
                }
                return _ListDiscipline;
            }

            set
            {
                if (_ListDiscipline != value)
                {
                    _ListDiscipline = value; OnPropertyChanged("ListDiscipline");
                }
            }
        }

        void InsertAndFindingError(string[] ListLine,StackPanel Stp)
        {
            var thisUser = DialogLogginViewModel.Users[0];
            var DisciplineRegistered = ST.GetListDisciplineForThisUser(thisUser.ID).ToList();
            string speak = string.Empty;
            foreach (string Line in ListLine)
            {
                TextBlock Announcement = new TextBlock();
                Announcement.FontSize = 14;
                int CheckDiscipline = 1;
                string ID = Line.Substring(0, 5);
                var data = ST.IsDateRegister().ToList()[0];
                foreach (GetListDisciplineForThisUser_Result Discipline in DisciplineRegistered)
                {


                    if (Discipline.DisciplineID != ID) CheckDiscipline = 1;
                    else if (Discipline.DisciplineID == ID.Trim() && Discipline.DisciplineStatus == true)
                    {
                        CheckDiscipline = 0;
                        Announcement.Foreground = new SolidColorBrush(Colors.Red);
                        Announcement.Text = ID + " Discipline had registered";
                        break;
                    }
                    else if (Discipline.DisciplineID == ID.Trim() && Discipline.DisciplineStatus == false) CheckDiscipline = 1;
                }
                if (CheckDiscipline == 1 && ID != " " && ID != "\n" && ID != null)
                {
                    try
                    {
                        
                        ST.InsertRegisterStudyUnit(thisUser.ID, ID, data.SemesterID);
                        ST.SaveChanges();
                        Announcement.Foreground = new SolidColorBrush(Colors.Green);
                        Announcement.Text = ID + " Successfully";
                    }
                    catch
                    {
                        Announcement.Foreground = new SolidColorBrush(Colors.Red);
                        Announcement.Text = ID + " Discipline not open or does not exist. Please check back...";
                    }
                }
                speak += Announcement.Text + "...";
                warningAudio.SpeakAsync(speak);
                if (Announcement != null || Announcement.Text != " ")
                    Stp.Children.Add(Announcement);
            }
        }
        private void OnRegisterCommand(object parameters)
        {

            var values = (object[])parameters;
            TextBox txtwrap = values[0] as TextBox;
            StackPanel Stp = values[1] as StackPanel;
            var thisUser = DialogLogginViewModel.Users[0];

            txtwrap.Text = StandardWord(txtwrap.Text);
            string[] ListLine = txtwrap.Text.Split(' ', ',', '-', '+', '\n');
            InsertAndFindingError(ListLine, Stp);
           
           
            ListRegistered = new ObservableCollection<GetInfoRegistered_Result>(ST.GetInfoRegistered(thisUser.ID).ToList());
        }






        private string StandardWord(string data)
        {
            if (data.Length > 0)
            {
                while (data.IndexOf("  ") > 0)
                {
                    data = data.Replace("  ", " ");
                    data = data.Trim();
                }
            }
            return data;
        }


        public ICommand DeleteRegistered { get; set; }

        private void OnDeleteRegistered(DataGrid Dtg)
        {
            var thisUser = DialogLogginViewModel.Users[0];
            foreach (GetInfoRegistered_Result DisciplineChecked in Dtg.Items)
            {
                if (DisciplineChecked.check == true)
                    ST.DeleteRegisterStudyUnit(thisUser.ID, DisciplineChecked.DisciplineID);
            }

            ListRegistered = new ObservableCollection<GetInfoRegistered_Result>(ST.GetInfoRegistered(thisUser.ID).ToList());


        }

        public ICommand InsertRegisterFromListDisciplineCommand { get; set; }
        private void OnInsertRegisterFromListDisciplineCommand(object Parameters)
        {
            var values = (object[])Parameters;
            DataGrid Dtg = values[0] as DataGrid;
            StackPanel Stp = values[1] as StackPanel;
            var data = ST.IsDateRegister().ToList()[0];
            var thisUser = DialogLogginViewModel.Users[0];  
            var DisciplineRegistered = ST.GetListDisciplineForThisUser(thisUser.ID).ToList();
            string speak = string.Empty;
            foreach (GetInfoDiscipline_Result DisciplineChecked in Dtg.Items)
            {
                TextBlock Announcement = new TextBlock();
                Announcement.FontSize = 14;
                int CheckDiscipline = 1;

                if (DisciplineChecked.check == true)
                {
                    foreach (GetListDisciplineForThisUser_Result Discipline in DisciplineRegistered)
                    {
                        if (Discipline.DisciplineID != DisciplineChecked.DisciplineID.ToString()) CheckDiscipline = 1;
                        else if (Discipline.DisciplineID == DisciplineChecked.DisciplineID.ToString().Trim() && Discipline.DisciplineStatus == true)
                        {
                            CheckDiscipline = 0;
                            Announcement.Foreground = new SolidColorBrush(Colors.Red);
                            Announcement.Text = DisciplineChecked.DisciplineID.ToString() + " Discipline had registered";
                            break;
                        }
                        else if (Discipline.DisciplineID == DisciplineChecked.DisciplineID.ToString().Trim() && Discipline.DisciplineStatus == false) CheckDiscipline = 1;
                    }
                    if (CheckDiscipline == 1 && DisciplineChecked.DisciplineID.ToString() != " " && DisciplineChecked.DisciplineID.ToString() != "\n" && DisciplineChecked.DisciplineID.ToString() != null)
                    {
                        try
                        {

                            ST.InsertRegisterStudyUnit(thisUser.ID, DisciplineChecked.DisciplineID.ToString(), data.SemesterID);
                            ST.SaveChanges();
                            Announcement.Foreground = new SolidColorBrush(Colors.Green);
                            Announcement.Text = DisciplineChecked.DisciplineID.ToString() + " Successfully";
                        }
                        catch
                        {
                            Announcement.Foreground = new SolidColorBrush(Colors.Red);
                            Announcement.Text = DisciplineChecked.DisciplineID.ToString() + " Discipline not open or does not exist. Please check back...";
                        }
                    }
                    speak += Announcement.Text + "...";
                    warningAudio.SpeakAsync(speak);
                    if (Announcement != null || Announcement.Text != " ")
                        Stp.Children.Add(Announcement);
                }
            }
            ListRegistered = new ObservableCollection<GetInfoRegistered_Result>(ST.GetInfoRegistered(thisUser.ID).ToList());
        }

        void Command()
        {
            SortByTeacherAndDepartment = new RelayCommand<object>((p) => true, OnSortByTeacherAndDepartment);
            RegisterCommand = new RelayCommand<object>((p) => true, OnRegisterCommand);
            DeleteRegistered = new RelayCommand<DataGrid>((p) => true, OnDeleteRegistered);
            InsertRegisterFromListDisciplineCommand = new RelayCommand<object>((p) => true, OnInsertRegisterFromListDisciplineCommand);
        }


        private ObservableCollection<String> _GetTeacherDiscipline;
        public ObservableCollection<String> GetTeacherDiscipline
        {
            get
            {

                if (_GetTeacherDiscipline == null)
                {
                    _GetTeacherDiscipline = new ObservableCollection<String>(ST.GetTeacherRegister().ToList());
                    _GetTeacherDiscipline.Insert(0, "All");
                }
                return _GetTeacherDiscipline;
            }
            set
            {
                if (_GetTeacherDiscipline != value)
                {
                    _GetTeacherDiscipline = value; OnPropertyChanged("GetTeacherDiscipline");
                }
            }
        }

        private ObservableCollection<String> _GetDepartmentDiscipline;
        public ObservableCollection<String> GetDepartmentDiscipline
        {
            get
            {

                if (_GetDepartmentDiscipline == null)
                {
                    _GetDepartmentDiscipline = new ObservableCollection<String>(ST.GetDepartmentRegister().ToList());
                    _GetDepartmentDiscipline.Insert(0, "All");
                }
                return _GetDepartmentDiscipline;
            }
            set
            {
                if (_GetDepartmentDiscipline != value)
                {
                    _GetDepartmentDiscipline = value; OnPropertyChanged("GetDepartmentDiscipline");
                }
            }
        }

        public  ICommand SortByTeacherAndDepartment { get; set; }
        private void OnSortByTeacherAndDepartment( object Parameters)
        {
            var values = (object[])Parameters;
            ComboBox Teacher = values[0] as ComboBox;
            ComboBox Department = values[1] as ComboBox;
            try
            {
                ObservableCollection<GetInfoDiscipline_Result> a = new ObservableCollection<GetInfoDiscipline_Result>();

                ObservableCollection<SortDisciplinebyTeacherAndDepartment_Result> ab = new ObservableCollection<SortDisciplinebyTeacherAndDepartment_Result>(ST.SortDisciplinebyTeacherAndDepartment(Teacher.SelectedItem.ToString(), Department.SelectedItem.ToString()).ToList());
                foreach (SortDisciplinebyTeacherAndDepartment_Result k in ab)
                {
                 //   a.Add(k as GetInfoDiscipline_Result);
                }
                ListDiscipline = new ObservableCollection<GetInfoDiscipline_Result>(a);
            }
            catch { }
           
        }

        private string _RegisterCloseHour = "00";

        public string RegisterCloseHour
        {
            get
            {
                return _RegisterCloseHour;
            }

            set
            {
                if (_RegisterCloseHour == value)
                    return;
                _RegisterCloseHour = value;
                OnPropertyChanged("RegisterCloseHour");
            }
        }

        private string _RegisterCloseMinute = "00";

        public string RegisterCloseMinute
        {
            get
            {
                return _RegisterCloseMinute;
            }

            set
            {
                if (_RegisterCloseMinute == value)
                    return;
                _RegisterCloseMinute = value;
                OnPropertyChanged("RegisterCloseMinute");
            }
        }

        private void UpdateTime()
        {
            if (_second < 10)
            {
                RegisterCloseSecond = "0" + _second.ToString();
            }
            else
            {
                RegisterCloseSecond = _second.ToString();
            }

            if (_minute < 10)
            {
                RegisterCloseMinute = "0" + _minute.ToString();
            }
            else
            {
                RegisterCloseMinute = _minute.ToString();
            }

            if (_hour < 10)
            {
                RegisterCloseHour = "0" + _hour.ToString();
            }
            else
            {
                RegisterCloseHour = _hour.ToString();
            }


        }
        private string _RegisterCloseSecond = "00";

        public string RegisterCloseSecond
        {
            get
            {
                return _RegisterCloseSecond;
            }

            set
            {
                if (_RegisterCloseSecond == value)
                    return;
                _RegisterCloseSecond = value;
                OnPropertyChanged("RegisterCloseSecond");
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
            if (_second != 0)
                _second--;
            if (_hour == 0 && _minute == 0 && _second == 0)
            {
                _timer.Stop();
               
            }
        }


        public RegisterStudyUnitViewModel()
        {
            Command();
            

            

            _timer = new DispatcherTimer(DispatcherPriority.Normal);
            _timer.Interval = TimeSpan.FromSeconds(1);

            _timer.Tick += Timer_Tick;
            _timer.Start();

        }
    }
}
