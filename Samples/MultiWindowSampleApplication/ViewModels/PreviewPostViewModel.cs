using MultiWindowSampleApplication.Models;
using MultiWindowSampleApplication.ViewModels;

namespace MultiWindowSampleApplication
{
    public class PreviewPostViewModel : AuthorizedViewModel
    {
        public PostModel Post { get; set; }

        public PreviewPostViewModel(PostModel post)
        {
            Post = post;
        }
    }
}