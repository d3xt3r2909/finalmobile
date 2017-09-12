using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESBX_MyPLC.ViewModel
{
    public class KorpaMobileVm
    {
        public int KorpaId { get; set; }
        public int StavkaId { get; set; }
        public string Cijena { get; set; }
        public string Kolicina { get; set; }
        public string Sastojci { get; set; }
    }

    public class KorpaMobileVmList : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<KorpaMobileVm> _items;

        public ObservableCollection<KorpaMobileVm> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged("Items"); }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged == null)
                return;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public KorpaMobileVmList(List<KorpaMobileVm> itemList)
        {
            Items = new ObservableCollection<KorpaMobileVm>();
            foreach (KorpaMobileVm itm in itemList)
            {
                Items.Add(itm);
            }
        }
    }

}
