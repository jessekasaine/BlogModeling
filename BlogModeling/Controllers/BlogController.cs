using BlogModeling.Data;
using BlogModeling.Interfaces;
using BlogModeling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogModeling.ViewModels;

namespace BlogModeling.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IPhotoService _photoService;
        public BlogController(AppDbContext db, IPhotoService photoService)
        {
            _db = db;
            _photoService = photoService;
        }

        public async Task<IActionResult> Index()
        {
            var Blogs = await _db.Blogs.ToListAsync();
            return View(Blogs);
        }
        //[Bind("Id,Title,Content,Category,PublicationDate,EditedDate,Image,Tag,Category")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel blogVM)
        {
            if (ModelState.IsValid)
            {
                
                var result = await _photoService.AddPhotoAsync(blogVM.Image);
                var blog = new Blog
                {
                    Title = blogVM.Title,
                    Content = blogVM.Content,
                    PublicationDate = blogVM.PublicationDate,
                    EditedDate = blogVM.EditedDate,
                    Tag = blogVM.Tag,
                    Category = blogVM.Category,
                    Image = result.Url.ToString()
                };
                _db.Add(blog);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError("", "Photo upload failed");
            }
            return View(blogVM);
        }
    }
}
