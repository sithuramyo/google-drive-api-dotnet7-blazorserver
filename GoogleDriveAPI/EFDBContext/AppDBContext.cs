﻿using Microsoft.EntityFrameworkCore;
using System;

namespace GoogleDriveAPI.EFDBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
    }
}
