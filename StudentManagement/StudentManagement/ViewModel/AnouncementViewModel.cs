using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class AnouncementViewModel : MainAnouncementViewModel
    {
        StudentDBEntities ST = new StudentDBEntities();
        private ObservableCollection<Get10NewestGeneralAnouncements_Result> _TopTenNewestGeneralAnouncement;
        public ObservableCollection<Get10NewestGeneralAnouncements_Result> TopTenNewestGeneralAnouncement
        {
            get
            {
                if (_TopTenNewestGeneralAnouncement == null)
                    _TopTenNewestGeneralAnouncement = new ObservableCollection<Get10NewestGeneralAnouncements_Result>(ST.Get10NewestGeneralAnouncements());
                return _TopTenNewestGeneralAnouncement;
            }

            set
            {
                if (value == _TopTenNewestGeneralAnouncement)
                    return;
                _TopTenNewestGeneralAnouncement = value;
                OnPropertyChanged("TopTenNewestGeneralAnouncement");
            }
        }

        private ObservableCollection<Get10NewestDisciplineAnouncements_Result> _TopTenNewestDisciplineAnouncement;
        public ObservableCollection<Get10NewestDisciplineAnouncements_Result> TopTenNewestDisciplineAnouncement
        {
            get
            {
                if (_TopTenNewestDisciplineAnouncement == null)
                    _TopTenNewestDisciplineAnouncement = new ObservableCollection<Get10NewestDisciplineAnouncements_Result>(ST.Get10NewestDisciplineAnouncements());
                return _TopTenNewestDisciplineAnouncement;
            }

            set
            {
                if (value == _TopTenNewestDisciplineAnouncement)
                    return;
                _TopTenNewestDisciplineAnouncement = value;
                OnPropertyChanged("TopTenNewestDisciplineAnouncement");
            }
        }


        private ICommand _MoreGeneralAnouncementClicked;

        public ICommand MoreGeneralAnouncementClicked
        {
            get
            {
                if (_MoreGeneralAnouncementClicked == null)
                {
                    _MoreGeneralAnouncementClicked = new RelayCommand<object>((p) => true, OnMoreGeneralAnouncementClicked);
                }
                return _MoreGeneralAnouncementClicked;
            }
        }


        private void OnMoreGeneralAnouncementClicked(object obj)
        {
            Messager.TypeOfMoreAnouncementBroadCast("General");
            Messager.AnouncementMessageTransmitted(false, false, true);
        }

        private ICommand _MoreDisciplineAnouncementClicked;

        public ICommand MoreDisciplineAnouncementClicked
        {
            get
            {
                if (_MoreDisciplineAnouncementClicked == null)
                {
                    _MoreDisciplineAnouncementClicked = new RelayCommand<object>((p) => true, OnMoreDisciplineAnouncementClicked);
                }
                return _MoreDisciplineAnouncementClicked;
            }
        }


        private void OnMoreDisciplineAnouncementClicked(object obj)
        {
            Messager.TypeOfMoreAnouncementBroadCast("Discipline");
            Messager.AnouncementMessageTransmitted(false, false, true);
        }


        private ICommand _GeneralAnouncementClicked;
        public ICommand GeneralAnouncementClicked
        {
            get
            {
                if (_GeneralAnouncementClicked == null)
                {
                    _GeneralAnouncementClicked = new RelayCommand<TextBlock>((p) => true, OnGeneralAnouncementClicked);
                }
                return _GeneralAnouncementClicked;
            }
        }
        private void OnGeneralAnouncementClicked(TextBlock currentAnouncement)
        {
            Messager.AnouncementBroadCast(false, true, false);
            Messager.TypeOfAnouncementBroadCast("GeneralAnouncement");
            Messager.AnouncementDetailBroadCast(currentAnouncement.Text);
            Messager.CurrentTabBroadCast("Anouncement");
        }


        private ICommand _DisciplineAnouncementClicked;
        public ICommand DisciplineAnouncementClicked
        {
            get
            {
                if (_DisciplineAnouncementClicked == null)
                {
                    _DisciplineAnouncementClicked = new RelayCommand<TextBlock>((p) => true, OnDisciplineAnouncementClicked);
                }
                return _DisciplineAnouncementClicked;
            }
        }
        private void OnDisciplineAnouncementClicked(TextBlock currentAnouncement)
        {
            Messager.AnouncementBroadCast(false, true, false);
            Messager.TypeOfAnouncementBroadCast("DisciplineAnouncement");
            Messager.AnouncementDetailBroadCast(currentAnouncement.Text);
            Messager.CurrentTabBroadCast("Anouncement");
        }

  


        public AnouncementViewModel()
        {

        }


    }
}