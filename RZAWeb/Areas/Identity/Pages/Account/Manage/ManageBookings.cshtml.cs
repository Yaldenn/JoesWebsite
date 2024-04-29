// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RZAWeb.Data;
using RZAWeb.Models;

namespace RZAWeb.Areas.Identity.Pages.Account.Manage
{
    public class ManageBookingsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ResetAuthenticatorModel> _logger;
        private readonly RZAWebContext _context;

        public ManageBookingsModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ResetAuthenticatorModel> logger,
            RZAWebContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
        }

        [TempData]
        public string StatusMessage { get; set; }
        public string BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public string UserId { get; set; }
        public List<BookZooTickets> ZooBookings { get; set; }

        private async Task LoadAsync(ApplicationUser user, List<BookZooTickets> zooBookings)
        {
            UserId = await _userManager.GetUserIdAsync(user);
            ZooBookings = zooBookings;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var bookings = _context.BookZooTickets.ToList();
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user, bookings);
            return Page();
        }
    }
}
