﻿using BlogModeling.Models;

namespace BlogModeling.ViewModels
{
    public class CreateBlogViewModel
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public DateOnly PublicationDate { get; set; }
        public DateOnly? EditedDate { get; set; }
        public required IFormFile Image { get; set; }
        public List<Tag>? Tag { get; set; }
        public List<Category>? Category { get; set; }

    }
}
