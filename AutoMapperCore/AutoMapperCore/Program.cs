using System;
using AutoMapper;

namespace AutoMapperCore
{
    internal class Program
    {
        private static void Main(string[] args) 
        {
            Console.WriteLine("This is a Console Application targeting .NET Core 2.0");

            
            RunStaticMapper();

            RunInstanceMapper();

            Console.ReadLine();
        }

        private static void RunStaticMapper()   
        {
            // Static
            Mapper.Initialize(cfg => {

                //cfg.AddProfile<AppProfile>();

                cfg.CreateMap<PersonDbo, PersonDto>();
                cfg.CreateMap<PersonDto, PersonDbo>();


            });

            var dest1 = Mapper.Map<PersonDbo, PersonDto>(new PersonDbo { FirstName = "Sean", LastName = "Lemster", Addresses = new AddressDbo { Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052" } });
            var dest2 = Mapper.Map<PersonDto, PersonDbo>(new PersonDto { FirstName = "Sean", LastName = "Lemster", Addresses = new AddressDto { Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052" } });


            Console.WriteLine(dest1.FirstName);
            Console.WriteLine(dest2.FirstName);
        }

        private static void RunInstanceMapper() 
        {
            // Instance
            var config = new MapperConfiguration(cfg => {

                //cfg.AddProfile<AppProfile>();

                cfg.CreateMap<PersonDbo, PersonDto>();
                cfg.CreateMap<PersonDto, PersonDbo>();

            });


            var mapper2 = config.CreateMapper();    // or   var mapper2 = new Mapper(config);


            var dest3 = mapper2.Map<PersonDbo, PersonDto>(new PersonDbo { FirstName = "Kristine", LastName = "Lemster", Addresses = new AddressDbo { Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052" } });
            var dest4 = mapper2.Map<PersonDto, PersonDbo>(new PersonDto { FirstName = "Kristine", LastName = "Lemster", Addresses = new AddressDto { Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052" } });


            Console.WriteLine(dest3.FirstName);
            Console.WriteLine(dest4.FirstName);
        }
    }
}
