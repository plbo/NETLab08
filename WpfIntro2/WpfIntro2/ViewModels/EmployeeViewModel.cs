using WpfIntro2.Base;
using WpfIntro2.Models;

namespace WpfIntro2.ViewModels
{
	public class EmployeeViewModel : ValidationObject
	{
		public static EmployeeViewModel FromEmployee(Employee employee)
		{
			return new EmployeeViewModel
			{
				_id = employee.Id,
				_name = employee.Name,
				_age = employee.Age,
				_salary = employee.Salary,
				_isHired = employee.IsHired
			};
		}

		public EmployeeViewModel()
		{
			Validators.Add("Name", p => string.IsNullOrWhiteSpace(Name) ? "Nazwisko nie może być puste" : null);
			Validators.Add("Age", p => (Age < 0 || Age > 150) ? "Wiek musi być w zakresie 0-150 lat" : null);
			Validators.Add("Salary", p => Salary < 0 ? "Pensja nie może być ujemna" : null);
		}

		private int _id;

		public int Id
		{
			get { return _id; }
			set
			{
				_id = value;
				RaisePropertyChanged();
				RaiseErrorsChanged();
			}
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set
			{
				_name = value;
				RaisePropertyChanged();
				RaiseErrorsChanged();
			}
		}

		private int _age;

		public int Age
		{
			get { return _age; }
			set
			{
				_age = value;
				RaisePropertyChanged();
				RaiseErrorsChanged();
			}
		}

		private decimal _salary;

		public decimal Salary
		{
			get { return _salary; }
			set
			{
				_salary = value;
				RaisePropertyChanged();
				RaiseErrorsChanged();
			}
		}

		private bool _isHired;

		public bool IsHired
		{
			get { return _isHired; }
			set
			{
				_isHired = value;
				RaisePropertyChanged();
				RaiseErrorsChanged();
			}
		}
	}
}
