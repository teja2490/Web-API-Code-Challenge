using SPXFlowWebApiTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SPXFlowWebApiTest.Controllers
{
    [RoutePrefix("api/product")]
    public class ProductApiController : ApiController
    {
        public ProductApiController()
        {
        }

        private SPXFlowDbContext _sampledbContext = new SPXFlowDbContext();


        [Route("")]
        [HttpGet]
        public IEnumerable<DTO.Product> GetAllProducts()
        {
            var products = _sampledbContext.Products;
            List<DTO.Product> lstofproducts = new List<DTO.Product>();
            if (products != null && products.Count() > 0)
            {
                products.ToList().ForEach(product =>
                {
                    lstofproducts.Add(new DTO.Product
                    {
                        Title = product.Title,
                        Id = product.Id,
                        ShortDescription = product.ShortDescription,
                        DatePublished = product.DatePublished,
                        Brand = (DTO.BrandName)product.Brand
                    });
                });
            }

            return lstofproducts;
        }


        [Route("{productTitle}/reviews")]
        [HttpGet]
        public IEnumerable<DTO.Review> GetAllReviewsofProduct(string productTitle)
        {
            var products = _sampledbContext.Products;
            List<DTO.Review> lstofproductreviews = new List<DTO.Review>();
            if (products != null && products.Count() > 0)
            {
                var product = products.ToList().SingleOrDefault(c => c.Title == productTitle);
                var reviews = _sampledbContext.Reviews.Where(c => c.ProductId == product.Id);
                if (reviews != null && reviews.Count() > 0)
                {
                    reviews.ToList().ForEach(review =>
                    {
                        lstofproductreviews.Add(new DTO.Review
                        {
                            Comment = review.Comment,
                            ProductId = review.ProductId,
                            Rating = review.Rating,
                            ReviewId = review.ReviewId,
                            User = review.User
                        });
                    });
                }
                else
                {
                    ControllerContext.Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }

            return lstofproductreviews;
        }

        [Route("addreview")]
        [HttpPost]
        public IHttpActionResult AddProduct(DTO.Review productreview)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ValidationException("Invalid User", ModelState);
                }

                _sampledbContext.Reviews.Add(new Review
                {
                    ReviewId = productreview.ReviewId,
                    User = productreview.User,
                    ProductId = productreview.ProductId,
                    Comment = productreview.Comment
                });
                _sampledbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("updatereview/{id:int}")]
        [HttpPut]
        public IHttpActionResult UpdateProduct(int id, DTO.Review review)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    throw new ValidationException("Invalid User", ModelState);
                }

                var dbreview = _sampledbContext.Reviews.SingleOrDefault(r => r.ReviewId == id);
                if (dbreview != null)
                {
                    dbreview.Comment = review.Comment;
                    dbreview.ProductId = review.ProductId;
                    dbreview.Rating = review.Rating;
                    dbreview.User = review.User;
                    _sampledbContext.Entry(dbreview).State = System.Data.Entity.EntityState.Modified;
                    _sampledbContext.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [Route("deletereview/{id:int}")]
        [HttpDelete]
        public IHttpActionResult DeleteProduct(int id)
        {
            try
            {
                var dbreview = _sampledbContext.Reviews.SingleOrDefault(r => r.ReviewId == id);
                if (dbreview != null)
                {
                    _sampledbContext.Reviews.Remove(dbreview);
                    _sampledbContext.SaveChanges();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
