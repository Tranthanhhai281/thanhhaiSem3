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

public partial class ThuVien_QuanLy_LapChiTietHoaDon : System.Web.UI.Page
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
            lbmadocgia.Text = Request.QueryString["MaDocGia"];
            lbmasach.Text = Request.QueryString["MaSach"];
            lbmavipham.Text = Request.QueryString["MaViPham"];
            if (!IsPostBack)
            {
                if (Convert.ToInt32(lbmavipham.Text.Trim()) == 1)
                {
                    drpNgay.Enabled = false;
                    drpThang.Enabled = false;
                    txtNam.Enabled = false;
                }
                else
                {
                    drpNgay.Enabled = true;
                    drpThang.Enabled = true;
                    txtNam.Enabled = true;
                    LayThoiGian _tghh = new LayThoiGian();
                    int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                    int _thanght = Convert.ToInt32(_tghh.Get_Month());
                    drpNgay.Items[_ngayht - 1].Selected = true;
                    drpThang.Items[_thanght - 1].Selected = true;
                    txtNam.Text = _tghh.Get_Year();
                }
            }
        } lbthongbaorongnam.Visible = false;
    }
    protected void btdongy_Click(object sender, EventArgs e)
    { 
        string ma_luotmuon=Request.QueryString["MaLuotMuon"];
        string duong_dan=Request.QueryString["duongdan"];
        DateTime datenow=DateTime.Now;
        int ma_sach=Convert.ToInt32(lbmasach.Text);
        int ma_vipham=Convert.ToInt32(lbmavipham.Text);
        string ma_docgia=lbmadocgia.Text.Trim();
        ChiTietTableAdapter c_tiet = new ChiTietTableAdapter();
        LuotMuonTableAdapter L_muon=new LuotMuonTableAdapter();
        SachTableAdapter S_ach =new SachTableAdapter();
        Data.SachDataTable ban_sach = S_ach.GetMaSach(Convert.ToInt32(lbmasach.Text.Trim()));
        LayThoiGian _tghh = new LayThoiGian();
        int _ngayht = Convert.ToInt32(_tghh.Get_Day());
        int _thanght = Convert.ToInt32(_tghh.Get_Month());
        int _namht = Convert.ToInt32(_tghh.Get_Year());
        
        if (Convert.ToInt32(lbmavipham.Text.Trim()) == 1)
        {
            drpNgay.Enabled = false;
            drpThang.Enabled = false;
            txtNam.Enabled=false;
            c_tiet.ThemViPham(ma_sach, ma_docgia, ma_vipham, datenow.ToString("dd/MM/yyyy"),null);
            L_muon.TraSach(Convert.ToString(Session["TaiKhoan"]), "Roi", Convert.ToInt32(ma_luotmuon));
            S_ach.UpdateSachCon(ban_sach[0].SachCon + 1, ma_sach);
            Response.Redirect("~/ThuVien/QuanLy/" + duong_dan.Trim() + "?Bien_1=LapViPham &Ma_DG=" + lbmadocgia.Text.Trim());

        }else{
            drpNgay.Enabled = true;
            drpThang.Enabled = true;
            txtNam.Enabled = true;
            int _date = Convert.ToInt32(drpNgay.SelectedValue);
            int _month = Convert.ToInt32(drpThang.SelectedValue);
            if (txtNam.Text.Trim() != "")
            {
                lbthongbaorongnam.Visible = false;
                int _year = Convert.ToInt32(txtNam.Text);
                string _ngayhen = DateTime.Parse(_month + "/" + _date + "/" + _year).ToString("dd/MM/yyyy");

                bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _date, _month, _year);

                if (_kiemtra == false)              //trể hẹn
                {
                    lbthongbao.Text = "Thời Gian Phải Bắt Đầu Hoặc Sau Ngày Lập!";
                }
                else
                {
                    c_tiet.ThemViPham(ma_sach, ma_docgia, ma_vipham, datenow.ToString("dd/MM/yyyy"), _ngayhen);
                    L_muon.TraSach(Convert.ToString(Session["TaiKhoan"]), "Roi", Convert.ToInt32(ma_luotmuon));
                    S_ach.UpdateSachCon(ban_sach[0].SachCon + 1, ma_sach);
                    Response.Redirect("~/ThuVien/QuanLy/" + duong_dan.Trim() + "?Bien_1=LapViPham &Ma_DG=" + lbmadocgia.Text.Trim());
                }
            }
            else
                lbthongbaorongnam.Visible = true;
        }
    }
    protected void btkhongdongy_Click(object sender, EventArgs e)
    {
        string duong_dan = Request.QueryString["duongdan"];
        Response.Redirect("~/ThuVien/QuanLy/" + duong_dan.Trim() + "?Bien_1=LapViPhamKDY &Ma_DG=" + lbmadocgia.Text.Trim());
    }
}
