using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace CodeDemo.Document.NPOIHelper
{
    /// <summary>
    /// Excel
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 通过文件名获取workbook
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static IWorkbook GetWorkbook(string fileName)
        {
            if(string.IsNullOrWhiteSpace(fileName))
                return new XSSFWorkbook();
            if(Path.GetExtension(fileName).ToLower() == ".xls")
                return  new HSSFWorkbook();
            else
                return  new XSSFWorkbook();
        }
    }
}
