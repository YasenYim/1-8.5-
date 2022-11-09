using System;

namespace _1_8._5_变量的生命期和引用
{
    class Program
    {
        static int count = 0; // int count的出现早于Main函数的执行，count消亡的时间比main函数执行完了还要晚
        static Random random;  // 随机数发生器定义在函数之外
        static void Func(int a)
        {
            a = 9;
            count++;
            int r = random.Next(0, 100); // 在其他函数里面也可以访问random
        }
        static void Main(string[] args)
        {
            count = 0;
            random = new Random();  // main函数开始的时候对其进行初始化

            int a = 3;
            Func(a);
            Func(a);
            Func(a);
            Func(a);

            int r = random.Next(0, 100);

            for(int i = 0; i<100;i++)
            {
                Console.WriteLine(i);
            }
            // {}代表代码块，代码块里面定义的东西，代码块外面无法访问
            // Console.WriteLine(i);



            Console.WriteLine("a=" + a);
            Console.WriteLine("count=" + count);
            Console.ReadKey();
        }


        /* 问题1.a的值是多少 
         * 答案：a = 3
         * 问题2.如果Func函数想改变Main函数中的a值，怎么修改？
           答：1、int a 改成ref int a，将a强行改为引用，一个函数不可能在不适用ref的情况下把外面的函数值改了
               2、如果就是要把a的值改为9要怎么做,首先把返回值改成int类型，然后将a传出去，在main函数里面主动接收
        */

        /* 
         static int Func(int a)
        {
            a = 9;
            return a;
        }
        static void Main(string[] args)
        {
            int a = 3;
            a = Func(a);

            Console.WriteLine("a=" + a);
            Console.ReadKey();
        }
         */

        /* 在函数中定义变量--临时变量
         * 函数参数--实际上也是临时变量
         * 在函数外定义变量--全局变量（要加static才好用），在整个程序执行过程中均存在
         */




        /*static void DoubleElement(int[] arr)  // arr这个临时的盒子，地址指向的和a的引用地址是一样的，arr这一步把堆里面的数据都乘以2，for循环结束，arr死亡，但是堆里面的数据永久被改变了
         * for (int i = 0;i < arr.Length;i++)
         * {
         *      arr[i] *= 2;
         * }
         * 
         *static void Main(string[] args)
         * {
         *      int[] a = {1,2,3,4,5};  // a是一个变量是一个盒子，如果里面有一万个元素，那么这个盒子是非常大的，在计算机编程里面不能把这么多元素放在一个盒子里面。把a存一个箭头，把数据存在堆里面（堆：内存空间）
         *      DoubleElement(a);       // a存的是一个引用，指向了内存空间中的数组
         * }
         */


    }
}
