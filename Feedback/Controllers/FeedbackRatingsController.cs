using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feedback_DAL.Data;
using Feedback_DAL.Models;
using Feedback_Service.Interface;

namespace Feedback.Controllers
{
    public class FeedbackRatingsController : Controller
    {
        private readonly IFeedback _feedback;


        public FeedbackRatingsController(IFeedback context)
        {
            _feedback = context;
        }

        // GET: FeedbackRatings
        public IActionResult Index()
        {
            return View();
        }

        // GET: FeedbackRatings/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = _feedback.GetFeedbackById(id);
            if (feedbackRating == null)
            {
                return NotFound();
            }

            return View(feedbackRating);
        }

        // GET: FeedbackRatings/Create
        public IActionResult Create()
        {
            int? ProductId = 1;
            if (ProductId == null)
            {

                return NotFound();

            }
            FeedbackRating feedbackRating = new FeedbackRating();
            feedbackRating.UserId = 1;
            feedbackRating.ProductId = (Int32)ProductId;
            return View(feedbackRating);

        }

        // POST: FeedbackRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,UserId,ProductId,Rating,Comment")] FeedbackRating feedbackRating)
        {
            if (ModelState.IsValid)
            {
                _feedback.AddFeedback(feedbackRating);
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackRating);
        }

        // GET: FeedbackRatings/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = _feedback.GetFeedbackById(id);
            if (feedbackRating == null)
            {
                return NotFound();
            }
            return View(feedbackRating);
        }

        // POST: FeedbackRatings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,UserId,ProductId,Rating,Comment")] FeedbackRating feedbackRating)
        {
            if (id != feedbackRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _feedback.UpdateFeedback(feedbackRating);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackRatingExists(feedbackRating.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackRating);
        }

        // GET: FeedbackRatings/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = _feedback.GetFeedbackById(id);
            if (feedbackRating == null)
            {
                return NotFound();
            }

            return View(feedbackRating);
        }

        // POST: FeedbackRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _feedback.DeleteFeedbackById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackRatingExists(int id)
        {
            return _feedback.Any(id);
        }
    }
}
