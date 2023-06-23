using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SumanWeb_Temp.Data;
using SumanWeb_Temp.Models;

namespace SumanWeb_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            if(Id !=null && Id != 0)
            {
                Category = _db.Categories.Find(Id);
            }


        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "The category has been updated successfully";
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
