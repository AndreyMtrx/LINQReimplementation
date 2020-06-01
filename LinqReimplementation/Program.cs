using Bogus;
using System;
using System.Collections.Generic;

namespace LinqReimplementation
{
    public class Person
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            //Check behavior
            Faker<Person> generatorPerson = getGeneratorPerson();
            List<Person> persons = generatorPerson.Generate(100);


            IEnumerable<char> editedPersons = persons.SelectMany(x=>x.FullName);

            List<string> nameList = new List<string>() { "Pranaya", "Kumar" };
            IEnumerable<char> methodSyntax = nameList.SelectMany(x => x);

            foreach (var item in editedPersons)
            {
                Console.WriteLine(item + " ");
            }

            
            Console.ReadKey();
        }

        private static Faker<Person> getGeneratorPerson()
        {
            return new Faker<Person>("ru")
                .RuleFor(x => x.FullName, f => f.Name.FullName())
                .RuleFor(x => x.Age, f => f.Random.Byte(16, 100))
                .RuleFor(x => x.Phone, f => f.Phone.PhoneNumber());
        }

    }
}
