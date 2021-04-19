using System;

namespace reflectionProj
{
     class Program
    {
        static void Main(string[] args)
		{
			Type personType = typeof(Person);

			var properties = personType.GetProperties();
			foreach (var item in properties)
			{
				Console.WriteLine($"Property: Type: {item.PropertyType.Name} | Name: {item.Name}");
			}

			var methods = personType.GetMethods();
			foreach (var item in methods)
			{
				Console.WriteLine($"Method: Type: {item.ReturnType.Name} | Name {item.Name}");
			}

			Console.ReadKey();
		}

		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Phone { get; set; }
			public int ZipCode { get; set; }

			public void Print()
			{
				Console.WriteLine($"{FirstName} {LastName}");
			}

			public void Move(int newZipCode)
			{
				ZipCode = newZipCode;
				Console.WriteLine($"{FirstName} {LastName} has been moved to {newZipCode}");
			}
		}
	}
}
