﻿namespace Almacen.Web.Data.Entities
{
	using System;
	using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("PRODUCTOS", Schema ="PPAL")]
	public class Product : IEntity
	{
		public int Id { get; set; }

		[MaxLength(50)]
	    [Required]
		public string Name { get; set; }

		[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
		public decimal Price { get; set; }

		[Display(Name = "Image")]
		public string ImageUrl { get; set; }

		[Display(Name = "Last Purchase")]
		public DateTime? LastPurchase { get; set; }

		[Display(Name = "Last Sale")]
		public DateTime? LastSale { get; set; }

		[Display(Name = "Is Availabe?")]
		public bool IsAvailabe { get; set; }

		[DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
		public double Stock { get; set; }
		public User User { get; set; }

		public string ImgageFullPath 
		{ 
			get 
			{
				if (string.IsNullOrEmpty(this.ImageUrl))	return null;
				return $"https://almacen.azurewebsites.net{this.ImageUrl.Substring(1)}";
			}
		}
	}

}
