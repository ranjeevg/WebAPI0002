namespace WebApi0002.Helpers_and_Enums;

public static class AppConstants
{
    // TODO: Convert these lists into DB-persisted data.
    
    /// <summary>
    /// Dummy data sources for the test APIs being called.
    /// </summary>
    public static class ApiLists
    {
        /// <summary>
        /// An array of preset language names.
        /// <br /><br />
        /// <i>
        /// (Chosen, TBH, because pure whimsy.)
        /// </i>
        /// </summary>
        public static string[] Languages =>
        [   
            "English", 
            "Tamil", 
            "Hindi", 
            "French", 
            "Spanish", 
            "Mandarin", 
            "Japanese", 
            "Punjabi", 
            "Urdu", 
            "Sinhala", 
            "Danish", 
            "Norwegian", 
            "Swedish", 
            "Finnish", 
            "Igbo",
            "Tagalog",
            "Dene",
            "Malayalam",
            "Russian",
            "Ukrainian",
            "Sanskrit"
        ];
        
        /// <summary>
        /// A dummy list of cities.
        /// </summary>
        public static string[] Cities =>
        [
            "Vancouver", 
            "Surrey", 
            "Toronto", 
            "Bangalore", 
            "Delhi", 
            "Madrid", 
            "Rome", 
            "Bern", 
            "Trondheim",
            "Calgary",
            "Edmonton",
            "Kamloops",
            "Chennai",
            "Montreal",
            "Hyderabad",
            "Udupi", 
            "Havana",
            "New York City",
            "Varanasi"
        ];
        
        /// <summary>
        /// A... whimsical... array of adjectives to describe the weather.
        /// </summary>
        public static string[] TemperatureDescriptions =>
        [
            "Solar",
            "Hot",
            "Humid",
            "Balmy",
            "Brisk",
            "Blistering",
            "Crisp",
            "Fresh",
            "Torrential rainfall",
            "Heatwave",
            "Icy",
            "Snowing",
            "Blizzard",
            "Hail",
            "Arctic winds",
            "Temperate",
            "Judeccan"
        ];
    }
    
    /// <summary>
    /// Miscellaneous values (table names and the like)
    /// </summary>
    public static class MiscConstants
    {
        /// <summary>
        /// 42. The answer to Life's Ultimate Question: what is six times nine?
        /// </summary>
        public static int TheAnswerToLifeTheUniverseAndEverything
            => 42;
    }
}