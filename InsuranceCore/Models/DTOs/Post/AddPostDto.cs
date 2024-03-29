﻿namespace InsuranceCore.Models.DTOs.Post
{
    /// <summary>
    /// Add Dto type of <see cref="Post"/>.
    /// </summary>
    public class AddPostDto : ADto, IPostDto
    {
        public string Content { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string Name { get; set; }

        public int Author { get; set; }

        public int Category { get; set; }
    }
}
