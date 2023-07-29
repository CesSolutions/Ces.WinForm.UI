using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ces.WinForm.UI.CesCalendar
{
    public partial class CesCalendar : UserControl
    {
        public CesCalendar()
        {
            InitializeComponent();

            _persianDayNameList.Add(DayOfWeek.Saturday, new PersinaDayName(1, "شنبه", "ش"));
            _persianDayNameList.Add(DayOfWeek.Sunday, new PersinaDayName(2, "یکشنبه", "ی"));
            _persianDayNameList.Add(DayOfWeek.Monday, new PersinaDayName(3, "دوشنبه", "د"));
            _persianDayNameList.Add(DayOfWeek.Tuesday, new PersinaDayName(4, "سه شنبه", "س"));
            _persianDayNameList.Add(DayOfWeek.Wednesday, new PersinaDayName(5, "چهارشنبه", "چ"));
            _persianDayNameList.Add(DayOfWeek.Thursday, new PersinaDayName(6, "پنجشنبه", "پ"));
            _persianDayNameList.Add(DayOfWeek.Friday, new PersinaDayName(7, "جمعه", "ج"));

            _persianMonthList.Add(1, new PersinaMonthName(1, "فروردین", "فر"));
            _persianMonthList.Add(2, new PersinaMonthName(2, "اردیبهشت", "ار"));
            _persianMonthList.Add(3, new PersinaMonthName(3, "خرداد", "خر"));
            _persianMonthList.Add(4, new PersinaMonthName(4, "تیر", "تی"));
            _persianMonthList.Add(5, new PersinaMonthName(5, "مرداد", "مر"));
            _persianMonthList.Add(6, new PersinaMonthName(6, "شهریور", "شه"));
            _persianMonthList.Add(7, new PersinaMonthName(7, "مهر", "مه"));
            _persianMonthList.Add(8, new PersinaMonthName(8, "آبان", "آب"));
            _persianMonthList.Add(9, new PersinaMonthName(9, "آذر", "آذ"));
            _persianMonthList.Add(10, new PersinaMonthName(10, "دی", "دی"));
            _persianMonthList.Add(11, new PersinaMonthName(11, "بهمن", "به"));
            _persianMonthList.Add(12, new PersinaMonthName(12, "اسفند", "اس"));
        }


        // Private Foelds and Proeprty


        private System.Globalization.PersianCalendar _persian = new System.Globalization.PersianCalendar();
        private Dictionary<System.DayOfWeek, PersinaDayName> _persianDayNameList = new Dictionary<System.DayOfWeek, PersinaDayName>();
        private Dictionary<int, PersinaMonthName> _persianMonthList = new Dictionary<int, PersinaMonthName>();

        int _year;
        int _month;
        int _day;
        int _firstDayIdOfWeek;
        string _firstDayNameOfWeek;
        int _dayIdOfWeek;
        string _dayNameOfWeek;
        string _monthName;
        int _daysInMonth;
        bool _isLeap;
        DateTime _dateOfFirstDay;


        // Public Property

        private DateTime cesValue { get; set; } = DateTime.Now;
        [System.ComponentModel.Category("CesCalendar")]
        public DateTime CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;
                InitialValues();
            }
        }


        private bool cesIsPersian { get; set; } = true;
        [System.ComponentModel.Category("CesCalendar")]
        public bool CesIsPersian
        {
            get { return cesIsPersian; }
            set
            {
                cesIsPersian = value;
                InitialValues();
            }
        }


        private bool cesShowWeekNumber { get; set; } = true;
        [System.ComponentModel.Category("CesCalendar")]
        public bool CesShowWeekNumber
        {
            get { return cesShowWeekNumber; }
            set
            {
                cesShowWeekNumber = value;
                this.pnlWeekNumber.Visible = value;
                SetWeekNumber();
            }
        }


        private Color cesWeekColor { get; set; } = Color.White;
        [System.ComponentModel.Category("CesCalendar")]
        public Color CesWeekColor
        {
            get { return cesWeekColor; }
            set
            {
                cesWeekColor = value;
                SetWeekNumber();
            }
        }


        private Color cesFridayForeColor { get; set; } = Color.Red;
        [System.ComponentModel.Category("CesCalendar")]
        public Color CesFridayForeColor
        {
            get { return cesFridayForeColor; }
            set
            {
                cesFridayForeColor = value;
                Redraw();
            }
        }


        private Color cesWeekLineColor { get; set; } = Color.FromArgb(224, 224, 224);
        [System.ComponentModel.Category("CesCalendar")]
        public Color CesWeekLineColor
        {
            get { return cesWeekLineColor; }
            set
            {
                clWeekNumber.CesLineColor = value;
            }
        }


        private Ces.WinForm.UI.CesButton.ColorTemplateEnum cesTodayColor { get; set; }
            = CesButton.ColorTemplateEnum.Orange;
        [System.ComponentModel.Category("CesCalendar")]
        public Ces.WinForm.UI.CesButton.ColorTemplateEnum CesTodayColor
        {
            get { return cesTodayColor; }
            set
            {
                cesTodayColor = value;
                Redraw();
            }
        }


        private Ces.WinForm.UI.CesButton.ColorTemplateEnum cesSelectColor { get; set; }
            = CesButton.ColorTemplateEnum.Blue;
        [System.ComponentModel.Category("CesCalendar")]
        public Ces.WinForm.UI.CesButton.ColorTemplateEnum CesSelectColor
        {
            get { return cesSelectColor; }
            set
            {
                cesSelectColor = value;
                Redraw();
            }
        }


        private bool cesUseBackColorForWeekNumber { get; set; } = true;
        [System.ComponentModel.Category("CesCalendar")]
        public bool CesUseBackColorForWeekNumber
        {
            get { return cesUseBackColorForWeekNumber; }
            set
            {
                cesUseBackColorForWeekNumber = value;
                Redraw();
            }
        }


        private bool cesMultiSelection { get; set; } = false;
        [System.ComponentModel.Category("CesCalendar")]
        public bool CesMultiSelection
        {
            get { return cesMultiSelection; }
            set
            {
                cesMultiSelection = value;
            }
        }


        private bool cesUseContraction { get; set; } = true;
        [System.ComponentModel.Category("CesCalendar")]
        public bool CesUseContraction
        {
            get { return cesUseContraction; }
            set
            {
                cesUseContraction = value;
                InitialValues();
            }
        }


        private void CesCalendar_Load(object sender, EventArgs e)
        {

        }

        private void InitialValues()
        {
            _year = _persian.GetYear(cesValue);
            _month = _persian.GetMonth(cesValue);
            _day = _persian.GetDayOfMonth(cesValue);
            _isLeap = _persian.IsLeapYear(_year);

            _monthName = _persianMonthList.FirstOrDefault(x =>
                x.Value.Id == _month).Value.Name;

            _dayIdOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(cesValue)).Value.Id;

            _dayNameOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(cesValue)).Value.Name;

            _daysInMonth = _persian.GetDaysInMonth(_year, _month);

            _dateOfFirstDay = _persian.ToDateTime(_year, _month, 1, 0, 0, 0, 0);

            _firstDayIdOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(_dateOfFirstDay)).Value.Id;

            _firstDayNameOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(_dateOfFirstDay)).Value.Name;

            this.lblYear.Text = _year.ToString();
            this.lblMonthName.Text = _monthName;

            Redraw();
        }

        private void Redraw()
        {
            this.btnGoToToday.BackColor = this.BackColor;

            SetDaysOfWeek();
            SetWeekNumber();
            SetDaysOfMonth();
        }

        private void SetDaysOfWeek()
        {
            this.flpCalendar.Controls.Clear();
            this.flpCalendar.BackColor = this.BackColor;

            if (cesIsPersian)
            {
                foreach (var item in _persianDayNameList.OrderBy(x => x.Value.Id))
                {
                    var dayName = new Ces.WinForm.UI.CesLabel();
                    dayName.Name = "lblDayOfWeek" + item.Value.Id;
                    dayName.Text = cesUseContraction ? item.Value.Contraction : item.Value.Name;
                    dayName.AutoSize = false;
                    dayName.Size = new Size(50, 40);
                    dayName.Margin = new System.Windows.Forms.Padding(all: 2);
                    dayName.ForeColor = this.ForeColor;
                    dayName.BackColor = this.BackColor;
                    dayName.TextAlign = ContentAlignment.MiddleCenter;

                    this.flpCalendar.Controls.Add(dayName);
                }
            }
        }

        private void SetWeekNumber()
        {
            this.flpWeekNumber.Controls.Clear();
            this.flpWeekNumber.BackColor = CesUseBackColorForWeekNumber ? this.BackColor : cesWeekColor;
            this.clWeekNumber.BackColor = CesUseBackColorForWeekNumber ? this.BackColor : cesWeekColor;

            if (!cesShowWeekNumber)
                return;


            // Add Week Number Title


            var weekTitle = new Ces.WinForm.UI.CesLabel();
            weekTitle.Name = "lblWeekNumberTitle";
            weekTitle.Text = string.Empty;
            weekTitle.AutoSize = false;
            weekTitle.Size = new Size(30, 40);
            weekTitle.Margin = new System.Windows.Forms.Padding(all: 2);
            weekTitle.TextAlign = ContentAlignment.MiddleCenter;
            weekTitle.BackColor = CesUseBackColorForWeekNumber ? this.BackColor : cesWeekColor;


            this.flpWeekNumber.Controls.Add(weekTitle);


            // Add Week Number


            for (int i = 1; i <= _daysInMonth; i++)
            {
                bool weekExist = false;

                var w =
                    _persian.GetWeekOfYear(
                        _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0),
                        System.Globalization.CalendarWeekRule.FirstDay,
                        DayOfWeek.Saturday);

                var week = new Ces.WinForm.UI.CesLabel();
                week.Name = "lblWeekNumber" + i.ToString();
                week.Text = w.ToString();
                week.AutoSize = false;
                week.Size = new Size(30, 40);
                week.Margin = new System.Windows.Forms.Padding(all: 2);
                week.TextAlign = ContentAlignment.MiddleCenter;
                week.ForeColor = this.ForeColor;
                week.BackColor = CesUseBackColorForWeekNumber ? this.BackColor : cesWeekColor;

                foreach (var item in this.flpWeekNumber.Controls)
                {
                    if (((Ces.WinForm.UI.CesLabel)item).Text == w.ToString())
                    {
                        weekExist = true;
                        break;
                    }
                }

                if (!weekExist)
                    this.flpWeekNumber.Controls.Add(week);
            }
        }

        private void SetDaysOfMonth()
        {

            // Create Days of previous month and tag value must be -1 as a signal
            // to show that this day is disabled
            for (int i = 1; i < _firstDayIdOfWeek; i++)
            {
                var day = new Ces.WinForm.UI.CesButton.CesButton();
                day.Name = "btnDayOnMonthDisabled" + i.ToString();
                day.Text = "";
                day.Enabled = false;
                day.AutoSize = false;
                day.Size = new Size(50, 40);
                day.Margin = new System.Windows.Forms.Padding(all: 2);
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.ForeColor = this.ForeColor;
                day.BackColor = this.BackColor;

                this.flpCalendar.Controls.Add(day);
            }


            // Create day of cesValue
            for (int i = 1; i <= _daysInMonth; i++)
            {
                var day = new Ces.WinForm.UI.CesButton.CesButton();
                day.Tag = "btnDayOnMonth" + i.ToString();
                day.Text = i.ToString(); ;
                day.AutoSize = false;
                day.Size = new Size(50, 40);
                day.Margin = new System.Windows.Forms.Padding(all: 2);
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.CesColorTemplate = cesSelectColor;
                day.ForeColor = ForeColor;
                day.CesColorTemplate = cesSelectColor;
                day.BackColor = this.BackColor;
                day.Cursor = Cursors.Hand;

                var date = _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0);

                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    day.ForeColor = cesFridayForeColor;
                    day.Font = new Font(new FontFamily(day.Font.FontFamily.Name), this.Font.Size, FontStyle.Bold);
                }

                if (i == _day)
                {
                    day.CesColorTemplate = cesTodayColor;
                }

                day.Tag = date.DayOfWeek;
                day.Click += new EventHandler(this.DayClicked);

                this.flpCalendar.Controls.Add(day);
            }
        }

        private void btnGoToToday_Click(object sender, EventArgs e)
        {
            CesValue = DateTime.Now;
        }

        private void btnNextYear_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddYears(_dateOfFirstDay, 1);
        }

        private void btnPreviousYear_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddYears(_dateOfFirstDay, -1);
        }

        private void CesCalendar_BackColorChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void CesCalendar_ForeColorChanged(object sender, EventArgs e)
        {
            Redraw();
        }

        private void pbNextMonth_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddMonths(_dateOfFirstDay, 1);
        }

        private void pbPreviousMonth_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddMonths(_dateOfFirstDay, -1);
        }

        private void DayClicked(object sender, EventArgs e)
        {
            if (!cesMultiSelection)
            {
                foreach (var item in this.flpCalendar.Controls)
                {
                    if (item.GetType() == typeof(Ces.WinForm.UI.CesButton.CesButton))
                    {
                        var current = (Ces.WinForm.UI.CesButton.CesButton)item;

                        current.CesColorTemplate = cesSelectColor;
                        current.BackColor = this.BackColor;

                        if (current.Tag is not null && (System.DayOfWeek)current.Tag == DayOfWeek.Friday)
                        {
                            current.ForeColor = cesFridayForeColor;
                            current.Font = new Font(new FontFamily(current.Font.FontFamily.Name), this.Font.Size, FontStyle.Bold);
                        }

                        if (current.Text == _day.ToString())
                        {
                            current.CesColorTemplate = cesTodayColor;
                        }
                    }
                }
            }

            var ctr = (Ces.WinForm.UI.CesButton.CesButton)sender;
            ctr.CesColorTemplate = cesSelectColor;
        }
    }

    internal class PersinaDayName
    {
        public PersinaDayName(int id, string name, string contraction)
        {
            Id = id;
            Name = name;
            Contraction = contraction;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contraction { get; set; }
    }

    internal class PersinaMonthName
    {
        public PersinaMonthName(int id, string name, string contraction)
        {
            Id = id;
            Name = name;
            Contraction = contraction;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Contraction { get; set; }
    }
}
