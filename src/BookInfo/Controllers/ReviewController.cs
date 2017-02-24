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
            ViewBag.BookTitle = title;
            ViewBag.Id = id;
            // TODO Create a view model
            /*
            Review review = new Review();
            review.Body = "Text of the review";
            review.Rating = 5;
            return View(review);
            */
            return View();
        }

        [HttpPost]
        public IActionResult ReviewForm(int bookId, int Rating, string Body)
        {
            // Get the full model for the book being reviewed
            Book book = (from b in bookRepo.GetAllBooks()
                       where b.BookId == bookId
                       select b).FirstOrDefault<Book>();

            // Add the review information
            book.BookReviews.Add(new Review { Rating = Rating, Body = Body });
            bookRepo.Update(book);

            return RedirectToAction("Index", "Book");
        }

    }
}
