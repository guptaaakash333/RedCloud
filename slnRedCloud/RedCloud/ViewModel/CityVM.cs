namespace RedCloud.ViewModel
{
    public class CityVM
    {
        public int CityId { get; set; }
        public string Name { get; set; }

        public int StateId { get; set; }
        public virtual StateVM State { get; set; }
    }
}
