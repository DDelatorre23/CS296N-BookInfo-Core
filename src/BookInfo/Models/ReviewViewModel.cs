﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookInfo.Models
{
    public class ReviewViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public Review BookReview { get; set; }

        [Display(Name ="Test Field")]
        public string TestField { get; set; }
    }
}
