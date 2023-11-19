namespace WEB.Models
{
    public class MenuModel
    {
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }
    public class MenuItem
    {
        public string Text { get; set; }
        public int ID { get; set; }
    }
}