using ECommerce.Core.Entities;
using ECommerce.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Repositories
{
    public class ImageRepository : Repository<ProductImage>, IImageRepository
    {
        public ImageRepository(DbContext dbContext)
         : base(dbContext)
        {


        }
    }
}
