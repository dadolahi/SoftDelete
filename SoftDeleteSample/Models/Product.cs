namespace SoftDeleteSample.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Title { set; get; }
        public decimal Price { set; get; }
        public bool IsDeleted { set; get; }
    }
}
