namespace CarBook.Domain.Entities
{
    public class AppUserRole
    {
        public int AppUserRoleId { get; set; }
        public string AppUserRoleName { get; set; }
        public List<AppUser> AppUsers { get; set; }
    }
}
