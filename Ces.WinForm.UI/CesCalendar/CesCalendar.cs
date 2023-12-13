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

            // add custome font from resource to PrivateFontCollection - For Text
            byte[] fontDataForText = Ces.WinForm.UI.Properties.Resources.BHOMA;
            var fontPtrForText = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontDataForText.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontDataForText, 0, fontPtrForText, fontDataForText.Length);
            _font.AddMemoryFont(fontPtrForText, fontDataForText.Length);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtrForText);

            // add custome font from resource to PrivateFontCollection - For Numbers
            byte[] fontDataForNumber = Ces.WinForm.UI.Properties.Resources.BKOODB;
            var fontPtrForNumber = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontDataForNumber.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontDataForNumber, 0, fontPtrForNumber, fontDataForNumber.Length);
            _font.AddMemoryFont(fontPtrForNumber, fontDataForNumber.Length);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtrForNumber);

            InitializeComponent();
            InitialValues();
            SetSidePanel();
            ReziseCalendar();
        }


        // Private Foelds and Proeprty

        public delegate void CalenderClosedEventHandler();
        public event CalenderClosedEventHandler CesCalenderClosed;

        private System.Globalization.PersianCalendar _persian = new System.Globalization.PersianCalendar();
        private Dictionary<System.DayOfWeek, PersinaDayName> _persianDayNameList = new Dictionary<System.DayOfWeek, PersinaDayName>();
        private Dictionary<int, PersinaMonthName> _persianMonthList = new Dictionary<int, PersinaMonthName>();
        private IList<SelectedDate> _selectedDateList = new List<SelectedDate>();
        private System.Drawing.Text.PrivateFontCollection _font = new System.Drawing.Text.PrivateFontCollection();
        private IList<string> _holidays = new List<string>();
        private Dictionary<string, IList<string>> _events = new Dictionary<string, IList<string>>();

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


        private int cesWeekNumbersFontSize { get; set; } = 10;
        [System.ComponentModel.Category("Ces Calendar")]
        public int CesWeekNumbersFontSize
        {
            get { return cesWeekNumbersFontSize; }
            set
            {
                cesWeekNumbersFontSize = value;
                Redraw();
            }
        }


        private int cesWeekDaysFontSize { get; set; } = 10;
        [System.ComponentModel.Category("Ces Calendar")]
        public int CesWeekDaysFontSize
        {
            get { return cesWeekDaysFontSize; }
            set
            {
                cesWeekDaysFontSize = value;
                Redraw();
            }
        }


        private int cesCalendarFontSize { get; set; } = 12;
        [System.ComponentModel.Category("Ces Calendar")]
        public int CesCalendarFontSize
        {
            get { return cesCalendarFontSize; }
            set
            {
                cesCalendarFontSize = value;
                Redraw();
            }
        }


        private int cesGeneralFontSize { get; set; } = 12;
        [System.ComponentModel.Category("Ces Calendar")]
        public int CesGeneralFontSize
        {
            get { return cesGeneralFontSize; }
            set
            {
                cesGeneralFontSize = value;
                Redraw();
            }
        }


        private DateTime cesValue { get; set; } = DateTime.Now;
        [System.ComponentModel.Category("Ces Calendar")]
        public DateTime CesValue
        {
            get { return cesValue; }
            set
            {
                cesValue = value;
                InitialValues();
            }
        }


        private string cesValuePersian { get; set; } = "1402/01/01";
        [System.ComponentModel.Category("Ces Calendar")]
        public string CesValuePersian
        {
            get { return cesValuePersian; }
            set
            {
                cesValuePersian = value;

                if (string.IsNullOrEmpty(value))
                    return;

                string[] date = cesValuePersian.Split('/');

                if (date.Length != 3)
                    return;

                try
                {
                    CesValue = _persian.ToDateTime(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2]), 0, 0, 0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
        }


        private bool cesIsPersian { get; set; } = true;
        [System.ComponentModel.Category("Ces Calendar")]
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
        [System.ComponentModel.Category("Ces Calendar")]
        public bool CesShowWeekNumber
        {
            get { return cesShowWeekNumber; }
            set
            {
                cesShowWeekNumber = value;
                ReziseCalendar();
                SetWeekNumbers();
            }
        }


        private bool cesShowSidePanel { get; set; } = false;
        [System.ComponentModel.Category("Ces Calendar")]
        public bool CesShowSidePanel
        {
            get { return cesShowSidePanel; }
            set
            {
                cesShowSidePanel = value;
                ReziseCalendar();
                SetWeekNumbers();
            }
        }


        private Color cesFridayForeColor { get; set; } = Color.Red;
        [System.ComponentModel.Category("Ces Calendar")]
        public Color CesFridayForeColor
        {
            get { return cesFridayForeColor; }
            set
            {
                cesFridayForeColor = value;
                Redraw();
            }
        }


        private Color cesWeekNumbersColor { get; set; } = Color.Gray;
        [System.ComponentModel.Category("Ces Calendar")]
        public Color CesWeekNumbersColor
        {
            get { return cesWeekNumbersColor; }
            set
            {
                cesWeekNumbersColor = value;
                SetWeekNumbers();
            }
        }

        private Color cesWeekDaysColor { get; set; } = Color.Gray;
        [System.ComponentModel.Category("Ces Calendar")]
        public Color CesWeekDaysColor
        {
            get { return cesWeekDaysColor; }
            set
            {
                cesWeekDaysColor = value;
                SetWeekDays();
            }
        }


        private Color cesLineColor { get; set; } = Color.FromArgb(224, 224, 224);
        [System.ComponentModel.Category("Ces Calendar")]
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
        [System.ComponentModel.Category("Ces Calendar")]
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
        [System.ComponentModel.Category("Ces Calendar")]
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
        [System.ComponentModel.Category("Ces Calendar")]
        public bool CesMultiSelection
        {
            get { return cesMultiSelection; }
            set
            {
                cesMultiSelection = value;
                ResetTabStop();
            }
        }


        private bool cesUseContraction { get; set; } = true;
        [System.ComponentModel.Category("Ces Calendar")]
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

        public SelectedDate GetToday()
        {
            var result = new SelectedDate
            {
                Geregorian =
                    $"{DateTime.Now.Year}/" +
                    $"{DateTime.Now.Month.ToString().PadLeft(2, '0')}/" +
                    $"{DateTime.Now.Day.ToString().PadLeft(2, '0')}",
                Persian =
                    $"{_persian.GetYear(DateTime.Now)}/" +
                    $"{_persian.GetMonth(DateTime.Now).ToString().PadLeft(2, '0')}/" +
                    $"{_persian.GetDayOfMonth(DateTime.Now).ToString().PadLeft(2, '0')}"
            };

            return result;
        }

        private void ReziseCalendar()
        {
            this.pnlSide.Visible = CesShowSidePanel;
            this.pnlWeekNumbers.Visible = CesShowWeekNumber;

            this.Width =
                385 +
                (CesShowSidePanel ? this.pnlSide.Width : 0) +
                (CesShowWeekNumber ? this.pnlWeekNumbers.Width : 0);
        }

        public void CesAddHoliday(string date)
        {
            if (!_holidays.Any(x => x == date))
                _holidays.Add(date);

            SetSidePanel();
        }

        public void CesRemoveHoliday(string date)
        {
            if (_holidays.Any(x => x == date))
                _holidays.Remove(date);

            SetSidePanel();
        }

        public void CesClearHoliday()
        {
            _holidays.Clear();
            SetSidePanel();
        }

        public bool CesIsHoliday(string date)
        {
            return _holidays.Any(x => x == date);
        }

        public void CesAddEvent(string date, string description)
        {
            var ev = _events.FirstOrDefault(x => x.Key == date);

            if (ev.Value is null)
                _events.Add(date, new List<string> { description });
            else
                ev.Value.Add(description);

            SetSidePanel();
        }

        public void CesRemoveEvent(string date)
        {
            var ev = _events.FirstOrDefault(x => x.Key == date);

            if (ev.Value is not null || ev.Value?.Count() > 0)
            {
                _events.Remove(date);
            }

            SetSidePanel();
        }

        public void CesClearEvent()
        {
            _events.Clear();
            SetSidePanel();
        }

        public bool CesHasEvent(string date)
        {
            return _events.Any(x => x.Key == date);
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

        private void SetSidePanel()
        {
            this.lblDayOfWeekOfPanel.Text = DateTime.Now.DayOfWeek.ToString();
            this.lblDayOfMonthOfPanel.Text = DateTime.Now.Day.ToString().PadLeft(2,'0');
            this.lblYearOfPanel.Text = DateTime.Now.ToString("MMM") + " " + DateTime.Now.Year.ToString();

            this.lblDayOfMonthOfPanel.CesShowUnderLine = _holidays.Any(x => x == GetToday().Persian);

            var ev = _events.FirstOrDefault(x => x.Key == GetToday().Persian);

            if (ev.Value is not null || ev.Value?.Count > 0)
                this.lblEvents.Text = Ces.WinForm.UI.Infrastructure.StringExtnsions.GenerateListOfItems(
                    ev.Value, new Infrastructure.StringOptions
                    {
                        ItemNumberSeparator = ". ",
                        ShowItemNumber = true
                    });
        }

        public void Redraw()
        {
            btnGoToToday.BackColor = this.BackColor;
            btnGoToToday.CesFont = new Font(_font.Families[0], CesGeneralFontSize, FontStyle.Regular);
            lblYear.Font = new Font(_font.Families[0], CesGeneralFontSize, FontStyle.Regular);
            lblMonthName.Font = new Font(_font.Families[0], CesGeneralFontSize, FontStyle.Regular);

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

                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).Font =
                        new Font(_font.Families[1], cesWeekDaysFontSize, FontStyle.Regular);
                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).Text = cesUseContraction ? dn.Contraction : dn.Name;
                    ((Ces.WinForm.UI.CesLabel)this.flpWeekDays.Controls[i]).ForeColor = CesWeekDaysColor;
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

                ((Ces.WinForm.UI.CesLabel)item).Font =
                    new Font(_font.Families[1], CesWeekNumbersFontSize, FontStyle.Regular);
                ((Ces.WinForm.UI.CesLabel)item).Text = string.Empty;
                ((Ces.WinForm.UI.CesLabel)item).ForeColor = CesWeekNumbersColor;
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

                        break;
                    }
                }
            }
        }

        private void SetDaysOfMonth()
        {
            ResetTabStop();

            this.flpCalendar.BackColor = this.BackColor;

            // Create Days of previous month and tag value must be -1 as a signal
            // to show that this day is disabled
            for (int i = 0; i < this.flpCalendar.Controls.Count; i++)
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
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Font =
                        new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Bold);
                }

                if (i == _day)
                {
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).CesColorTemplate = cesTodayColor;

                    // Current Day shall be selected as initial selected date
                    // ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).PerformClick();
                }

                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Tag = date.DayOfWeek;
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Font =
                    new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Regular);

                // evey time this method execute, duplicate eent hander added to click
                // to avoid this, first time we remove it and then add new
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Click -= new EventHandler(this.DayClicked);
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).Click += new EventHandler(this.DayClicked);

                // Chek if cuurent day is hodiday or not
                if (_holidays.Any(x => x == $"{_year}/{_month.ToString().PadLeft(2, '0')}/{i.ToString().PadLeft(2, '0')}"))
                {
                    ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[index]).ForeColor = cesFridayForeColor;
                }
            }
        }

        private void ResetTabStop()
        {
            for (int i = 0; i < this.flpCalendar.Controls.Count; i++)
                ((Ces.WinForm.UI.CesButton.CesButton)this.flpCalendar.Controls[i]).TabStop = false;

        }

        private void btnGoToToday_Click(object sender, EventArgs e)
        {
            _selectedDateList.Clear();
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
            if (ctr.TabStop)
            {
                ctr.TabStop = false;
                ctr.ForeColor = this.ForeColor;
                ctr.BackColor = this.BackColor;
                ctr.Font = new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Regular);

                if (ctr.Tag is not null && ((System.DayOfWeek)ctr.Tag) == DayOfWeek.Friday)
                    ctr.ForeColor = cesFridayForeColor;

                if (int.Parse(ctr.Text) == _day)
                    ctr.CesColorTemplate = cesTodayColor;

                // remove unselected date from list
                AddSelectedDateToList(int.Parse(ctr.Text));
                return;
            }

            if (!cesMultiSelection)
            {
                foreach (var item in this.flpCalendar.Controls)
                {
                    var current = (Ces.WinForm.UI.CesButton.CesButton)item;

                    if (string.IsNullOrEmpty(current.Text))
                        continue;

                    current.CesColorTemplate = cesSelectColor;
                    current.BackColor = this.BackColor;
                    current.Font = new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Regular);

                    if (current.Tag is not null && (System.DayOfWeek)current.Tag == DayOfWeek.Friday)
                    {
                        current.ForeColor = cesFridayForeColor;
                        current.Font = new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Bold);
                    }

                    if (current.Text == _day.ToString())
                    {
                        current.CesColorTemplate = cesTodayColor;
                    }
                }
            }

            ctr.TabStop = true;
            ctr.CesColorTemplate = cesSelectColor;
            ctr.Font = new Font(_font.Families[1], CesCalendarFontSize, FontStyle.Bold);
            AddSelectedDateToList(int.Parse(ctr.Text));
            return;
        }

        private void AddSelectedDateToList(int day)
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


        private void btnOk_Click(object sender, EventArgs e)
        {
            if (CesCalenderClosed is not null)
                CesCalenderClosed();
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

    [System.ComponentModel.TypeConverter(typeof(System.ComponentModel.ExpandableObjectConverter))]
    public class SelectedDate
    {
        public SelectedDate()
        {
        }

        public SelectedDate(string geregorian, string persian)
        {
            this.Geregorian = geregorian;
            this.Persian = persian;
        }

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
