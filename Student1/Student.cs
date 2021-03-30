using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Student1
{
    public class Student : INotifyPropertyChanged
    {
        private string fio;
        private string faculty;
        private int maths;
        private int physics;
        private int essay;
        private int sum;

        public int Id { get; set; }

        public string FIO
        {
            get { return fio; }
            set
            {
                fio = value;
                OnPropertyChanged("FIO");
            }
        }

        public string Faculty
        {
            get { return faculty; }
            set
            {
                faculty = value;
                OnPropertyChanged("Faculty");
            }
        }

        public int Maths
        {
            get { return maths; }
            set
            {
                maths = value;
                OnPropertyChanged("Maths");
            }
        }

        public int Physics
        {
            get { return physics; }
            set
            {
                physics = value;
                OnPropertyChanged("Physics");
            }
        }

        public int Essay
        {
            get { return essay; }
            set
            {
                essay = value;
                OnPropertyChanged("Essay");
            }
        }

        public int Sum
        {
            get { return sum = Maths + Physics + Essay; }
            set
            {
                sum = Maths + Physics + Essay;
                OnPropertyChanged("Sum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}