using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Feedback_DAL.Data;
using Feedback_DAL.Models;

namespace Feedback.Controllers
{
    public class FeedbackRatingsController : Controller
    {
        private readonly UsersDbContext _context;

        public FeedbackRatingsController(UsersDbContext context)
        {
            _context = context;
        }

        // GET: FeedbackRatings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feedbacks.ToListAsync());
        }

        // GET: FeedbackRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackRating == null)
            {
                return NotFound();
            }

            return View(feedbackRating);
        }

        // GET: FeedbackRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeedbackRatings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Rating,Comment")] FeedbackRating feedbackRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedbackRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feedbackRating);
        }

        // GET: FeedbackRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = await _context.Feedbacks.FindAsync(id);
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
        public async Task<IActionResult> Edit(int id, [Bind("Id,Rating,Comment")] FeedbackRating feedbackRating)
        {
            if (id != feedbackRating.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedbackRating);
                    await _context.SaveChangesAsync();
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
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedbackRating = await _context.Feedbacks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feedbackRating == null)
            {
                return NotFound();
            }

            return View(feedbackRating);
        }

        // POST: FeedbackRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedbackRating = await _context.Feedbacks.FindAsync(id);
            _context.Feedbacks.Remove(feedbackRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackRatingExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Id == id);
        }
    }
}
