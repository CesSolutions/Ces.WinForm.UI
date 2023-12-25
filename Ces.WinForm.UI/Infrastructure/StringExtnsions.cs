using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{

    /// <summary>
    /// this class uses as input parameter for [GetnerateListOfItems] extension method
    /// </summary>
    public class StringOptions
    {
        public StringOptions(
            bool showItemNumber = true,
            string itemNumberSeparator = ".")
        {
            AddItemNumber = showItemNumber;
            ItemNumberSeparator = itemNumberSeparator;
        }

        public bool AddItemNumber { get; set; } = true;
        public string ItemNumberSeparator { get; set; } = ".";
    }


    /// <summary>
    /// Convert IList<string> to a list of string items
    /// </summary>
    public static class StringExtnsions
    {
        public static string GenerateListOfItems(this IList<string>? source, StringOptions? options = null)
        {
            if (source == null)
                return string.Empty;

            if (options == null)
                options = new StringOptions();

            var result = new StringBuilder();
            var counter = 0;

            foreach (var item in source)
            {
                counter += 1;

                string currentItem =
                    (options.AddItemNumber ? counter.ToString() + options.ItemNumberSeparator : string.Empty) +
                    item.ToString();

                result.Append(currentItem + Environment.NewLine);
            }

            return result.ToString();
        }
    }
}
