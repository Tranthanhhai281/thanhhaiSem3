using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataTableAdapters;

public partial class ThuVien_DocGia_DangKy1 : System.Web.UI.Page
{   
    private Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Thêm Đọc Giả";
        if (!IsPostBack) {
            btchon.Enabled = false;
            txtfileValue.Enabled = false;
            tbThem.Enabled = true;
            txtMaDG.Enabled = true;
            txthoten.Enabled = true;
            txtEmail.Enabled = true;
            drpChucVu.Enabled = true;
            txtNam.Enabled = true;
            drpGioi.Enabled = true;
            drpNgay.Enabled = true;
            drpThang.Enabled = true;
        }
    }    

    protected void txtTenDannhap_TextChanged(object sender, EventArgs e)
    {
        lbThanhCong.Text = "";
    }
    protected void tbDangky_Click(object sender, EventArgs e)
    {
        lbCanhBao.Text = "";
        lbCanhBao.Text = "";
        DocGiaTableAdapter D_G = new DocGiaTableAdapter();
        Data.DocGiaDataTable ban_docgia = D_G.GetDocGia();
        bool _co = true;
        string _madocgia = txtMaDG.Text;
        if (txtMaDG.Text == "")
        { lbrongmadg.Visible = true; }
        else 
        { lbrongmadg.Visible = false;
            if (ban_docgia.Count > 0)
            {                
                for (int i = 0; i < ban_docgia.Count; i++)
                {
                    if (ban_docgia[i].MaDocGia.Trim() == _madocgia.Trim())
                    {   _co = false;
                        i = ban_docgia.Count;    }
                    else
                    { _co = true; }
                }
                if (_co == false)
                { lbCanhBao.Text = "Mã Đọc Giả Đã Tồn Tại!"; }
                else 
                { lbCanhBao.Text = "";                
                }
            }
        }
        if (txthoten.Text != "" && txtNam.Text != ""&&_co==true)
        {
            string _hoten = txthoten.Text;
            string _gioi = drpGioi.SelectedValue;
            string _ngay = drpNgay.SelectedValue;
            string _thang = drpThang.SelectedValue;
            string _nam = txtNam.Text;
            string _email = txtEmail.Text;
            string _date = _ngay + "/" + _thang + "/" + _nam;
            int _machucvu = Convert.ToInt32(drpChucVu.SelectedValue);

            if (txtEmail.Text != "")
            {
                D_G.ThemDG(_madocgia, _machucvu, _hoten, _gioi, _date, _email);
                lbThanhCong.Text = "Đọc Giả " + _madocgia + " Đã Được Thêm";
            }
            else
            {
                D_G.ThemDG(_madocgia, _machucvu, _hoten, _gioi, _date, null);
                lbThanhCong.Text = "Đọc Giả " + _madocgia + " Đã Được Thêm";
            }
        }
        else
        {
            if (txtNam.Text != "")
            { lbrongnam.Visible = false; }
            else { lbrongnam.Visible = true; }
            if (txthoten.Text != "")
            { lbrongten.Visible = false; }
            else { lbrongten.Visible = true; }
        }       
    } 
    protected void radiochon_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (radiochon.SelectedValue == "0")
        { btchon.Enabled = false;
          txtfileValue.Enabled = false;
          tbThem.Enabled = true;
          txtMaDG.Enabled = true;
          txthoten.Enabled = true;
          txtEmail.Enabled = true;
          drpChucVu.Enabled = true;
          txtNam.Enabled = true;
          drpGioi.Enabled = true;
          drpNgay.Enabled = true;
          drpThang.Enabled = true;
        }
        else {
                      
            txtfileValue.Enabled =true;            
            btchon.Enabled = true;
            tbThem.Enabled = false;
            txtMaDG.Enabled = false;
            txthoten.Enabled = false;
            txtEmail.Enabled = false;
            drpChucVu.Enabled = false;
            txtNam.Enabled = false;
            drpGioi.Enabled = false;
            drpNgay.Enabled = false;
            drpThang.Enabled = false;
        }
    }
    protected void btchon_Click(object sender, EventArgs e)
    {
        string m_strFileName = "";

        if (txtfileValue.HasFile)//không có ảnh up load 
        {
            // Make sure that a JPG has been uploaded
            if (string.Compare(System.IO.Path.GetExtension(txtfileValue.FileName), ".xls", true) != 0)
            {
                lbCanhBao.Text = "Chỉ Có Tập Tin *.xls";                
            }
            else
            {              
                // Save the file to disk and set the value of the brochurePath parameter
                const string BrochureDirectory = "~/ThuVien/QuanLy/Excel/";
                string brochurePath = BrochureDirectory + txtfileValue.FileName;
                string fileNameWithoutExtension =
                System.IO.Path.GetFileNameWithoutExtension(txtfileValue.FileName);
                int iteration = 1;
                while (System.IO.File.Exists(Server.MapPath(brochurePath)))
                {
                    brochurePath = string.Concat(BrochureDirectory, fileNameWithoutExtension,
                        "-", iteration, ".xls");
                    iteration++;
                }            
               
                // Save the file to disk and set the value of the brochurePath parameter
                txtfileValue.SaveAs(Server.MapPath(brochurePath));
                // e.Values["brochurePath"] = brochurePath;
                m_strFileName = txtfileValue.FileName;
                Response.Redirect("~/ThuVien/QuanLy/ChiTietThemDocGia.aspx?Ten_file=" + brochurePath);
               // System.IO.File.Delete(Server.MapPath(brochurePath));

                // e.Values["brochurePath"] = brochurePath;                             
            }
        }
        lbCanhBao.Text = m_strFileName;
      
       
    }
        // Trong hàm này, ta xây dựng Hàm GetListofSheetsAndCharts(m_strFileName, true, drpShtAndChrt) để tách File thành các Sheet và Chart, có nội dung như sau:
   
    
    protected void grvthongtin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
