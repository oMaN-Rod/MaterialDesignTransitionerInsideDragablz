using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using MaterialDesignTransitionerInsideDragablz.Annotations;

namespace MaterialDesignTransitionerInsideDragablz
{
    public partial class SimpleFormView : INotifyPropertyChanged
    {
        public SimpleFormView()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Title { get; set; }

        private string _firstName;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Submit_OnClick(object sender, RoutedEventArgs e)
        {
            Message = $"Hello {FirstName} {LastName}, have a great day!";
        }
    }
}
