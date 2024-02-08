using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using исрпо2.Models;

namespace исрпо2.Controllers
{
   
    public class HomeController : Controller
    {
        int count1;
        int month1;
        int year1;
        int count2;
        int month2;
        int year2;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult TaskFirst()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskFirst(int FirstDate1, int FirstDate2, int FirstDate3, int SecondDate1, int SecondDate2, int SecondDate3)
        {
            try { 
            var a = FirstDate1;
            var b = FirstDate2;
            var c = FirstDate3;
            var a2 = SecondDate1;
            var b2 = SecondDate2;
            var c2= SecondDate3;
            var birthDay1 = new DateTime(c, b, a);
            var birthDay2 = new DateTime(c2, b2, a2);
            if(birthDay1 < birthDay2)
            {
                ViewBag.H = "Первый старше ";
            }
            if(birthDay2 < birthDay1)
            {
                ViewBag.H = "Второй старше";
            }
            if(birthDay1 == birthDay2)
            {
                ViewBag.H = "Родились в один день";
            }
            return View();
            }
            catch 
            {
                ViewBag.H = "Error!";
                return View();
            }
            
        }
        public int Perimetr(int a,int b,int c)
        {
            int p = a + b + c;
            return p;
        }
        public double Ploshad(int a, int b, int c)
        {
            var p = (a + b + c)/2;
            double s = Math.Sqrt(p*(p-a)*(p-b)*(p-c));
            return Math.Round(s,2);
        }
        public double[] Median(int a, int b, int c)
        {
            var p = (a + b + c) / 2;
            double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            double h1 = (2 / a) * s;
            double h2= (2 / b) * s;
            double h3= (2 / c) * s;
            double xA = 0;
            double xB=c;
            double xC = (Math.Pow(b,2)+Math.Pow(c,2)-Math.Pow(a,2))/2*c;
            double yA = 0;
            double yB=0;
            double yC = h1;
            double xM = Math.Round(((xA+xB+xC)/3),2);
            double yM= Math.Round(((yA+yB+yC)/3),2);
            double[] M= { xM, yM };
            return M;
        }
        public IActionResult TaskSecond()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskSecond(int FirstDate1, int FirstDate2, int FirstDate3)
        {
            try
            {
                var a = FirstDate1;
                var b = FirstDate2;
                var c = FirstDate3;
                
                ClassTriangle t = new ClassTriangle 
                {
                    a=a,b=b,c=c, P=Perimetr(a,b,c),S=Ploshad(a,b,c),Point=Median(a,b,c)
                };
                ViewBag.tr= Convert.ToString(t.a)+","+Convert.ToString(t.b) + ","+Convert.ToString(t.c) ;
                if (a <= 0 || b <= 0 || c <= 0 || a + b < c || b + c < a || a + c < b)
                {
                    ViewBag.be = "Треугольника с такими сторонами не существует";
                    
                }
                else { 
                    ViewBag.S = Convert.ToString(t.S);
                ViewBag.P = Convert.ToString(t.P);
                ViewBag.T=Convert.ToString(t.Point[0]) + " ; " + Convert.ToString(t.Point[1]);
                }
                return View();
            }
            catch
            {
                ViewBag.H = "Error!";
                return View();
            }

        }
        public IActionResult TaskThird()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TaskThird(int Razm)
        {
            try
            {
                Random random = new Random();
                int c=0;
                int a = Razm;
                int[] array=new int[Razm];
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = random.Next(-50, 50);
                    if (array[i] < 0)
                    {
                        c++;
                    }
                }
                    int[] arr = new int[c];
                int y = 0;
                
                for (int i = 0; i < array.Length; i++) 
                { 
                    
                    if (array[i]<0)
                    {
                        arr[y] += array[i];
                        y++;
                    }
                    if (array[i] > 0)
                    {
                        ViewBag.H += Convert.ToInt32(array[i])+" ";
                    }
                    ViewBag.Mas += Convert.ToString(array[i])+" ";
                }
                for(int i = 0; i < arr.Length; i++)
                ViewBag.H += Convert.ToString(arr[i])+" ";
                return View();
            }
            catch
            {
                ViewBag.H = "Error!";
                return View();
            }

        }
    }
}