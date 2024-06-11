using System;
using System.Collections.Generic;

namespace UdemyAngularBlogCore.API.Models;

public partial class Category
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
