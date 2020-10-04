namespace WhereToEat.Models
{
    public class FoodTruck
    {
        public string objectid { get; set; }
        public string applicant { get; set; }
        public string facilitytype { get; set; }
        public string locationdescription { get; set; }
        public string address { get; set; }
        public string blocklot { get; set; }
        public string block { get; set; }
        public string lot { get; set; }
        public string status { get; set; }
        public string fooditems { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string schedule { get; set; }
        public string dayshours { get; set; }
        public Location location { get; set; }
    }

    public class Location
    {
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string human_address { get; set; }
    }

}

