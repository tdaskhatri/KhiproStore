using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI.WebControls;

namespace eLearning.Common.Utils
{
  public  class ExportToExcel
    {
        Logger logger = Logger.getInstance();
        string Module_NAME = "ExportToExcel";

        // Added by AVANZA\vijay.kumar on 08/02/2018 12:20:28
        public void GenerateExcel(string fileName,GridView gv, int isPaymentSearch = 0)
        {
            try
            {
                System.Web.HttpContext.Current.Response.Clear();
                System.Web.HttpContext.Current.Response.ClearContent();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = true;
                HttpContext.Current.Response.ContentType = "application/ms-excel";
                HttpContext.Current.Response.Write(@"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.0 Transitional//EN"">");
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName + ".xls");
                HttpContext.Current.Response.Charset = "utf-8";
                HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("windows-1250");
                //sets font
                HttpContext.Current.Response.Write("<font style='font-size:10.0pt; font-family:Calibri;'>");
                HttpContext.Current.Response.Write("<BR><BR><BR>");
                //sets the table border, cell spacing, border color, font of the text, background, foreground, font height
                HttpContext.Current.Response.Write("<Table border='1' bgColor='#ffffff' " +
                  "borderColor='#000000' cellSpacing='0' cellPadding='0' " +
                  "style='font-size:10.0pt; font-family:Calibri; background:white;'> <TR>");
                //am getting my grid's column headers
                int columnscount = gv.Columns.Count;

                for (int j = 0; j < columnscount-1; j++)
                {      //write in new column
                    HttpContext.Current.Response.Write("<Td>");
                    //Get column headers  and make it as bold in excel columns
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write(gv.Columns[j].HeaderText.ToString());
                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                }
                HttpContext.Current.Response.Write("</TR>");
                decimal amount = 0;
                decimal discount = 0;
                decimal additionalAmount = 0;
                decimal totalTaxAmount = 0;
                decimal grandTotal = 0;
                string userName = gv.Rows[0].Cells[11].Text.ToString();

                foreach (GridViewRow row  in gv.Rows)
                {//write in new row
                    // Added by Muhammad Uzair on 14/03/2018 15:02:28 as ONSITE_DEV
                    // Warning do not remove the created by column from 11 position other wise error
                    if (isPaymentSearch == 1 && (userName != row.Cells[11].Text.ToString()))
                    {
                        userName = row.Cells[11].Text.ToString();
                        // Headers for the extra fields
                        HttpContext.Current.Response.Write("<TR>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write("<B>");
                        HttpContext.Current.Response.Write("AMOUNT SUM");
                        HttpContext.Current.Response.Write("</B>");
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write("<B>");
                        HttpContext.Current.Response.Write("DISCOUNT SUM");
                        HttpContext.Current.Response.Write("</B>");
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write("<B>");
                        HttpContext.Current.Response.Write("ADDITIONAL AMOUNT SUM");
                        HttpContext.Current.Response.Write("</B>");
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write("<B>");
                        HttpContext.Current.Response.Write("TOTAL TAX AMOUNT SUM");
                        HttpContext.Current.Response.Write("</B>");
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write("<B>");
                        HttpContext.Current.Response.Write("GRAND TOTAL SUM");
                        HttpContext.Current.Response.Write("</B>");
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("</TR>");

                        // Values for the extra fields
                        HttpContext.Current.Response.Write("<TR>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(amount);
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(discount);
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(additionalAmount);
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(totalTaxAmount);
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(grandTotal);
                        HttpContext.Current.Response.Write("</Td>");
                        HttpContext.Current.Response.Write("</TR>");

                        amount = discount = additionalAmount = totalTaxAmount = grandTotal = 0;
                    }

                    HttpContext.Current.Response.Write("<TR>");
                    for (int i = 0; i < gv.Columns.Count-1; i++)
                    {
                        // Added by Muhammad Uzair on 14/03/2018 14:13:55 as ONSITE_DEV
                        // Catered Specific case for Payment Search
                        if(isPaymentSearch == 1)
                        {
                            switch (i)
                            {
                                case 5:
                                    amount += Convert.ToDecimal(row.Cells[i].Text);
                                    break;
                                case 6:
                                    discount += Convert.ToDecimal(row.Cells[i].Text);
                                    break;
                                case 7:
                                    additionalAmount += Convert.ToDecimal(row.Cells[i].Text);
                                    break;
                                case 8:
                                    totalTaxAmount += Convert.ToDecimal(row.Cells[i].Text);
                                    break;
                                case 9:
                                    grandTotal += Convert.ToDecimal(row.Cells[i].Text);
                                    break;
                            }
                        }

                        HttpContext.Current.Response.Write("<Td>");
                        HttpContext.Current.Response.Write(row.Cells[i].Text.ToString());
                        HttpContext.Current.Response.Write("</Td>");
                    }

                    HttpContext.Current.Response.Write("</TR>");
                }
                // Added by Muhammad Uzair on 14/03/2018 14:04:03 as ONSITE_DEV
                if(isPaymentSearch == 1)
                {
                    // Headers for the extra fields
                    HttpContext.Current.Response.Write("<TR>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write("AMOUNT SUM");
                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write("DISCOUNT SUM");
                    HttpContext.Current.Response.Write("</B>"); 
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write("ADDITIONAL AMOUNT SUM");
                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write("TOTAL TAX AMOUNT SUM");
                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write("<B>");
                    HttpContext.Current.Response.Write("GRAND TOTAL SUM");
                    HttpContext.Current.Response.Write("</B>");
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("</TR>");

                    // Values for the extra fields
                    HttpContext.Current.Response.Write("<TR>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(amount);
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(discount);
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(additionalAmount);
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(totalTaxAmount);
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("<Td>");
                    HttpContext.Current.Response.Write(grandTotal);
                    HttpContext.Current.Response.Write("</Td>");
                    HttpContext.Current.Response.Write("</TR>");
                }

                HttpContext.Current.Response.Write("</Table>");
                HttpContext.Current.Response.Write("</font>");
                HttpContext.Current.Response.Flush();
              //  HttpContext.Current.ApplicationInstance.CompleteRequest();
                HttpContext.Current.Response.End();
            }
            //Added by Fahim Nasir 02/03/2018 11:39:37
            catch (System.Threading.ThreadAbortException exp)
            {
                logger.Error(Module_NAME, "GenerateExcel", exp);
            }
            //===========================================
            catch (Exception ex)
            {
                logger.Error(Module_NAME, "GenerateExcel", ex);
                throw ex;
            }
            
        }
        

    }
}
