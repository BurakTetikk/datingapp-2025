using System;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<AppUser> Users { get; set; } //DB'de Users tablosu oluşturmamızı sağlar.(AppUser entity'sine karşılık gelir ama ismi değişken ismi ile oluşturur)
    public DbSet<Member> Members { get; set; }

    public DbSet<Photo> Photos { get; set; }
}
