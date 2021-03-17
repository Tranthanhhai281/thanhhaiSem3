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

public partial class ThuVien_QuanLy_LapLuotMuon : System.Web.UI.Page
{
    public void ham(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btLap.Enabled = false;           
        }
        else
        {
            btLap.Enabled = true;           
        }
    }    

    protected void btLap_Click1(object sender, EventArgs e)
    {
        LayThoiGian _tghh = new LayThoiGian();
        QuiDinhTableAdapter _QD = new QuiDinhTableAdapter();
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        DocGiaTableAdapter _DG = new DocGiaTableAdapter();      
        DangKyTableAdapter _Dk = new DangKyTableAdapter();

        Label lbstt=(Label) dtlchitiet.FindControl("lbstt");
        Label lbmasach=(Label) dtlchitiet.FindControl("lbmasach");
        Label lbmadocgia=(Label) dtlchitiet.FindControl("lbmadocgia");
        string _madg = lbmadocgia.Text.Trim();
        int _masach=Convert.ToInt32(lbmasach.Text.Trim());
        int S_tt=Convert.ToInt32(lbstt.Text.Trim());
        string _nhanVien=Convert.ToString(Session["TaiKhoan"]);

        Data.LuotMuonDataTable ban_luotmuonall = L_muon.GetLuotMuon();
        Data.QuiDinhDataTable ban_quidinh = _QD.GetQuiDinh();
        Data.DocGiaDataTable ban_docgia = _DG.GetByMaDG(_madg);
        Data.DangKyDataTable _banDK = _Dk.GetSachDG(_masach, _madg);
        string _ngaytra = "NULL";
        DateTime _ngaymuon = DateTime.Now;
        string _date = _ngaymuon.ToString("dd/MM/yyyy");

        if (ban_docgia[0].MaChucVu == 1)
        {
            _ngaytra = _ngaymuon.AddDays(ban_quidinh[0].NgayMuonSV).ToString("dd/MM/yyyy");
        }
        else
        {
            if (ban_docgia[0].MaChucVu == 2)
            {
                _ngaytra = _ngaymuon.AddDays(ban_quidinh[0].NgayMuonCB).ToString("dd/MM/yyyy");
            }
        }
        
        /*chèn số*/
        int luu = 0;
        int _stt;
        bool _co = false;

        if (ban_luotmuonall.Count > 0)                   //có dữ liệu.
        {
            for (int i = 0; i < ban_luotmuonall.Count - 1; i++)
            {
                if (ban_luotmuonall[i + 1].MaLuotMuon - ban_luotmuonall[i].MaLuotMuon != 1)//có lỗ rỗng
                {
                    _co = true;
                    luu = i;
                    i = ban_luotmuonall.Count - 1;
                }
            }
            if (ban_luotmuonall[0].MaLuotMuon != 1) //vị trí 0 khác 1.
                _stt = 1;
            else
            {
                if (_co == true)//có lỗ trống.
                    _stt = ban_luotmuonall[luu].MaLuotMuon + 1;
                else
                    _stt = ban_luotmuonall[ban_luotmuonall.Count - 1].MaLuotMuon + 1;
            }
        }
        else
        {
            _stt = 1;
        }
        /*Kết thúc chèn*/
        if (_banDK.Count > 0)
        {
            L_muon.ThemLuotMuon(_stt, _masach, _madg, 0, _nhanVien, _date, _ngaytra, "Chua");
            _Dk.DeleteDK(_masach, _madg, S_tt);
            lbKetQua.Text = "Ngày trả sách " + _ngaytra;
            
            Response.Redirect("~/ThuVien/QuanLy/LapLuotMuon.aspx?Bien_1=ChiTietMuonSach &Ma_DG=" + _madg.Trim());
        }
    }   
   
    protected void btkhongdongy_Click(object sender, EventArgs e)
    {
        Label lbmadocgia = (Label)dtlchitiet.FindControl("lbmadocgia");
        string _madg = lbmadocgia.Text.Trim();
        Response.Redirect("~/ThuVien/QuanLy/LapLuotMuon.aspx?Bien_1=KhongDongY &Ma_DG=" + _madg.Trim());
    }
    protected void Unnamed1_PageIndexChanging(object sender, DetailsViewPageEventArgs e)
    {

    }
}
