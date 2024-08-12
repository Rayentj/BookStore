using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreDbContext : IdentityDbContext<IdentityUser>
    {
        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : base(options)
        {
            
        }

        public  DbSet<Book> Books { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            //configure shopping cart
            modelBuilder.Entity<ShoppingCart>().
                HasKey(x => x.Id);
            //configure shopping cart item
            modelBuilder.Entity<ShoppingCartItem>().
                HasKey(x => x.Id);
            // Configure relationship between ShoppingCart and ShoppingCartItem

            modelBuilder.Entity<ShoppingCart>().
                HasMany(x => x.Items)
                .WithOne(x => x.ShoppingCart)
                .HasForeignKey(x => x.ShoppingcartId);
            modelBuilder.Entity<ShoppingCartItem>().
                HasOne(x => x.Book)
                .WithMany()
                .HasForeignKey(x => x.BookeId);



        }

    }
}
