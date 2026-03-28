using System;
using System.ComponentModel;

namespace Capa_AccesoDatos.Entidades
{
    public class Informe : INotifyPropertyChanged
    {
        private int _idInforme;
        private string _tipoInforme;
        private string _ordenadoPor;
        private string _visualizadoEn;
        private DateTime _fechaInicial;
        private DateTime _fechaFinal;
        private DateTime _fechaGeneracion;

        public int IdInforme
        {
            get => _idInforme;
            set { if (_idInforme != value) { _idInforme = value; OnPropertyChanged(nameof(IdInforme)); } }
        }

        public string TipoInforme
        {
            get => _tipoInforme;
            set { if (_tipoInforme != value) { _tipoInforme = value; OnPropertyChanged(nameof(TipoInforme)); } }
        }

        public string OrdenadoPor
        {
            get => _ordenadoPor;
            set { if (_ordenadoPor != value) { _ordenadoPor = value; OnPropertyChanged(nameof(OrdenadoPor)); } }
        }

        public string VisualizadoEn
        {
            get => _visualizadoEn;
            set { if (_visualizadoEn != value) { _visualizadoEn = value; OnPropertyChanged(nameof(VisualizadoEn)); } }
        }

        public DateTime FechaInicial
        {
            get => _fechaInicial;
            set { if (_fechaInicial != value) { _fechaInicial = value; OnPropertyChanged(nameof(FechaInicial)); } }
        }

        public DateTime FechaFinal
        {
            get => _fechaFinal;
            set { if (_fechaFinal != value) { _fechaFinal = value; OnPropertyChanged(nameof(FechaFinal)); } }
        }

        public DateTime FechaGeneracion
        {
            get => _fechaGeneracion;
            set { if (_fechaGeneracion != value) { _fechaGeneracion = value; OnPropertyChanged(nameof(FechaGeneracion)); } }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
