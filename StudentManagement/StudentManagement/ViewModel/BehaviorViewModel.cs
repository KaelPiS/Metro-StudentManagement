﻿using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;

namespace StudentManagement.ViewModel
{
    public class BehaviorViewModel : ViewModelBase
    {
        StudentDBEntities ST = new StudentDBEntities();
        public string GroupName = string.Empty;
        public string Activities_ = string.Empty;

        #region Activity Group, which hold all activity groups of current User
        private ObservableCollection<object> _ActiveGroup;
        public ObservableCollection<object> ActiveGroup
        {
            get
            {
                var thisUser = DialogLogginViewModel.Users[0];
                if (_ActiveGroup == null)
                {
                    _ActiveGroup = new ObservableCollection<object>(ST.GetActivityGroup(thisUser.ID).ToList());
                }
                return _ActiveGroup;
            }
            set
            {
                if (_ActiveGroup != value)
                {
                    _ActiveGroup = value; OnPropertyChanged("ActiveGroup");
                }
            }
        }
        #endregion


        #region Activities List, which hold all the activities of one Group
        public ICommand ActivitiesCommand { get; set; }
        private ObservableCollection<object> _Activities;
        public ObservableCollection<object> Activities
        {
            get
            {
                if (_Activities == null)
                {
                    _Activities = new ObservableCollection<object>(ST.GetActivities(GroupName).ToList());
                }
                return _Activities;
            }
            set
            {
                if (_Activities != value)
                {
                    _Activities = value; OnPropertyChanged("Activities");
                }
            }
        }

        void OnActivitiesCommand()
        {
            ActivitiesCommand = new RelayCommand<ListBox>((p) => true, (p) =>
            {
                GetActivityGroup_Result data = (GetActivityGroup_Result)p.SelectedItem;
                GroupName = data.GroupName;
                Activities = new ObservableCollection<object>(ST.GetActivities(GroupName).ToList());
            });
        }
        #endregion
 

        #region Detail Activities, which show detail about one Activity
        public ICommand DetailCommand { get; set; }
        private ObservableCollection<object> _DetailActivity;
        public ObservableCollection<object> DetailActivity
        {
            get
            {
                if (_DetailActivity == null)
                {
                    _DetailActivity = new ObservableCollection<object>(ST.GetDetailActivity(Activities_).ToList());
                }
                return _DetailActivity;
            }
            set
            {
                if (_DetailActivity != value)
                {
                    _DetailActivity = value; OnPropertyChanged("DetailActivity");
                }
            }
        }

        private void OnDetailCommand()
        {
            DetailCommand = new RelayCommand<ListBox>((p) => true, (p) =>
            {

                if (p.Items.Count <= 0) Activities_ = string.Empty;
                else
                {
                    try
                    {
                        GetActivities_Result data = (GetActivities_Result)p.SelectedItem;
                        Activities_ = data.ActivityName;
                    }
                    catch { }
                }
                if (p.SelectedIndex < 0) p.SelectedIndex = 0;
                DetailActivity = new ObservableCollection<object>(ST.GetDetailActivity(Activities_).ToList());
            });
        }

        #endregion

        public BehaviorViewModel()
        {
            OnActivitiesCommand();
            OnDetailCommand();
        }

    }
}
