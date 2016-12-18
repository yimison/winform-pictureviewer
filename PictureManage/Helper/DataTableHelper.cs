using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PictureManage
{
   public class DataTableHelper
    {
        /// <summary>
         /// 将DataRow赋值给model中同名属性
         /// </summary>
         /// <typeparam name="T">泛型：model的类型</typeparam>
         /// <param name="objmodel">model实例</param>
         /// <param name="dtRow">DataTable行数据</param>
         public T TableRowToModel<T>(T objmodel, DataRow dtRow)
         {
             //获取model的类型
             Type modelType = typeof(T);
             //获取model中的属性
             PropertyInfo[] modelpropertys = modelType.GetProperties();
             //遍历model每一个属性并赋值DataRow对应的列
             foreach (PropertyInfo pi in modelpropertys)
             {
                 //获取属性名称
                 String name = pi.Name;
                 if (dtRow.Table.Columns.Contains(name))
                 {
                     //非泛型
                     if (!pi.PropertyType.IsGenericType)
                     {
                         pi.SetValue(objmodel, string.IsNullOrEmpty(dtRow[name].ToString()) ? null : Convert.ChangeType(dtRow[name], pi.PropertyType), null);
                     }
                     //泛型Nullable<>
                     else
                     {
                         Type genericTypeDefinition = pi.PropertyType.GetGenericTypeDefinition();
                         //model属性是可为null类型，进行赋null值
                         if (genericTypeDefinition == typeof(Nullable<>))
                         {
                            //返回指定可以为 null 的类型的基础类型参数
                            pi.SetValue(objmodel, string.IsNullOrEmpty(dtRow[name].ToString()) ? null : Convert.ChangeType(dtRow[name], Nullable.GetUnderlyingType(pi.PropertyType)), null);
                         }
                     }
                 }
             }
             return objmodel;
         }
    }
}
