using System;
using System.Text;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Calculator;

namespace CalculatorTecsup.ViewModels
{
    public class ViewModelCalculator : ViewModelBase
    {

        int currentState = 1;
        string mathOperator;

        string result;

        public string Result
        {
            get { return result; }
            set
            {
                if (result != value)
                {
                    result = value;
                    OnPropertyChanged();
                }
            }

        }

        double firstNumber;

        public double FirstNumber
        {
            get { return firstNumber; }
            set
            {
                if (firstNumber != value)
                {
                    firstNumber = value;
                    OnPropertyChanged();
                }
            }

        }

        double secondNumber;

        public double SecondNumber
        {
            get { return secondNumber; }
            set
            {
                if (secondNumber != value)
                {
                    secondNumber = value;
                    OnPropertyChanged();
                }
            }

        }


        string operation;
        public string Operation
        {
            get { return operation; }
            set
            {
                if (operation != value)
                {
                    operation = value;
                    OnPropertyChanged();
                }
            }
        }

        #region Comandos

        public ICommand OnSelectNumber { protected set; get; }
        public ICommand OnSelectOperator { protected set; get; }
        public ICommand OnClear { protected set; get; }
        public ICommand OnCalculate { protected set; get; }
        #endregion

        public ViewModelCalculator()
        {
            OnSelectNumber = new Command<string>(
                execute: (string parameter) =>
             {
                 string pressed = parameter;

                 if (Result == "0" || currentState < 0)
                 {
                     Result = "";
                     if (currentState < 0)
                         currentState *= -1;
                 }

                 Result += pressed;

                 double number;
                 if (double.TryParse(Result, out number))
                 {
                     Result = number.ToString("N0");
                     if (currentState == 1)
                     {
                         firstNumber = number;
                     }
                     else
                     {
                         secondNumber = number;
                     }
                 }
             });

            OnSelectOperator = new Command<string>(
                execute: (string parameter) =>
                {
                    currentState = -2;
                    string pressed = parameter;
                    mathOperator = pressed;
                });

            OnCalculate = new Command<string>(
                execute: (string parameter) =>
                {
                    if (currentState == 2)
                    {
                        var result = SimpleCalculator.Calculate(firstNumber, secondNumber, mathOperator);

                        Result = result.ToString();
                        firstNumber = result;
                        currentState = -1;
                    }
                });

            OnClear = new Command(() =>
            {
                firstNumber = 0;
                secondNumber = 0;
                currentState = 1;
                Result = "0";
            });
        }
    }
}
