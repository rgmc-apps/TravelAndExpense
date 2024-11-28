using System;
using System.Data;
using System.Windows.Forms;

using MyCommon;
using MyCommon.Settings;

namespace MyRIS
{
    public partial class frmFilter : Form
    {
        private Function function = new Function();

        private DataTable mvColumnHeader;

        private string mvFilterBy = "";
        private string mvFilterCaption = "";

        const int IX_FIELD_NAME = 1;
        const int IX_DATA_TYPE = 2;

        const string CONTAINS = "CONTAINS";
        const string IS_EQUAL_TO = "IS EQUAL TO";
        const string IS_NOT_EQUAL_TO = "IS NOT EQUAL TO";
        const string IS_GREATER_THAN = "IS GREATER THAN";
        const string IS_GREATER_THAN_OR_EQUAL_TO = "IS GREATER THAN OR EQUAL TO";
        const string IS_LESS_THAN = "IS LESS THAN";
        const string IS_LESS_THAN_OR_EQUAL_TO = "IS LESS THAN OR EQUAL TO";
        const string IS_BETWEEN = "IS BETWEEN";        
                
        public frmFilter()
        {
            InitializeComponent();
        }

        #region Property

        public DataTable ColumnHeader
        {
            set { mvColumnHeader = value; }
        }

        public string FilterBy
        {
            get
            { return mvFilterBy; }
        }

        public string FilterCaption
        {
            get
            { return mvFilterCaption; }
        }


        #endregion


        #region Procedure        

        private void LoadComboList()
        {
            try
            {
                // fields
                // ******************************
                function.PopulateComboBox(cboField, mvColumnHeader, "tag", "name");
                cboField.SelectedIndex = 0;
                // ******************************

                // operation
                // ******************************
                cboOperation.Items.Add(CONTAINS);
                cboOperation.Items.Add(IS_EQUAL_TO);
                cboOperation.Items.Add(IS_NOT_EQUAL_TO);
                cboOperation.Items.Add(IS_GREATER_THAN);
                cboOperation.Items.Add(IS_GREATER_THAN_OR_EQUAL_TO);
                cboOperation.Items.Add(IS_LESS_THAN);
                cboOperation.Items.Add(IS_LESS_THAN_OR_EQUAL_TO);
                cboOperation.Items.Add(IS_BETWEEN);

                cboOperation.SelectedIndex = 0;
                // ******************************

            }

            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void ShowObjects()
        {
            string strDataType = function.SplitText(cboField.SelectedValue.ToString(), IX_DATA_TYPE);

            txtFilter.Visible = false;

            dtpFromDate.Visible = false;
            lblDashDate.Visible = false;
            dtpToDate.Visible = false;

            txtFromNumber.Visible = false;
            lblDashNumber.Visible = false;
            txtToNumber.Visible = false;

            if (cboOperation.Text == IS_BETWEEN)
            {
                if ((strDataType == GlobalSettings.DATE) || (strDataType == GlobalSettings.DATETIME))
                {
                    dtpFromDate.Visible = true;
                    lblDashDate.Visible = true;
                    dtpToDate.Visible = true;
                }
                else
                {
                    txtFromNumber.Visible = true;
                    lblDashNumber.Visible = true;
                    txtToNumber.Visible = true;
                }
            }
            else
            {
                switch (strDataType)
                {
                    case GlobalSettings.DATE:
                        dtpFromDate.Visible = true;
                        break;

                    case GlobalSettings.DATETIME:
                        dtpFromDate.Visible = true;
                        break;

                    case GlobalSettings.INTEGER:
                        txtFromNumber.Visible = true;
                        break;

                    case GlobalSettings.DOUBLE:
                        txtFromNumber.Visible = true;
                        break;

                    default:
                        txtFilter.Visible = true;
                        break;
                }
            }
        }

        private string ValidateInfo()
        {
            string strReturn = "";

            string strDataType = function.SplitText(cboField.SelectedValue.ToString(), IX_DATA_TYPE);

            try
            {
                if (cboOperation.Text == CONTAINS)
                {
                    if ((strDataType == GlobalSettings.DATE) || 
                        (strDataType == GlobalSettings.DATETIME) ||
                        (strDataType == GlobalSettings.INTEGER) ||
                        (strDataType == GlobalSettings.DOUBLE))
                    { throw new Exception("Invalid search operation."); }
                }

                if ((txtFilter.Visible == true) && (txtFilter.Text.Trim() == ""))
                { throw new Exception("Invalid filter value."); }

                if (txtFromNumber.Visible == true)
                {
                    if (txtFromNumber.Text.Trim() == "")
                    { throw new Exception("Invalid filter value."); }

                    if (function.IsDouble(txtFromNumber.Text) == false)
                    { throw new Exception("Invalid filter value."); }
                }

                if (txtToNumber.Visible == true)
                {
                    if (txtToNumber.Text.Trim() == "")
                    { throw new Exception("Invalid filter value."); }

                    if (function.IsDouble(txtToNumber.Text) == false)
                    { throw new Exception("Invalid filter value."); }
                }
            }
            catch (Exception ex)
            { strReturn = ex.Message; }

            return strReturn;
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();            
        }        
        
        private void frmFilter_Load(object sender, EventArgs e)
        {
            LoadComboList();
        }

        private void cboField_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string strDataType = function.SplitText(cboField.SelectedValue.ToString(), IX_DATA_TYPE);

            if (cboOperation.Text == CONTAINS)
            {
                if ((strDataType == GlobalSettings.DATE) || 
                    (strDataType == GlobalSettings.DATETIME) ||
                    (strDataType == GlobalSettings.INTEGER) || 
                    (strDataType == GlobalSettings.DOUBLE))
                { cboOperation.Text = IS_EQUAL_TO; }
            }

            ShowObjects();
        }

