﻿using System;
using System.Collections.Generic;

namespace UdemyAngularBlogCore.API.Models;

public partial class Article
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string ContentSummary { get; set; } = null!;

    public string ContentMain { get; set; } = null!;

    public DateTime PublishDate { get; set; }

    public string? Picture { get; set; }

    public int CategoryId { get; set; }

    public int ViewCount { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
