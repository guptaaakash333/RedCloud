namespace RedCloud.ViewModel
{
    public class StateVM
    {
        public int StateId { get; set; }
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual CountryVM Countries { get; set; }

        public virtual ICollection<CityVM> Cities { get; set; } = new List<CityVM>();

    }
}
