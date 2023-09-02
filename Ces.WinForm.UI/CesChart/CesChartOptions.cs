using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesChart
{
    public class CesChartOptions
    {        
        public string? ChartTitle { get; set; }
        public bool ChartTitleVisible { get; set; }

        public IList<string>? Legend { get; set; } // SerieA, SerieB, ...
        public bool LegendVisible { get; set; }

        public string? YAxisTitle { get; set; } // Price
        public bool YAxisVisible { get; set; }
        public int YAxisScale { get; set; } = 10; // 0,10,20,30
        public bool YAxisLineVisible { get; set; }

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
