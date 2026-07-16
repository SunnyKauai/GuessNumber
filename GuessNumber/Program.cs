namespace GuessNumber
{
    public class Program
    {
        public static int timeS = 0;
        public static int timeSh = 2147483647;
        public static int RandomNumber()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 101);
            return num;
        }
        public static int CheckNumber()
        {
            bool resl1;
            int oup;
            do
            {
                string? inp = Console.ReadLine();
                resl1 = int.TryParse(inp, out oup);
                if (!resl1 || oup < 1 || oup > 100)
                {
                    Console.WriteLine("请输入1~100的整数：");
                }
            } while (!resl1 || oup < 1 || oup > 100);
            timeS += 1;
            return oup;
        }
        public static bool CompareNumber(int inp1)
        {
            bool rel = false;
            int inp2;
            do
            {
                inp2 = CheckNumber();
                if (inp1 > inp2)
                {
                    Console.WriteLine("猜小了，请再输入一次：");
                }
                else if (inp1 < inp2)
                {
                    Console.WriteLine("猜大了，请再输入一次：");
                }
                else
                {
                    if (timeS < timeSh)
                    {
                        timeSh = timeS;
                    }
                    Console.Write("恭喜你，猜对了。您的猜测次数为：{0}。您的历史最佳成绩为：{1}。", timeS, timeSh);
                    rel = true;
                }
            }
            while (!rel);
            return rel;
        }
        public static void Main()
        {
            bool win = false;
            int i = RandomNumber();
            string? inwin = "y";
            Console.WriteLine("游戏开始，请输入1~100之间的整数：");
            for (; inwin == "y";)
            {
                win = CompareNumber(i);
                for (; win;)
                {
                    Console.WriteLine("是否继续游戏(y/n)：");
                    inwin = Console.ReadLine();
                    if (inwin == "y")
                    {
                        i = RandomNumber();
                        win = false;
                        timeS = 0;
                        Console.WriteLine("游戏开始，请输入1~100之间的整数：");
                    }
                    else if (inwin == "n")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("请重新输入：");
                    }
                }
            }
        }
    }
}