using SimpleWPF.Core.Core;
using SimpleWPF.Core.Navigation;
using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Navigation;

namespace MultiWindowSampleApplication.ViewModels
{
    public class AppViewModel : SimpleViewModel, ISimpleNavigationHandler
    {
        public ICommand HomeCommand { get; set; }

        private SimpleViewModel current;
        public SimpleViewModel Current
        {
            get { return current; }
            set
            {
                OnPropertyChanged(ref current, value);
            }
        }

        private ISimpleWindow window;
        public ISimpleWindow Window
        {
            get { return window; }
            set
            {
                OnPropertyChanged(ref window, value);
            }
        }


        public AppViewModel()
        {
            HomeCommand = new SimpleRelayCommand(NavigateToHome);
        }

        private void NavigateToHome()
        {
            Navigate(new NewPostViewModel());
        }
    }
}
