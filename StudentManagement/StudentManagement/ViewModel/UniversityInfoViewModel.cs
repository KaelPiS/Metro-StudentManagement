using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class UniversityInfoViewModel:ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        private ObservableCollection<GetUniversityInfo_Result> _UniversityInfo;
        public ObservableCollection<GetUniversityInfo_Result> UniversityInfo
        {
            get
            {
                if (_UniversityInfo == null)
                    _UniversityInfo = new ObservableCollection<GetUniversityInfo_Result>(ST.GetUniversityInfo());
                return _UniversityInfo;
            }

            set
            {
                if (_UniversityInfo == value)
                    return;
                _UniversityInfo = value;
                OnPropertyChanged("UniversityInfo");
            }
        }
        private ICommand _IntroUnloadCommand;
        public ICommand IntroUnloadCommand
        {
            get
            {
                if (_IntroUnloadCommand==null)
                    _IntroUnloadCommand = new RelayCommand<MediaElement>((p) => true, OnIntroUnloadCommand);
                return _IntroUnloadCommand;
            }

           
        }

        private void OnIntroUnloadCommand(MediaElement currentMediaEle)
        { 
            currentMediaEle.Position = new TimeSpan(0, 0, 1);
            currentMediaEle.Play();
        }
   
    }
}