        private void cboOperation_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ShowObjects();
        }

        private void txtFromNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = function.DoubleOnly(e.KeyChar, sender);    
        }

        private void txtToNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = function.DoubleOnly(e.KeyChar, sender);    
        }

        private void txtFilter_Enter(object sender, EventArgs e)
        {
            txtFilter.SelectAll();
        }

        private void txtFromNumber_Enter(object sender, EventArgs e)
        {
            txtFromNumber.SelectAll();
        }

        private void txtToNumber_Enter(object sender, EventArgs e)
        {
            txtToNumber.SelectAll();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strResult = "";

            string strFilterBy = "";
            string strFieldName = "";
            string strDataType = "";

            string strFilter1 = "";
            string strFilter2 = "";

            try
            {
                strResult = ValidateInfo();

                if (strResult != "")
                { throw new Exception(strResult); }

                // text
                // ******************************
                if (txtFilter.Visible == true)
                { strFilter1 = txtFilter.Text.Trim(); }
                // ******************************


                // date
                // ******************************
                if (dtpFromDate.Visible == true)
                { strFilter1 = dtpFromDate.Value.ToString("MM/dd/yyyy"); }

                if (dtpToDate.Visible == true)
                { strFilter2 = dtpToDate.Value.ToString("MM/dd/yyyy"); }
                // ******************************

                // number
                // ******************************
                if (txtFromNumber.Visible == true)
                { strFilter1 = Convert.ToDouble(txtFromNumber.Text.Trim()).ToString(); }

                if (txtToNumber.Visible == true)
                { strFilter2 = Convert.ToDouble(txtToNumber.Text.Trim()).ToString(); }
                // ******************************

                strFieldName = function.SplitText(cboField.SelectedValue.ToString(), IX_FIELD_NAME);
                strDataType = function.SplitText(cboField.SelectedValue.ToString(), IX_DATA_TYPE);

                mvFilterCaption = cboField.Text + " " + cboOperation.Text + " " + strFilter1;

                switch (cboOperation.Text)
                {
                    case CONTAINS:
                        strFilterBy = strFieldName + " LIKE " + (strFilter1 + '%').sQuote();
                        break;

                    case IS_EQUAL_TO:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " = " + strFilter1; }
                        else if ((strDataType == GlobalSettings.DATE) || (strDataType == GlobalSettings.DATETIME))
                        { strFilterBy = strFieldName + " >= " + strFilter1.sQuote() + " AND " + strFieldName + " < " + Convert.ToDateTime(strFilter1).AddDays(1).ToString().sQuote(); }
                        else
                        { strFilterBy = strFieldName + " = " + strFilter1.sQuote(); }
                        
                        break;

                    case IS_NOT_EQUAL_TO:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " <> " + strFilter1; }
                        else
                        { strFilterBy = strFieldName + " <> " + strFilter1.sQuote(); }
                        
                        break;

                    case IS_GREATER_THAN:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " > " + strFilter1; }
                        else if ((strDataType == GlobalSettings.DATE) || (strDataType == GlobalSettings.DATETIME))
                        { strFilterBy = strFieldName + " >= " + Convert.ToDateTime(strFilter1).AddDays(1).ToString().sQuote(); }
                        else
                        { strFilterBy = strFieldName + " > " + strFilter1.sQuote(); }

                        break;

                    case IS_GREATER_THAN_OR_EQUAL_TO:
                        if ((strDataType == GlobalSettings.INTEGER)|| (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " >= " + strFilter1; }
                        else
                        { strFilterBy = strFieldName + " >= " + strFilter1.sQuote(); }

                        break;

                    case IS_LESS_THAN:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " < " + strFilter1; }
                        else
                        { strFilterBy = strFieldName + " < " + strFilter1.sQuote(); }

                        break;

                    case IS_LESS_THAN_OR_EQUAL_TO:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " <= " + strFilter1; }
                        else
                        { strFilterBy = strFieldName + " <= " + strFilter1.sQuote(); }

                        break;

                    case IS_BETWEEN:
                        if ((strDataType == GlobalSettings.INTEGER) || (strDataType == GlobalSettings.DOUBLE))
                        { strFilterBy = strFieldName + " >= " + strFilter1 + " AND " + strFieldName + " <= " + strFilter2; }
                        else if ((strDataType == GlobalSettings.DATE) || (strDataType == GlobalSettings.DATETIME))
                        { strFilterBy = strFieldName + " >= " + strFilter1.sQuote() + " AND " + strFieldName + " < " + Convert.ToDateTime(strFilter2).AddDays(1).ToString().sQuote(); }
                        else
                        { strFilterBy = strFieldName + " >= " + strFilter1.sQuote() + " AND " + strFieldName + " <= " + strFilter2.sQuote(); }

                        mvFilterCaption = cboField.Text + " " + cboOperation.Text + " " + strFilter1 + " AND " + strFilter2;

                        break;
                }

                mvFilterBy = strFilterBy;                

                this.Close();
            }
            catch (Exception ex)
            { function.MsgBoxInfo(this.Text, ex.Message); }
        }

        private void frmFilter_Activated(object sender, EventArgs e)
        {
            txtFilter.Focus();
        }
               
    }
}
