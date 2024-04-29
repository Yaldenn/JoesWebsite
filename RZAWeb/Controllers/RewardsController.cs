using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RZAWeb.Data;
using RZAWeb.Models;

namespace RZAWeb.Controllers
{
    //prevents non-signed in users from accessing the page
    [Authorize]
    public class RewardsController : Controller
    {
        private readonly RZAWebContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RewardsController(RZAWebContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Rewards
        public async Task<IActionResult> Index()
        {
              return _context.Rewards != null ? 
                          View(await _context.Rewards.ToListAsync()) :
                          Problem("Entity set 'RZAWebContext.Rewards'  is null.");
        }

        // GET: Rewards/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewards == null)
            {
                return NotFound();
            }

            return View(rewards);
        }

        // GET: Rewards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rewards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RewardName,RewardDescription,RewardPoints,RewardImage")] Rewards rewards)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rewards);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rewards);
        }

        // GET: Rewards/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards.FindAsync(id);
            if (rewards == null)
            {
                return NotFound();
            }
            return View(rewards);
        }

        // POST: Rewards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,RewardName,RewardDescription,RewardPoints,RewardImage")] Rewards rewards)
        {
            if (id != rewards.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rewards);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RewardsExists(rewards.Id))
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
            return View(rewards);
        }

        // GET: Rewards/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Rewards == null)
            {
                return NotFound();
            }

            var rewards = await _context.Rewards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (rewards == null)
            {
                return NotFound();
            }

            return View(rewards);
        }

        // POST: Rewards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Rewards == null)
            {
                return Problem("Entity set 'RZAWebContext.Rewards'  is null.");
            }
            var rewards = await _context.Rewards.FindAsync(id);
            if (rewards != null)
            {
                _context.Rewards.Remove(rewards);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmRedeem(Rewards reward)
        {
            if (_context.Rewards == null)
            {
                return Problem();
            }
            //check if the user has enough points for the reward
            ApplicationUser user = await _userManager.GetUserAsync(User);
            if (user.RewardPoints >= reward.RewardPoints)
            {
                //take the points off of thier account
                user.RewardPoints -= reward.RewardPoints;

                //store the point cost to send to the redeem page
                ViewData["RewardCost"] = reward.RewardPoints;
                ViewData["UserPoints"] = user.RewardPoints;
                ViewData["UserEmail"] = user.Email;

                _userManager.UpdateAsync(user);
            }
            else
            {
                //Have a pop up toast message notifying them that they do not have enough points for this reward
            }
            return View();
        }
        private bool RewardsExists(string id)
        {
          return (_context.Rewards?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
