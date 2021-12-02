﻿using System;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Flow.Launcher.Infrastructure.UserSettings;
using Flow.Launcher.Resources.Pages;
using ModernWpf.Media.Animation;

namespace Flow.Launcher
{
    public partial class WelcomeWindow : Window
    {
        private readonly Settings settings;

        public WelcomeWindow(Settings settings)
        {
            InitializeComponent();
            BackButton.IsEnabled = false;
            this.settings = settings;
            ContentFrame.Navigate(PageTypeSelector(1), settings);
        }

        private NavigationTransitionInfo _transitionInfo = new SlideNavigationTransitionInfo()
        {
            Effect = SlideNavigationTransitionEffect.FromRight
        };
        private NavigationTransitionInfo _backTransitionInfo = new SlideNavigationTransitionInfo()
        {
            Effect = SlideNavigationTransitionEffect.FromLeft
        };
        Storyboard sb = new Storyboard();
        private int pageNum = 1;
        private int MaxPage = 5;
        public string PageDisplay => $"{pageNum}/5";

        private void UpdateView()
        {
            PageNavigation.Text = PageDisplay;
            if (pageNum == 1)
            {
                BackButton.IsEnabled = false;
                NextButton.IsEnabled = true;
            }
            else if (pageNum == MaxPage)
            {
                BackButton.IsEnabled = true;
                NextButton.IsEnabled = false;
            }
            else
            {
                BackButton.IsEnabled = true;
                NextButton.IsEnabled = true;
            }
        }

        private void ForwardButton_Click(object sender, RoutedEventArgs e)
        {
            pageNum++;
            UpdateView();

            ContentFrame.Navigate(PageTypeSelector(pageNum), settings, _transitionInfo);
        }

        private void BackwardButton_Click(object sender, RoutedEventArgs e)
        {
            if (pageNum > 1)
            {
                pageNum--;
                UpdateView();
                ContentFrame.Navigate(PageTypeSelector(pageNum), settings, _backTransitionInfo);
            }
            else
            {
                BackButton.IsEnabled = false;
            }
        }

        private void BtnCancel_OnClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private static Type PageTypeSelector(int pageNumber)
        {
            return pageNumber switch
            {
                1 => typeof(WelcomePage1),
                2 => typeof(WelcomePage2),
                3 => typeof(WelcomePage3),
                4 => typeof(WelcomePage4),
                5 => typeof(WelcomePage5),
                _ => throw new ArgumentOutOfRangeException(nameof(pageNumber), pageNumber, "Unexpected Page Number")
            };
        }
    }
}