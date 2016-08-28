using System;
using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Graphes
{
    class ChartAreaPartogrammeBase : ChartAeraBase
    {
        public ChartAreaPartogrammeBase()
        {
            AxisX.Enabled = AxisEnabled.False;

            AxisX.MajorTickMark.Enabled = false;
            AxisX.MajorGrid.Enabled = false;

            AxisX.IntervalType = DateTimeIntervalType.Hours;
            AxisX.Interval = 1;

            AxisX.RoundAxisValues();

            DateTime thisDay = DateTime.Now;
            AxisX.Minimum = thisDay.AddMinutes(-thisDay.Minute).ToOADate();
            int decalage = 60 - -thisDay.Minute;
            //PARAMETER Pouvoir changer la valeur de AddHours 
            AxisX.Maximum = thisDay.AddHours(12).AddMinutes(-thisDay.Minute).ToOADate();
            AxisX.Crossing = this.AxisX.Minimum;
        }
    }
}
