
namespace Blog.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Emai { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }
    }
}