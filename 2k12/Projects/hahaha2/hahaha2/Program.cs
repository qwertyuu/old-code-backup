class Program{
    static void Main(string[] args){
        for (int x = 0; true; x++){
            System.Console.ForegroundColor = (x + 2) % 40 == 0 ? (System.ConsoleColor)((x / 40) % 15 + 1) : System.Console.ForegroundColor;
            System.Console.WriteLine(new string(' ', (int)(77.5d / 2d * System.Math.Cos(System.Math.PI / (5 * System.Math.Cos(2 * System.Math.PI / 200 * x) + 95) * x) + 77.5d / 2d)) + new string((char)(x % 26 + 65), 2));
            System.Threading.Thread.Sleep(30);}}}