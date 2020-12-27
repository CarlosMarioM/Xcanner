using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace QRLectorApp.Model
{
    class QrColorApp :INotifyPropertyChanged
    {
        public string color { get; set; }
        public string status { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
