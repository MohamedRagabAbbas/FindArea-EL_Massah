using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace FindArea.Model
{
    class Project:INotifyPropertyChanged
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                if(name!=value)
                {
                    name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        private string date;

        public string Date
        {
            get => date;
            set
            {
                if (date != value)
                {
                    date = value;
                    OnPropertyChanged("Date");

                }
            }
        }

        private string imagepath;

        public string ImagePath
        {
            get => imagepath;
            set
            {
                if (imagepath != value)
                {
                    imagepath = value;
                    OnPropertyChanged("ImagePath");

                }
            }
        }

        private string totalArea;

        public string TotalArea
        {
            get => totalArea;
            set
            {
                if (totalArea != value)
                {
                    totalArea = value;
                    OnPropertyChanged("TotalArea");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
