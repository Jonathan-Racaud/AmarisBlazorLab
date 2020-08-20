namespace AmarisBlazorLab.Core.Domain
{
    public class UserProject
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
