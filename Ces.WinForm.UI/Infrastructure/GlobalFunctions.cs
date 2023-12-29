using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ces.WinForm.UI.Infrastructure
{
    public  class GlobalFunctions
    {
        /// <summary>
        /// این متد توسط کنترل هایی فراخوانده خواهد شد که کاربر می بایست
        /// یک لیست از کلاس و یا نوع دیگری از داده ها را در اختیار کنترل
        /// قرار دهد. فراخوانی این متد باید بصورت زیر باشد
        ///
        /// following list must be send to control:
        /// 
        /// IList<hadi> dataSource = new List<hadi>()
        /// {
        ///     new hadi { Id = 1, Name = "Name1" },
        ///     new hadi { Id = 1, Name = "Name1" },
        ///     new hadi { Id = 1, Name = "Name1" },
        ///     new hadi { Id = 1, Name = "Name1" },
        /// };
        /// 
        /// Following codes with use of reflection, create new instance of function then use.
        /// 
        /// private void ReadDataSource()
        /// {
        ///     System.Reflection.MethodInfo methodInfo =
        ///         typeof(Ces.WinForm.UI.Infrastructure.GlobalFunctions)
        ///         .GetMethod(nameof(Ces.WinForm.UI.Infrastructure.GlobalFunctions.ConvertToTypedList));
        ///
        ///     System.Reflection.MethodInfo createGenericMethod =
        ///         methodInfo.MakeGenericMethod(dataSource.GetType().GetGenericArguments()[0]);
        ///
        ///     createGenericMethod.Invoke(new Ces.WinForm.UI.Infrastructure.GlobalFunctions(), new[] { dataSource });
        /// }
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        public  IList<T> ConvertToTypedList<T>( IList<T> sourceList)
        {
            //var b = sourceList.Cast<T>();
            IList<T> destinationList = sourceList.ToList();
            return destinationList;
        }

        //public static object ConvertToTypedList(this object sourceList)
        //{

        //    bool isGeneric = sourceList.GetType().IsGenericType;
        //    bool isList = sourceList.GetType().GetGenericTypeDefinition().IsAssignableFrom(typeof(List<>));
        //    Type t =sourceList.GetType().GetGenericArguments()[0];

        //    if (!isGeneric || !isList)
        //        return null;



        //    IList<t> list = (IList<t>)sourceList;
        //    //var b = sourceList.Cast<T>();
        //    object destinationList = sourceList;
        //    return destinationList;
        //}
    }
}
