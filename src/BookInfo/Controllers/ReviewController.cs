using BookInfo.Models;
using BookInfo.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Controllers
{
    public class ReviewController : Controller
    {
        private IBookRepository bookRepo;

        public ReviewController(IBookRepository repo)
        {
            bookRepo = repo;
        }

        [HttpGet]
        public ViewResult ReviewForm(string title, int id)
        {
            var reviewVm = new ReviewViewModel();
            reviewVm.BookReview = new Review { Body = "Write review here", Rating = 3 };
            reviewVm.BookId = id;
            reviewVm.Title = title;
           
            return View(reviewVm);
        }

        [HttpPost]
        public IActionResult ReviewForm(ReviewViewModel reviewVm)
        {
            // Get the full model for the book being reviewed
            Book book = (from b in bookRepo.GetAllBooks()
                         where b.BookId == reviewVm.BookId
                         select b).FirstOrDefault<Book>();
            book.BookReviews.Add(reviewVm.BookReview);
            bookRepo.Update(book);
            return RedirectToAction("Index", "Book");
        }

    }
}
