﻿using SimpleWPF.Navigation;
using SimpleWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateProject
{
    public class AppViewModel : SimpleViewModel, ISimpleNavigationProvider
    {
        private SimpleViewModel current;

        public SimpleViewModel Current
        {
            get { return current; }
            set { OnPropertyChanged(ref current, value); }
        }

        private ISimpleWindow window;

        public ISimpleWindow Window
        {
            get { return window; }
            set { OnPropertyChanged(ref window, value); }
        }
    }
}
