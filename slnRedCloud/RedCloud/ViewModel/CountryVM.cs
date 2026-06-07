namespace RedCloud.ViewModel
{
    public class CountryVM
    {
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<StateVM> States { get; set; } = new List<StateVM>();

    }
}
