using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.Text;

using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;


namespace Store
{
    public partial class SaleReports : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
      
        DAStock stock = new DAStock();

        protected void Page_Load(object sender, EventArgs e)
        {
            total_sale.Visible = false;
          //  popup.Visible = false;
        }
        protected void btnSaleReport_Click(object sender, EventArgs e)
        {
            string fromDate, toDate;
            total_sale.Visible = true;
            fromDate = datepicker1.Value;
            toDate = datepicker2.Value;
            DataTable sale = stock.GetSalesReport(fromDate, toDate);
            sale_total.Visible = true;
            Decimal finalamount = 0;
            foreach (DataRow dr in sale.Rows)
            {
                finalamount += Convert.ToDecimal(dr["TOTAL_AMOUNT"].ToString());
            }
            Label_Total_sale.Text = finalamount.ToString();
            SaleStockTrans.DataSource = sale as DataTable;
            SaleStockTrans.DataBind();
        }
        protected void btnSaleReportDetail_Click(object sender, EventArgs e)
        {
            string fromDate, toDate;
            Decimal finalamount = 0;
            total_sale.Visible = true;
            fromDate = DateTime.Now.ToString("yyyy-MM-dd");
            toDate = DateTime.Now.ToString("yyyy-MM-dd");
            DataTable sale = stock.GetSalesReport(fromDate, toDate);
            sale_total.Visible = true;
            foreach (DataRow dr in sale.Rows)
            {
                finalamount += Convert.ToDecimal(dr["TOTAL_AMOUNT"].ToString());
            }
            Label_Total_sale.Text = finalamount.ToString();
            SaleStockTrans.DataSource = sale as DataTable;
            SaleStockTrans.DataBind();
        }
        protected void btnSaleReportPrint_Click(object sender, EventArgs e)
        {
            string fromDate, toDate;
            string companyName = "ASP";
            int orderNo = 2303;
            fromDate = datepicker1.Value;
            toDate = datepicker2.Value;
            DataTable dt = stock.GetSalesReport(fromDate, toDate);

          //  SaleStockTrans.DataSource = dt as DataTable;
            //SaleStockTrans.DataBind();
            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    StringBuilder sb = new StringBuilder();

                    //Generate Invoice (Bill) Header.
                    sb.Append("<table width='100%' cellspacing='0' cellpadding='2'>");
                    sb.Append("<tr><td align='center' style='background-color: #18B5F0' colspan = '2'><b>Order Sheet</b></td></tr>");
                    sb.Append("<tr><td colspan = '2'></td></tr>");
                    sb.Append("<tr><td><b>Order No: </b>");
                    sb.Append(orderNo);
                    sb.Append("</td><td align = 'right'><b>Date: </b>");
                    sb.Append(DateTime.Now);
                    sb.Append(" </td></tr>");
                    sb.Append("<tr><td colspan = '2'><b>Company Name: </b>");
                    sb.Append(companyName);
                    sb.Append("</td></tr>");
                    sb.Append("</table>");
                    sb.Append("<br />");

                    //Generate Invoice (Bill) Items Grid.
                    sb.Append("<table border = '1'>");
                    sb.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        sb.Append("<th style = 'background-color: #D20B0C;color:#ffffff'>");
                        sb.Append(column.ColumnName);
                        sb.Append("</th>");
                    }
                    sb.Append("</tr>");
                    foreach (DataRow row in dt.Rows)
                    {
                        sb.Append("<tr>");
                        foreach (DataColumn column in dt.Columns)
                        {
                            sb.Append("<td>");
                            sb.Append(row[column]);
                            sb.Append("</td>");
                        }
                        sb.Append("</tr>");
                    }
                   
                    sb.Append("</table>");

                    //Export HTML String as PDF.
                    StringReader sr = new StringReader(sb.ToString());
                    Document pdfDoc = new Document(PageSize.A3, 10f, 10f, 10f, 10f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Invoice_" + orderNo + ".pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }
        protected void Display(object sender, EventArgs e)
        {
            int rowIndex = Convert.ToInt32(((sender as LinkButton).NamingContainer as GridViewRow).RowIndex);
            // GridViewRow row = SaleStockTrans.Rows[rowIndex];
           string id = SaleStockTrans.Rows[rowIndex].Cells[0].Text;
           string customer = SaleStockTrans.Rows[rowIndex].Cells[1].Text;
            CustName.Text = customer.ToString();

            DataTable sale = stock.GetSalesReportDetail(id);
            GridView1.DataSource = sale as DataTable;
            GridView1.DataBind();
         
            ClientScript.RegisterStartupScript(this.GetType(), "Pop", "openModal();", true);
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            //Your Saving code.
        }
        protected void btnClose_Click(object sender, EventArgs e)
        {
            total_sale.Visible = true;
        }


    }
}