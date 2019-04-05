using System.Web.Mvc;
using NET1.S._2019.Tsyvis._06;

namespace Calculator.Controllers
{
    public class CalculatorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CalculateGcd(int number1, int number2, string algorithm)
        {
            ViewBag.Number1 = number1;
            ViewBag.Number2 = number2;
            int gcd = 0;
            long millisecond = 0;
            switch (algorithm)
            {
                case "binary":
                    gcd = GCDAlgorithms.CalculateGcdBySteinAndTime(number1, number2, out millisecond);
                    ViewBag.Algorithms = "Stain algorithm";
                    break;

                case "euclidean":
                    gcd = GCDAlgorithms.CalculateGcdByEuclideanAndTime(number1, number2, out millisecond);
                    ViewBag.Algorithms = "Euclidean algorithm";
                    break;
            }

            ViewBag.Millisecond = millisecond;
            ViewBag.GCD = gcd;

            return View();
        }
    }
}