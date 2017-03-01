using System.Collections.ObjectModel;
using System.Linq;

namespace StudentManagement.ViewModel
{
    class DiplomaProjectView:ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        private ObservableCollection<GetDiplomaProject_Result> _DiplomaProject;

        public ObservableCollection<GetDiplomaProject_Result> DiplomaProject
        {
            get
            {
                var thisUser = DialogLogginViewModel.Users[0];
                if (_DiplomaProject == null)
                {
                    _DiplomaProject = new ObservableCollection<GetDiplomaProject_Result>(ST.GetDiplomaProject(thisUser.ID).ToList());
                }
                return _DiplomaProject;
            }

            set
            {
                _DiplomaProject = value; OnPropertyChanged("DiplomaProject");
            }
        }
    }
}
