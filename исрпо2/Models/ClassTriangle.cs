namespace исрпо2.Models
{
    public class ClassTriangle
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public int P { get; set; }
        public double S { get; set; }
        public double[] Point { get; set; }
        public ClassTriangle(int a, int b, int c, int p, double s, double[] point)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            P = p;
            S = s;
            Point = point;
        }
    }
}
