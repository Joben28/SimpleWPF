using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MultiWindowSampleApplication.Models;
using MultiWindowSampleApplication.ViewModels;

namespace MultiWindowSampleApplication
{
    public class NewPostViewModel : AuthorizedViewModel
    {
        public PostModel Post { get; set; }

        public ICommand SubmitCommand { get; set; }

        public NewPostViewModel()
        {
            Post = new PostModel();
            SubmitCommand = new SimpleRelayCommand(NavigateToB);
        }

        private void NavigateToB(object obj)
        {
            Navigate(new PreviewPostViewModel(Post));
        }
    }
}
