using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article
    {
        public int Id { get; set; }
        public string codArticle {  get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image {  get; set; }
        public Brand Brand { get; set; }
        public Categories Categories { get; set; }
        public decimal Price { get; set; }
    }
}
