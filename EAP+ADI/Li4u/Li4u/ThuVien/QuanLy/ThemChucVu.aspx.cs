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

public partial class ThuVien_QuanLy_ThemTacGia : System.Web.UI.Page
{
    public void ham(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        { btThem.Enabled = false; }
        else { btThem.Enabled = true; }
        lbrong.Visible = false;
    }
    protected void lbThem_Click(object sender, EventArgs e)
    {        
        ChucVuTableAdapter C_vu = new ChucVuTableAdapter();
        Data.ChucVuDataTable ban_chucvu = C_vu.GetChucVu();
        int luu = 0;
        int _stt;
        bool _co = false;

        if (ban_chucvu.Count > 0)                   //có dữ liệu.
        {
            for (int i = 0; i < ban_chucvu.Count - 1; i++)
            {
                if (ban_chucvu[i + 1].MaChucVu - ban_chucvu[i].MaChucVu != 1)//có lỗ rỗng
                {
                    _co = true;
                    luu = i;
                    i = ban_chucvu.Count - 1;
                }
            }
            if (ban_chucvu[0].MaChucVu != 1) //vị trí 0 khác 1.
                _stt = 1;
            else
            {
                if (_co == true)//có lỗ trống.
                    _stt = ban_chucvu[luu].MaChucVu + 1;
                else
                    _stt = ban_chucvu[ban_chucvu.Count - 1].MaChucVu + 1;
            }
        }
        else
        {
            _stt = 1;
        }
        if (txtchucvu.Text != "")
        { 
            lbrong.Visible = false;
            C_vu.ThemChucVu (_stt,txtchucvu.Text);
            ham("Chức vụ: " + txtchucvu.Text.Trim() + " Mã Chức Vụ: " + _stt);
            txtchucvu.Text = "";
        }
        else
        { lbrong.Visible = true; }
        
    }
   
}
