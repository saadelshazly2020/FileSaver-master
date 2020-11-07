using RepositoryServicePatternDemo.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServicePatternDemo.Core.DTO
{
    public class FileMapping
    {
        public List<FileModelDTO> GetDataMapping(List<FileModel> source)
        {
            List<FileModelDTO> destination = new List<FileModelDTO>();
            foreach (var item in source)
            {
                destination.Add(new FileModelDTO()
                {
                    Key = item.Key,
                    Color = item.Color,
                    ColorCode = item.ColorCode,
                    DeliveredIn = item.DeliveredIn,
                    Description = item.Description,
                    DiscountPrice = item.DiscountPrice,
                    ItemCode = item.ItemCode,
                    Price = item.Price,
                    Q1 = item.Q1,
                    Size = item.Size

                });
            }
            return destination;
        }

        public List<FileModel> AddDataMapping(List<FileModelDTO> source)
        {
            List<FileModel> destination = new List<FileModel>();
            foreach (var item in source)
            {
                destination.Add(new FileModel()
                {
                    Key = item.Key,
                    Color = item.Color,
                    ColorCode = item.ColorCode,
                    DeliveredIn = item.DeliveredIn,
                    Description = item.Description,
                    DiscountPrice = item.DiscountPrice,
                    ItemCode = item.ItemCode,
                    Price = item.Price,
                    Q1 = item.Q1,
                    Size = item.Size

                });
            }
            return destination;
        }
    }
}
