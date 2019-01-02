using System;
using System.Collections.Generic;

namespace composite_type_test
{
    public class Place
    {
        public Guid Id { get; set; }
        public List<PlaceName> Names { get; set; }
        public string TelCode { get; set; }

        public override string ToString() => $"Place(id: {Id}, names: \"{string.Join("", "", Names)}\", tel_code: {TelCode})";
    }
}