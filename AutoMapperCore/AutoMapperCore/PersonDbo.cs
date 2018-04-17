namespace AutoMapperCore
{
    /// <summary>
    /// Sample Class used for testing the features of AutoMapper 
    /// </summary>
    public class PersonDbo
    {
        public string FirstName     { get; set; }
        public string LastName      { get; set; }
        public int Age              { get; set; }
        public AddressDbo Addresses { get; set; }
        
    }
}