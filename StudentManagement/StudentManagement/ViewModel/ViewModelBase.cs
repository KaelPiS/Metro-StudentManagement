using System.ComponentModel;

namespace StudentManagement.ViewModel
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region event PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
