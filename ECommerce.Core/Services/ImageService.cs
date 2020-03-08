using ECommerce.Core.Entities;
using ECommerce.Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Core.Services
{
    public class ImageService : IImageService
    {
        private IStoreUnitOfWork _storeUnitOfWork;
        public ImageService(IStoreUnitOfWork storeUnitOfWork)
        {
            _storeUnitOfWork = storeUnitOfWork;
        }

        public void AddImage(ProductImage productImage)
        {
            if (productImage == null || string.IsNullOrWhiteSpace(productImage.Url))
                throw new InvalidOperationException("Product-Image Name is missing");

            _storeUnitOfWork.ImageRepository.Add(productImage);
            _storeUnitOfWork.Save();
        }
    }
}
