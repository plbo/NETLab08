using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Threading;
using WpfIntro2.Models;

namespace WpfIntro2.Services
{
	public static class EmployeeService
	{
		public static List<Employee> GetEmployees()
		{
			Thread.Sleep(TimeSpan.FromSeconds(3));
			List<Employee> result;
			var serializer = new DataContractJsonSerializer(typeof(Employee[]));
			using (StreamReader reader = File.OpenText(@"Data\employees.json"))
			{
				result = ((Employee[])serializer.ReadObject(reader.BaseStream)).ToList();
			}
			Thread.Sleep(TimeSpan.FromSeconds(3));
			return result;
		}
	}
}
