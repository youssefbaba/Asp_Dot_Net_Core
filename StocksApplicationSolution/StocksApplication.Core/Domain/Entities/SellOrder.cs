﻿using System.ComponentModel.DataAnnotations;

namespace StocksApplication.Core.Domain.Entities
{
    public class SellOrder
    {
        [Key]
        public Guid SellOrderID { get; set; }

        [Display(Name = "Stock Symbol")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [MaxLength(40)]
        public string? StockSymbol { get; set; }

        [Display(Name = "Stock Name")]
        [Required(ErrorMessage = "{0} can't be blank")]
        [MaxLength(40)]
        public string? StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public uint Quantity { get; set; }


        [Range(1, 10000, ErrorMessage = "{0} should be between ${1} and ${2}")]
        public double Price { get; set; }
    }
}
