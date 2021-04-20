using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using PocketHorseTrainer.API.Models;

namespace PocketHorseTrainer.API.Pages
{
    [AllowAnonymous]
    public class ConfirmEmailChangeModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;

        public ConfirmEmailChangeModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? userId, string email, string code)
        {
            if (userId == null || email == null || code == null)
            {
                return BadRequest();
            }

            var user = await userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            {
                return NotFound();
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await userManager.ChangeEmailAsync(user, email, code);
            StatusMessage = result.Succeeded ? "Email has been changed successfully." : "Could not change that email.";
            return Page();
        }
    }
}
