namespace StudentManagement.ViewModel
{
    public class ViewModelLocator
    {
        public MainViewModel Main
        {
            get { return CreateViewModel<MainViewModel>(); }
        }

        private T CreateViewModel<T>() where T : new()
        {
            return new T();
        }
    }
}
