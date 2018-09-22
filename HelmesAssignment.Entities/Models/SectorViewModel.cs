namespace HelmesAssignment.Entities.Models
{
    public class SectorViewModel
    {

        public int Deep { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }

        public SectorViewModel(Sector sector, int deep)
        {
            Id = sector.ID;
            Name = sector.Name;
            Deep = deep;
        }
    }
}