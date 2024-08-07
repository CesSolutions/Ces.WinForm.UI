﻿namespace Ces.WinForm.UI.CesGauge
{
    public class CesGaugeOptions
    {
        public Color SegmentColor { get; set; } = Color.Gray;
        public float Percent { get; set; } = 100;
        public string? Title { get; set; }
    }

    public class CesGaugeRecord
    {
        public DateTime RecordDateTime { get; set; }
        public float RecordValue { get; set; }
    }

    public enum CesGaugeIndicatorTypeEnum
    {
        Type1,
        Type2,
        Type3,
    }

    public enum CesGaugeImageLocationEnum
    {
        Top,
        Bottom,
        Left,
        Right,
    }
}
