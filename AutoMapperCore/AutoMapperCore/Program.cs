using System;
using AutoMapper;
using Newtonsoft.Json;

namespace AutoMapperCore
{
    internal class Program
    {
        private static void Main(string[] args) 
        {
            Console.WriteLine("This is a Console Application targeting .NET Core 2.0");

            
            RunStaticMapper();

            RunInstanceMapper();


            var retval = Serialize(PersonDtoInit());
            DeSerialize(retval);

            Console.ReadLine();
        }

        /// <summary>
        /// Run AutoMapper as Static
        /// </summary>
        private static void RunStaticMapper()           
        {
            // Static
            Mapper.Initialize(cfg => {

                //cfg.AddProfile<AppProfile>();

                cfg.CreateMap<PersonDbo, PersonDto>();
                cfg.CreateMap<PersonDto, PersonDbo>();


            });

            var dto = Mapper.Map<PersonDbo, PersonDto>(PersonDboInit());
            var dbo = Mapper.Map<PersonDto, PersonDbo>(PersonDtoInit());

            
            Console.WriteLine(JsonConvert.SerializeObject(dto));
            Console.WriteLine(JsonConvert.SerializeObject(dbo));
        }

        /// <summary>
        /// Run AutoMapper as Instance
        /// </summary>
        private static void RunInstanceMapper()         
        {
            // Instance
            var config = new MapperConfiguration(cfg => {

                //cfg.AddProfile<AppProfile>();

                cfg.CreateMap<PersonDbo, PersonDto>();
                cfg.CreateMap<PersonDto, PersonDbo>();

            });


            var mapper = config.CreateMapper();    // or   var mapper2 = new Mapper(config);


            var dto = mapper.Map<PersonDbo, PersonDto>(PersonDboInit());
            var dbo = mapper.Map<PersonDto, PersonDbo>(PersonDtoInit());


            Console.WriteLine(JsonConvert.SerializeObject(dto));
            Console.WriteLine(JsonConvert.SerializeObject(dbo));
        }





        private static PersonDto PersonDtoInit()        
        {
            var retobj = new PersonDto
            {
                FirstName = "Sean",
                LastName  = "Lemster",
                Age       = 18,
                Addresses = new AddressDto {Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052"}
            };

            return retobj;
        }

        private static PersonDbo PersonDboInit()        
        {
            var retobj = new PersonDbo
            {
                FirstName = "Sean",
                LastName = "Lemster",
                Age = 18,
                Addresses = new AddressDbo { Address1 = "", Address2 = "", City = "Redmond", State = "WA", Zip = "98052" }
            };

            return retobj;
        }

        private static string Serialize(PersonDto dto)  
        {
            var s = JsonConvert.SerializeObject(dto);
            return s;
        }

        private static void DeSerialize(string json)    
        {
            var dto = JsonConvert.DeserializeObject<PersonDto>(json);
            Console.WriteLine(dto.FirstName);
        }
    }
}
