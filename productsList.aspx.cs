using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Store
{
    public partial class productsList : System.Web.UI.Page
    {
        Logger logger = Logger.getInstance();
        string MODULE_NAME = "PRODUCT_STOCK_LIST";
        DAStock stock = new DAStock();
        StringBuilder htmlTable = new StringBuilder();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //popddlStockType();
                //               GetTotalProducts();
                DataTable dt = stock.GetStockList();
                StockList.DataSource = dt;

                StockList.DataBind();

            }
        }
        private void GetTotalProducts()
        {
            try
            {
               
                DataTable dt = stock.GetStockList();
                int countRow = dt.Rows.Count;
                int countCol = dt.Columns.Count;
                StringBuilder html = new StringBuilder();
                html.Append("<table id='example1' class='table table - bordered table - striped dataTable' role='grid' aria-describedby='example1_info'>");

                //Building the Header row.
                html.Append("<tr role='row'>");
                foreach (DataColumn column in dt.Columns)
                {
                    html.Append("<th tabindex='0' aria-controls='example1' rowspan='1' colspan='1' style='width: 182.467px; ' aria-sort='ascending'>");
                    html.Append(column.ColumnName);
                    html.Append("</th>");
                }
                html.Append("</tr>");

                //Building the Data rows.
                foreach (DataRow row in dt.Rows)
                {
                    html.Append("<tr>");
                    foreach (DataColumn column in dt.Columns)
                    {
                        html.Append("<td>");
                        html.Append(row[column.ColumnName]);
                        html.Append("</td>");
                    }
                    html.Append("</tr>");
                }

                //Table end.
                html.Append("</table>");

                //Append the HTML string to Placeholder.
             //   PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
            
            





                /*  for (int i = 0; i < countRow; i++)
                      for (int j = 0; j < countCol; j++)
                      {
                          if (j == 0)
                          {
                              SFieldName= (dt.Rows[i][j]).ToString();
                              Name.Text = SFieldName;
                          }
                          else if (j == 1)
                          {
                              iFieldName = Convert.ToInt32(dt.Rows[i][j]);
                              sFieldValue = iFieldName.ToString();
                              Name1.Text = sFieldValue;
                          }
                          else if (j == 2)
                          {
                              iFieldName = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                              sFieldValue = iFieldName.ToString();
                              Name2.Text = sFieldValue;
                          }
                          else if (j == 3)
                          {
                              iFieldName = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                              sFieldValue = iFieldName.ToString();
                              Name3.Text = sFieldValue;
                          }
                          else if (j == 4)
                          {
                              iFieldName = Convert.ToInt32(dt.Rows[i].ItemArray[j]);
                              sFieldValue = iFieldName.ToString();
                              Name4.Text = sFieldValue;
                          }
                      }

                  
               
                
                foreach (DataRow row in dt.Rows)
                {  // String sFieldValue;
                    //int iFieldName;
                    foreach (var item in row.ItemArray) {

                        //Name1.Text = (item).ToString();
                    }

                    /*string sName = row["NAME"].ToString();
                    Name.Text= sName;
                    int Measure_Type = Convert.ToInt32(row["MEASURE_TYPE"]);
                    sFieldValue = Measure_Type.ToString();
                    Name1.Text = sFieldValue;


                    iFieldName = Convert.ToInt32(row["PURCHASE_PRICE"]);
                    sFieldValue = Measure_Type.ToString();
                    Name2.Text = sFieldValue;

                    iFieldName = Convert.ToInt32(row["SELL_PRICE"]);
                    sFieldValue = Measure_Type.ToString();
                    Name3.Text = sFieldValue;

                    iFieldName = Convert.ToInt32(row["STOCK_PRICE"]);
                    sFieldValue = Measure_Type.ToString();
                    Name4.Text = sFieldValue;
                    

                  
                }*/




            }

            catch (Exception ex)
            {
                logger.Error(MODULE_NAME, "RODUCT_STOCK_LIST", ex);
            }

        }
    }
}