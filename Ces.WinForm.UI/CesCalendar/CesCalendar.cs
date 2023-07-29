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

        private DateTime cesValue { get; set; } = DateTime.Now;
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
        public bool CesIsPersian
        {
            get { return cesIsPersian; }
            set
            {
                cesIsPersian = value;
                InitialValues();
            }
        }


        private bool cesUseContraction { get; set; } = true;
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
            this.flpCalendar.BackColor = Color.White;

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

            SetDaysOfWeek();
            SetDaysOfMonth();
        }

        private void SetDaysOfWeek()
        {
            this.flpWeekNumber.Controls.Clear();
            this.flpCalendar.Controls.Clear();

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
                    dayName.BackColor = this.flpCalendar.BackColor;
                    dayName.TextAlign = ContentAlignment.MiddleCenter;

                    this.flpCalendar.Controls.Add(dayName);
                }
            }
        }

        private void SetDaysOfMonth()
        {

            var weekTitle = new Ces.WinForm.UI.CesButton.CesButton();
            weekTitle.Name = "btnWeekNumberTitle";
            weekTitle.Text = string.Empty;
            weekTitle.AutoSize = false;
            weekTitle.Size = new Size(30, 40);
            weekTitle.Margin = new System.Windows.Forms.Padding(all: 2);
            weekTitle.TextAlign = ContentAlignment.MiddleCenter;
            weekTitle.BackColor = this.flpCalendar.BackColor; //.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;
            this.flpWeekNumber.Controls.Add(weekTitle);

            for (int i = 1; i <= _daysInMonth; i++)
            {
                bool weekExist = false;

                var w =
                    _persian.GetWeekOfYear(
                        _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0),
                        System.Globalization.CalendarWeekRule.FirstDay,
                        DayOfWeek.Saturday);

                var week = new Ces.WinForm.UI.CesButton.CesButton();
                week.Name = "btnWeekNumber" + i.ToString();
                week.Text = w.ToString();
                week.AutoSize = false;
                week.Size = new Size(30, 40);
                week.Margin = new System.Windows.Forms.Padding(all: 2);
                week.TextAlign = ContentAlignment.MiddleCenter;
                week.BackColor = this.flpCalendar.BackColor; //.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;

                foreach (var item in this.flpWeekNumber.Controls)
                {
                    if (((Ces.WinForm.UI.CesButton.CesButton)item).Text == w.ToString())
                    {
                        weekExist = true;
                        break;
                    }
                }

                if (!weekExist)
                    this.flpWeekNumber.Controls.Add(week);
            }

            // Create Days of previous month and tag value must be -1 as a signal
            // to show that this day is disabled
            for (int i = 1; i < _firstDayIdOfWeek; i++)
            {
                var day = new Ces.WinForm.UI.CesButton.CesButton();
                day.Name = "btnDayOnMonthDisabled" + i.ToString();
                day.Tag = "-1";
                day.Text = "";
                day.AutoSize = false;
                day.Size = new Size(50, 40);
                day.Margin = new System.Windows.Forms.Padding(all: 2);
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.BackColor = this.flpCalendar.BackColor; //.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;

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
                day.CesColorTemplate = CesButton.ColorTemplateEnum.Blue;
                day.BackColor = Color.White;

                var date = _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0);

                if (i == _day)
                {
                    day.CesColorTemplate = CesButton.ColorTemplateEnum.Orange;
                }

                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    //day.CesColorTemplate = CesButton.ColorTemplateEnum.Red;
                    day.ForeColor = Color.Red;
                    day.Font = new Font(new FontFamily(day.Font.FontFamily.Name), this.Font.Size, FontStyle.Bold);
                }

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

        private void btnNextMonth_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddMonths(_dateOfFirstDay, 1);
        }

        private void btnPreviousMonth_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddMonths(_dateOfFirstDay, -1);
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
