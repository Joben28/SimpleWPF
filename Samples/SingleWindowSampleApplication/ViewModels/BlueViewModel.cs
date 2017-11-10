﻿using SimpleWPF.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SingleWindowSampleApplication.ViewModels
{
    public class BlueViewModel : SimpleViewModel
    {
        public ICommand GotoRedCommand { get; set; }

        public BlueViewModel()
        {
            GotoRedCommand = new SimpleRelayCommand(GotoRed);
        }

        private void GotoRed(object obj)
        {
            Navigate(new RedViewModel());
        }
    }
}