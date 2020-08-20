namespace AmarisBlazorLab.Core.Domain
{
    public class Material
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Source { get; set; }
        public MaterialType MaterialType { get; set; }
        public Project Project { get; set; }
    }
}
