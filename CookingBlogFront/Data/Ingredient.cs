namespace CookingBlogFront.Data
{
    public class Ingredient
    {
        public int id { get; set; }
        public string name { get; set; }
        public string unit { get; set; }
        public double amount { get; set; }
        public string image { get; set; }
        public double price { get; set; }
        public Measures measures { get; set; }
    }
}
