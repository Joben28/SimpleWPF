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
    public class PreviewPostViewModel : AuthorizedViewModel
    {
        public PostModel Post { get; set; }

        public PreviewPostViewModel(PostModel post)
        {
            Post = post;
        }
    }
}
