using System.Collections.ObjectModel;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class AnouncementDetailViewModel : AnouncementViewModel
    {
        StudentDBEntities ST = new StudentDBEntities();
        private string previousTab;
        private string typeOfAnouncement;
        private ObservableCollection<GetGeneralAnoucementDetailByTitle_Result> _GeneralAnouncementDetail;


        public ObservableCollection<GetGeneralAnoucementDetailByTitle_Result> GeneralAnouncementDetail
        {
            get
            {
                if (_GeneralAnouncementDetail == null)
                    _GeneralAnouncementDetail = new ObservableCollection<GetGeneralAnoucementDetailByTitle_Result>();
                return _GeneralAnouncementDetail;
            }

            set
            {
                if (_GeneralAnouncementDetail != value)
                    _GeneralAnouncementDetail = value;
                OnPropertyChanged("GeneralAnouncementDetail");
            }
        }

        private ObservableCollection<GetDisciplineAnoucementDetailByTitle_Result> _DisciplineAnouncementDetail;


        public ObservableCollection<GetDisciplineAnoucementDetailByTitle_Result> DisciplineAnouncementDetail
        {
            get
            {
                if (_DisciplineAnouncementDetail == null)
                    _DisciplineAnouncementDetail = new ObservableCollection<GetDisciplineAnoucementDetailByTitle_Result>();
                return _DisciplineAnouncementDetail;
            }

            set
            {
                if (_DisciplineAnouncementDetail != value)
                    _DisciplineAnouncementDetail = value;
                OnPropertyChanged("DisciplineAnouncementDetail");
            }
        }


        private string anouncementTitle;
        private bool isGeneralAnouncementDetailOpen = false;
        public bool IsGeneralAnouncementDetailOpen
        {
            get
            {
                return isGeneralAnouncementDetailOpen;
            }

            set
            {
                if (isGeneralAnouncementDetailOpen != value)
                    isGeneralAnouncementDetailOpen = value;
                OnPropertyChanged("IsGeneralAnouncementDetailOpen");
            }
        }

        private bool isDisciplineAnouncementDetailOpen = false;
        public bool IsDisciplineAnouncementDetailOpen
        {
            get
            {
                return isDisciplineAnouncementDetailOpen;
            }

            set
            {
                if (isDisciplineAnouncementDetailOpen != value)
                    isDisciplineAnouncementDetailOpen = value;
                OnPropertyChanged("IsDisciplineAnouncementDetailOpen");
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
                if (anouncementTitle != value)
                    anouncementTitle = value;
                OnPropertyChanged("AnouncementTitle");
            }
        }

        public ICommand PreviousCommand
        {
            get
            {
                if (_PreviousCommand == null)
                    _PreviousCommand = new RelayCommand<object>((p) => true, OnPreviousCommand);
                return _PreviousCommand;
            }
        }

        public ICommand BackToMenu
        {
            get
            {
                if (_BackToMenu == null)
                    _BackToMenu = new RelayCommand<object>((p) => true, OnBackToMenuCommand);
                return _BackToMenu;
            }
        }
        private void OnBackToMenuCommand(object obj)
        {
            Messager.PreviousTabBroadCast(true, false, false, "Anouncement");
        }

        private ICommand _PreviousCommand;

        public AnouncementDetailViewModel()
        {
            Messager.AnouncementDetailMessageTransmitted += OnMessageReceived;
            Messager.CurrentTabTransmitted += OnPreviousTabReceived;
            Messager.TypeOfAnouncementTransmitted += OnTypeOfAnouncementReceived;
        }

        private void OnTypeOfAnouncementReceived(string type)
        {
            typeOfAnouncement = type;
        }

        private void OnPreviousTabReceived(string arg4)
        {
            previousTab = arg4;
        }

        private void OnPreviousCommand(object obj)
        {
            Messager.PreviousTabBroadCast(true, false, false, previousTab);
        }

        private ICommand _BackToMenu;

        private void OnMessageReceived(string Title)
        {
            AnouncementTitle = Title;
            if (typeOfAnouncement == "GeneralAnouncement")
            {
                GeneralAnouncementDetail = new ObservableCollection<GetGeneralAnoucementDetailByTitle_Result>(ST.GetGeneralAnoucementDetailByTitle(AnouncementTitle));
                IsGeneralAnouncementDetailOpen = true;
                IsDisciplineAnouncementDetailOpen = false;
            }

            else
                if (typeOfAnouncement == "DisciplineAnouncement")
            {
                DisciplineAnouncementDetail = new ObservableCollection<GetDisciplineAnoucementDetailByTitle_Result>(ST.GetDisciplineAnoucementDetailByTitle(AnouncementTitle));
                IsDisciplineAnouncementDetailOpen = true;
                IsGeneralAnouncementDetailOpen = false;
            }

        }
    }
}