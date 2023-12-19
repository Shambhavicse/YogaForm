using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using yogaForm.Models;

namespace yogaForm.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        private readonly YogaEntities _dbContext = new YogaEntities();
      
        [HttpGet]
        public ActionResult Registration()
        {
            var model = new Class1
            {
                EnrollFor500Rs = true // Default checkbox value
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Registration(Class1 model)
        {
            if (ModelState.IsValid)
            {
                // Save to database
                _dbContext.SaveChanges();

                // Mock payment function
                var paymentResult = CompletePayment(model);

                // Return response to front-end based on payment response
                if (paymentResult)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("", "Payment failed. Please try again.");
                }
            }

            // If the model is not valid, return to the form with validation errors
            return View(model);
        }

        public ActionResult Success()
        {
            return View();
        }

        // Remember to dispose of the DbContext when it's no longer needed
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }

        // Mock function for payment (replace with your actual payment logic)
        private bool CompletePayment(Class1 user)
        {
            // Mock function, replace with actual payment logic
            // Assume payment is successful for demonstration purposes
            return true;
        }
    }
}