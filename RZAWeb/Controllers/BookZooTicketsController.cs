using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RZAWeb.Data;
using RZAWeb.Models;

namespace RZAWeb.Controllers
{
    public class BookZooTicketsController : Controller
    {
        private readonly RZAWebContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookZooTicketsController(RZAWebContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookZooTickets
        public async Task<IActionResult> Index()
        {
              return _context.BookZooTickets != null ? 
                          View(await _context.BookZooTickets.ToListAsync()) :
                          Problem("Entity set 'RZAWebContext.BookZooTickets'  is null.");
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookZooTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookZooTickets == null)
            {
                return NotFound();
            }

            var bookZooTickets = await _context.BookZooTickets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookZooTickets == null)
            {
                return NotFound();
            }

            return View(bookZooTickets);
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookZooTickets/Create
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult ZooInformation()
        {
            return View();
        }

        public IActionResult EducationalVisits()
        {
            return View();
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BookingConfirmed([Bind("Id,BookingDate,ChildTickets,AdultTickets")] BookZooTickets bookZooTickets)
        {
            if (ModelState.IsValid)
            {
                //get the currently logged in user and assign thier user id value to the zoobookings userid value, this makes it so that every zoo ticket is assigned to a user.
                bookZooTickets.UserID = _userManager.GetUserId(User);

                //the booking time value in the database be automatically set to whenever the user booked it.
                bookZooTickets.BookingTime = DateTime.Now;

                //Calculate the reward points that the users earned and add them onto thier account
                ApplicationUser user = await _userManager.GetUserAsync(User);
                var pointsEarned = 50 * bookZooTickets.AdultTickets + 25 * bookZooTickets.ChildTickets;
                user.RewardPoints += pointsEarned;

                //calculate the total price
                var totalPrice = bookZooTickets.AdultTickets * 14.99 + bookZooTickets.ChildTickets * 9.99;

                //stores all the information needed to send to the booking confirmed page
                ViewData["AdultTickets"] = bookZooTickets.AdultTickets;
                ViewData["ChildTickets"] = bookZooTickets.ChildTickets;
                ViewData["TotalPrice"] = totalPrice;
                ViewData["PointsEarned"] = pointsEarned;
                ViewData["UserPoints"] = user.RewardPoints;
                ViewData["UserEmail"] = user.Email;

                _userManager.UpdateAsync(user);

                _context.Add(bookZooTickets);
                await _context.SaveChangesAsync();
            }
            return View();
        }

    }
}
