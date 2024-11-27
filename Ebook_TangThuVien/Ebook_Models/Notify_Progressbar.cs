using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebook_TangThuVien.Ebook_Models
{
    internal class Loading_LB : INotifyPropertyChanged
    {
        private static string _content;

        public static string _Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnStaticPropertyChanged(nameof(_Content));
            }
        }
        //_Value
        private static int _value;
        public static int _Value
        {
            get => _value;
            set
            {
                if (_value != value)
                {
                    _value = value;
                    OnStaticPropertyChanged(nameof(_Value));
                }
            }
        }


        public static event PropertyChangedEventHandler StaticPropertyChanged;

        public event PropertyChangedEventHandler PropertyChanged;

        private static void OnStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }

        // Notify instance property changes
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
