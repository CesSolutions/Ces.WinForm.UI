using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.CesGauge
{
    public class CesGaugeOptions
    {
        public Color SegmentColor { get; set; } = Color.Gray;
        public float Percent { get; set; } = 100;
        public string? Title { get; set; }
    }

    public class CesGaugeRcord
    {
        public DateTime RecoerdDateTime { get; set; }
        public float RecordValue { get; set; }
    }

    public enum CesGaugeTypeEnum
    {
        Type1,
        Type2,
        Type3,
    }

    public enum CesIndicatorTypeEnum
    {
        Type1,
        Type2,
        Type3,
    }
}
