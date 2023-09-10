using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesChart
{
    //public class CesChartOptions
    //{
    //    public string? ChartTitle { get; set; } = "Chart title";
    //    public bool ChartTitleVisible { get; set; } = true;

    //    public IList<string>? Legend { get; set; } // SerieA, SerieB, ...
    //    public bool LegendVisible { get; set; } = true;

    //    public bool CategoryVisible { get; set; } = true;
    //    public bool CategoryGridLineVisible { get; set; } = false;

    //    public string? ScaleTitle { get; set; } // Price, Time, ...
    //    public bool ScaleVisible { get; set; } = true;
    //    public int Scale { get; set; } = 10; // 0, 10, 20, 30, ...

    //    public IList<CesChartData>? Data { get; set; }
    //}

    public enum CesChartTypeEnum
    {
        Column,
        Area,
    }

    public class CesChartData
    {
        public CesChartSerie? Serie { get; set; }
        public string? Category { get; set; }
        public decimal Value { get; set; }
    }

    public class CesChartSerie
    {
        public string? Name { get; set; }
        public Color SeriColor { get; set; }
        public Color AreaColor { get; set; }
        public CesChartTypeEnum Type { get; set; } = CesChartTypeEnum.Column;
    }

    internal class CesChartCategory
    {
        public string? Name { get; set; }
        public decimal SumValue { get; set; } = 0;
        public decimal Percent { get; set; } = 0;
        public int Order { get; set; } = 0;
    }
}
