namespace GuessNumber
{
    public class Program
    {
        //初始化每局成绩和历史最佳成绩变量
        public static int timeS = 0;
        public static int timeSh = 2147483647;
        //生成1~100的随机整数
        public static int RandomNumber()
        {
            Random rnd = new Random();
            int num = rnd.Next(1, 101);
            return num;
        }
        //检查输入值是否符合1~100的整数，若不符合要求则要求重试，若符合要求则本次成绩加一，并返回输入值
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
                    Console.WriteLine("无效输入，请输入1~100的整数：");
                }
            } while (!resl1 || oup < 1 || oup > 100);
            timeS += 1;
            return oup;
        }
        //循环将随机生成数与输入值进行比较并告知是否猜中、猜大了还是猜小了，若猜中则告知本次成绩和历史最佳成绩并退出循环，返回布尔值用于进入继续游戏循环
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
                    //比较本次成绩和历史最佳成绩大小并使历史最佳成绩保留较小值
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
            //初始化win用于判断是否进入继续游戏循环，初始化随机数i，初始化inwin用于判断是否退出游戏循环
            bool win = false;
            int i = RandomNumber();
            string? inwin = "y";
            Console.WriteLine("游戏开始，请输入1~100之间的整数：");
            for (; inwin == "y";)//游戏循环
            {
                //利用CompareNumber方法，当猜中时令win为true进入继续游戏循环
                win = CompareNumber(i);
                for (; win;)//继续游戏循环
                {
                    Console.WriteLine("是否继续游戏(y/n)：");
                    inwin = Console.ReadLine();
                    //若输入为y，则重新生成随机数i并恢复win为false退出继续游戏循环
                    if (inwin == "y")
                    {
                        i = RandomNumber();
                        win = false;
                        timeS = 0;
                        Console.WriteLine("游戏开始，请输入1~100之间的整数：");
                    }
                    //若输入为n，退出继续游戏循环及游戏循环
                    else if (inwin == "n")
                    {
                        break;
                    }
                    //输入非法，告知重新输入
                    else
                    {
                        Console.Write("输入无效，请重新输入，");
                    }
                }
            }
        }
    }
}