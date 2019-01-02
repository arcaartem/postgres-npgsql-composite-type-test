namespace composite_type_test
{
    public class PlaceName
    {
        public Language Language { get; set; }
        public string Name { get; set; }

        public override string ToString() => $"({Language}) - {Name}";
    }
}