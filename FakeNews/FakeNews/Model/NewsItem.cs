using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeNews.Model
{
    public class NewsItem
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public string Headline { get; set; }

        public string Subhead { get; set; }

        public string Dateline { get; set; }

        public string Image { get; set; }
    }

    private static List<NewsItem> getNewsItems()
    {
       
            var items = new List<NewsItem>();

            items.Add(new NewsItem()
            {
                Id = 1,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Financial.png"
            });
            items.Add(new NewsItem()
            {
                Id = 2,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Financial2.png"
            });
            items.Add(new NewsItem()
            {
                Id = 3,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Financial3.png"
            });

            items.Add(new NewsItem()
            {
                Id = 4,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Financial4.png"
            });
            items.Add(new NewsItem()
            {
                Id = 5,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Financial5.png"
            });
            items.Add(new NewsItem()
            {
                Id = 6,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Food1.png"
            });
            items.Add(new NewsItem()
            {
                Id = 7,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Food2.png"
            });
            items.Add(new NewsItem()
            {
                Id = 8,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Food3.png"
            });
            items.Add(new NewsItem()
            {
                Id = 9,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Food4.png"
            });
            items.Add(new NewsItem()
            {
                Id = 10,
                Category = "Financial",
                Headline = "Lorem Ipsum",
                Subhead = "doro sit amet",
                Dateline = "Nunc tristique nec",
                Image = "Assets/Food5.png"
            });

            return items;
      
    }

    public class NewsManager
    {
        public static void Getnews(string category, ObservableCollection<NewsItem> newsItems)
        {
            var allItems = getNewsItems();

            var filteredNewsItems = allItems.Where(p => p.Category == category).Tolist();

            newsItems.Clear();

            filteredNewsItems.ForEach(p => newsItems.Add(p));
        }

    }
    
}
