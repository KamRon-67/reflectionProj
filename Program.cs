using System;
using System.Reflection;
using System.Linq;

namespace reflectionProj
{
	public class Program
	{
		public static void Main()
		{
			Type personType = typeof(Person);

			var properties = personType.GetProperties();
			foreach (var item in properties)
			{
				Console.WriteLine($"Property: Type: {item.PropertyType.Name} | Name: {item.Name}");
			}

			Person person = new Person();

			var methods = personType.GetMethods();
			foreach (var item in methods)
			{
				Console.WriteLine($"Method: Type: {item.ReturnType.Name} | Name {item.Name}");
				if (item.Name == "Print")
				{
					item.Invoke(person, null);
				}
			}
			Console.WriteLine("-------------------------------");
			AttributeTest(typeof(Person));

			Console.ReadKey();
		}

		public class Person
		{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Phone { get; set; }
			public int ZipCode { get; set; }

			[RunMethod(Count = 3)]
			public void Print()
			{
				Console.WriteLine($"{FirstName} {LastName}");
			}

			[RunMethod(Count = 3)]
			public void TestMethod()
			{
				Console.WriteLine("Hello from TestMethod");
			}

			public void Move(int newZipCode)
			{
				ZipCode = newZipCode;
				Console.WriteLine($"{FirstName} {LastName} has been moved to {newZipCode}");
			}

			[RunMethod(Count = 1)]
			public void SayHi()
			{
				Console.WriteLine($"Hi {FirstName}");
			}
		}


		static void AttributeTest(Type type)
		{
			// Get the methods
			var allMethods = type.GetMethods();
			var methodsWithAttribute = allMethods.Where(m => m.GetCustomAttribute(typeof(RunMethodAttribute)) != null);

			var obj = Activator.CreateInstance(type);

			foreach (var item in methodsWithAttribute)
			{
				var attribute = (RunMethodAttribute)item.GetCustomAttribute(typeof(RunMethodAttribute));
				Console.WriteLine($"{item.Name} run for {attribute.Count} times");
				for (int i = 0; i < attribute.Count; i++)
				{
					item.Invoke(obj, null);
				}
			}
		}

		public class RunMethodAttribute : Attribute
		{
			public int Count { get; set; }
		}
	}
}
