using MultiWindowSampleApplication.Models;
using MultiWindowSampleApplication.ViewModels;
using SimpleWPF.Core.Input;
using System.Windows.Input;

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

        private void NavigateToB()
        {
            Navigate(new PreviewPostViewModel(Post));
        }
    }
}