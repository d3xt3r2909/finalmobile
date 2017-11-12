﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESBX.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPage : MasterDetailPage
    {
        public MyPage()
        {
            InitializeComponent();
            MasterPage.ListView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MyPageMenuItem;
            if (item == null)
                return;

            var page = (Page)Activator.CreateInstance(item.TargetType);
            page.Title = item.Title;

            if (Global.logedUser == null)
            {
                Application.Current.MainPage = new ESBX.Login();
            }
            else
            {
                Detail = new NavigationPage(page);
            }
            IsPresented = false;

            MasterPage.ListView.SelectedItem = null;
        }
    }
}