using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeedDemo
{
    public class Model : INotifyPropertyChanged
    {
        private string title;
        private string description;
        private bool isLiked;
        private string imageName;
        private string views;
        private string dateTime;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Title)));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Description)));
            }
        }

        public bool IsLiked
        {
            get => isLiked;
            set
            {
                isLiked = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsLiked)));
            }
        }

        public string ImageName
        {
            get => imageName;
            set
            {
                imageName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ImageName)));
            }
        }

        public string Views
        {
            get => views;
            set
            {
                views = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Views)));
            }
        }

        public string NewsDate
        {
            get => dateTime;
            set
            {
                dateTime = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(DateTime)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
