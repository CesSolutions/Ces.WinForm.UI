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
        }


        // Private Foelds and Proeprty


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
        [System.ComponentModel.Category("CesCalendar")]
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
        [System.ComponentModel.Category("CesCalendar")]
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
        [System.ComponentModel.Category("CesCalendar")]
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
        [System.ComponentModel.Category("CesCalendar")]
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


        private string cesValuePersian { get; set; } = "0000/00/00";
        [System.ComponentModel.Category("CesCalendar")]
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
                ReziseCalendar();
                SetWeekNumbers();
            }
        }


        private bool cesShowSidePanel { get; set; } = true;
        [System.ComponentModel.Category("CesCalendar")]
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


        private Color cesWeekNumbersColor { get; set; } = Color.Gray;
        [System.ComponentModel.Category("CesCalendar")]
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
        [System.ComponentModel.Category("CesCalendar")]
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
                ResetTabStop();
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
            this.lblYearOfPanel.Text = DateTime.Now.Year.ToString();
            this.lblDayOfWeekOfPanel.Text = DateTime.Now.DayOfWeek.ToString();
            this.lblMonthOfPanel.Text = DateTime.Now.Day.ToString() + " " + DateTime.Now.ToString("MMM");

            this.lblMonthOfPanel.CesShowUnderLine = _holidays.Any(x => x == GetToday().Persian);

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

        private void InitializeComponent()
        {
            this.flpCalendar = new System.Windows.Forms.FlowLayoutPanel();
            this.cesButton1 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton2 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton3 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton4 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton5 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton6 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton7 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton8 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton9 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton10 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton11 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton12 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton13 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton14 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton15 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton16 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton17 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton18 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton19 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton20 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton21 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton22 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton23 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton24 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton25 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton26 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton27 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton28 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton29 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton30 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton31 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton32 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton33 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton34 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton35 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton36 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton37 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton38 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton39 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton40 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton41 = new Ces.WinForm.UI.CesButton.CesButton();
            this.cesButton42 = new Ces.WinForm.UI.CesButton.CesButton();
            this.lblYear = new Ces.WinForm.UI.CesLabel();
            this.lblMonthName = new Ces.WinForm.UI.CesLabel();
            this.btnGoToToday = new Ces.WinForm.UI.CesButton.CesRoundedButton();
            this.flpWeekNumbers = new System.Windows.Forms.FlowLayoutPanel();
            this.lblWeekNo1 = new Ces.WinForm.UI.CesLabel();
            this.lblWeekNo2 = new Ces.WinForm.UI.CesLabel();
            this.lblWeekNo3 = new Ces.WinForm.UI.CesLabel();
            this.lblWeekNo4 = new Ces.WinForm.UI.CesLabel();
            this.lblWeekNo5 = new Ces.WinForm.UI.CesLabel();
            this.lblWeekNo6 = new Ces.WinForm.UI.CesLabel();
            this.pnlWeekNumbers = new System.Windows.Forms.Panel();
            this.lineWeekNumber = new Ces.WinForm.UI.CesLine();
            this.pbNextMonth = new System.Windows.Forms.PictureBox();
            this.pbPreviousMonth = new System.Windows.Forms.PictureBox();
            this.pbNextYear = new System.Windows.Forms.PictureBox();
            this.pbPreviousYear = new System.Windows.Forms.PictureBox();
            this.pnlWeekDays = new System.Windows.Forms.Panel();
            this.lineWeekDays = new Ces.WinForm.UI.CesLine();
            this.flpWeekDays = new System.Windows.Forms.FlowLayoutPanel();
            this.lblDayOfWeek1 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek2 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek3 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek4 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek5 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek6 = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeek7 = new Ces.WinForm.UI.CesLabel();
            this.pnlSide = new System.Windows.Forms.Panel();
            this.lblEvents = new System.Windows.Forms.Label();
            this.lblMonthOfPanel = new Ces.WinForm.UI.CesLabel();
            this.lblDayOfWeekOfPanel = new System.Windows.Forms.Label();
            this.lblYearOfPanel = new System.Windows.Forms.Label();
            this.flpCalendar.SuspendLayout();
            this.flpWeekNumbers.SuspendLayout();
            this.pnlWeekNumbers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousMonth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextYear)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousYear)).BeginInit();
            this.pnlWeekDays.SuspendLayout();
            this.flpWeekDays.SuspendLayout();
            this.pnlSide.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpCalendar
            // 
            this.flpCalendar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flpCalendar.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpCalendar.Controls.Add(this.cesButton1);
            this.flpCalendar.Controls.Add(this.cesButton2);
            this.flpCalendar.Controls.Add(this.cesButton3);
            this.flpCalendar.Controls.Add(this.cesButton4);
            this.flpCalendar.Controls.Add(this.cesButton5);
            this.flpCalendar.Controls.Add(this.cesButton6);
            this.flpCalendar.Controls.Add(this.cesButton7);
            this.flpCalendar.Controls.Add(this.cesButton8);
            this.flpCalendar.Controls.Add(this.cesButton9);
            this.flpCalendar.Controls.Add(this.cesButton10);
            this.flpCalendar.Controls.Add(this.cesButton11);
            this.flpCalendar.Controls.Add(this.cesButton12);
            this.flpCalendar.Controls.Add(this.cesButton13);
            this.flpCalendar.Controls.Add(this.cesButton14);
            this.flpCalendar.Controls.Add(this.cesButton15);
            this.flpCalendar.Controls.Add(this.cesButton16);
            this.flpCalendar.Controls.Add(this.cesButton17);
            this.flpCalendar.Controls.Add(this.cesButton18);
            this.flpCalendar.Controls.Add(this.cesButton19);
            this.flpCalendar.Controls.Add(this.cesButton20);
            this.flpCalendar.Controls.Add(this.cesButton21);
            this.flpCalendar.Controls.Add(this.cesButton22);
            this.flpCalendar.Controls.Add(this.cesButton23);
            this.flpCalendar.Controls.Add(this.cesButton24);
            this.flpCalendar.Controls.Add(this.cesButton25);
            this.flpCalendar.Controls.Add(this.cesButton26);
            this.flpCalendar.Controls.Add(this.cesButton27);
            this.flpCalendar.Controls.Add(this.cesButton28);
            this.flpCalendar.Controls.Add(this.cesButton29);
            this.flpCalendar.Controls.Add(this.cesButton30);
            this.flpCalendar.Controls.Add(this.cesButton31);
            this.flpCalendar.Controls.Add(this.cesButton32);
            this.flpCalendar.Controls.Add(this.cesButton33);
            this.flpCalendar.Controls.Add(this.cesButton34);
            this.flpCalendar.Controls.Add(this.cesButton35);
            this.flpCalendar.Controls.Add(this.cesButton36);
            this.flpCalendar.Controls.Add(this.cesButton37);
            this.flpCalendar.Controls.Add(this.cesButton38);
            this.flpCalendar.Controls.Add(this.cesButton39);
            this.flpCalendar.Controls.Add(this.cesButton40);
            this.flpCalendar.Controls.Add(this.cesButton41);
            this.flpCalendar.Controls.Add(this.cesButton42);
            this.flpCalendar.Location = new System.Drawing.Point(203, 77);
            this.flpCalendar.Margin = new System.Windows.Forms.Padding(0);
            this.flpCalendar.Name = "flpCalendar";
            this.flpCalendar.Size = new System.Drawing.Size(378, 262);
            this.flpCalendar.TabIndex = 36;
            // 
            // cesButton1
            // 
            this.cesButton1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton1.CesBorderThickness = 1;
            this.cesButton1.CesBorderVisible = false;
            this.cesButton1.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton1.FlatAppearance.BorderSize = 0;
            this.cesButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton1.Location = new System.Drawing.Point(2, 2);
            this.cesButton1.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton1.Name = "cesButton1";
            this.cesButton1.Size = new System.Drawing.Size(50, 40);
            this.cesButton1.TabIndex = 7;
            this.cesButton1.TabStop = false;
            this.cesButton1.UseVisualStyleBackColor = false;
            // 
            // cesButton2
            // 
            this.cesButton2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton2.CesBorderThickness = 1;
            this.cesButton2.CesBorderVisible = false;
            this.cesButton2.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton2.FlatAppearance.BorderSize = 0;
            this.cesButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton2.Location = new System.Drawing.Point(56, 2);
            this.cesButton2.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton2.Name = "cesButton2";
            this.cesButton2.Size = new System.Drawing.Size(50, 40);
            this.cesButton2.TabIndex = 8;
            this.cesButton2.TabStop = false;
            this.cesButton2.UseVisualStyleBackColor = false;
            // 
            // cesButton3
            // 
            this.cesButton3.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton3.CesBorderThickness = 1;
            this.cesButton3.CesBorderVisible = false;
            this.cesButton3.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton3.FlatAppearance.BorderSize = 0;
            this.cesButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton3.Location = new System.Drawing.Point(110, 2);
            this.cesButton3.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton3.Name = "cesButton3";
            this.cesButton3.Size = new System.Drawing.Size(50, 40);
            this.cesButton3.TabIndex = 9;
            this.cesButton3.TabStop = false;
            this.cesButton3.UseVisualStyleBackColor = false;
            // 
            // cesButton4
            // 
            this.cesButton4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton4.CesBorderThickness = 1;
            this.cesButton4.CesBorderVisible = false;
            this.cesButton4.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton4.FlatAppearance.BorderSize = 0;
            this.cesButton4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton4.Location = new System.Drawing.Point(164, 2);
            this.cesButton4.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton4.Name = "cesButton4";
            this.cesButton4.Size = new System.Drawing.Size(50, 40);
            this.cesButton4.TabIndex = 10;
            this.cesButton4.TabStop = false;
            this.cesButton4.UseVisualStyleBackColor = false;
            // 
            // cesButton5
            // 
            this.cesButton5.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton5.CesBorderThickness = 1;
            this.cesButton5.CesBorderVisible = false;
            this.cesButton5.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton5.FlatAppearance.BorderSize = 0;
            this.cesButton5.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton5.Location = new System.Drawing.Point(218, 2);
            this.cesButton5.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton5.Name = "cesButton5";
            this.cesButton5.Size = new System.Drawing.Size(50, 40);
            this.cesButton5.TabIndex = 11;
            this.cesButton5.TabStop = false;
            this.cesButton5.UseVisualStyleBackColor = false;
            // 
            // cesButton6
            // 
            this.cesButton6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton6.CesBorderThickness = 1;
            this.cesButton6.CesBorderVisible = false;
            this.cesButton6.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton6.FlatAppearance.BorderSize = 0;
            this.cesButton6.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton6.Location = new System.Drawing.Point(272, 2);
            this.cesButton6.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton6.Name = "cesButton6";
            this.cesButton6.Size = new System.Drawing.Size(50, 40);
            this.cesButton6.TabIndex = 12;
            this.cesButton6.TabStop = false;
            this.cesButton6.UseVisualStyleBackColor = false;
            // 
            // cesButton7
            // 
            this.cesButton7.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton7.CesBorderThickness = 1;
            this.cesButton7.CesBorderVisible = false;
            this.cesButton7.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton7.FlatAppearance.BorderSize = 0;
            this.cesButton7.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton7.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton7.Location = new System.Drawing.Point(326, 2);
            this.cesButton7.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton7.Name = "cesButton7";
            this.cesButton7.Size = new System.Drawing.Size(50, 40);
            this.cesButton7.TabIndex = 13;
            this.cesButton7.TabStop = false;
            this.cesButton7.UseVisualStyleBackColor = false;
            // 
            // cesButton8
            // 
            this.cesButton8.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton8.CesBorderThickness = 1;
            this.cesButton8.CesBorderVisible = false;
            this.cesButton8.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton8.FlatAppearance.BorderSize = 0;
            this.cesButton8.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton8.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton8.Location = new System.Drawing.Point(2, 46);
            this.cesButton8.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton8.Name = "cesButton8";
            this.cesButton8.Size = new System.Drawing.Size(50, 40);
            this.cesButton8.TabIndex = 14;
            this.cesButton8.TabStop = false;
            this.cesButton8.UseVisualStyleBackColor = false;
            // 
            // cesButton9
            // 
            this.cesButton9.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton9.CesBorderThickness = 1;
            this.cesButton9.CesBorderVisible = false;
            this.cesButton9.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton9.FlatAppearance.BorderSize = 0;
            this.cesButton9.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton9.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton9.Location = new System.Drawing.Point(56, 46);
            this.cesButton9.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton9.Name = "cesButton9";
            this.cesButton9.Size = new System.Drawing.Size(50, 40);
            this.cesButton9.TabIndex = 15;
            this.cesButton9.TabStop = false;
            this.cesButton9.UseVisualStyleBackColor = false;
            // 
            // cesButton10
            // 
            this.cesButton10.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton10.CesBorderThickness = 1;
            this.cesButton10.CesBorderVisible = false;
            this.cesButton10.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton10.FlatAppearance.BorderSize = 0;
            this.cesButton10.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton10.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton10.Location = new System.Drawing.Point(110, 46);
            this.cesButton10.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton10.Name = "cesButton10";
            this.cesButton10.Size = new System.Drawing.Size(50, 40);
            this.cesButton10.TabIndex = 16;
            this.cesButton10.TabStop = false;
            this.cesButton10.UseVisualStyleBackColor = false;
            // 
            // cesButton11
            // 
            this.cesButton11.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton11.CesBorderThickness = 1;
            this.cesButton11.CesBorderVisible = false;
            this.cesButton11.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton11.FlatAppearance.BorderSize = 0;
            this.cesButton11.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton11.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton11.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton11.Location = new System.Drawing.Point(164, 46);
            this.cesButton11.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton11.Name = "cesButton11";
            this.cesButton11.Size = new System.Drawing.Size(50, 40);
            this.cesButton11.TabIndex = 17;
            this.cesButton11.TabStop = false;
            this.cesButton11.UseVisualStyleBackColor = false;
            // 
            // cesButton12
            // 
            this.cesButton12.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton12.CesBorderThickness = 1;
            this.cesButton12.CesBorderVisible = false;
            this.cesButton12.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton12.FlatAppearance.BorderSize = 0;
            this.cesButton12.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton12.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton12.Location = new System.Drawing.Point(218, 46);
            this.cesButton12.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton12.Name = "cesButton12";
            this.cesButton12.Size = new System.Drawing.Size(50, 40);
            this.cesButton12.TabIndex = 18;
            this.cesButton12.TabStop = false;
            this.cesButton12.UseVisualStyleBackColor = false;
            // 
            // cesButton13
            // 
            this.cesButton13.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton13.CesBorderThickness = 1;
            this.cesButton13.CesBorderVisible = false;
            this.cesButton13.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton13.FlatAppearance.BorderSize = 0;
            this.cesButton13.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton13.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton13.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton13.Location = new System.Drawing.Point(272, 46);
            this.cesButton13.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton13.Name = "cesButton13";
            this.cesButton13.Size = new System.Drawing.Size(50, 40);
            this.cesButton13.TabIndex = 19;
            this.cesButton13.TabStop = false;
            this.cesButton13.UseVisualStyleBackColor = false;
            // 
            // cesButton14
            // 
            this.cesButton14.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton14.CesBorderThickness = 1;
            this.cesButton14.CesBorderVisible = false;
            this.cesButton14.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton14.FlatAppearance.BorderSize = 0;
            this.cesButton14.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton14.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton14.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton14.Location = new System.Drawing.Point(326, 46);
            this.cesButton14.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton14.Name = "cesButton14";
            this.cesButton14.Size = new System.Drawing.Size(50, 40);
            this.cesButton14.TabIndex = 20;
            this.cesButton14.TabStop = false;
            this.cesButton14.UseVisualStyleBackColor = false;
            // 
            // cesButton15
            // 
            this.cesButton15.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton15.CesBorderThickness = 1;
            this.cesButton15.CesBorderVisible = false;
            this.cesButton15.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton15.FlatAppearance.BorderSize = 0;
            this.cesButton15.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton15.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton15.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton15.Location = new System.Drawing.Point(2, 90);
            this.cesButton15.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton15.Name = "cesButton15";
            this.cesButton15.Size = new System.Drawing.Size(50, 40);
            this.cesButton15.TabIndex = 21;
            this.cesButton15.TabStop = false;
            this.cesButton15.UseVisualStyleBackColor = false;
            // 
            // cesButton16
            // 
            this.cesButton16.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton16.CesBorderThickness = 1;
            this.cesButton16.CesBorderVisible = false;
            this.cesButton16.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton16.FlatAppearance.BorderSize = 0;
            this.cesButton16.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton16.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton16.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton16.Location = new System.Drawing.Point(56, 90);
            this.cesButton16.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton16.Name = "cesButton16";
            this.cesButton16.Size = new System.Drawing.Size(50, 40);
            this.cesButton16.TabIndex = 22;
            this.cesButton16.TabStop = false;
            this.cesButton16.UseVisualStyleBackColor = false;
            // 
            // cesButton17
            // 
            this.cesButton17.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton17.CesBorderThickness = 1;
            this.cesButton17.CesBorderVisible = false;
            this.cesButton17.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton17.FlatAppearance.BorderSize = 0;
            this.cesButton17.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton17.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton17.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton17.Location = new System.Drawing.Point(110, 90);
            this.cesButton17.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton17.Name = "cesButton17";
            this.cesButton17.Size = new System.Drawing.Size(50, 40);
            this.cesButton17.TabIndex = 23;
            this.cesButton17.TabStop = false;
            this.cesButton17.UseVisualStyleBackColor = false;
            // 
            // cesButton18
            // 
            this.cesButton18.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton18.CesBorderThickness = 1;
            this.cesButton18.CesBorderVisible = false;
            this.cesButton18.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton18.FlatAppearance.BorderSize = 0;
            this.cesButton18.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton18.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton18.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton18.Location = new System.Drawing.Point(164, 90);
            this.cesButton18.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton18.Name = "cesButton18";
            this.cesButton18.Size = new System.Drawing.Size(50, 40);
            this.cesButton18.TabIndex = 24;
            this.cesButton18.TabStop = false;
            this.cesButton18.UseVisualStyleBackColor = false;
            // 
            // cesButton19
            // 
            this.cesButton19.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton19.CesBorderThickness = 1;
            this.cesButton19.CesBorderVisible = false;
            this.cesButton19.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton19.FlatAppearance.BorderSize = 0;
            this.cesButton19.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton19.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton19.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton19.Location = new System.Drawing.Point(218, 90);
            this.cesButton19.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton19.Name = "cesButton19";
            this.cesButton19.Size = new System.Drawing.Size(50, 40);
            this.cesButton19.TabIndex = 25;
            this.cesButton19.TabStop = false;
            this.cesButton19.UseVisualStyleBackColor = false;
            // 
            // cesButton20
            // 
            this.cesButton20.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton20.CesBorderThickness = 1;
            this.cesButton20.CesBorderVisible = false;
            this.cesButton20.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton20.FlatAppearance.BorderSize = 0;
            this.cesButton20.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton20.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton20.Location = new System.Drawing.Point(272, 90);
            this.cesButton20.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton20.Name = "cesButton20";
            this.cesButton20.Size = new System.Drawing.Size(50, 40);
            this.cesButton20.TabIndex = 26;
            this.cesButton20.TabStop = false;
            this.cesButton20.UseVisualStyleBackColor = false;
            // 
            // cesButton21
            // 
            this.cesButton21.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton21.CesBorderThickness = 1;
            this.cesButton21.CesBorderVisible = false;
            this.cesButton21.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton21.FlatAppearance.BorderSize = 0;
            this.cesButton21.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton21.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton21.Location = new System.Drawing.Point(326, 90);
            this.cesButton21.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton21.Name = "cesButton21";
            this.cesButton21.Size = new System.Drawing.Size(50, 40);
            this.cesButton21.TabIndex = 27;
            this.cesButton21.TabStop = false;
            this.cesButton21.UseVisualStyleBackColor = false;
            // 
            // cesButton22
            // 
            this.cesButton22.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton22.CesBorderThickness = 1;
            this.cesButton22.CesBorderVisible = false;
            this.cesButton22.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton22.FlatAppearance.BorderSize = 0;
            this.cesButton22.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton22.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton22.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton22.Location = new System.Drawing.Point(2, 134);
            this.cesButton22.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton22.Name = "cesButton22";
            this.cesButton22.Size = new System.Drawing.Size(50, 40);
            this.cesButton22.TabIndex = 28;
            this.cesButton22.TabStop = false;
            this.cesButton22.UseVisualStyleBackColor = false;
            // 
            // cesButton23
            // 
            this.cesButton23.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton23.CesBorderThickness = 1;
            this.cesButton23.CesBorderVisible = false;
            this.cesButton23.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton23.FlatAppearance.BorderSize = 0;
            this.cesButton23.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton23.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton23.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton23.Location = new System.Drawing.Point(56, 134);
            this.cesButton23.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton23.Name = "cesButton23";
            this.cesButton23.Size = new System.Drawing.Size(50, 40);
            this.cesButton23.TabIndex = 29;
            this.cesButton23.TabStop = false;
            this.cesButton23.UseVisualStyleBackColor = false;
            // 
            // cesButton24
            // 
            this.cesButton24.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton24.CesBorderThickness = 1;
            this.cesButton24.CesBorderVisible = false;
            this.cesButton24.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton24.FlatAppearance.BorderSize = 0;
            this.cesButton24.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton24.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton24.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton24.Location = new System.Drawing.Point(110, 134);
            this.cesButton24.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton24.Name = "cesButton24";
            this.cesButton24.Size = new System.Drawing.Size(50, 40);
            this.cesButton24.TabIndex = 30;
            this.cesButton24.TabStop = false;
            this.cesButton24.UseVisualStyleBackColor = false;
            // 
            // cesButton25
            // 
            this.cesButton25.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton25.CesBorderThickness = 1;
            this.cesButton25.CesBorderVisible = false;
            this.cesButton25.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton25.FlatAppearance.BorderSize = 0;
            this.cesButton25.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton25.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton25.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton25.Location = new System.Drawing.Point(164, 134);
            this.cesButton25.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton25.Name = "cesButton25";
            this.cesButton25.Size = new System.Drawing.Size(50, 40);
            this.cesButton25.TabIndex = 31;
            this.cesButton25.TabStop = false;
            this.cesButton25.UseVisualStyleBackColor = false;
            // 
            // cesButton26
            // 
            this.cesButton26.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton26.CesBorderThickness = 1;
            this.cesButton26.CesBorderVisible = false;
            this.cesButton26.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton26.FlatAppearance.BorderSize = 0;
            this.cesButton26.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton26.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton26.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton26.Location = new System.Drawing.Point(218, 134);
            this.cesButton26.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton26.Name = "cesButton26";
            this.cesButton26.Size = new System.Drawing.Size(50, 40);
            this.cesButton26.TabIndex = 32;
            this.cesButton26.TabStop = false;
            this.cesButton26.UseVisualStyleBackColor = false;
            // 
            // cesButton27
            // 
            this.cesButton27.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton27.CesBorderThickness = 1;
            this.cesButton27.CesBorderVisible = false;
            this.cesButton27.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton27.FlatAppearance.BorderSize = 0;
            this.cesButton27.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton27.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton27.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton27.Location = new System.Drawing.Point(272, 134);
            this.cesButton27.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton27.Name = "cesButton27";
            this.cesButton27.Size = new System.Drawing.Size(50, 40);
            this.cesButton27.TabIndex = 33;
            this.cesButton27.TabStop = false;
            this.cesButton27.UseVisualStyleBackColor = false;
            // 
            // cesButton28
            // 
            this.cesButton28.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton28.CesBorderThickness = 1;
            this.cesButton28.CesBorderVisible = false;
            this.cesButton28.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton28.FlatAppearance.BorderSize = 0;
            this.cesButton28.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton28.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton28.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton28.Location = new System.Drawing.Point(326, 134);
            this.cesButton28.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton28.Name = "cesButton28";
            this.cesButton28.Size = new System.Drawing.Size(50, 40);
            this.cesButton28.TabIndex = 34;
            this.cesButton28.TabStop = false;
            this.cesButton28.UseVisualStyleBackColor = false;
            // 
            // cesButton29
            // 
            this.cesButton29.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton29.CesBorderThickness = 1;
            this.cesButton29.CesBorderVisible = false;
            this.cesButton29.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton29.FlatAppearance.BorderSize = 0;
            this.cesButton29.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton29.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton29.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton29.Location = new System.Drawing.Point(2, 178);
            this.cesButton29.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton29.Name = "cesButton29";
            this.cesButton29.Size = new System.Drawing.Size(50, 40);
            this.cesButton29.TabIndex = 35;
            this.cesButton29.TabStop = false;
            this.cesButton29.UseVisualStyleBackColor = false;
            // 
            // cesButton30
            // 
            this.cesButton30.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton30.CesBorderThickness = 1;
            this.cesButton30.CesBorderVisible = false;
            this.cesButton30.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton30.FlatAppearance.BorderSize = 0;
            this.cesButton30.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton30.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton30.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton30.Location = new System.Drawing.Point(56, 178);
            this.cesButton30.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton30.Name = "cesButton30";
            this.cesButton30.Size = new System.Drawing.Size(50, 40);
            this.cesButton30.TabIndex = 36;
            this.cesButton30.TabStop = false;
            this.cesButton30.UseVisualStyleBackColor = false;
            // 
            // cesButton31
            // 
            this.cesButton31.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton31.CesBorderThickness = 1;
            this.cesButton31.CesBorderVisible = false;
            this.cesButton31.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton31.FlatAppearance.BorderSize = 0;
            this.cesButton31.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton31.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton31.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton31.Location = new System.Drawing.Point(110, 178);
            this.cesButton31.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton31.Name = "cesButton31";
            this.cesButton31.Size = new System.Drawing.Size(50, 40);
            this.cesButton31.TabIndex = 37;
            this.cesButton31.TabStop = false;
            this.cesButton31.UseVisualStyleBackColor = false;
            // 
            // cesButton32
            // 
            this.cesButton32.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton32.CesBorderThickness = 1;
            this.cesButton32.CesBorderVisible = false;
            this.cesButton32.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton32.FlatAppearance.BorderSize = 0;
            this.cesButton32.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton32.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton32.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton32.Location = new System.Drawing.Point(164, 178);
            this.cesButton32.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton32.Name = "cesButton32";
            this.cesButton32.Size = new System.Drawing.Size(50, 40);
            this.cesButton32.TabIndex = 38;
            this.cesButton32.TabStop = false;
            this.cesButton32.UseVisualStyleBackColor = false;
            // 
            // cesButton33
            // 
            this.cesButton33.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton33.CesBorderThickness = 1;
            this.cesButton33.CesBorderVisible = false;
            this.cesButton33.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton33.FlatAppearance.BorderSize = 0;
            this.cesButton33.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton33.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton33.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton33.Location = new System.Drawing.Point(218, 178);
            this.cesButton33.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton33.Name = "cesButton33";
            this.cesButton33.Size = new System.Drawing.Size(50, 40);
            this.cesButton33.TabIndex = 39;
            this.cesButton33.TabStop = false;
            this.cesButton33.UseVisualStyleBackColor = false;
            // 
            // cesButton34
            // 
            this.cesButton34.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton34.CesBorderThickness = 1;
            this.cesButton34.CesBorderVisible = false;
            this.cesButton34.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton34.FlatAppearance.BorderSize = 0;
            this.cesButton34.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton34.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton34.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton34.Location = new System.Drawing.Point(272, 178);
            this.cesButton34.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton34.Name = "cesButton34";
            this.cesButton34.Size = new System.Drawing.Size(50, 40);
            this.cesButton34.TabIndex = 40;
            this.cesButton34.TabStop = false;
            this.cesButton34.UseVisualStyleBackColor = false;
            // 
            // cesButton35
            // 
            this.cesButton35.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton35.CesBorderThickness = 1;
            this.cesButton35.CesBorderVisible = false;
            this.cesButton35.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton35.FlatAppearance.BorderSize = 0;
            this.cesButton35.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton35.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton35.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton35.Location = new System.Drawing.Point(326, 178);
            this.cesButton35.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton35.Name = "cesButton35";
            this.cesButton35.Size = new System.Drawing.Size(50, 40);
            this.cesButton35.TabIndex = 41;
            this.cesButton35.TabStop = false;
            this.cesButton35.UseVisualStyleBackColor = false;
            // 
            // cesButton36
            // 
            this.cesButton36.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton36.CesBorderThickness = 1;
            this.cesButton36.CesBorderVisible = false;
            this.cesButton36.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton36.FlatAppearance.BorderSize = 0;
            this.cesButton36.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton36.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton36.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton36.Location = new System.Drawing.Point(2, 222);
            this.cesButton36.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton36.Name = "cesButton36";
            this.cesButton36.Size = new System.Drawing.Size(50, 40);
            this.cesButton36.TabIndex = 42;
            this.cesButton36.TabStop = false;
            this.cesButton36.UseVisualStyleBackColor = false;
            // 
            // cesButton37
            // 
            this.cesButton37.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton37.CesBorderThickness = 1;
            this.cesButton37.CesBorderVisible = false;
            this.cesButton37.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton37.FlatAppearance.BorderSize = 0;
            this.cesButton37.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton37.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton37.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton37.Location = new System.Drawing.Point(56, 222);
            this.cesButton37.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton37.Name = "cesButton37";
            this.cesButton37.Size = new System.Drawing.Size(50, 40);
            this.cesButton37.TabIndex = 43;
            this.cesButton37.TabStop = false;
            this.cesButton37.UseVisualStyleBackColor = false;
            // 
            // cesButton38
            // 
            this.cesButton38.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton38.CesBorderThickness = 1;
            this.cesButton38.CesBorderVisible = false;
            this.cesButton38.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton38.FlatAppearance.BorderSize = 0;
            this.cesButton38.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton38.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton38.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton38.Location = new System.Drawing.Point(110, 222);
            this.cesButton38.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton38.Name = "cesButton38";
            this.cesButton38.Size = new System.Drawing.Size(50, 40);
            this.cesButton38.TabIndex = 44;
            this.cesButton38.TabStop = false;
            this.cesButton38.UseVisualStyleBackColor = false;
            // 
            // cesButton39
            // 
            this.cesButton39.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton39.CesBorderThickness = 1;
            this.cesButton39.CesBorderVisible = false;
            this.cesButton39.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton39.FlatAppearance.BorderSize = 0;
            this.cesButton39.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton39.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton39.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton39.Location = new System.Drawing.Point(164, 222);
            this.cesButton39.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton39.Name = "cesButton39";
            this.cesButton39.Size = new System.Drawing.Size(50, 40);
            this.cesButton39.TabIndex = 45;
            this.cesButton39.TabStop = false;
            this.cesButton39.UseVisualStyleBackColor = false;
            // 
            // cesButton40
            // 
            this.cesButton40.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton40.CesBorderThickness = 1;
            this.cesButton40.CesBorderVisible = false;
            this.cesButton40.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton40.FlatAppearance.BorderSize = 0;
            this.cesButton40.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton40.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton40.Location = new System.Drawing.Point(218, 222);
            this.cesButton40.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton40.Name = "cesButton40";
            this.cesButton40.Size = new System.Drawing.Size(50, 40);
            this.cesButton40.TabIndex = 46;
            this.cesButton40.TabStop = false;
            this.cesButton40.UseVisualStyleBackColor = false;
            // 
            // cesButton41
            // 
            this.cesButton41.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton41.CesBorderThickness = 1;
            this.cesButton41.CesBorderVisible = false;
            this.cesButton41.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton41.FlatAppearance.BorderSize = 0;
            this.cesButton41.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton41.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton41.Location = new System.Drawing.Point(272, 222);
            this.cesButton41.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton41.Name = "cesButton41";
            this.cesButton41.Size = new System.Drawing.Size(50, 40);
            this.cesButton41.TabIndex = 47;
            this.cesButton41.TabStop = false;
            this.cesButton41.UseVisualStyleBackColor = false;
            // 
            // cesButton42
            // 
            this.cesButton42.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cesButton42.CesBorderThickness = 1;
            this.cesButton42.CesBorderVisible = false;
            this.cesButton42.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.None;
            this.cesButton42.FlatAppearance.BorderSize = 0;
            this.cesButton42.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.cesButton42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.cesButton42.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cesButton42.Location = new System.Drawing.Point(326, 222);
            this.cesButton42.Margin = new System.Windows.Forms.Padding(2);
            this.cesButton42.Name = "cesButton42";
            this.cesButton42.Size = new System.Drawing.Size(50, 40);
            this.cesButton42.TabIndex = 48;
            this.cesButton42.TabStop = false;
            this.cesButton42.UseVisualStyleBackColor = false;
            // 
            // lblYear
            // 
            this.lblYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblYear.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblYear.CesShowUnderLine = false;
            this.lblYear.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblYear.CesUnderlineThickness = 1;
            this.lblYear.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblYear.Location = new System.Drawing.Point(252, 6);
            this.lblYear.Name = "lblYear";
            this.lblYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblYear.Size = new System.Drawing.Size(76, 20);
            this.lblYear.TabIndex = 37;
            this.lblYear.Text = "1402";
            this.lblYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMonthName
            // 
            this.lblMonthName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMonthName.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblMonthName.CesShowUnderLine = false;
            this.lblMonthName.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblMonthName.CesUnderlineThickness = 1;
            this.lblMonthName.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblMonthName.Location = new System.Drawing.Point(421, 6);
            this.lblMonthName.Name = "lblMonthName";
            this.lblMonthName.Size = new System.Drawing.Size(113, 20);
            this.lblMonthName.TabIndex = 38;
            this.lblMonthName.Text = "اردیبهشت";
            this.lblMonthName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoToToday
            // 
            this.btnGoToToday.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGoToToday.BackColor = System.Drawing.SystemColors.Control;
            this.btnGoToToday.CesBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoToToday.CesBorderColor = System.Drawing.Color.Black;
            this.btnGoToToday.CesBorderRadius = 10;
            this.btnGoToToday.CesBorderThickness = 1;
            this.btnGoToToday.CesBorderVisible = false;
            this.btnGoToToday.CesColorTemplate = Ces.WinForm.UI.CesButton.ColorTemplateEnum.Dark;
            this.btnGoToToday.CesFont = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnGoToToday.CesForeColor = System.Drawing.Color.White;
            this.btnGoToToday.CesIcon = null;
            this.btnGoToToday.CesIconAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoToToday.CesMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoToToday.CesMouseOverColor = System.Drawing.Color.Gray;
            this.btnGoToToday.CesShowIcon = false;
            this.btnGoToToday.CesShowText = true;
            this.btnGoToToday.CesText = "امروز";
            this.btnGoToToday.CesTextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnGoToToday.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoToToday.Location = new System.Drawing.Point(507, 343);
            this.btnGoToToday.Margin = new System.Windows.Forms.Padding(10);
            this.btnGoToToday.Name = "btnGoToToday";
            this.btnGoToToday.Size = new System.Drawing.Size(74, 35);
            this.btnGoToToday.TabIndex = 39;
            this.btnGoToToday.TabStop = false;
            this.btnGoToToday.Click += new System.EventHandler(this.btnGoToToday_Click);
            // 
            // flpWeekNumbers
            // 
            this.flpWeekNumbers.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo1);
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo2);
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo3);
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo4);
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo5);
            this.flpWeekNumbers.Controls.Add(this.lblWeekNo6);
            this.flpWeekNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWeekNumbers.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWeekNumbers.Location = new System.Drawing.Point(0, 0);
            this.flpWeekNumbers.Margin = new System.Windows.Forms.Padding(2);
            this.flpWeekNumbers.Name = "flpWeekNumbers";
            this.flpWeekNumbers.Size = new System.Drawing.Size(30, 265);
            this.flpWeekNumbers.TabIndex = 37;
            // 
            // lblWeekNo1
            // 
            this.lblWeekNo1.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo1.CesShowUnderLine = false;
            this.lblWeekNo1.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo1.CesUnderlineThickness = 1;
            this.lblWeekNo1.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo1.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo1.Location = new System.Drawing.Point(2, 2);
            this.lblWeekNo1.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo1.Name = "lblWeekNo1";
            this.lblWeekNo1.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo1.TabIndex = 2;
            this.lblWeekNo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeekNo2
            // 
            this.lblWeekNo2.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo2.CesShowUnderLine = false;
            this.lblWeekNo2.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo2.CesUnderlineThickness = 1;
            this.lblWeekNo2.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo2.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo2.Location = new System.Drawing.Point(2, 46);
            this.lblWeekNo2.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo2.Name = "lblWeekNo2";
            this.lblWeekNo2.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo2.TabIndex = 3;
            this.lblWeekNo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeekNo3
            // 
            this.lblWeekNo3.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo3.CesShowUnderLine = false;
            this.lblWeekNo3.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo3.CesUnderlineThickness = 1;
            this.lblWeekNo3.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo3.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo3.Location = new System.Drawing.Point(2, 90);
            this.lblWeekNo3.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo3.Name = "lblWeekNo3";
            this.lblWeekNo3.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo3.TabIndex = 4;
            this.lblWeekNo3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeekNo4
            // 
            this.lblWeekNo4.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo4.CesShowUnderLine = false;
            this.lblWeekNo4.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo4.CesUnderlineThickness = 1;
            this.lblWeekNo4.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo4.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo4.Location = new System.Drawing.Point(2, 134);
            this.lblWeekNo4.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo4.Name = "lblWeekNo4";
            this.lblWeekNo4.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo4.TabIndex = 5;
            this.lblWeekNo4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeekNo5
            // 
            this.lblWeekNo5.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo5.CesShowUnderLine = false;
            this.lblWeekNo5.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo5.CesUnderlineThickness = 1;
            this.lblWeekNo5.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo5.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo5.Location = new System.Drawing.Point(2, 178);
            this.lblWeekNo5.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo5.Name = "lblWeekNo5";
            this.lblWeekNo5.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo5.TabIndex = 6;
            this.lblWeekNo5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblWeekNo6
            // 
            this.lblWeekNo6.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblWeekNo6.CesShowUnderLine = false;
            this.lblWeekNo6.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblWeekNo6.CesUnderlineThickness = 1;
            this.lblWeekNo6.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblWeekNo6.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblWeekNo6.Location = new System.Drawing.Point(2, 222);
            this.lblWeekNo6.Margin = new System.Windows.Forms.Padding(2);
            this.lblWeekNo6.Name = "lblWeekNo6";
            this.lblWeekNo6.Size = new System.Drawing.Size(25, 40);
            this.lblWeekNo6.TabIndex = 8;
            this.lblWeekNo6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlWeekNumbers
            // 
            this.pnlWeekNumbers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeekNumbers.Controls.Add(this.lineWeekNumber);
            this.pnlWeekNumbers.Controls.Add(this.flpWeekNumbers);
            this.pnlWeekNumbers.Location = new System.Drawing.Point(173, 76);
            this.pnlWeekNumbers.Margin = new System.Windows.Forms.Padding(30);
            this.pnlWeekNumbers.Name = "pnlWeekNumbers";
            this.pnlWeekNumbers.Size = new System.Drawing.Size(30, 265);
            this.pnlWeekNumbers.TabIndex = 44;
            // 
            // lineWeekNumber
            // 
            this.lineWeekNumber.CesBackColor = System.Drawing.Color.Empty;
            this.lineWeekNumber.CesLineColor = System.Drawing.Color.Silver;
            this.lineWeekNumber.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineWeekNumber.CesLineWidth = 1F;
            this.lineWeekNumber.CesQuality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.lineWeekNumber.CesVertical = true;
            this.lineWeekNumber.Dock = System.Windows.Forms.DockStyle.Right;
            this.lineWeekNumber.Location = new System.Drawing.Point(25, 0);
            this.lineWeekNumber.Margin = new System.Windows.Forms.Padding(0);
            this.lineWeekNumber.Name = "lineWeekNumber";
            this.lineWeekNumber.Size = new System.Drawing.Size(5, 265);
            this.lineWeekNumber.TabIndex = 38;
            // 
            // pbNextMonth
            // 
            this.pbNextMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNextMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNextMonth.Image = global::Ces.WinForm.UI.Properties.Resources.CalendarDownArrow;
            this.pbNextMonth.Location = new System.Drawing.Point(540, 6);
            this.pbNextMonth.Name = "pbNextMonth";
            this.pbNextMonth.Size = new System.Drawing.Size(20, 20);
            this.pbNextMonth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbNextMonth.TabIndex = 45;
            this.pbNextMonth.TabStop = false;
            this.pbNextMonth.Click += new System.EventHandler(this.pbNextMonth_Click);
            // 
            // pbPreviousMonth
            // 
            this.pbPreviousMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreviousMonth.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreviousMonth.Image = global::Ces.WinForm.UI.Properties.Resources.CalendarUpArrow;
            this.pbPreviousMonth.Location = new System.Drawing.Point(561, 6);
            this.pbPreviousMonth.Name = "pbPreviousMonth";
            this.pbPreviousMonth.Size = new System.Drawing.Size(20, 20);
            this.pbPreviousMonth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreviousMonth.TabIndex = 46;
            this.pbPreviousMonth.TabStop = false;
            this.pbPreviousMonth.Click += new System.EventHandler(this.pbPreviousMonth_Click);
            // 
            // pbNextYear
            // 
            this.pbNextYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbNextYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbNextYear.Image = global::Ces.WinForm.UI.Properties.Resources.CalendarDownArrow;
            this.pbNextYear.Location = new System.Drawing.Point(205, 6);
            this.pbNextYear.Name = "pbNextYear";
            this.pbNextYear.Size = new System.Drawing.Size(20, 20);
            this.pbNextYear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbNextYear.TabIndex = 49;
            this.pbNextYear.TabStop = false;
            this.pbNextYear.Click += new System.EventHandler(this.pbNextYear_Click);
            // 
            // pbPreviousYear
            // 
            this.pbPreviousYear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pbPreviousYear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPreviousYear.Image = global::Ces.WinForm.UI.Properties.Resources.CalendarUpArrow;
            this.pbPreviousYear.Location = new System.Drawing.Point(226, 6);
            this.pbPreviousYear.Name = "pbPreviousYear";
            this.pbPreviousYear.Size = new System.Drawing.Size(20, 20);
            this.pbPreviousYear.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbPreviousYear.TabIndex = 48;
            this.pbPreviousYear.TabStop = false;
            this.pbPreviousYear.Click += new System.EventHandler(this.pbPreviousYear_Click);
            // 
            // pnlWeekDays
            // 
            this.pnlWeekDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlWeekDays.Controls.Add(this.lineWeekDays);
            this.pnlWeekDays.Controls.Add(this.flpWeekDays);
            this.pnlWeekDays.Location = new System.Drawing.Point(202, 42);
            this.pnlWeekDays.Margin = new System.Windows.Forms.Padding(0);
            this.pnlWeekDays.Name = "pnlWeekDays";
            this.pnlWeekDays.Size = new System.Drawing.Size(378, 35);
            this.pnlWeekDays.TabIndex = 50;
            // 
            // lineWeekDays
            // 
            this.lineWeekDays.CesBackColor = System.Drawing.Color.Empty;
            this.lineWeekDays.CesLineColor = System.Drawing.Color.Silver;
            this.lineWeekDays.CesLineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lineWeekDays.CesLineWidth = 1F;
            this.lineWeekDays.CesQuality = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            this.lineWeekDays.CesVertical = false;
            this.lineWeekDays.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lineWeekDays.Location = new System.Drawing.Point(0, 30);
            this.lineWeekDays.Margin = new System.Windows.Forms.Padding(0);
            this.lineWeekDays.Name = "lineWeekDays";
            this.lineWeekDays.Size = new System.Drawing.Size(378, 5);
            this.lineWeekDays.TabIndex = 38;
            // 
            // flpWeekDays
            // 
            this.flpWeekDays.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek1);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek2);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek3);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek4);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek5);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek6);
            this.flpWeekDays.Controls.Add(this.lblDayOfWeek7);
            this.flpWeekDays.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWeekDays.Location = new System.Drawing.Point(0, 0);
            this.flpWeekDays.Margin = new System.Windows.Forms.Padding(2);
            this.flpWeekDays.Name = "flpWeekDays";
            this.flpWeekDays.Size = new System.Drawing.Size(378, 35);
            this.flpWeekDays.TabIndex = 37;
            // 
            // lblDayOfWeek1
            // 
            this.lblDayOfWeek1.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek1.CesShowUnderLine = false;
            this.lblDayOfWeek1.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek1.CesUnderlineThickness = 1;
            this.lblDayOfWeek1.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek1.Location = new System.Drawing.Point(2, 2);
            this.lblDayOfWeek1.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek1.Name = "lblDayOfWeek1";
            this.lblDayOfWeek1.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek1.TabIndex = 7;
            this.lblDayOfWeek1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek2
            // 
            this.lblDayOfWeek2.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek2.CesShowUnderLine = false;
            this.lblDayOfWeek2.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek2.CesUnderlineThickness = 1;
            this.lblDayOfWeek2.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek2.Location = new System.Drawing.Point(56, 2);
            this.lblDayOfWeek2.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek2.Name = "lblDayOfWeek2";
            this.lblDayOfWeek2.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek2.TabIndex = 8;
            this.lblDayOfWeek2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek3
            // 
            this.lblDayOfWeek3.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek3.CesShowUnderLine = false;
            this.lblDayOfWeek3.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek3.CesUnderlineThickness = 1;
            this.lblDayOfWeek3.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek3.Location = new System.Drawing.Point(110, 2);
            this.lblDayOfWeek3.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek3.Name = "lblDayOfWeek3";
            this.lblDayOfWeek3.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek3.TabIndex = 9;
            this.lblDayOfWeek3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek4
            // 
            this.lblDayOfWeek4.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek4.CesShowUnderLine = false;
            this.lblDayOfWeek4.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek4.CesUnderlineThickness = 1;
            this.lblDayOfWeek4.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek4.Location = new System.Drawing.Point(164, 2);
            this.lblDayOfWeek4.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek4.Name = "lblDayOfWeek4";
            this.lblDayOfWeek4.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek4.TabIndex = 10;
            this.lblDayOfWeek4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek5
            // 
            this.lblDayOfWeek5.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek5.CesShowUnderLine = false;
            this.lblDayOfWeek5.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek5.CesUnderlineThickness = 1;
            this.lblDayOfWeek5.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek5.Location = new System.Drawing.Point(218, 2);
            this.lblDayOfWeek5.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek5.Name = "lblDayOfWeek5";
            this.lblDayOfWeek5.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek5.TabIndex = 11;
            this.lblDayOfWeek5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek6
            // 
            this.lblDayOfWeek6.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek6.CesShowUnderLine = false;
            this.lblDayOfWeek6.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek6.CesUnderlineThickness = 1;
            this.lblDayOfWeek6.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek6.Location = new System.Drawing.Point(272, 2);
            this.lblDayOfWeek6.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek6.Name = "lblDayOfWeek6";
            this.lblDayOfWeek6.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek6.TabIndex = 12;
            this.lblDayOfWeek6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeek7
            // 
            this.lblDayOfWeek7.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblDayOfWeek7.CesShowUnderLine = false;
            this.lblDayOfWeek7.CesUnderlineColor = System.Drawing.Color.Black;
            this.lblDayOfWeek7.CesUnderlineThickness = 1;
            this.lblDayOfWeek7.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblDayOfWeek7.Location = new System.Drawing.Point(326, 2);
            this.lblDayOfWeek7.Margin = new System.Windows.Forms.Padding(2);
            this.lblDayOfWeek7.Name = "lblDayOfWeek7";
            this.lblDayOfWeek7.Size = new System.Drawing.Size(50, 25);
            this.lblDayOfWeek7.TabIndex = 13;
            this.lblDayOfWeek7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlSide.Controls.Add(this.lblEvents);
            this.pnlSide.Controls.Add(this.lblMonthOfPanel);
            this.pnlSide.Controls.Add(this.lblDayOfWeekOfPanel);
            this.pnlSide.Controls.Add(this.lblYearOfPanel);
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(170, 381);
            this.pnlSide.TabIndex = 51;
            // 
            // lblEvents
            // 
            this.lblEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEvents.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEvents.ForeColor = System.Drawing.Color.Khaki;
            this.lblEvents.Location = new System.Drawing.Point(0, 173);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblEvents.Size = new System.Drawing.Size(170, 208);
            this.lblEvents.TabIndex = 55;
            // 
            // lblMonthOfPanel
            // 
            this.lblMonthOfPanel.CesDegree = Ces.WinForm.UI.CesLabelRotationDegreeEnum.Rotate0;
            this.lblMonthOfPanel.CesShowUnderLine = false;
            this.lblMonthOfPanel.CesUnderlineColor = System.Drawing.Color.Tomato;
            this.lblMonthOfPanel.CesUnderlineThickness = 2;
            this.lblMonthOfPanel.CesUnderlineType = System.Drawing.Drawing2D.DashStyle.Solid;
            this.lblMonthOfPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMonthOfPanel.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMonthOfPanel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblMonthOfPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMonthOfPanel.Location = new System.Drawing.Point(0, 77);
            this.lblMonthOfPanel.Name = "lblMonthOfPanel";
            this.lblMonthOfPanel.Size = new System.Drawing.Size(170, 96);
            this.lblMonthOfPanel.TabIndex = 0;
            this.lblMonthOfPanel.Text = "15 Apr";
            this.lblMonthOfPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDayOfWeekOfPanel
            // 
            this.lblDayOfWeekOfPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDayOfWeekOfPanel.Font = new System.Drawing.Font("Georgia", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDayOfWeekOfPanel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.lblDayOfWeekOfPanel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDayOfWeekOfPanel.Location = new System.Drawing.Point(0, 37);
            this.lblDayOfWeekOfPanel.Name = "lblDayOfWeekOfPanel";
            this.lblDayOfWeekOfPanel.Size = new System.Drawing.Size(170, 40);
            this.lblDayOfWeekOfPanel.TabIndex = 52;
            this.lblDayOfWeekOfPanel.Text = "Sun";
            this.lblDayOfWeekOfPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblYearOfPanel
            // 
            this.lblYearOfPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblYearOfPanel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYearOfPanel.ForeColor = System.Drawing.Color.DarkGray;
            this.lblYearOfPanel.Location = new System.Drawing.Point(0, 0);
            this.lblYearOfPanel.Name = "lblYearOfPanel";
            this.lblYearOfPanel.Size = new System.Drawing.Size(170, 37);
            this.lblYearOfPanel.TabIndex = 54;
            this.lblYearOfPanel.Text = "2018";
            this.lblYearOfPanel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CesCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlSide);
            this.Controls.Add(this.pnlWeekDays);
            this.Controls.Add(this.pbNextYear);
            this.Controls.Add(this.pbPreviousYear);
            this.Controls.Add(this.pbPreviousMonth);
            this.Controls.Add(this.pbNextMonth);
            this.Controls.Add(this.pnlWeekNumbers);
            this.Controls.Add(this.btnGoToToday);
            this.Controls.Add(this.lblMonthName);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.flpCalendar);
            this.Name = "CesCalendar";
            this.Size = new System.Drawing.Size(585, 381);
            this.Load += new System.EventHandler(this.CesCalendar_Load);
            this.BackColorChanged += new System.EventHandler(this.CesCalendar_BackColorChanged);
            this.ForeColorChanged += new System.EventHandler(this.CesCalendar_ForeColorChanged);
            this.flpCalendar.ResumeLayout(false);
            this.flpWeekNumbers.ResumeLayout(false);
            this.pnlWeekNumbers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbNextMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousMonth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbNextYear)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviousYear)).EndInit();
            this.pnlWeekDays.ResumeLayout(false);
            this.flpWeekDays.ResumeLayout(false);
            this.pnlSide.ResumeLayout(false);
            this.ResumeLayout(false);

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
