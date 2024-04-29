using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using RZAWeb.Data;
using RZAWeb.Models;

namespace RZAWeb.Controllers
{
    public class BookHotelRoomsController : Controller
    {
        private readonly RZAWebContext _context;
        //get the UserManager
        private readonly UserManager<ApplicationUser> _userManager;

        public BookHotelRoomsController(RZAWebContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookHotelRooms
        public async Task<IActionResult> Index()
        {
            return _context.BookHotelRooms != null ?
                        View(await _context.BookHotelRooms.ToListAsync()) :
                        Problem("Entity set 'RZAWebContext.BookHotelTickets'  is null.");
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookHotelRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BookHotelRooms == null)
            {
                return NotFound();
            }

            var bookHotelRooms = await _context.BookHotelRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bookHotelRooms == null)
            {
                return NotFound();
            }

            return View(bookHotelRooms);
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        // GET: BookHotelRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: BookHotelRooms/HotelInformation
        public IActionResult HotelInformation()
        {
            return View();
        }

        //prevents non-signed in users from accessing the page
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //This method saves a new booking to the database, gives users reward points and sends information to the booking confirmed page
        public async Task<IActionResult> BookingConfirmed([Bind("Id,BookingDate,FamilyRooms,DoubleRooms,SingleRooms")] BookHotelRooms bookHotelRooms)
        {
            if (ModelState.IsValid)
            {
                //get the currently logged in user and assign thier user id value to the zoobookings userid value, this makes it so that every zoo ticket is assigned to a user.
                bookHotelRooms.UserID = _userManager.GetUserId(User);

                //the booking time value in the database be automatically set to whenever the user booked it.
                bookHotelRooms.BookingTime = DateTime.Now;

                //Calculate the reward points that the users earned and add them onto thier account
                ApplicationUser user = await _userManager.GetUserAsync(User);
                var pointsEarned = 100 * bookHotelRooms.FamilyRooms + 50 * bookHotelRooms.DoubleRooms + 25 * bookHotelRooms.SingleRooms;
                user.RewardPoints += pointsEarned;

                //calculate the total price
                var totalPrice = bookHotelRooms.FamilyRooms * 150 + bookHotelRooms.DoubleRooms * 100 + bookHotelRooms.SingleRooms * 50;

                // stores all the information needed to send to the booking confirmed page
                ViewData["FamilyRooms"] = bookHotelRooms.FamilyRooms;
                ViewData["DoubleRooms"] = bookHotelRooms.DoubleRooms;
                ViewData["SingleRooms"] = bookHotelRooms.SingleRooms;
                ViewData["TotalPrice"] = totalPrice;
                ViewData["PointsEarned"] = pointsEarned;
                ViewData["UserPoints"] = user.RewardPoints;
                ViewData["UserEmail"] = user.Email;

                //save everything
                _userManager.UpdateAsync(user);
                _context.Add(bookHotelRooms);
                await _context.SaveChangesAsync();
            }
            //will send users to the booking confirmed page
            return View();
        }
    }
}
