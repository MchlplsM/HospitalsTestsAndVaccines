using HospitalsTestsAndVaccines.Core;
using HospitalsTestsAndVaccines.Models;
using HospitalsTestsAndVaccines.ViewModels;
using PayPal.Api;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalsTestsAndVaccines.Controllers
{
    public class PaymentsController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.StripePublishKey = ConfigurationManager.AppSettings["stripePublishableKey"];
            return View();
        }

        [HttpPost]
        public ActionResult Charge(string stripeToken, string stripeEmail)
        {
            Stripe.StripeConfiguration.SetApiKey("stripePublishableKey");
            Stripe.StripeConfiguration.ApiKey = "stripeSecretKey";

            AppointmentFormViewModel GetProductPrice = new AppointmentFormViewModel();

            var myCharge = new Stripe.ChargeCreateOptions();
            // always set these properties
            myCharge.Amount = 100 * (long)context.Products.SingleOrDefault(p => p.Id == GetProductPrice.Product).Price;
            myCharge.Currency = "eur";
            myCharge.ReceiptEmail = stripeEmail;
            myCharge.Description = GetProductPrice.Product.ToString();
            myCharge.Source = stripeToken;
            myCharge.Capture = true;
            var chargeService = new Stripe.ChargeService();
            Charge stripeCharge = chargeService.Create(myCharge);
            return View();
        }
    }
}