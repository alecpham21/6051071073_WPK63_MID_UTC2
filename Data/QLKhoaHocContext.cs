using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class QLKhoaHocContext : DbContext
{
    public QLKhoaHocContext(DbContextOptions<QLKhoaHocContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Course> Courses { get; set; }
}
public class Category
{
    public int CatID { get; set; }
    public string CatName { get; set; }
    public string CatDescription { get; set; }

    // Navigation property
    public ICollection<Course> Courses { get; set; }
}

public class Course
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string ImageFilePath { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }
    public int CatID { get; set; }
    public int NumViews { get; set; }

    // Navigation property
    public Category Category { get; set; }
}