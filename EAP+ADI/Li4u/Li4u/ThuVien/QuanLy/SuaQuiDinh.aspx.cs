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
        QuiDinhTableAdapter Q_dinh = new QuiDinhTableAdapter();
        Data.QuiDinhDataTable ban_quidinh = Q_dinh.GetQuiDinh();
        if (!IsPostBack)
        {
            txtSachCB.Text = ban_quidinh[0].LuongSachCanBoMuon.ToString();
            txtSachSV.Text = ban_quidinh[0].LuongSachChoSinhVienMuon.ToString();
            txtlanvipham.Text = ban_quidinh[0].DuocPhepViPham.ToString();
            txtthoihansv.Text = ban_quidinh[0].NgayMuonSV.ToString();
            txtthoihancb.Text = ban_quidinh[0].NgayMuonCB.ToString();
        }
        lbrongsachcb.Visible = false;
        lbrongthoihancb.Visible = false;
        lbrongthoihansv.Visible = false;
        lbrongsachsv.Visible = false;
        lbrongviphamtoida.Visible = false;
         if (Convert.ToString(Session["TaiKhoan"]) != "")
         {            
             btThem.Enabled = true;
             btThem.Enabled = true;           
         }
         else
         {
             btThem.Enabled = false;
             btThem.Enabled = false;
         }
    }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        QuiDinhTableAdapter Q_dinh = new QuiDinhTableAdapter();
        //Q_dinh.SuaQuiDinh(2, 3, 4, 5, 5);
        lbrongsachcb.Visible = false;
        lbrongthoihancb.Visible = false;
        lbrongthoihansv.Visible = false;
        lbrongsachsv.Visible = false;
        lbrongviphamtoida.Visible = false;
        int sachcanbomuon = Convert.ToInt32(txtSachCB.Text.Trim());
        int sachsinhvienmuon = Convert.ToInt32(txtSachSV.Text.Trim());
        int vipham = Convert.ToInt32(txtlanvipham.Text.Trim());
        int thoihanchosv = Convert.ToInt32(txtthoihansv.Text.Trim());
        int thoihanchocb = Convert.ToInt32(txtthoihancb.Text.Trim());
        Q_dinh.SuaQuiDinh(sachcanbomuon, sachsinhvienmuon, vipham, thoihanchosv, thoihanchocb);
        lbketqua.Text = "Cập Nhật Thành Công!";
    }
    protected void btthem_Click(object sender, EventArgs e)
    {
        QuiDinhTableAdapter Q_dinh = new QuiDinhTableAdapter();

        if (txtSachCB.Text != "" && txtSachSV.Text != "" && txtthoihancb.Text != "" && txtthoihansv.Text != "" && txtlanvipham.Text != "")
        {
            lbrongsachcb.Visible = false;
            lbrongthoihancb.Visible = false;
            lbrongthoihansv.Visible = false;
            lbrongsachsv.Visible = false;
            lbrongviphamtoida.Visible = false;
            int sachcanbomuon = Convert.ToInt32(txtSachCB.Text.Trim());
            int sachsinhvienmuon = Convert.ToInt32(txtSachSV.Text.Trim());
            int vipham = Convert.ToInt32(txtlanvipham.Text.Trim());
            int thoihanchosv = Convert.ToInt32(txtthoihansv.Text.Trim());
            int thoihanchocb = Convert.ToInt32(txtthoihancb.Text.Trim());
            Q_dinh.SuaQuiDinh(sachcanbomuon, sachsinhvienmuon, vipham, thoihanchosv, thoihanchocb);
            lbketqua.Text = "Cập Nhật Thành Công!";
        }
        else
        {
            if (txtSachCB.Text == "") { lbrongsachcb.Visible = true; } else { lbrongsachcb.Visible = false; }
            if (txtthoihancb.Text == "") { lbrongthoihancb.Visible = true; } else { lbrongthoihancb.Visible = false; }
            if (txtthoihansv.Text == "") { lbrongthoihansv.Visible = true; } else { lbrongthoihansv.Visible = false; }
            if (txtSachSV.Text == "") { lbrongsachsv.Visible = true; } else { lbrongsachsv.Visible = false; }
            if (txtlanvipham.Text == "") { lbrongviphamtoida.Visible = true; } else { lbrongviphamtoida.Visible = false; }
        }
    }
}