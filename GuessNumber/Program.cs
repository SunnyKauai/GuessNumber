using System;
namespace GuessNumber
{
    class Program
    {
        //声明成员变量并初始化部分成员变量
        int target;
        int score;int highScore = int.MaxValue;
        int min;int max;
        bool inGame = true;bool isWin;
        //程序主方法
        static void Main()
        {
            //实例化Random类用于生成随机数 实例化Program类用于使用实例方法及调用成员变量
            Random random = new();
            Program program = new();
            //开场白
            Console.WriteLine("欢迎来到猜数游戏，该游戏需要你猜出程序随机生成的一个在1~100区间内的整数");
            Console.WriteLine("该游戏具有记分功能，会记录你本次挑战的次数以及历次挑战的最低次数");
            Console.WriteLine("该游戏还具有动态范围，使你能够更简单地进行游戏\n");
            //游戏主循环
            while (program.inGame) 
            {
                program.Initialize(random.Next(1, 101));
                program.GameProcess();
            }
        }
        //初始化部分成员变量
        void Initialize(int input)
        {
            target = input;
            score = 0;
            min = 1;
            max = 100;
            isWin = false;
        }
        //游戏进程
        void GameProcess()
        {
            
            string? input;
            bool success;

            Console.WriteLine("接下来游戏开始，请输入1~100之间的整数：");

            while (!isWin)
            {
                input = Console.ReadLine();
                success = CheckInput(input,out int guess);
                if (success)
                {
                    isWin = CompareNumber(guess);
                }
                if (isWin) { GameExit(); }
            }
        }
        //检查游戏进程中用户输入是否合法
        bool CheckInput(string? input, out int output)
        {

            bool success = int.TryParse(input, out output);
            if (!success || output < min || output > max)
            {
                Console.WriteLine("无效输入，请输入{0}~{1}之间的整数：", min, max);
                return false;
            }
            else
            {
                return true;
            }
        }
        //检查游戏进程中用户输入是否猜对
        bool CompareNumber(int input)
        {
            if (input < target)
            {
                score++;
                min = input + 1;
                Console.WriteLine("猜小了，当前次数{0}，请输入{1}~{2}之间的整数：", score, min, max);
                return false;
            }
            else if (input > target)
            {
                score++;
                max = input - 1;
                Console.WriteLine("猜大了，当前次数{0}，请输入{1}~{2}之间的整数：", score, min, max);
                return false;
            }
            else
            {
                score++;
                if (score < highScore) { highScore = score; }
                Console.WriteLine("恭喜你，猜对了。您的本轮猜测次数为：{0} 您的历史最佳次数为：{1} ", score, highScore);
                return true;
            }
        }
        //退出进程
        void GameExit()
        {
            string? input;
            bool exit = false;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("是否继续游戏(y/n)：");
                input = Console.ReadLine();
                success = CheckInputExit(input, out exit);
            }
            if (exit) { inGame = false; }
        }
        //检查退出进程中用户输入
        bool CheckInputExit(string? input, out bool exit)
        {
            if (input == "y") 
            { 
                exit = false; 
                return true; 
            }
            else if (input == "n") 
            { 
                exit = true; 
                return true; 
            }
            else 
            { 
                Console.Write("输入无效，请再输入一次，"); 
                exit = false; 
                return false; 
            }
        }
    }
}