using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Graphes
{
    class SerieCroissance : Series
    {
        public SerieCroissance()
        {             
            ChartType = SeriesChartType.Line;
            BorderWidth = 2;
        }   
    }
}
