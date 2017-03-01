namespace StudentManagement.ViewModel
{
    public class MainAnouncementViewModel : ViewModelBase
    {
        private bool isAnouncementOpen = true;
        public bool IsAnouncementOpen
        {
            get
            {
                return isAnouncementOpen;
            }

            set
            {
                isAnouncementOpen = value;
                OnPropertyChanged("IsAnouncementOpen");
            }
        }

        private bool isDetailAnouncementOpen = false;



        public bool IsDetailAnouncementOpen
        {
            get
            {
                return isDetailAnouncementOpen;
            }

            set
            {
                isDetailAnouncementOpen = value;
                OnPropertyChanged("IsDetailAnouncementOpen");
            }
        }

        private bool isMoreAnouncementOpen = false;



        public bool IsMoreAnouncementOpen
        {
            get
            {
                return isMoreAnouncementOpen;
            }

            set
            {
                isMoreAnouncementOpen = value;
                OnPropertyChanged("IsMoreAnouncementOpen");
            }
        }



        public MainAnouncementViewModel()
        {
            Messager.AnouncementMessageTransmitted += OnMessageReceived;
            Messager.PreviousTabTransmitted += OnPreviousTabTransmitted;
        }

        private void OnPreviousTabTransmitted(bool isAnouncementOpen, bool isDetailAnouncementOpen, bool isMoreAnouncementOpen, string previousTab)
        {
            if (previousTab == "Anouncement")
            {
                IsAnouncementOpen = isAnouncementOpen;
                IsDetailAnouncementOpen = isDetailAnouncementOpen;
                IsMoreAnouncementOpen = isMoreAnouncementOpen;
            }
            else
                if (previousTab=="MoreAnouncement")
            {
                IsAnouncementOpen = !isAnouncementOpen;
                IsDetailAnouncementOpen = isDetailAnouncementOpen;
                IsMoreAnouncementOpen = !isMoreAnouncementOpen;
            }
        }

        private void OnMessageReceived(bool para1, bool para2, bool para3)
        {
            IsAnouncementOpen = para1;
            IsDetailAnouncementOpen = para2;
            IsMoreAnouncementOpen = para3;
        }
    }
}
