using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace repo1
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private double height = 180;
        private double weight = 72;
        private const double STEP = 1.0;

        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                UpdateResults();
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                UpdateResults();
            }
        }
        public double Bmi
            => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);

        public string Classification
        {
            get
            {
                if (Bmi < 18.5)
                    return "Masz niedowage";
                else if (Bmi < 25)
                    return "Masz optymalną wage";
                else if (Bmi < 30)
                    return "Masz nadwage";
                else
                    return "Masz otyłość";
            }
        }
        private void UpdateResults()
        {
            RaisePropertyChanged(nameof(Bmi));
            RaisePropertyChanged(nameof(Classification));
        }

        private double NextStep(double value)
        {
            return Math.Round(value / STEP) * STEP;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
