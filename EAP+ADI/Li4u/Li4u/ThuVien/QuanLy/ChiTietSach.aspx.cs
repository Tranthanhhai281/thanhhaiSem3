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
    {
        if (Convert.ToString(Session["TaiKhoan"])!= "")
        {
            Label ma_sach = (Label)frmChiTietSach.FindControl("lbMaSach");
            Label Ma_phanloai = (Label)frmChiTietSach.FindControl("lbmaphanloai"); 
            string _duongdan = Request.QueryString["DuongDan"];
            hlnksuasach.NavigateUrl = "~/ThuVien/QuanLy/SuaSach.aspx?MaSach=" + Convert.ToInt32(ma_sach.Text) + "&suasach=" + _duongdan ;
            hlnkthemsach.NavigateUrl = "~/ThuVien/QuanLy/ThemSach.aspx?themsach="+_duongdan;
           lnkbtxoa.Attributes.Add("onClick", "return confirm('Bạn Muốn Xóa Sách Không?');");
            
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
            return "Không Có Tác Giả";
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
    protected void lnkbtxoa_Click(object sender, EventArgs e)
    {
        string duongdan = Request.QueryString["Duongdan"];
        SachTableAdapter Sach_ = new SachTableAdapter();
        Label masach= (Label) frmChiTietSach.FindControl("lbMaSach");
        Data.SachDataTable ban_sach = Sach_.GetMaSach(Convert.ToInt32(masach.Text));
        Sach_.DeleteSach(Convert.ToInt32( masach.Text));
        if (ban_sach[0].IsAnhBiaNull() == false)
        {
             System.IO.File.Delete(Server.MapPath(ban_sach[0].AnhBia.Trim()));
        }
        Response.Redirect("~/ThuVien/QuanLy/" + duongdan);
    }
}
