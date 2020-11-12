
using ExcelFileReader.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ExcelFileReader.Core.DTO
{
    public class FileMapping
    {
        public List<FileModelDTO> GetDataMapping(List<FileEntity> source)
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

        public List<FileEntity> AddDataMapping(List<FileModelDTO> source)
        {
            List<FileEntity> destination = new List<FileEntity>();
            foreach (var item in source)
            {
                destination.Add(new FileEntity()
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
