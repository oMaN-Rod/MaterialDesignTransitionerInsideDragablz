using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MaterialDesignTransitionerInsideDragablz.Annotations;

namespace MaterialDesignTransitionerInsideDragablz
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Slides = new object[] { Form1, Form2, Form3 };
        }

        public ICommand PrevCommand => new DelegateCommand(Previous);
        public ICommand NextCommand => new DelegateCommand(Next);

        public object[] Slides { get; }

        public SimpleFormView Form1 { get; set; } = new SimpleFormView() { Title = "Form 1" };

        public SimpleFormView Form2 { get; set; } = new SimpleFormView() { Title = "Form 2" };

        public SimpleFormView Form3 { get; set; } = new SimpleFormView() { Title = "Form 3" };

        private int _activeSlideIndex;
        public int ActiveSlideIndex
        {
            get => _activeSlideIndex;
            set
            {
                _activeSlideIndex = value;
                OnPropertyChanged(nameof(ActiveSlideIndex));
            }
        }

        private void Previous()
        {
            if (ActiveSlideIndex == 0)
            {
                ActiveSlideIndex = Slides.Length - 1;
            }
            else
            {
                ActiveSlideIndex--;
            }
        }

        private void Next()
        {
            if (ActiveSlideIndex == Slides.Length - 1)
            {
                ActiveSlideIndex = 0;
            }
            else
            {
                ActiveSlideIndex++;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
