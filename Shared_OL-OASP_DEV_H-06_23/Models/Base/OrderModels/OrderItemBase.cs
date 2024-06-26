﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared_OL_OASP_DEV_H_06_23.Models.Base.OrderModels
{
    public abstract class OrderItemBase
    {
        public decimal Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
