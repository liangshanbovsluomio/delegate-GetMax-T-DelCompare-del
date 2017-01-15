using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 用委托比较数组中组件大小_泛型_
{
    public delegate int DelCompare<T>(T a, T b);//因为大小比较差值为整数所以此处返回值为int

    class Program
    {

        static void Main(string[] args)
        {

            int[] arr = { -1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233 };
            string[] arr2 = { "方式发送到", "水电费水电费是", "fsdfsdfsf" };
            Person[] arr3 = { new Person("李雷", 18), new Person("韩梅梅", 16) };

            #region int数组
            DelCompare<int> delTemp = (int a, int b) =>
            {
                return (int)a - (int)b;
            };
            Console.WriteLine(GetMax<int>(arr, delTemp));
            #endregion

            #region string类型数组
            DelCompare<string> delTemp2 = (string a, string b) =>
            {
                //string c = (string)a;
                //string d = (string)b;
                return ((string)a).Length - ((string)b).Length;
            };
            Console.WriteLine(GetMax(arr2, delTemp2));
            #endregion

            #region 对象类型数组
            //
            DelCompare<Person> delTemp3 = (a, b) =>
            {

                return ((Person)a).Age - ((Person)b).Age;
            };
            Console.WriteLine(((Person)GetMax(arr3, delTemp3)).Name);
            #endregion


        }

        /// <summary>
        /// 如此形式可以比较多种类型，符合面向对象思想
        /// </summary>
        /// <param name="name"></param>
        /// <param name="del"></param>
        /// <returns></returns>
        static T GetMax<T>(T[] name, DelCompare<T> del)
        {
            T max = name[0];
            for (int i = 0; i < name.Length; i++)
            {
                if (del(max, name[i]) < 0)
                {
                    max = name[i];
                }
            }
            return max;
        }

        #region 原始写法
        //static int GetMax(int[] a)
        //{
        //    int max=0;
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i]>max)
        //        {
        //            max = a[i];
        //        }
        //    }
        //    return max;
        //}
        //static int GetMin(int[] a)
        //{
        //    int min = 0;
        //    for (int i = 0; i < a.Length; i++)
        //    {
        //        if (a[i] < min)
        //        {
        //            min = a[i];
        //        }
        //    }
        //    return min;
        //} 
        #endregion


    }
}
