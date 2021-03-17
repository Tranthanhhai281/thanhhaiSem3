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
            btchitietvipham.Enabled = false;
        }
        else
        {
            btLap.Enabled = true;
            int ma_luotmuon = Convert.ToInt32(Request.QueryString["MaLuotMuon"]);           
            Label lbmadocgia = (Label)dtlchitiet.FindControl("lbmadocgia");
            string  ma_DG = lbmadocgia.Text.Trim();
            
            DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
            LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
            QuiDinhTableAdapter Q_dinh = new QuiDinhTableAdapter();
            GiaHanTableAdapter G_han = new GiaHanTableAdapter();
            ChiTietTableAdapter C_tiet = new ChiTietTableAdapter();

            Data.GiaHanDataTable ban_giahan = G_han.GetGiaHan();
            Data.LuotMuonDataTable ban_luotmuon = L_muon.GetbyMaLuotMuon(ma_luotmuon);
            Data.DocGiaDataTable ban_docgia = D_gia.GetByMaDG(ma_DG);
            Data.QuiDinhDataTable ban_quidinh = Q_dinh.GetQuiDinh();
           
            DateTime datenow = DateTime.Now;
            if (ban_luotmuon[0]._Tra_Chua.Trim() == "Chua")                    //Trường hợp chưa trả sách
            {
                LayThoiGian _tghh = new LayThoiGian();
                int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                int _thanght = Convert.ToInt32(_tghh.Get_Month());
                int _namht = Convert.ToInt32(_tghh.Get_Year());

                string _NgayTra = ban_luotmuon[0].NgayTra.Trim();
                string[] mang = _NgayTra.Trim().Split('/');
                int _date = Convert.ToInt32(mang[0]);
                int _month = Convert.ToInt32(mang[1]);
                int _year = Convert.ToInt32(mang[2]);
                string _ngay1 = DateTime.Parse(_month + "/" + _date + "/" + _year).ToString("dd/MM/yyyy");

                bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _date, _month, _year);

                if (_kiemtra == false)                                       //trể hẹn
                {
                   
                    lbThongBao.Text = "Đọc Giả " + ma_DG + " Đã Trễ Hẹn Trả Sách Mời Bạn Lập Chi Tiết Vi Phạm Và Thu Hồi Sách Mượn!";
                    btchitietvipham.Enabled = true;
                    btLap.Enabled = false;
                }
                else                                                        //không trể hẹn
                {
                    if (ban_docgia[0].MaChucVu == 1)      //nếu đọc giả là sinh viên thì cộng thêm 14 ngày
                    {
                        lbngaytra.Text = datenow.AddDays(ban_quidinh[0].NgayMuonSV).ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        if (ban_docgia[0].MaChucVu != 1) //nếu đọc giả là cán bộ thì cộng thêm 30 ngày
                            lbngaytra.Text = datenow.AddDays(ban_quidinh[0].NgayMuonCB).ToString("dd/MM/yyyy");
                    }
                    if (ban_luotmuon[0].MaGiaHan < ban_giahan[ban_giahan.Count - 1].MaGiaHan)//mã gia hạn phải nhỏ hơn mã gia hạn lớn nhất trong bản gia hạn.
                    {
                        lblangiahan.Text = (ban_luotmuon[0].MaGiaHan + 1).ToString();
                        btLap.Enabled = true;
                        btkhongdongy.Enabled = true;
                        btchitietvipham.Enabled = false;
                    }
                    else//mã gia hạn lớn hơn mã gia hạn qui định
                    {
                        lbThongBao.Text = "Đọc Giả " + ma_DG + " Không Thể Tiếp Tục Gia Hạn!";
                        btchitietvipham.Enabled = false;
                        btLap.Enabled = false;
                        btkhongdongy.Enabled = true;
                        lblangiahan.Text = "Không Thể Gia Hạn ";
                        lbngaytra.Text = "Không Thể Gia Hạn";
                    }
                }
            }
            else                                     //trả sách rồi
            {
                lbThongBao.Text = "Đọc " + ma_DG + " Giả Đã Trả Sách";               
                btLap.Enabled = false;
                btLap.Enabled = false;
                btkhongdongy.Enabled = true;
            }
        }
    }    

    protected void btLap_Click1(object sender, EventArgs e)
    {
        DateTime datenow=DateTime.Now;
        Label lbmadocgia=(Label )dtlchitiet.FindControl("lbmadocgia");
        Label lbmaluotmuon=(Label)dtlchitiet.FindControl("lbmaluotmuon");
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        Data.LuotMuonDataTable ban_luotmuon=L_muon.GetbyMaLuotMuon(Convert.ToInt32(lbmaluotmuon.Text));
        L_muon.SuaLuotMuon(Convert.ToInt32(lblangiahan.Text.Trim()), Convert.ToString(Session["TaiKhoan"]), datenow.ToString("dd/MM/yyyy"), lbngaytra.Text.Trim(), ban_luotmuon[0]._Tra_Chua.Trim(), Convert.ToInt32(lbmaluotmuon.Text));
        btLap.Enabled = false;
        Response.Redirect("~/ThuVien/QuanLy/GiaHan.aspx?Bien_1=ChiTietGiaHan &Ma_DG=" + lbmadocgia.Text.Trim());//gọi hàm javascript trang GiaHan.aspx
    }   
    protected void btchitietvipham_Click(object sender, EventArgs e)
    {
        string duongdan=Request.QueryString["duongdan"];
        Label _lbmadocgia=(Label)dtlchitiet.FindControl("lbmadocgia");
        Label _lbmasach=(Label)dtlchitiet.FindControl("lbmasach");
        Label _lbmaluotmuon = (Label)dtlchitiet.FindControl("lbmaluotmuon");
        ChiTietTableAdapter C_tiet=new ChiTietTableAdapter();
        QuiDinhTableAdapter Q_dinh=new QuiDinhTableAdapter ();
        Data.QuiDinhDataTable ban_quidinh=Q_dinh.GetQuiDinh();
        Data.ChiTietDataTable ban_chitiet=C_tiet.GetByMaDG(_lbmadocgia.Text.Trim());
        int demmax = 0;
        int _mavipham = 0;
        //tìm mã vi phạm lớn nhất của đọc giả
        if (ban_chitiet.Count > 0)//nếu trong bản chi tiết đã có mẫu tin
        {
            int Max = ban_chitiet[0].MaViPham;
            for (int i = 1; i < ban_chitiet.Count; i++)
            {
                if (ban_chitiet[i].MaViPham > Max)
                {
                    Max = ban_chitiet[i].MaViPham;
                    demmax = i;
                }
            }          
                _mavipham = ban_chitiet[demmax].MaViPham + 1;//mã vi phạm tăng lên 1            
        }
        else {
            _mavipham = 1;//nếu chưa có vị mẫu tin nào trong bản chi tiết.
        }
        //kết thúc việc tìm mã vi phạm lớn nhất của đọc giả
        Response.Redirect("~/ThuVien/QuanLy/LapChiTietViPham.aspx?MaSach=" + _lbmasach.Text + "&MaDocGia=" + _lbmadocgia.Text.Trim() + "&MaViPham=" + _mavipham + "&duongdan="+duongdan.Trim()+"&MaLuotMuon="+_lbmaluotmuon.Text.Trim());
    }
    protected void btkhongdongy_Click(object sender, EventArgs e)
    {
        Label _lbmadocgia = (Label)dtlchitiet.FindControl("lbmadocgia");
        Response.Redirect("~/ThuVien/QuanLy/GiaHan.aspx?Bien_1=KhongDongY &Ma_DG=" + _lbmadocgia.Text.Trim());
    }
}
