using System;

namespace AutoMapperCore
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("This is a Console Application targeting .NET Core 2.0");
        }
    }



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

    public class AddressDbo
    {
        public string  Address1 { get; set; }
        public string Address2  { get; set; }
        public string City      { get; set; }
        public string State     { get; set; }
        public string Zip       { get; set; } 

    }



    /// <summary>
    /// Sample Class used for testing the features of AutoMapper 
    /// </summary>
    public class PersonDto
    {
        public string FirstName     { get; set; }
        public string LastName      { get; set; }
        public int Age              { get; set; }
        public AddressDto Addresses { get; set; }


    }

    public class AddressDto
    {
        public string  Address1 { get; set; }
        public string Address2  { get; set; }
        public string City      { get; set; }
        public string State     { get; set; }
        public string Zip       { get; set; } 

    }
}
