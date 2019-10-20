using MvcAlphabaticPagination_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcAlphabaticPagination_Demo.ViewModels
{
    public class AlphabeticCustomerPagingViewModel
    {
        public List<string> CustomerName { get; set; }
        public IList<string> Alphabet
        {
            get
            {
                var alphabet = Enumerable.Range(65, 26).Select(i => ((char)i).ToString()).ToList();
                alphabet.Insert(0, "All");
                return alphabet;
            }
        }
        public List<string> FirstLetters { get; set; }
        public string SelectedLetter { get; set; }
        public bool NamesStartWithNumbers
        {
            get
            {
                var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());
                return FirstLetters.Intersect(numbers).Any();
            }
        }
    }
}