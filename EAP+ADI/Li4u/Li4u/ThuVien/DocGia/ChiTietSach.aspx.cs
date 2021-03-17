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

public partial class ThuVien_DocGia_ChiTietSach : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   Label lbmasach=(Label) frmChiTietSach.FindControl("lbMaSach");
        SachTableAdapter _sach = new SachTableAdapter();
        Data.SachDataTable ban_sach = _sach.GetMaSach(Convert.ToInt32(lbmasach.Text.Trim()));
        if (!IsPostBack)
        {            
                hlnkDangKy.Visible = false;
                lbThongBao.Visible = false;  
                lbketqua.Text = "Chi Tiết Sách";            
        }
        string _duongdan = Request.QueryString["Duongdan"];
        if (Convert.ToString(Session["DGDangNhap"]) != "")//đã đăng nhập
        {
            hlnkDangKy.Visible = false;
            lbThongBao.Visible = false;
            Label ma_sach = (Label)frmChiTietSach.FindControl("lbMaSach");
            if (ban_sach.Count > 0)
            {
                if (ban_sach[0]._Muon_Doc.Trim() != "Muon")
                {
                    hlnkDangKy.Visible = false;
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Sách Chỉ Cho Đọc!";
                }
                else
                {
                    if (ban_sach[0].SachCon <= 0)
                    {
                        hlnkDangKy.Visible = false;
                        lbThongBao.Visible = true;
                        lbThongBao.Text = "Thư Viện Không Còn!";
                    }
                    else
                    {
                        hlnkDangKy.Visible = true;
                        lbThongBao.Visible = false;
                        hlnkDangKy.NavigateUrl = "~/ThuVien/DocGia/ChiTietDangKyMuon.aspx?MaSach=" + Convert.ToInt32(ma_sach.Text) + "&MaDG=" + Convert.ToString(Session["DGDangNhap"]) + "&Duongdan=" + _duongdan;
                    }
                }
            }   
        }
        else {
            if (ban_sach.Count > 0)
            {
                if (ban_sach[0]._Muon_Doc.Trim() != "Muon")
                {
                    hlnkDangKy.Visible = false;
                    lbThongBao.Visible = true;
                    lbThongBao.Text = "Sách Chỉ Cho Đọc!";
                }
                else
                {
                    if (ban_sach[0].SachCon <= 0)
                    {
                        hlnkDangKy.Visible = false;
                        lbThongBao.Visible = true;
                        lbThongBao.Text = "Thư Viện Không Còn!";
                    }
                    else
                    {
                        hlnkDangKy.Visible = true;
                        lbThongBao.Visible = false;
                        hlnkDangKy.NavigateUrl = "~/ThuVien/DocGia/DangNhap.aspx"; }
                }
            }           
        }           
    }
    protected string Anh_Bia(object AnhBia)
    {
        string _anh = Convert.ToString(AnhBia);
        if (_anh == "")
            return "~/ThuVien/Anh/khongsach.jpg";
        else
            return _anh.Trim();
    }
    protected string Tac_Gia(object MaSach)
    {
        int _masach = Convert.ToInt32(MaSach);
        TacGiaTableAdapter T_gia = new TacGiaTableAdapter();
        Data.TacGiaDataTable ban_tg = T_gia.GetChiTietTacGia(_masach);
        if (ban_tg.Count > 0)
        {
            string str = "";
            if (ban_tg.Count == 1)
                str = ban_tg[0].TenTacGia.Trim();
            else
            {
                str = ban_tg[0].TenTacGia.Trim();
                for (int i = 1; i < ban_tg.Count; i++)
                {                    
                    str += "," + ban_tg[i].TenTacGia.Trim();
                }
            }
            return str;
        }
        else
            return "Không Có Tác Gia";
    }
   
    protected string N_XB(object MaSach)
    {
        int _masach = Convert.ToInt32(MaSach);
        NhaXuatBanTableAdapter N_XB = new NhaXuatBanTableAdapter();
        Data.NhaXuatBanDataTable ban_NXB = N_XB.GetChiTetNXB(_masach);
        if (ban_NXB.Count>0)
        {
            string str = "";
            if (ban_NXB.Count == 1)
                str = ban_NXB[0].TenNhaXuatBan.Trim();
            else
            {
                str = ban_NXB[0].TenNhaXuatBan.Trim();
                for (int i = 1; i <ban_NXB.Count;i++)
                {                   
                    str += "," + ban_NXB[i].TenNhaXuatBan.Trim();
                }
            }
            return str;
        }
        else
            return "Không Có NXB";
    }
    
}
