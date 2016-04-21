using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Aspose.Cells;

using System.Reflection;
using System.IO;



namespace ArchLib
{

    [AttributeUsage(AttributeTargets.Property)]
    public class TitleAttribute : System.Attribute
    {
        public readonly string Title;

        public readonly string Format;

        public TitleAttribute(string title, string format)
        {
            this.Title = title;
            this.Format = format;
        }

        public TitleAttribute(string title)
        {
            this.Title = title;
        }
    }

    /// <summary>
    /// excel import export helper class 
    /// </summary>
    public class ExcelMappingUtil
    {

        private string GetValueStr(object value, string format)
        {
            string valueStr = "";
            if (value == null)
            {
                valueStr = "";
            }
            else if (value is DateTime && !string.IsNullOrEmpty(format))
            {
                valueStr = ((DateTime)value).ToString(format);
            }
            else
            {
                valueStr = value.ToString();
            }
            return valueStr;
        }
      
        public string ExportToFile<T>(List<T> list)
        {
            Workbook book = new Workbook();
            Worksheet sheet = book.Worksheets[0];
            sheet.Name = "Export Data";

            List<PropertyInfo> destPros = new List<PropertyInfo>();
            PropertyInfo[] props = typeof(T).GetProperties();

            //set title and get pros list
            int realColIndex = 0;
            for (int colIndex = 0; colIndex <= props.Length - 1; colIndex++)
            {
                PropertyInfo prop = props[colIndex];
                object[] attributes = prop.GetCustomAttributes(typeof(TitleAttribute), true);
                if (attributes.Length > 0)
                {
                    sheet.Cells[0, realColIndex].PutValue(((TitleAttribute)attributes[0]).Title);
                    destPros.Add(prop);
                    realColIndex++;
                }
            }

            for (int rowIndex = 0; rowIndex <= list.Count - 1; rowIndex++)
            {
                T rowObj = list[rowIndex];
                for (int colIndex = 0; colIndex <= destPros.Count - 1; colIndex++)
                {
                    //get format
                    object[] attributes = destPros[colIndex].GetCustomAttributes(typeof(TitleAttribute), true);
                    string format = ((TitleAttribute)attributes[0]).Format;
                    Object value = destPros[colIndex].GetValue(rowObj, null);
                    //似乎aspose.cells有bug，写入datetime,但是被当做数值了
                    /*
                    if (string.IsNullOrEmpty(format))
                    {
                        if (value != null)
                        {
                                sheet.Cells[rowIndex + 1, colIndex].PutValue(value);
                        }
                   
                    }
                     */
                    string valueStr = GetValueStr(value, format);
                    //rowIndex+1:because data row start from row 2
                    sheet.Cells[rowIndex + 1, colIndex].PutValue(valueStr, false);
                }
            }
            string fileName = Guid.NewGuid().ToString() + ".xls";
            string fullfileName = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/TempFiles/" + fileName));
            book.Save(fullfileName);
            return "TempFiles/" + fileName;
        }


        public List<T> ImportFromFile<T>(string fileName) where T : new()
        {
            Workbook book = new Workbook(fileName);
            Worksheet sheet = book.Worksheets[0];
            Dictionary<int, PropertyInfo> dictPros = new Dictionary<int, PropertyInfo>();
            for (int colIndex = 0; colIndex <= sheet.Cells.MaxColumn; colIndex++)
            {
                if (sheet.Cells[0, colIndex].Value != null)
                {
                    string fieldName = sheet.Cells[0, colIndex].Value.ToString().Trim();
                    PropertyInfo[] props = typeof(T).GetProperties();
                    foreach (PropertyInfo prop in props)
                    {
                        object[] attributes = prop.GetCustomAttributes(typeof(TitleAttribute), true);
                        if (attributes.Length > 0)
                        {
                            if (((TitleAttribute)attributes[0]).Title == fieldName)
                            {
                                dictPros.Add(colIndex, prop);
                            }
                        }
                    }
                }
            }


            List<T> retList = new List<T>();
            for (int rowIndex = 1; rowIndex <= sheet.Cells.MaxDataRow; rowIndex++)
            {
                T rowObj = new T();
                foreach (int colIndex in dictPros.Keys)
                {
                    object cellValue = sheet.Cells[rowIndex, colIndex].Value;

                    //nullable 
                    Type u = Nullable.GetUnderlyingType(dictPros[colIndex].PropertyType);
                    if (u == null)
                        u = dictPros[colIndex].PropertyType;

                    //changvalue = cellValue != null ? Convert.ChangeType(cellValue, u) : cellValue;
                    //2015-03-23郭志松修改
                    //skip  on error
                    object changvalue = null;
                    try
                    {
                        changvalue = cellValue != null ? Convert.ChangeType(cellValue, u) : cellValue;
                    }
                    catch (Exception)
                    {

                    }

                    dictPros[colIndex].SetValue(rowObj, changvalue, null);
                }
                retList.Add(rowObj);
            }
            return retList;

        }



    }

}
