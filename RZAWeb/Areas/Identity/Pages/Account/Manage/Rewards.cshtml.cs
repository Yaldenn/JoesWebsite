// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RZAWeb.Data;
using RZAWeb.Models;

namespace RZAWeb.Areas.Identity.Pages.Account.Manage
{
    public class RewardsModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RZAWebContext _context;

        public RewardsModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RZAWebContext rzaWebContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = rzaWebContext;
        }
        public string Username { get; set; }
        [TempData]
        public string StatusMessage { get; set; }
        [BindProperty]
        public InputModel Input { get; set; }

        public int UserRewardPoints { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
        public int RewardPointCost { get; set; }
        public string RewardImage { get; set; }
        public List<Rewards> Rewards { get; set; }
        public class InputModel
        {
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user, List<Rewards> rewards)
        {
            UserRewardPoints = user.RewardPoints;
            Rewards = rewards;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            var rewards = _context.Rewards.ToList();
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user, rewards);
            return Page();
        }

    }
}
