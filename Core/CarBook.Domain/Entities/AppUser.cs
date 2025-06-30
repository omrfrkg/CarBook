namespace CarBook.Domain.Entities
{
    public class AppUser
    {
        public int AppUserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int AppUserRoleId { get; set; }
        public AppUserRole AppUserRole { get; set; }
    }
}
