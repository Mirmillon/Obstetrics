using System.Windows.Forms.DataVisualization.Charting;

namespace Echographie.Graphes
{
    public class ChartAeraBase : ChartArea
    {
        public ChartAeraBase()
        {
            AlignmentOrientation = AreaAlignmentOrientations.Horizontal;

            Position.X = 0F;
            Position.Y = 5;
            Position.Width = 100F;
            Position.Height = 85;
            AlignmentStyle = AreaAlignmentStyles.PlotPosition | AreaAlignmentStyles.AxesView;
        }
    }
}
