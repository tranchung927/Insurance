﻿#nullable enable
using System;
using System.Collections.Generic;

namespace InsuranceCore.Models.DTOs.Post
{
    /// <summary>
    /// UPDATE Dto type of <see cref="Post"/>.
    /// </summary>
    public class UpdatePostDto : ADto, IPostDto
    {
        public string Content { get; set; }

        public string? ThumbnailUrl { get; set; }

        public string Name { get; set; }

        public int Author { get; set; }

        public int Category { get; set; }
    }
}
