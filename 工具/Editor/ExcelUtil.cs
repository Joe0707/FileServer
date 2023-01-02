using System.Collections.Generic;
using System.Collections;
using NPOI.SS.UserModel;
using NPOI.HSSF.UserModel;
using System.Reflection;
using System;
using System.IO;
//Excel工具
public class ExcelUtil
{
    //根据一级数据对象（不包含嵌套数据）创建excel表
    public static void WriteRowData(ISheet sheet, List<string> values, int rowindex)
    {
        var row = sheet.CreateRow(rowindex);
        for (var i = 0; i < values.Count; i++)
        {
            row.CreateCell(i).SetCellValue(values[i]);
        }
    }
    //生成对象的Workbook
    public static HSSFWorkbook GenerateObjWorkbook<T>(T obj)
    {
        var workbook = new HSSFWorkbook();
        var fields = typeof(T).GetFields();
        for (var i = 0; i < fields.Length; i++)
        {
            var field = fields[i];
            var value = field.GetValue(obj);
            if (value is IList)
            {
                var args = field.FieldType.GetGenericArguments();
                var type = typeof(object);
                if (args != null && args.Length > 0)
                {
                    type = args[0];
                }
                //可转excel的对象
                var sheet = workbook.CreateSheet(field.Name);
                GenerateSheetContents(sheet, new ArrayList((IList)value), type);
            }
        }
        return workbook;
    }



    //生成sheet内容
    public static void GenerateSheetContents(ISheet sheet, ArrayList objs, Type type)
    {
        var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
        var listfields = new List<string>();
        for (var i = 0; i < fields.Length; i++)
        {
            var field = fields[i];
            listfields.Add(field.Name);
        }
        WriteRowData(sheet, listfields, 0);
        for (var i = 0; i < objs.Count; i++)
        {
            var obj = objs[i];
            var listvalues = new List<string>();
            for (var j = 0; j < fields.Length; j++)
            {
                listvalues.Add(fields[j].GetValue(obj).ToString());
            }
            WriteRowData(sheet, listvalues, i + 1);
        }
    }

    //仅支持集合 序列化数据
    public static HSSFWorkbook GenerateWorkbook(List<object> objs, Type type)
    {
        var workbook = new HSSFWorkbook();
        if (objs.Count > 0)
        {
            var sheet = workbook.CreateSheet();
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var listfields = new List<string>();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                listfields.Add(field.Name);
            }
            WriteRowData(sheet, listfields, 0);
            for (var i = 0; i < objs.Count; i++)
            {
                var obj = objs[i];
                var listvalues = new List<string>();
                for (var j = 0; j < fields.Length; j++)
                {
                    listvalues.Add(fields[j].GetValue(obj).ToString());
                }
                WriteRowData(sheet, listvalues, i + 1);
            }
        }
        return workbook;
    }

    //仅支持集合 序列化数据
    public static HSSFWorkbook GenerateWorkbook<T>(List<T> objs)
    {
        var workbook = new HSSFWorkbook();
        if (objs.Count > 0)
        {
            var sheet = workbook.CreateSheet();
            var type = typeof(T);
            var fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
            var listfields = new List<string>();
            for (var i = 0; i < fields.Length; i++)
            {
                var field = fields[i];
                listfields.Add(field.Name);
            }
            WriteRowData(sheet, listfields, 0);
            for (var i = 0; i < objs.Count; i++)
            {
                var obj = objs[i];
                var listvalues = new List<string>();
                for (var j = 0; j < fields.Length; j++)
                {
                    listvalues.Add(fields[j].GetValue(obj).ToString());
                }
                WriteRowData(sheet, listvalues, i + 1);
            }
        }
        return workbook;
    }
    //加载Workbook反序列化数据
    public static T LoadWorkBookData<T>(HSSFWorkbook book)
    {
        T t = System.Activator.CreateInstance<T>();
        var fields = t.GetType().GetFields();
        for (var i = 0; i < fields.Length; i++)
        {
            var field = fields[i];
            var args = field.FieldType.GetGenericArguments();
            var type = typeof(object);
            if (args != null && args.Length > 0)
            {
                type = args[0];
            }
            var sheet = book.GetSheet(field.Name);
            var method = typeof(ExcelUtil).GetMethod("LoadFromSheet", BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo mi = method.MakeGenericMethod(type);
            var methodResult = mi.Invoke(null, new object[] { sheet });
            field.SetValue(t, methodResult);
        }
        return t;
    }
    //从表格sheet中加载
    private static List<T> LoadFromSheet<T>(ISheet sheet)
    {
        var result = new List<T>();
        var rows = sheet.GetRowEnumerator();
        if (rows != null && rows.MoveNext())
        {
            var type = typeof(T);
            var fields = type.GetFields();
            int index = 0;
            var fieldvalues = new List<string>();
            do
            {
                var row = rows.Current as IRow;
                var cellvalues = row.Cells;
                if (index == 0)
                {
                    for (var i = 0; i < cellvalues.Count; i++)
                    {
                        fieldvalues.Add(cellvalues[i].StringCellValue);
                    }
                }
                else
                {
                    T obj = System.Activator.CreateInstance<T>();
                    for (var i = 0; i < cellvalues.Count; i++)
                    {
                        var fieldname = fieldvalues[i];
                        var field = GetFieldInfoFromFields(fields, fieldname);
                        var fieldType = field.FieldType;
                        if (fieldType.IsEnum)
                        {
                            field.SetValue(obj, System.Enum.Parse(fieldType, cellvalues[i].StringCellValue));
                        }
                        else
                        {
                            field.SetValue(obj, System.Convert.ChangeType(cellvalues[i].StringCellValue, fieldType));
                        }
                    }
                    result.Add(obj);
                }
                index++;
            } while (rows.MoveNext());
        }
        return result;
    }
    //从Workbook第一个sheet反序列化数据
    public static List<T> LoadWorkbook<T>(string path)
    {
        List<T> result = null;
        FileStream fs = null;
        try
        {
            fs = new FileStream(path, FileMode.Open);
            var workbook = new HSSFWorkbook(fs, false);
            result = ExcelUtil.LoadWorkbook<T>(workbook);
        }
        catch (System.Exception ex)
        {
            throw ex;
        }
        finally
        {
            fs.Close();
        }
        return result;
    }

    //从Workbook第一个sheet反序列化数据
    public static List<T> LoadWorkbook<T>(HSSFWorkbook book)
    {
        var sheet = book.GetSheetAt(0);
        var result = LoadFromSheet<T>(sheet);
        return result;
    }
    //根据字段名查找字段信息
    private static FieldInfo GetFieldInfoFromFields(FieldInfo[] infos, string fieldName)
    {
        FieldInfo result = null;
        for (var i = 0; i < infos.Length; i++)
        {
            var info = infos[i];
            if (info.Name == fieldName)
            {
                result = info;
                break;
            }
        }
        return result;
    }
}
