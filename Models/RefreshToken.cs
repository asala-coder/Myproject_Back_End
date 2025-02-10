namespace MyProject.Models
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string? Token { get; set; }
        public int UserId { get; set; }
        public DateTime ExpiryDate { get; set; }

        public User? User { get; set; }
        public string? Role { get; set; } // إضافة صلاحية
        
    }
}