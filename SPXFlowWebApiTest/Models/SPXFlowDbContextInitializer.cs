using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Xml.Serialization;


namespace SPXFlowWebApiTest.Models
{
    public class SPXFlowDbContextInitializer<T> : DropCreateDatabaseIfModelChanges<SPXFlowWebApiTest.Models.SPXFlowDbContext>
    {
        protected override void Seed(SPXFlowWebApiTest.Models.SPXFlowDbContext context)
        {
            var products = ReadXmlData();

            foreach (var product in products.product)
            {

                var dbproduct = new Product
                {
                    Id = product.id,
                    Title = product.title,
                    ShortDescription = product.shortDescription,
                    Brand = (BrandName)product.brand,
                    DatePublished = DateTime.Now
                };

                List<Review> lstreviews = new List<Review>();

                foreach (var review in product.reviews)
                {
                    lstreviews.Add(new Review
                    {
                        User = review.user,
                        ProductId = dbproduct.Id,
                        Comment = review.comment,
                        Rating = !string.IsNullOrEmpty(review.rating) ?
                                  int.Parse(review.rating) : 0
                    });
                }

                dbproduct.Reviews = lstreviews;

                context.Products.Add(dbproduct);

                context.SaveChanges();
            }
        }

        private products ReadXmlData()
        {
            products prdocuts = null;

            XmlSerializer serializer = new XmlSerializer(typeof(products));

            string path = System.Web.HttpContext.Current.Server.MapPath("~/App_Data/productsData.xml");

            StreamReader reader = new StreamReader(path);
            prdocuts = (products)serializer.Deserialize(reader);
            reader.Close();

            return prdocuts;
        }
    }
}