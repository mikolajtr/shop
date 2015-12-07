﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Shop.Model.Models
{
    public class ShopContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Image> Images { get; set; }


        public ShopContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
                .HasRequired(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.ProductId);
            modelBuilder.Entity<Review>()
                .HasRequired(x => x.Author)
                .WithMany(x => x.Reviews)
                .HasForeignKey(x => x.AuthorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Category>()
                .HasOptional(x => x.BaseCategory)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.BaseCategoryId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Basket>()
                .HasRequired(x => x.User)
                .WithMany(x => x.ProductsInBasket)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Basket>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Baskets)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Image>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Transaction>()
                .HasRequired(x => x.Order)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.OrderId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Transaction>()
                .HasRequired(x => x.Product)
                .WithMany(x => x.Transactions)
                .HasForeignKey(x => x.ProductId)
                .WillCascadeOnDelete(true);
            modelBuilder.Entity<Order>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.UserId);

        }

        public static ShopContext Create()
        {
            return new ShopContext();
        }
    }
}