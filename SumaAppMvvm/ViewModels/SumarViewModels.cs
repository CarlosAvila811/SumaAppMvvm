using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace SumaAppMvvm.ViewModels
{
    public class SumarViewModel : INotifyPropertyChanged
    {
        private string _valor1;
        private string _valor2;
        private string _resultado;

        public string Valor1
        {
            get => _valor1;
            set
            {
                _valor1 = value;
                OnPropertyChanged();
            }
        }

        public string Valor2
        {
            get => _valor2;
            set
            {
                _valor2 = value;
                OnPropertyChanged();
            }
        }

        public string Resultado
        {
            get => _resultado;
            set
            {
                _resultado = value;
                OnPropertyChanged();
            }
        }

        public ICommand SumarCommand { get; }
        public ICommand LimpiarCommand { get; }

        public SumarViewModel()
        {
            SumarCommand = new Command(Sumar);
            LimpiarCommand = new Command(Limpiar);
        }

        private void Sumar()
        {
            if (double.TryParse(Valor1, out double num1) && double.TryParse(Valor2, out double num2))
            {
                Resultado = $"Resultado: {num1 + num2}";
            }
            else
            {
                Resultado = "Error: Ingrese valores válidos.";
            }
        }

        private void Limpiar()
        {
            Valor1 = string.Empty;
            Valor2 = string.Empty;
            Resultado = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
