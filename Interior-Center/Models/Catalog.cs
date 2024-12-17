namespace Interior_Center.Models
{
    public class Catalog
    {
        int Id { get; set; }
        public string Name { get; set; }
        public string Short { get; set; }

        public string Long { get; set; }

        public int Price { get; set; }
        public int Type {  get; set; }

        public string Image { get; set; }

        public int Quantity { get; set; }

    }
}
