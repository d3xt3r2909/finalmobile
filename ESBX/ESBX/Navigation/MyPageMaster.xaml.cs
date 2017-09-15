using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ESBX.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageMaster : ContentPage
    {
        public ListView ListView;

        public MyPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyPageMenuItem> MenuItems { get; set; }
            
            public MyPageMasterViewModel()
            {
                MenuItems = new ObservableCollection<MyPageMenuItem>(new[]
                {
                    new MyPageMenuItem { Title = "Kreiraj salatu",TargetType=typeof(KreiranjeSalate) },
                    new MyPageMenuItem {  Title = "Korpa",TargetType=typeof(KorisnickKorpa)  },
                  //  new MyPageMenuItem { Title = "Ocjeni salatu" ,TargetType=typeof() },
                    new MyPageMenuItem {Title = "Pregled ocjena" ,TargetType=typeof(PregledOcjena) },
                    new MyPageMenuItem {  Title = "Trenutna narudžba",TargetType=typeof(TrenutnoNarucene)  },
                    new MyPageMenuItem { Title = "Historija narudžbi" ,TargetType=typeof(HistorijaNarucenih) },
                   
                    new MyPageMenuItem { Title = "Podešavanje profila" ,TargetType=typeof(PodesavanjeProfila) },
                   //  new MyPageMenuItem { Title = "odjavi se" ,TargetType=typeof(Odjava) },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}