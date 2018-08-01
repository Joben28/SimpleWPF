using MultiWindowSampleApplication.Models;
using MultiWindowSampleApplication.ViewModels;
using SimpleWPF.Input;
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
            SubmitCommand = new RelayCommand(NavigateToB);
        }

        private void NavigateToB()
        {
            Navigate(new PreviewPostViewModel(Post));
        }
    }
}