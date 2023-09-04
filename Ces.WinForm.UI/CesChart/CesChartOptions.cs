using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesChart
{
    public class CesChartOptions
    {
        public string? ChartTitle { get; set; } = "Chart title";
        public bool ChartTitleVisible { get; set; } = true;

        public IList<string>? Legend { get; set; } // SerieA, SerieB, ...
        public bool LegendVisible { get; set; } = true ;

        public bool CategoryVisible { get; set; } = true;
        public bool CategoryGridLineVisible{ get; set; } = false;

        public string? ScaleTitle { get; set; } // Price, Time, ...
        public bool ScaleVisible { get; set; } = true;
        public int Scale { get; set; } = 10; // 0, 10, 20, 30, ...

        public IList<CesChartData>? Data { get; set; }
    }

    public enum CesChartTypeEnum
    {        
        Column,       
    }

    public enum CesLegendPositionEnum
    {
        Top,
        Right,
        Bottom,
        Left,
    }

    public class CesChartData
    {
        public string? Serie { get; set; }
        public string? Category { get; set; }
        public long Value { get; set; }
    }

}
