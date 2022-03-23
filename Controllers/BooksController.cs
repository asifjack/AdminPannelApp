using AdminPannelApp.Repository.Interface;
using AdminPannelApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPannelApp.Controllers
{
    public class BooksController : Controller
    {
        public GenericInterface<BookWithAuthorViewModel> BookServices { get; }
        public BooksController(GenericInterface<BookWithAuthorViewModel> _book)
        {
            BookServices = _book;
        }
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetBook()
        {
            var books = BookServices.GetData();
            return Json(books);
        }
    }
}
