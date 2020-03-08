using System;
using System.Collections.Generic;
using System.Text;
using ECommerce.Core.Entities;

namespace ECommerce.Core.Services
{
    public interface IImageService
    {
        void AddImage(ProductImage productImage);
    }
}
