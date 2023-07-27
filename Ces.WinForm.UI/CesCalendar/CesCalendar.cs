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
            _persianDayNameList.Add(DayOfWeek.Friday, new PersinaDayName(7, "جمعه", "جم"));

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
            _year = _persian.GetYear(cesValue);
            _month = _persian.GetMonth(cesValue);
            _day = _persian.GetDayOfMonth(cesValue);
            _monthName = _persianMonthList.FirstOrDefault(x => 
                x.Value.Id == _month).Value.Name;

            _dayIdOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(cesValue)).Value.Id;

            _dayNameOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(cesValue)).Value.Name;

            _daysInMonth = _persian.GetDaysInMonth(_year, _month);
            _isLeap = _persian.IsLeapYear(_year);

            var date = _persian.ToDateTime(_year, _month, 1, 0, 0, 0, 0);

            _firstDayIdOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(date)).Value.Id;
            _firstDayNameOfWeek = _persianDayNameList.FirstOrDefault(x =>
                x.Key == _persian.GetDayOfWeek(date)).Value.Name;

            this.cesLabel1.Text = _year.ToString();
            this.cesLabel2.Text = _monthName;

            SetDaysOfWeek();
            SetDaysOfMonth();
        }

        private void SetDaysOfWeek()
        {
            this.flowLayoutPanel1.Controls.Clear();

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
                    dayName.BackColor = Color.Khaki;
                    dayName.TextAlign = ContentAlignment.MiddleCenter;

                    this.flowLayoutPanel1.Controls.Add(dayName);
                }
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
                day.Tag = "-1";
                day.Text = "";
                day.AutoSize = false;
                day.Size = new Size(50, 40);
                day.Margin = new System.Windows.Forms.Padding(all: 2);
                day.TextAlign = ContentAlignment.MiddleCenter;
                day.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;

                this.flowLayoutPanel1.Controls.Add(day);
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

                if (i == _day)
                {
                    day.CesColorTemplate = CesButton.ColorTemplateEnum.Orange;
                }
                else
                {
                    day.CesColorTemplate = CesButton.ColorTemplateEnum.Gray;
                }

                this.flowLayoutPanel1.Controls.Add(day);
            }
        }

        private void btnGoToToday_Click(object sender, EventArgs e)
        {
            cesValue = DateTime.Now;

            InitialValues();
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
