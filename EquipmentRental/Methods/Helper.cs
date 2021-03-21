using EquipmentRental.Models;
using System.Collections.Generic;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace EquipmentRental.Methods
{
    public static class Helper
    {
        private static int one_time = 100;

        private static int premium = 60;

        private static int regular = 40;

        public static readonly Dictionary<int, string> EquipmentTypes = new Dictionary<int, string>
        {
            {1,"Specialized" },
            {2,"Regular" },
            {3, "Heavy"}
        };

        public static int Calculate(int number_of_days,int Type_id)
        {
           int total = 0;

           switch(Type_id)
            {
                case 1:
                    total += number_of_days > 3 ? (3 * premium) + (number_of_days - 3) * regular : number_of_days * premium;
                    break;
                case 2:
                    total += number_of_days > 2 ? one_time + 2 * premium + (number_of_days - 2) * regular : one_time + number_of_days * premium;
                    break;
                case 3:
                    total += one_time + premium * number_of_days;
                    break;
                    
            }

            return total;
        }
        public static byte[] GenerateReport(List<Order> orders)
        {
            byte[] fileContents;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var package=new ExcelPackage())
            {
                var workSheet = package.Workbook.Worksheets.Add("Report");

                List<string> Headers = new List<string>()
                {
                    "Name","Price","Bonus"
                };
                #region Header Row

                for(int i=0;i<Headers.Count;i++)
                {
                    workSheet.Cells[1, i+1].Value = Headers[i];
                    workSheet.Cells[1, i+1].Style.Font.Size = 12;
                    workSheet.Cells[1, i+1].Style.Font.Bold = true;
                    workSheet.Cells[1, i+1].Style.Border.Top.Style = ExcelBorderStyle.Hair;
                }

                #endregion

                #region Rows

                int total_price = 0;
                int total_bonus = 0;
                for(int i=0;i<orders.Count;i++)
                {
                    int bonus = orders[i].Equipment.Type_id == 3 ? 2 : 1;
                    total_price += orders[i].Price;
                    total_bonus += bonus;
                    workSheet.Cells[i + 2, 1].Value = orders[i].Equipment.Name;
                    workSheet.Cells[i + 2, 2].Value = orders[i].Price;
                    workSheet.Cells[i + 2, 3].Value = bonus;
                }

                int cell_index = 1 + orders.Count + 2;
                workSheet.Cells[cell_index, 4].AutoFitColumns();
                workSheet.Cells[cell_index, 4].Value = $"Total Price:{total_price}";
                workSheet.Cells[cell_index, 4].Style.Font.Size = 20;

                workSheet.Cells[cell_index+1, 4].AutoFitColumns();
                workSheet.Cells[cell_index+1, 4].Value = $"Total Bonus: {total_bonus}";
                workSheet.Cells[cell_index+1,4].Style.Font.Size = 20;
                #endregion

                fileContents = package.GetAsByteArray();
            }

            return fileContents;

        }
    }
}
