using System.Collections.ObjectModel;

namespace StudentManagement.ViewModel
{
    public class ProfileDetailViewModel : ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        private ObservableCollection<GetClassDetail_Result> _ClassInfo;

        public ObservableCollection<GetClassDetail_Result> ClassInfo
        {
            get
            {
                if (_ClassInfo == null)
                    _ClassInfo = new ObservableCollection<GetClassDetail_Result>(ST.GetClassDetail(ProfileViewModel.ClassID));
                return _ClassInfo;
            }

            set
            {
                if (value.Equals(_ClassInfo))
                    return;
                _ClassInfo = value;
                OnPropertyChanged("ClassInfo");
            }
        }

        private ObservableCollection<GetFacultyDetail_Result> _FacultyInfo;

        public ObservableCollection<GetFacultyDetail_Result> FacultyInfo
        {
            get
            {
                if (_FacultyInfo == null)
                    _FacultyInfo = new ObservableCollection<GetFacultyDetail_Result>(ST.GetFacultyDetail(ProfileViewModel.FacultyID));
                return _FacultyInfo;
            }

            set
            {
                if (value.Equals(_FacultyInfo))
                    return;
                _FacultyInfo = value;
                OnPropertyChanged("FacultyInfo");
            }
        }

        private ObservableCollection<GetDeparmentDetail_Result> _DepartmentInfo;

        public ObservableCollection<GetDeparmentDetail_Result> DepartmentInfo
        {
            get
            {
                if (_DepartmentInfo == null)
                    _DepartmentInfo = new ObservableCollection<GetDeparmentDetail_Result>(ST.GetDeparmentDetail(ProfileViewModel.DepartmentID));
                return _DepartmentInfo;
            }

            set
            {
                if (value.Equals(_DepartmentInfo))
                    return;
                _DepartmentInfo = value;
                OnPropertyChanged("DepartmentInfo");
            }
        }

        private ObservableCollection<GetSchooltDetail_Result> _SchoolInfo;

        public ObservableCollection<GetSchooltDetail_Result> SchoolInfo
        {
            get
            {
                if (_SchoolInfo == null)
                    _SchoolInfo = new ObservableCollection<GetSchooltDetail_Result>(ST.GetSchooltDetail(ProfileViewModel.SchoolID));
                return _SchoolInfo;
            }

            set
            {
                if (value.Equals(_SchoolInfo))
                    return;
                _SchoolInfo = value;
                OnPropertyChanged("SchoolInfo");
            }
        }
    }
}
