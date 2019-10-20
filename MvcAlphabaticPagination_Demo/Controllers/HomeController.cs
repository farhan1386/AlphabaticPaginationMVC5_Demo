using MvcAlphabaticPagination_Demo.Models;
using MvcAlphabaticPagination_Demo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAlphabaticPagination_Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly CustomerContext db = new CustomerContext();

        public ActionResult Index(string selectedLetter)
        {
            var viewModel = new AlphabeticCustomerPagingViewModel { SelectedLetter = selectedLetter };

            viewModel.FirstLetters =db.Customers
            .GroupBy(c => c.FirstName.Substring(0, 1))
            .Select(x => x.Key.ToUpper())
            .ToList();

            if (string.IsNullOrEmpty(selectedLetter) || selectedLetter == "All")
            {
                viewModel.CustomerName = db.Customers
                    .Select(c => c.FirstName)
                    .ToList();
            }
            else
            {
                if (selectedLetter == "0-9")
                {
                    var numbers = Enumerable.Range(0, 10).Select(i => i.ToString());
                    viewModel.CustomerName = db.Customers
                        .Where(p => numbers.Contains(p.FirstName.Substring(0, 1)))
                        .Select(p => p.FirstName)
                        .ToList();
                }
                else
                {
                    viewModel.CustomerName = db.Customers
                        .Where(p => p.FirstName.StartsWith(selectedLetter))
                        .Select(p => p.FirstName)
                        .ToList();
                }
            }

                return View(viewModel);
        }
    }
}