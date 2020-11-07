﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryServicePatternDemo.Core.Models
{
    public class FileModel
    {
        public int ID { get; set; }
        public string Key { get; set; }
        public string ItemCode { get; set; }
        public string ColorCode { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }
        public string DiscountPrice { get; set; }
        public string DeliveredIn { get; set; }
        public string Q1 { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }


    }
}
