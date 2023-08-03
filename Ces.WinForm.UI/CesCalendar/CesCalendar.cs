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

            InitialValues();
        }


        // Private Foelds and Proeprty


        private System.Globalization.PersianCalendar _persian = new System.Globalization.PersianCalendar();
        private Dictionary<System.DayOfWeek, PersinaDayName> _persianDayNameList = new Dictionary<System.DayOfWeek, PersinaDayName>();
        private Dictionary<int, PersinaMonthName> _persianMonthList = new Dictionary<int, PersinaMonthName>();
        private IList<SelectedDate> _selectedDateList = new List<SelectedDate>();

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
                this.pnlWeekNumbers.Visible = value;

                if (value)
                    this.Width = 430;
                else
                    this.Width = 430 - this.pnlWeekNumbers.Width;

                SetWeekNumbers();
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


        private Color cesLineColor { get; set; } = Color.FromArgb(224, 224, 224);
        [System.ComponentModel.Category("CesCalendar")]
        public Color CesWeekLineColor
        {
            get { return cesLineColor; }
            set
            {
                lineWeekNumber.CesLineColor = value;
                lineWeekDays.CesLineColor = value;
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


        [System.ComponentModel.Browsable(false)]
        public IList<SelectedDate> CesSelectedDates
        {
            get { return _selectedDateList; }
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

            SetWeekDays();
            SetWeekNumbers();
            SetDaysOfMonth();
        }

        private void SetWeekDays()
        {
            // set color
            this.pnlWeekDays.BackColor = this.BackColor;
            this.flpWeekDays.BackColor = this.BackColor;

            // set property value
            if (cesIsPersian)
            {
                for (int i = 0; i < 7; i++)
                {
                    if (this.flpWeekDays.Controls[i].GetType() != typeof(Ces.WinForm.UI.CesLabel))
                        continue;

                    var dn = _persianDayNameList.FirstOrDefault(x => x.Value.Id == i + 1).Value;

                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).Text = cesUseContraction ? dn.Contraction : dn.Name;
                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).ForeColor = this.ForeColor;
                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).BackColor = this.BackColor;
                }
            }
        }

        private void SetWeekNumbers()
        {
            // set color
            this.flpWeekNumbers.BackColor = this.BackColor;
            this.lineWeekNumber.BackColor = this.BackColor;

            // set property value
            foreach (var item in this.flpWeekNumbers.Controls)
            {
                if (item.GetType() != typeof(Ces.WinForm.UI.CesLabel))
                    continue;

                ((Ces.WinForm.UI.CesLabel)item).Text = string.Empty;
                ((Ces.WinForm.UI.CesLabel)item).ForeColor = this.ForeColor;
                ((Ces.WinForm.UI.CesLabel)item).BackColor = this.BackColor;
            }

            if (!cesShowWeekNumber)
                return;

            for (int i = 1; i <= _daysInMonth; i++)
            {
                var wNumber =
                    _persian.GetWeekOfYear(
                        _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0),
                        System.Globalization.CalendarWeekRule.FirstDay,
                        DayOfWeek.Saturday);

                foreach (var item in this.flpWeekNumbers.Controls)
                {
                    if (item.GetType() != typeof(Ces.WinForm.UI.CesLabel))
                        continue;

                    if (((Ces.WinForm.UI.CesLabel)item).Tag is not null &&
                        ((Ces.WinForm.UI.CesLabel)item).Tag.ToString() == "-1")
                        continue;

                    if (!string.IsNullOrEmpty(((Ces.WinForm.UI.CesLabel)item).Text) &&
                       ((Ces.WinForm.UI.CesLabel)item).Text == wNumber.ToString())
                        break;

                    if (!string.IsNullOrEmpty(((Ces.WinForm.UI.CesLabel)item).Text))
                        continue;

                    if (string.IsNullOrEmpty(((Ces.WinForm.UI.CesLabel)item).Text))
                    {
                        ((Ces.WinForm.UI.CesLabel)item).Text = wNumber.ToString();
                        ((Ces.WinForm.UI.CesLabel)item).ForeColor = this.ForeColor;
                        ((Ces.WinForm.UI.CesLabel)item).BackColor = this.BackColor;

                        break;
                    }
                }
            }
        }

        private void SetDaysOfMonth()
        {
            this.flpCalendar.BackColor = this.BackColor;

            // Create Days of previous month and tag value must be -1 as a signal
            // to show that this day is disabled
            for (int i = 0; i < _firstDayIdOfWeek - 1; i++)
            {
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).Text = "";
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).Enabled = false;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).ForeColor = this.ForeColor;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).BackColor = this.BackColor;
            }


            // set calendar days
            for (int i = 1; i <= _daysInMonth; i++)
            {
                int index = (_firstDayIdOfWeek - 1) + (i - 1);

                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Text = i.ToString();
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Enabled = true;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).CesColorTemplate = cesSelectColor;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).ForeColor = ForeColor;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).BackColor = this.BackColor;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Cursor = Cursors.Hand;

                var date = _persian.ToDateTime(_year, _month, i, 0, 0, 0, 0);

                if (date.DayOfWeek == DayOfWeek.Friday)
                {
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).ForeColor = cesFridayForeColor;
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Font = new Font(
                            new FontFamily(this.Font.FontFamily.Name),
                            this.Font.Size,
                            FontStyle.Bold);
                }

                if (i == _day)
                {
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).CesColorTemplate = cesTodayColor;
                }

                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Tag = date.DayOfWeek;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Click += new EventHandler(this.DayClicked);
            }


            int startIndex = (_firstDayIdOfWeek - 1) + _daysInMonth;

            for (int i = startIndex; i < this.flpCalendar.Controls.Count; i++)
            {
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).Text = "";
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).Enabled = false;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).ForeColor = this.ForeColor;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).BackColor = this.BackColor;
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
            var ctr = (Ces.WinForm.UI.CesButton.CesButton)sender;

            // after second click, selected date must be unselect and remove from _selectedDateList
            if (ctr.Font.Bold)
            {
                ctr.ForeColor = this.ForeColor;
                ctr.BackColor = this.BackColor;
                ctr.Font = new Font(
                    new FontFamily(this.Font.FontFamily.Name),
                    this.Font.Size,
                    FontStyle.Regular);

                if (ctr.Tag is not null && ((System.DayOfWeek)ctr.Tag) == DayOfWeek.Friday)
                    ctr.ForeColor = cesFridayForeColor;

                if (int.Parse(ctr.Text) == _day)
                    ctr.CesColorTemplate = cesTodayColor;

                // remove unselected date from list
                AddSelectedDateToLst(int.Parse(ctr.Text));
                return;
            }

            if (!cesMultiSelection)
            {
                foreach (var item in this.flpCalendar.Controls)
                {
                    if (item.GetType() == typeof(Ces.WinForm.UI.CesButton.CesButton))
                    {
                        var current = (Ces.WinForm.UI.CesButton.CesButton)item;

                        current.CesColorTemplate = cesSelectColor;
                        current.BackColor = this.BackColor;
                        current.Font = new Font(new FontFamily(this.Font.FontFamily.Name), this.Font.Size, FontStyle.Regular);

                        if (current.Tag is not null && (System.DayOfWeek)current.Tag == DayOfWeek.Friday)
                        {
                            current.ForeColor = cesFridayForeColor;
                            current.Font = new Font(new FontFamily(this.Font.FontFamily.Name), this.Font.Size, FontStyle.Bold);
                        }

                        if (current.Text == _day.ToString())
                        {
                            current.CesColorTemplate = cesTodayColor;
                        }
                    }
                }
            }

            ctr.CesColorTemplate = cesSelectColor;
            ctr.Font = new Font(new FontFamily(this.Font.FontFamily.Name), this.Font.Size, FontStyle.Bold);
            AddSelectedDateToLst(int.Parse(ctr.Text));
        }

        private void AddSelectedDateToLst(int day)
        {
            var selectedGeregorian = _persian.ToDateTime(_year, _month, day, 0, 0, 0, 0);
            var selectedPersian = $"{_year}/{_month.ToString().PadLeft(2, '0')}/{day.ToString().PadLeft(2, '0')}";



            var current = _selectedDateList.FirstOrDefault(x => x.Persian == selectedPersian);

            if (current is not null)
            {
                _selectedDateList.Remove(current);
                return;
            }

            if (!CesMultiSelection)
                _selectedDateList.Clear();

            _selectedDateList.Add(new SelectedDate
            {
                Geregorian = selectedGeregorian.ToString("yyyy/MM/dd"),
                Persian = selectedPersian,
            });
        }

        private void pbPreviousYear_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddYears(_dateOfFirstDay, -1);
        }

        private void pbNextYear_Click(object sender, EventArgs e)
        {
            CesValue = _persian.AddYears(_dateOfFirstDay, 1);
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

    public class SelectedDate
    {
        public string Geregorian { get; set; } = string.Empty;
        public string Persian { get; set; } = string.Empty;
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
