using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Lab6App1
{
    enum Precipitation
    {
        sunny,
        cloudy,
        rain,
        snow
    }
    internal class WeatherControl : DependencyObject
    {
        private string directionwind;
        private int speedwind;
        private Precipitation precipitation;

        public WeatherControl(string Dirwind, int Spwind, Precipitation precipitation)
        {
            this.Directionwind = Dirwind;
            this.Speedwind = Spwind;
            this.precipitation = precipitation;
        }

        public static readonly DependencyProperty TemperatureProperty;
        public string Directionwind
        {
            get => directionwind;
            set => directionwind = value;
        }
        public int Speedwind
        {
            get => speedwind;
            set => speedwind = value;
        }
        public int Temperature
        {
            get => (int)GetValue(TemperatureProperty);
            set => SetValue(TemperatureProperty, value);
        }

        static WeatherControl()
        {
            TemperatureProperty = DependencyProperty.Register(
                nameof(Temperature),
                typeof(int),
                typeof(WeatherControl),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                    null,
                    new CoerceValueCallback(CoerceTemperature)),
                new ValidateValueCallback(ValidateTemperature));
        }

        private static bool ValidateTemperature(object value)
        {
            int t = (int) value;
            if (t >= -50 && t <= 50)
                return true;
            else
                return false; 
        }

        private static object CoerceTemperature(DependencyObject d, object basevalue)
        {
            int t = (int) basevalue;
            if (t >=  -50 && t <= 50)
                return t;
            else
            return (string)"Значение не верное";
        }
    }
}
