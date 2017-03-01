using System;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class MoreAnouncementViewModel : ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        private string currentTypeMoreAnouncement;
        private int currentPage = 1;
        private string anouncementTitle;

        public int CurrentPage
        {
            get
            {
                return currentPage;
            }

            set
            {
                if (currentPage != value)
                    currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

      

        private ObservableCollection<SelectAnouncementTypeInRange_Result> _CurrentPageAnouncement;

        public ObservableCollection<SelectAnouncementTypeInRange_Result> CurrentPageAnouncement
        {
            get
            {
                if (_CurrentPageAnouncement == null)
                    _CurrentPageAnouncement = new ObservableCollection<SelectAnouncementTypeInRange_Result>();
                return _CurrentPageAnouncement;
            }

            set
            {
                if (value == _CurrentPageAnouncement)
                    return;
                _CurrentPageAnouncement = value;
                OnPropertyChanged("CurrentPageAnouncement");
            }
        }

        private ICommand _AnouncementClicked;

   
        private void OnAnouncementClicked(TextBlock currentAnouncement)
        {
            Messager.AnouncementBroadCast(false, true, false);
            if (currentTypeMoreAnouncement == "General")
            {
                Messager.TypeOfAnouncementBroadCast("GeneralAnouncement");
            }
            else
                Messager.AnouncementBroadCast(false, true, false);
            if (currentTypeMoreAnouncement == "Discipline")
            {
                Messager.TypeOfAnouncementBroadCast("DisciplinelAnouncement");
            }
            Messager.AnouncementDetailBroadCast(currentAnouncement.Text);
            Messager.CurrentTabTransmitted("MoreAnouncement");
        }

        public ICommand AnouncementClicked
        {
            get
            {
                if (_AnouncementClicked == null)
                {
                    _AnouncementClicked = new RelayCommand<TextBlock>((p) => true, OnAnouncementClicked);
                }
                return _AnouncementClicked;
            }


        }

        public string AnouncementTitle
        {
            get
            {
                return anouncementTitle;
            }

            set
            {
                if (anouncementTitle!=value)
                anouncementTitle = value;
                OnPropertyChanged("AnouncementTitle");
            }
        }

        public MoreAnouncementViewModel()
        {
            Messager.CurrentPageTransmitted += OnChangePageAnouncement;
            Messager.TypeOfMoreAnouncementTransmitted += OnTypeOfMoreAnouncementReceived;
        }

        private void OnTypeOfMoreAnouncementReceived(string type)
        {
            currentTypeMoreAnouncement = type;
            AnouncementTitle = type + " Anouncements";
            CurrentPageAnouncement = new ObservableCollection<SelectAnouncementTypeInRange_Result>(ST.SelectAnouncementTypeInRange(currentPage, currentPage + 4, currentTypeMoreAnouncement));
        }

        private void OnChangePageAnouncement(string obj)
        {
            CurrentPage = Convert.ToInt32(obj);
            CurrentPageAnouncement = new ObservableCollection<SelectAnouncementTypeInRange_Result>(ST.SelectAnouncementTypeInRange(currentPage, currentPage + 4,currentTypeMoreAnouncement));
        }
    }
}
