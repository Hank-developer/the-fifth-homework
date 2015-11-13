using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace recursion
{
    class Program
    {
        #region 递归（不太严格）
        static string recursion(string n)
        {

            string s = "0";
            string q = "y";

            n = Console.ReadLine();
        tt:
            s = s + " " + n;
            Console.WriteLine("是否输入结束？结束请按y，不结束请继续输入");
            q = Console.ReadLine();
            if (q == "y")
            {

                return s;
            }
            else
            {
                n = q;
                goto tt;
            }
        }
        #endregion

        #region 定义接口，实现接口
        interface mysort//接口
        {
            void usesort(string[,] pass, int s);
        }
        #endregion

        #region 排序内容存储
        public class save
        {
            public string[,] allsave = new string[100, 4];
            public int nowjs;
            private int js//记录数据位置
            {
                get { return nowjs; }
                set { nowjs = value; }
            }

            public void saves(string number, string name, string age, string studentnumber)
            {
                int js = 0;
                allsave[js, 0] = number;
                allsave[js, 1] = name;
                allsave[js, 2] = age;
                allsave[js++, 3] = studentnumber;
                Console.WriteLine("是否继续输入，如果是，则继续输入，如果退出，请输入y");
            zl:
                string judge = Console.ReadLine();
                switch (judge)
                {
                    case "y":
                        nowjs = js;
                        break;
                    default:
                        allsave[js, 0] = judge;
                        allsave[js, 1] = Console.ReadLine();
                        allsave[js, 2] = Console.ReadLine();
                        allsave[js++, 3] = Console.ReadLine();
                        Console.WriteLine("是否继续输入，如果是，则继续输入，如果退出，请输入y");
                        goto zl;

                }
            }
            public void forout(string[,] cd, int jj)//输出
            {
                switch (jj)
                {
                    case 0://顺序输出
                        int pass = (Convert.ToInt32(cd[jj, 0]));
                        while (pass != 0)
                        {
                            Console.WriteLine("{0},{1},{2},{3}", cd[jj, 0], cd[jj, 1], cd[jj, 2], cd[jj++, 3]);
                            pass = (Convert.ToInt32(cd[jj, 0]));
                        }
                        break;
                    default://逆序输出
                        jj = jj - 1;
                        while (jj != -1)
                        {
                            Console.WriteLine("{0},{1},{2},{3}", cd[jj, 0], cd[jj, 1], cd[jj, 2], cd[jj--, 3]);
                        }
                        break;
                }

            }

        }
        #endregion

        #region 冒泡排序算法
        public class sort : save, mysort//继承于存储（为了使用存储的方法），并实现接口。
        {
            public void usesort(string[,] pass, int s)//网上找的冒泡排序算法，最讨厌写排序算法，绕不过来。。。
            {

                switch (s)
                {
                    case 0:
                    case 2:
                    case 3:                    //判断数字
                        for (int i = 0; i <= nowjs - 1; i++)
                        {
                            for (int j = 0; j < nowjs - 1 - i; j++)
                            {

                                if (Convert.ToInt64(pass[j, s]) >= Convert.ToInt64(pass[j + 1, s]))
                                {
                                    string temp0 = pass[j, 0];
                                    pass[j, 0] = pass[j + 1, 0];
                                    pass[j + 1, 0] = temp0;

                                    string temp1 = pass[j, 1];
                                    pass[j, 1] = pass[j + 1, 1];
                                    pass[j + 1, 1] = temp1;

                                    string temp2 = pass[j, 2];
                                    pass[j, 2] = pass[j + 1, 2];
                                    pass[j + 1, 2] = temp2;

                                    string temp3 = pass[j, 3];
                                    pass[j, 3] = pass[j + 1, 3];
                                    pass[j + 1, 3] = temp3;
                                }
                            }
                        }
                        break;


                    case 1://判断汉字
                        CultureInfo 拼音 = new CultureInfo(0x804);
                        for (int i = 0; i <= nowjs - 1; i++)
                        {
                            for (int j = 0; j < nowjs - 1 - i; j++)
                            {

                                if (string.Compare(pass[j, s], pass[j + 1, s], 拼音, CompareOptions.None) >= 0)
                                {
                                    string temp0 = pass[j, 0];
                                    pass[j, 0] = pass[j + 1, 0];
                                    pass[j + 1, 0] = temp0;

                                    string temp1 = pass[j, 1];
                                    pass[j, 1] = pass[j + 1, 1];
                                    pass[j + 1, 1] = temp1;

                                    string temp2 = pass[j, 2];
                                    pass[j, 2] = pass[j + 1, 2];
                                    pass[j + 1, 2] = temp2;

                                    string temp3 = pass[j, 3];
                                    pass[j, 3] = pass[j + 1, 3];
                                    pass[j + 1, 3] = temp3;
                                }
                            }
                        }
                        break;
                }

            }
        }
        #endregion


        static void Main(string[] args)//主程序
        {

            #region 使用递归
            string n = "从0到";
            string j = "0";
            Console.Write("您想从0输出到:");
            j = Console.ReadLine();
            Console.WriteLine("开始输入");
            Console.WriteLine("从0到{0}:{1}", j, recursion(n));
            #endregion


            #region 排序
            sort data = new sort();
            Console.WriteLine("请输入编号，姓名，年龄，学号。之间用回车间隔。");
            data.saves(Console.ReadLine(), Console.ReadLine(), Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("是否想查看数据?如果是请输入y，如果否请输入n");
            string pd = Console.ReadLine();
            if (pd == "y")
            {
                data.forout(data.allsave, 0);
            }
            Console.WriteLine("是否进行排序？如果是，请输入想按照编号、姓名、年龄还是学号排序，并选择逆序还是顺序排序。输入格式例：姓名+逆序  如果不想排序请输入n");
            #region 选择排序方式
            string choose = Console.ReadLine();
            switch (choose)
            {
                case "编号+顺序":
                    data.usesort(data.allsave, 0);
                    data.forout(data.allsave, 0);
                    break;

                case "姓名+顺序":
                    data.usesort(data.allsave, 1);
                    data.forout(data.allsave, 0);
                    break;

                case "年龄+顺序":
                    data.usesort(data.allsave, 2);
                    data.forout(data.allsave, 0);
                    break;

                case "学号+顺序":
                    data.usesort(data.allsave, 3);
                    data.forout(data.allsave, 0);
                    break;

                case "编号+逆序":
                    data.usesort(data.allsave, 0);
                    data.forout(data.allsave, data.nowjs);
                    break;

                case "姓名+逆序":
                    data.usesort(data.allsave, 1);
                    data.forout(data.allsave, data.nowjs);
                    break;

                case "年龄+逆序":
                    data.usesort(data.allsave, 2);
                    data.forout(data.allsave, data.nowjs);
                    break;

                case "学号+逆序":
                    data.usesort(data.allsave, 3);
                    data.forout(data.allsave, data.nowjs);
                    break;
            }


            #endregion
        }
        #endregion
    }
}
