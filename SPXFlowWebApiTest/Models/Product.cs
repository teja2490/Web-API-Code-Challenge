using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SPXFlowWebApiTest.Models
{
    public class Product
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ShortDescription { get; set; }

        public BrandName Brand { get; set; }

        public List<Review> Reviews { get; set; }

        public System.DateTime DatePublished { get; set; }
    }

    public class Review
    {
        [Key]
        public long ReviewId { get; set; }

        [Required]
        public int Rating { get; set; }

        public string Comment { get; set; }

        public string User { get; set; }

        [ForeignKey("Product")]
        public long ProductId { get; set; }

        public Product Product { get; set; }
    }

    public enum BrandName
    {
        APV,
        Airpel,
        PowerTeam,
    }


}