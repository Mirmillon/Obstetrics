using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Graphes
{
    public class SerieWeight : Series
    {
        public SerieWeight()
        {
            ChartType = SeriesChartType.Point;
            IsValueShownAsLabel = true;
            MarkerStyle = MarkerStyle.Triangle;
            MarkerSize = 10;
            Color = System.Drawing.Color.Red;
        }
    }
}
