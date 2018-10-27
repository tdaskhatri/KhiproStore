using eLearning.Common.Utils;
using eLearning.DAL.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Store
{
    public partial class TotalAmount : System.Web.UI.Page
    {
        public TotalAmount() { }

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnEditText_Click(object sender, EventArgs e)
        {
            // Initialize the controls in the panel used as the UI of the dialog box
            InitDialog();

            // The panel markup has been served already to the page. To edit it, 
            // you need to a) wrap the panel's content in an UpdatePanel region and 
            // b) update the panel once you made any changes
            ModalPanel1.Update();

            // Order to inject the script to show the dialog as the page loads up 
            // in the browser.
            ModalPopupExtender1.Show();
        }
        protected void InitDialog()
        {
            editCustomerID.Text = lblCustomerID.Text;
            editTxtCompanyName.Text = lblCompanyName.Text;
            editTxtContactName.Text = lblContactName.Text;
            editTxtCountry.Text = lblCountry.Text;
            SetFocus("editTxtCompanyName");
        }
        protected void btnApply_Click(object sender, EventArgs e)
        {
            // Edit the server controls in the modal panel. Because the 
            // call occurs over a partial rendering call, any updates
            // will be automatically reflected by the client UI.
            if (editTxtCountry.Text == "Germany")
                editTxtCountry.Text = "Cuba";
            else
                editTxtCountry.Text = "USA";
        }
        protected void editBox_OK_Click(object sender, EventArgs e)
        {
            // Save to the database
            // Refresh the UI
            lblCompanyName.Text = editTxtCompanyName.Text;
            lblContactName.Text = editTxtContactName.Text;
            lblCountry.Text = editTxtCountry.Text;
        }
    }
}