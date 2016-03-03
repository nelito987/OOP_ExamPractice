
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MusicShopManager.Interfaces;

namespace MusicShop.Models
{
    public class MusicShop: IMusicShop
    {
        private string name;
        private IList<IArticle> articles; 
    
        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }
    
        public string Name
        {
            get { return this.name; }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, String.Format(ErrorMessage.StringCannotBeNullOrEmpty, "Music shop name"));
                this.name = value;
            }
        }
    
        public IList<IArticle> Articles
        {
            get
            {
                return this.articles;
            }
    
            private set
            {
                this.articles = value;
            }
        }
    
        public void AddArticle(IArticle article)
        {
            //if (!this.Articles.Contains(article))
            //{
                this.Articles.Add(article);
            //}
        }
    
        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }
    
        //public string ListArticles()
        //{
        //    var output = new StringBuilder();
        //    output.AppendFormat("===== {0} =====", this.Name).AppendLine();
        //
        //    if (!this.Articles.Any())
        //    {
        //       output.AppendLine("The shop is empty. Come back soon.");
        //        return output.ToString();
        //    }
        //    var microphones = this.Articles.Where(x => x is Microphone);
        //    output.Append(PrintArticles(microphones, "Microphones"));
        //
        //    var drums = this.Articles.Where(x => x is Drum);
        //    output.Append(PrintArticles(drums, "Drums"));
        //
        //    var elGuitar = this.Articles.Where(x => x is ElectricGuitar);
        //    output.Append(PrintArticles(elGuitar, "Electric guitars"));
        //
        //    var acGuitar = this.Articles.Where(x => x is AcousticGuitar);
        //    output.Append(PrintArticles(acGuitar, "Acoustic guitars"));
        //
        //    var bassGuitar = this.Articles.Where(x => x is BassGuitars);
        //    output.Append(PrintArticles(bassGuitar, "Bass guitars"));
        //
        //    return output.ToString();
        //}
        //
        //private string PrintArticles(IEnumerable<IArticle> articles, string title)
        //{
        //    if (articles.Count() == 0)
        //    {
        //        return string.Empty;
        //    }
        //
        //    StringBuilder articlesAsString = new StringBuilder();
        //    articles.OrderBy(x => x.Make + " " + x.Model);
        //    articlesAsString.AppendFormat("----- {0} -----", title).AppendLine();
        //    foreach (var article in articles)
        //    {
        //        articlesAsString.AppendLine(article.ToString());
        //    }
        //
        //    return articlesAsString.ToString();
        //}

        public string ListArticles()
        {
            var musicShop = new StringBuilder();
            musicShop.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name).AppendLine();
            if (!this.Articles.Any())
            {
                musicShop.AppendLine("The shop is empty. Come back soon.");
                return musicShop.ToString();
            }

            var microphones = this.Articles.Where(a => a is Microphone);
            musicShop.Append(this.PrintArticles(microphones, "Microphones"));

            var drums = this.Articles.Where(a => a is Drum);
            musicShop.Append(this.PrintArticles(drums, "Drums"));

            var electricGuitars = this.Articles.Where(a => a is ElectricGuitar);
            musicShop.Append(this.PrintArticles(electricGuitars, "Electric guitars"));

            var acousticGuitars = this.Articles.Where(a => a is AcousticGuitar);
            musicShop.Append(this.PrintArticles(acousticGuitars, "Acoustic guitars"));

            var bassGuitars = this.Articles.Where(a => a is BassGuitars);
            musicShop.Append(this.PrintArticles(bassGuitars, "Bass guitars"));

            return musicShop.ToString();
        }

        private string PrintArticles(IEnumerable<IArticle> articles, string title)
        {
            if (articles.Count() == 0)
            {
                return string.Empty;
            }

            StringBuilder articlesAsString = new StringBuilder();
            articles = articles.OrderBy(a => a.Make + " " + a.Model);
            articlesAsString.AppendFormat("{0} {1} {0}", new string('-', 5), title).AppendLine();
            foreach (var article in articles)
            {
                articlesAsString.Append(article.ToString());
            }

            return articlesAsString.ToString();
        }
    }

   
}
