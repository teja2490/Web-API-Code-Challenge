using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SPXFlowWebApiTest.DTO
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public long Id { get; set; }

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public BrandName Brand { get; set; }

        [DataMember]
        public System.DateTime DatePublished { get; set; }
    }

    [DataContract]
    public class Review
    {
        [DataMember]
        public long ReviewId { get; set; }

        [Required(ErrorMessage = "Please Give Rating")]
        [DataMember]
        public int Rating { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string User { get; set; }

        [Required(ErrorMessage = "Please Specify Product Id")]
        [DataMember]
        public long ProductId { get; set; }

    }

    public enum BrandName
    {
        [EnumMember]
        APV,
        [EnumMember]
        Airpel,
        [EnumMember]
        PowerTeam,
    }

}