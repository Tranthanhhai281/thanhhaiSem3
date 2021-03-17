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

public partial class ThuVien_DocGia_DangKyMuonSach : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void tbDangNhap_Click(object sender, EventArgs e)
    {
        DocGiaTableAdapter _DG = new DocGiaTableAdapter();
        lbThongBao.Text = "";
        String _madg = txtMaDocGia.Text.Trim();
        Data.DocGiaDataTable _banDG = _DG.GetByMaDG(_madg);
        if (_banDG.Count > 0)//là đoc giả
        {
            Session["DGDangNhap"] = _banDG[0].MaDocGia.Trim();
            HttpCookie DGDangNhap = new HttpCookie("DGDangNhap", _banDG[0].MaDocGia.Trim());
            DGDangNhap.Expires = DateTime.Now.AddDays(1); // Sau 1 ngày hết hạn
            Response.Cookies.Add(DGDangNhap);
           Response.Redirect("~/ThuVien/DocGia/Default.aspx");
        }
        else
        {
            lbThongBao.Text = "Mã Đọc Giả Không Tồn Tại!";
        }
    }
}
