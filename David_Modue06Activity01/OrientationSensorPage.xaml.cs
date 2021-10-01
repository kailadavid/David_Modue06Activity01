using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace David_Modue06Activity01
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OrientationSensorPage : ContentPage
    {
        public OrientationSensorPage()
        {
            InitializeComponent();
        }

        private void ButtonStart_Clicked_1(object sender, EventArgs e)
        {
            if (OrientationSensor.IsMonitoring)
                return;

            OrientationSensor.ReadingChanged += OrientationSensor_ReadingChanged;
            OrientationSensor.Start(SensorSpeed.UI);
        }

        private void OrientationSensor_ReadingChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            LabelX.Text = e.Reading.Orientation.X.ToString();
            LabelY.Text = e.Reading.Orientation.Y.ToString();
            LabelZ.Text = e.Reading.Orientation.Z.ToString();
        }

        private void ButtonStop_Clicked_1(object sender, EventArgs e)
        {
            if (OrientationSensor.IsMonitoring)
                return;

            OrientationSensor.ReadingChanged -= OrientationSensor_ReadingChanged;
            OrientationSensor.Stop();
        }
    }
}