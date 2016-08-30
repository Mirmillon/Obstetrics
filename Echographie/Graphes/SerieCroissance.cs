using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Graphes
{
    public class SerieCroissance : Series
    {
        public SerieCroissance()
        {             
            ChartType = SeriesChartType.Line;
            Color = System.Drawing.Color.Blue;
            BorderWidth = 2;
        }   
    }
}
