using Calculator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CalculatorTecsup
{
    public partial class MainPage : ContentPage
    {
		int currentState = 1;
		string mathOperator;
		double firstNumber, secondNumber;

		public MainPage()
        {
            InitializeComponent();
			this.BindingContext = new ViewModels.ViewModelCalculator();
			//OnClear(this, null);
		}

	}
}
