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

public partial class ThuVien_QuanLy_ThongKeTacGia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (grvthongtin.Rows.Count > 0)
        {
            btexcel.Visible = true;
            btword.Visible = true;
            btpdf.Visible = true;
        }
        else {
            btexcel.Visible = false;
            btword.Visible = false;
            btpdf.Visible = false;
        }
    }
    protected void btexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("BaoCao.xls", grvthongtin);
    }
    protected void btword_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.XuatDuLieuRaWord(grvthongtin);
    }
    protected void btpdf_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.XuatDuLieuGridRaPDF(grvthongtin);
    }
}
