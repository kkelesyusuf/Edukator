﻿using Edukator.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Edukator.DataAccessLayer.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MM84V2T\\SQLEXPRESS;initial catalog=DbEdukator;integrated security=true;");
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<AboutGrid> AboutGrids { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<MailSubscribe> MailSubscribes { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<CourseRegister> CourseRegisters { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Progress> Progresses { get; set; }
        public DbSet<Join> Joins { get; set; }
        public DbSet<Map> Maps { get; set; }
        

    }
}
