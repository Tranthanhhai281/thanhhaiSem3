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

public partial class ThuVien_DocGia_TKNamXuatBan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (grwthongtin.Rows.Count <= 0)
            lbtieude.Text = "Không Có Kết Quả";
        else
        lbtieude.Text ="Kết Quả Xuất Bản Năm:"+ Request.QueryString["NamXuatBan"];
    }
    protected void grvNamXuatBan_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected string Anh_Bia(object AnhBia)
    {
        string _anh = Convert.ToString(AnhBia);
        if (string.IsNullOrEmpty(_anh) == true)
            return "~/ThuVien/Anh/khongsach.jpg";
        else
            return _anh.Trim();
    }
}
