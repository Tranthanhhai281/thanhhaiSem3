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

public partial class ThuVien_QuanLy_LapChiTietViPham : System.Web.UI.Page
{
    public void ham(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btdongy.Enabled = false;
        }
        else
        {
            btdongy.Enabled = true;
            lbrongmahoadon.Visible = false;
            lbrongsotien.Visible = false;
            string _maluotmuon = Request.QueryString["MaLuotMuon"];
            LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
            SachTableAdapter S_ach = new SachTableAdapter();
            Data.LuotMuonDataTable ban_luotmuon = L_muon.GetbyMaLuotMuon(Convert.ToInt32(_maluotmuon.Trim()));
            if (ban_luotmuon.Count > 0)
            {
                string _madocgia = ban_luotmuon[0].MaDocGia.Trim();
                int _masach = ban_luotmuon[0].MaSach;
                Data.SachDataTable ban_sach = S_ach.GetMaSach(_masach);
                if (ban_sach.Count > 0)
                {
                    string _gia = ban_sach[0].Gia.Trim();
                    lbmadocgia.Text = _madocgia;
                    lbmaluotmuon.Text = _maluotmuon;
                    txtsotien.Text = _gia;
                }
            }
        }
    }
    protected void btdongy_Click(object sender, EventArgs e)
    {
        DateTime _datenow=DateTime.Now;
        HoaDonTableAdapter H_don = new HoaDonTableAdapter();
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        SachTableAdapter S_ach = new SachTableAdapter();
        Data.LuotMuonDataTable ban_luotmuon = L_muon.GetbyMaLuotMuon(Convert.ToInt32(lbmaluotmuon.Text.Trim()));
        
        if (txtmahoadon.Text != "" && txtsotien.Text != "")
        {
            lbrongmahoadon.Enabled = false; lbrongsotien.Enabled = false;
            Data.HoaDonDataTable ban_hoadon = H_don.GetMaHoaDon(txtmahoadon.Text.Trim());
            if (ban_hoadon.Count > 0)
            { ham("Mã Hóa Đơn Đã Tồn Tại!"); }
            else {
                H_don.ThemHoaDon(txtmahoadon.Text.Trim(),Convert.ToInt32(lbmaluotmuon.Text.Trim()),lbmadocgia.Text.Trim(),Convert.ToString(Session["TaiKhoan"]),txtsotien.Text.Trim(),_datenow.ToString("dd/MM/yyyy"),drptrachua.SelectedValue);
                L_muon.TraSach(Convert.ToString(Session["TaiKhoan"]), "Roi", Convert.ToInt32(lbmaluotmuon.Text.Trim()));
                if (ban_luotmuon.Count > 0)
                {
                    int _masach = ban_luotmuon[0].MaSach;
                    Data.SachDataTable ban_sach = S_ach.GetMaSach(_masach);
                    if (ban_sach.Count > 0)
                    {
                        S_ach.UpdateSachCon(ban_sach[0].SachCon + 1, _masach);
                    }
                    Response.Redirect("~/ThuVien/QuanLy/LapHoaDon.aspx?Bien_1=ChiTietHoaDon &Ma_DG=" + lbmadocgia.Text.Trim());
                }               
            }
        }
        else
        {
            if (txtmahoadon.Text == "") { lbrongmahoadon.Visible = true; } else { lbrongmahoadon.Visible = false; }
            if (txtsotien.Text == "") { lbrongsotien.Visible = true; } else { lbrongsotien.Visible = false; }
        }
    }
    protected void btkhongdongy_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ThuVien/QuanLy/LapHoaDon.aspx?Bien_1=KhongDongY &Ma_DG=" + lbmadocgia.Text.Trim());
    }
}
