using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WpfIntro2.Base;
using WpfIntro2.Models;
using WpfIntro2.Services;
using WpfIntro2.ViewModels;

namespace WpfIntro2
{
	public class MainWindowViewModel : NotificationObject
	{
		private ObservableCollection<EmployeeViewModel> _employees = new ObservableCollection<EmployeeViewModel>();
		public ObservableCollection<EmployeeViewModel> Employees
		{
			get { return _employees; }
			set
			{
				_employees = value;
				RaisePropertyChanged();
			}
		}

		private EmployeeViewModel _selectedEmployee;
		public EmployeeViewModel SelectedEmployee
		{
			get { return _selectedEmployee; }
			set
			{
				_selectedEmployee = value;
				RaisePropertyChanged();
			}
		}

		private bool _isLoading;
		public bool IsLoading
		{
			get { return _isLoading; }
			set
			{
				_isLoading = value;
				RaisePropertyChanged();
				LoadCommand.RaiseCanExecuteChanged();
			}
		}

		private BasicCommand _loadCommand;

		public BasicCommand LoadCommand
		{
			get { return _loadCommand ?? (_loadCommand = new BasicCommand(OnLoad, CanLoad)); }
		}

		private BasicCommand _newEmployeeCommand;

		public BasicCommand NewEmployeeCommand
		{
			get { return _newEmployeeCommand ?? (_newEmployeeCommand = new BasicCommand(OnNewEmployee)); }
		}

		private void OnLoad(object _)
		{
			IsLoading = true;

			Task<List<Employee>>.Factory.StartNew(
				() =>
				{
					return EmployeeService.GetEmployees();
				},
				TaskCreationOptions.LongRunning)
			.ContinueWith(
				task =>
				{
					foreach (var employee in task.Result)
					{
						Employees.Add(EmployeeViewModel.FromEmployee(employee));
					}
					IsLoading = false;
				}, TaskScheduler.FromCurrentSynchronizationContext());
		}

		private bool CanLoad(object _)
		{
			return !IsLoading;
		}

		private void OnNewEmployee(object _)
		{
			var employee = new EmployeeViewModel { Id = Employees.Count > 0 ? Employees.Max(e => e.Id) + 1 : 1 };
			Employees.Add(employee);
			SelectedEmployee = employee;
		}
	}
}
