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
    public partial class GyroscopePage : ContentPage
    {
        public GyroscopePage()
        {
            InitializeComponent();
            try
            {
                Gyroscope.ReadingChanged += ReadingChanged;
                Gyroscope.Start(SensorSpeed.UI);
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                lblMeasure.Text = fnsEx.Message;
            }
            catch (Exception ex)
            {
                lblMeasure.Text = ex.Message;
            }
            void ReadingChanged(Object sender, GyroscopeChangedEventArgs e)
            {
                var data = e.Reading;
                lblMeasure.Text = $"Reading: X: {data.AngularVelocity.X}, Y: {data.AngularVelocity.Y}, Z: {data.AngularVelocity.Z}";
            }
        }
    }
}