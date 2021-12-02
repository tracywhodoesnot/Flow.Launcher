﻿using Flow.Launcher.Infrastructure.UserSettings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flow.Launcher.Resources.Pages
{
    /// <summary>
    /// WelcomePage4.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class WelcomePage4
    {
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.ExtraData is Settings settings)
                Settings = settings;
            else
                throw new ArgumentException("Unexpected Navigation Parameter for Settings");
            InitializeComponent();
        }

        public Settings Settings { get; set; }
    }
}
