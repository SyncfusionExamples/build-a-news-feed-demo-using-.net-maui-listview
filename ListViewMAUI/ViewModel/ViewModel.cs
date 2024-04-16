using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NewsFeedDemo
{
    public class ViewModel
    {
        private ObservableCollection<Model> news;

        public ViewModel() 
        {
            this.news = new ObservableCollection<Model>();
            this.LikeActionCommand = new Command(DoLike);
            LoadData();
        }

        public ObservableCollection<Model> News
        {
            get => news;
            set
            {
                news = value;
            }
        }

        public Command LikeActionCommand
        {
            get;
        }

        private void DoLike(object obj)
        {
            if (obj != null)
            {
                var item = obj as Model;
                item!.IsLiked = !item.IsLiked;
            }
        }
        private void LoadData()
        {
            
            news.Add(new Model { Title = "Breaking News: MAUI Released!", Description = "Microsoft has officially released .NET MAUI, the next-gen cross-platform framework. Developers can now build apps for Android, iOS, and Windows with a single codebase.",ImageName="maui.png", IsLiked = false });
            news.Add(new Model { Title = "Tech Innovation Summit 2024", Description = "Join us at the Tech Innovation Summit 2024 where industry leaders will discuss the latest advancements in artificial intelligence, blockchain, and more.", ImageName="techinnovation.png", IsLiked = false });
            news.Add(new Model { Title = "World News", Description = "In a breakthrough summit, global leaders unite to address rising cyber threats, unveiling a collaborative cybersecurity initiative.", ImageName="worldnews.png", IsLiked = false });
            news.Add(new Model { Title = "Sports Updates", Description = " In a thrilling match, Team A secured a last-minute victory against their rivals with a stunning goal, solidifying their position at the top of the football league.", ImageName="sportsupdates.png", IsLiked = false });
            news.Add(new Model { Title = "Health Tips", Description = "Stay active and healthy with these simple exercises you can do at home. #WellnessWednesday", ImageName="healthtips.png", IsLiked = false });
            news.Add(new Model { Title = "Science Breakthroughs", Description = "Scientists make a groundbreaking discovery in renewable energy research. A step towards a greener future.", ImageName="greenerenergy.png", IsLiked = false });
            news.Add(new Model { Title = "Art Showcase", Description = "Featured artist of the week: Check out the incredible paintings by [Artist Name]",ImageName="artshowcase.png", IsLiked = false });
            news.Add(new Model { Title = "Tech News", Description = "Major tech companies showcased their newest products and technologies at the Tech Summit 2024.", ImageName="technews.png", IsLiked = false });
            news.Add(new Model { Title = "Climate Change Summit Highlights Urgency for Global Action", Description = "World leaders gather to discuss and address the escalating challenges posed by climate change.", ImageName="climatechange.png", IsLiked = false });
            news.Add(new Model { Title = "Artificial Intelligence Revolutionizes Healthcare", Description = "AI-driven technologies are transforming the healthcare industry, improving diagnostics and patient care.", ImageName="aihealthcare.png", IsLiked = false });
            news.Add(new Model { Title = "Global Economy Outlook for the Coming Year", Description = "Economists predict trends and challenges for the global economy for the coming year.", ImageName="economy.png", IsLiked = false });
            news.Add(new Model { Title = "Health and Wellness Tips for a Balanced Life", Description = "Experts share insights on maintaining a healthy lifestyle through exercise, nutrition, and mindfulness.", ImageName="health.png", IsLiked = false });
            news.Add(new Model { Title = "Innovation in the Automotive Industry", Description = "Explore the latest innovations and developments in the automotive industry, with a focus on electric vehicles.", ImageName="automotive.png", IsLiked = false });
            news.Add(new Model { Title = "Innovations in Learning Technologies", Description = "Explore the latest advancements in educational technologies and their impact on learning.", ImageName="learningtech.png", IsLiked = false });
            news.Add(new Model { Title = "Sports Highlights", Description = "Recap of the thrilling moments and standout performances from the latest sports tournaments.", ImageName="sportshighlights.png", IsLiked = false });
            news.Add(new Model { Title = "Breaking News: Major Scientific Discovery in Medicine", Description = "Scientists announce a groundbreaking discovery that could revolutionize the field of medicine.", ImageName="medicine.png", IsLiked = false });


            Random r = new Random();
            Random r1 = new Random(); 
            DateTime currentTime = DateTime.Now;
            foreach (var item in news)
            {
                item.NewsDate = currentTime.AddDays(-r.Next(1, 5)).AddHours(-r.Next(1, 24)).AddMinutes(-r.Next(1, 60)).ToString("dd MMM yyyy | HH:mm | ");
                
                item.Views = r.Next(100, 500).ToString();
            }
        }

        internal string[] ImageNames = new string[]
        {
            "aihealthcare.png",
            "artshowcase.png",
            "automotive.png",
            "climatechange.png",
            "economy.png",
            "greenenergy.png",
            "health.png",
            "healthtips.png",
            "learningtech.png",
            "maui.png",
            "medicine.png",
            "sportshighlights.png",
            "sportsupdates.png",
            "techinnovation.png",
            "technews.png",
            "worldnews.png"
        };
    }
}
