using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LoginSampleApplication.Models;
using LoginSampleApplication.ViewModels;

namespace LoginSampleApplication
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
