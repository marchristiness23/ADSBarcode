using SHUNetMVC.Abstraction.Model.View;
using ClosedXML.Excel;
using System.Linq;
using System.Reflection;
using System;
using System.Collections.Generic;

namespace SHUNetMVC.Infrastructure.Helpers
{
    public static class SpreadsheetGenerator
    {
        public static XLWorkbook Generate<T>(string title, 
            IEnumerable<T> items, 
            List<ColumnDefinition> columnDefinitions, 
            FilterList filter)
        {
           
            XLWorkbook wb = new ClosedXML.Excel.XLWorkbook();
            IXLWorksheet ws = wb.AddWorksheet(title);

            // header
            var col = 1;
            foreach (var columnDefinition in columnDefinitions)
            {
                // set column name with format text
                ws.Cell(2, col).SetValue(columnDefinition.Name);
                col++;
            }

            // title report
            ws.FirstCell().SetValue(title);
            ws.FirstCell().Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            ws.FirstCell().Style.Font.SetBold();
            ws.FirstCell().SetDataType(XLDataType.Text);
            ws.Range(ws.Cell(1, 1), ws.Cell(1, columnDefinitions.Count())).Merge();

            // rows mulai dari row 3
            var row = 3;
            foreach (var item in items)
            {
                Type t = item.GetType();
                PropertyInfo[] props = t.GetProperties();

                // tiap col
                col = 1;
                foreach (var columnDefinition in columnDefinitions)
                {
                    var prop = props.FirstOrDefault(o => o.Name == columnDefinition.Id);
                    var val = prop.GetValue(item);

                    if (val != null)
                    {
                        // set column format
                        switch (columnDefinition.Type)
                        {
                            case ColumnType.Number:
                                if (prop.PropertyType == typeof(Int32))
                                {
                                    ws.Cell(row, col).Style.NumberFormat.SetNumberFormatId((int)XLPredefinedFormat.Number.Integer);
                                }
                                else
                                {
                                    ws.Cell(row, col).Style.NumberFormat.SetNumberFormatId((int)XLPredefinedFormat.Number.General);
                                }
                                break;
                            case ColumnType.DateTime:
                                ws.Cell(row, col).Style.NumberFormat.SetNumberFormatId((int)XLPredefinedFormat.DateTime.MonthDayYear4WithDashesHour24Minutes);
                                break;
                            case ColumnType.Date:
                                if (prop.PropertyType == typeof(DateTime?))
                                {
                                    var valDateTime = (DateTime?)prop.GetValue(item);
                                    val = valDateTime.Value.Date;
                                }
                                ws.Cell(row, col).Style.NumberFormat.SetNumberFormatId((int)XLPredefinedFormat.DateTime.DayMonthYear4WithSlashes);
                                break;
                        }
                        ws.Cell(row, col).SetValue(val);
                    }
                    col++;
                }
                row++;
            }

            //auto fit column
            ws.Columns(1,columnDefinitions.Count()).AdjustToContents();

            return wb;
        }
    }
}
