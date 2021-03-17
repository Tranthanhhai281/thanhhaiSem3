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

//có thể đăng ký nhiều cuốn sách cùng mã số

public partial class ThuVien_DocGia_ChiTietDangKyMuon : System.Web.UI.Page
{
    public void ThongBaoJava(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            lbMaDG.Text = Request.QueryString["MaDG"];
           lbSach.Text = Request.QueryString["MaSach"];
        }
    }
    protected void tbDangKy_Click1(object sender, EventArgs e)
    {
        int cohd = 0;
        lbThongBao.Text = "";
        int ma_sach = Convert.ToInt32(lbSach.Text);
        string _madg = lbMaDG.Text.Trim();
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        SachTableAdapter _sach = new SachTableAdapter();
        DocGiaTableAdapter _DG = new DocGiaTableAdapter();
        ChiTietTableAdapter _CT = new ChiTietTableAdapter();
        DangKyTableAdapter _DK = new DangKyTableAdapter();
        HoaDonTableAdapter _HD = new HoaDonTableAdapter();
        QuiDinhTableAdapter _QD = new QuiDinhTableAdapter();
        LayThoiGian _tghh = new LayThoiGian();     
        Data.SachDataTable ban_sach = _sach.GetMaSach(ma_sach);
        Data.DocGiaDataTable _banDG = _DG.GetByMaDG(_madg);
        Data.DangKyDataTable ban_dkAll = _DK.GetDangKy();

        Data.LuotMuonDataTable ban_luotmuon = L_muon.DGTraSach("Chua", _madg);
        Data.DangKyDataTable _bandk = _DK.GetByMaDG(_madg);
        Data.QuiDinhDataTable _banqd = _QD.GetQuiDinh();
        string datedk = _tghh.Get_Day() + "/" + _tghh.Get_Month() + "/" + _tghh.Get_Year();
        DateTime _ngay1 = DateTime.Now;
        string datemuon = _ngay1.AddDays(7).ToString("dd/MM/yyyy");
        lbThongBao.Text = datemuon;
        if (_madg!="")                                                            //là đoc giả
        {
            /*chèn số*/
            int luu = 0;
            int _stt;
            bool _co = false;

            if (ban_dkAll.Count > 0)//có dữ liệu.
            {
                for (int i = 0; i < ban_dkAll.Count - 1; i++)
                {
                    if (ban_dkAll[i + 1].STT - ban_dkAll[i].STT != 1)//có lỗ rỗng
                    {
                        _co = true;
                        luu = i;
                        i = ban_dkAll.Count - 1;
                    }
                }
                if (ban_dkAll[0].STT != 1)//vị trí 0 khác 1.
                    _stt = 1;
                else
                {
                    if (_co == true)//có lỗ trống.
                        _stt = ban_dkAll[luu].STT + 1;
                    else
                        _stt = ban_dkAll[ban_dkAll.Count - 1].STT + 1;
                }
            }
            else
            {
                _stt = 1;
            }
            /*Kết thúc chèn*/
           Data.HoaDonDataTable _banhd=_HD.GetByMaDG(_madg);
            if (_banhd.Count > 0)                                                 //có hóa đơn
            {
                for (int i = 0; i < _banhd.Count; i++)
                {
                    if (_banhd[i].ThanhToan.ToString().Trim() == "Chua")
                        cohd++;
                }
                if (cohd > 0)//có hóa đơn chưa thanh toán
                {
                    string _thanhcong = _madg + " cần thanh toán " + cohd.ToString() + " hóa đơn";                    
                    string _duongdan = Request.QueryString["Duongdan"];
                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                }
                else //có hóa đơn đã thanh toán
                //xử lý vi phạm
                {
                    Data.ChiTietDataTable _banct = _CT.GetByMaDG(_madg);
                    if (_banct.Count > 0)                                          //có vi phạm
                    {
                        int Max = _banct[0].MaViPham;
                        for (int i = 1; i < _banct.Count; i++)
                        {
                            if (Max == _banqd[0].DuocPhepViPham)
                            {
                                Max = _banqd[0].DuocPhepViPham;                                
                                i = _banct.Count;
                            }
                            else
                            {
                                if (_banct[i].MaViPham > Max)
                                {
                                    Max = _banct[i].MaViPham;                                   
                                }
                            }
                        } 
                        Data.ChiTietDataTable ban_ct = _CT.GetMDGMVP(_madg, Max);
                        if (ban_ct[0].IsHetHanNull() == false)                 //Hết Hạn khác Null
                        {
                            //lấy ngày tháng năm của mã vi phạm Max
                        
                            string _thoihan = ban_ct[0].HetHan.Trim();
                            int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                            int _thanght = Convert.ToInt32(_tghh.Get_Month());
                            int _namht = Convert.ToInt32(_tghh.Get_Year());
                            string[] _tg = new string[10];
                            _tg = _tghh.catchuoi(_thoihan, '/');
                            int _ngay = Convert.ToInt32(_tg[0]);
                            int _thang = Convert.ToInt32(_tg[1]);
                            int _nam = Convert.ToInt32(_tg[2]);
                            lbThongBao.Text = _thoihan.ToString();
                            bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngay, _thang, _nam);
                            if (_kiemtra == true)
                            {
                                string _thanhcong = _madg + "Chưa Hết Vi Phạm Lần " + ban_ct[0].MaViPham.ToString() +" Hết Hạn("+_thoihan +") !";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                            else
                            {        //Kiểm Tra Đăng Ký                                                                
                                if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                                {
                                    if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                    {
                                        string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                    else//còn có thể mượn tiết
                                    {
                                        _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                        _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                        tbDangKy.Visible = false;
                                        string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                }
                                else
                                {
                                    if (_banDG[0].MaChucVu !=1)         //đọc giả là Cán Bộ
                                    {
                                        if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                        {
                                            string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                            string _duongdan = Request.QueryString["Duongdan"];
                                            Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                        }
                                        else//còn có thể mượn tiết
                                        {
                                            _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                            _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                            tbDangKy.Visible = false;
                                            string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                            string _duongdan = Request.QueryString["Duongdan"];
                                            Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                        }
                                    }
                                }

                            }//kết thúc kiểm tra đăng ký
                        }
                        else                                                                 //Hết Hạn bằng Null
                        {
                            if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                            {
                                if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                {
                                    string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                                else//còn có thể mượn tiết
                                {
                                    _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                    tbDangKy.Visible = false;
                                    string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                            }
                            else
                            {
                                if (_banDG[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                {
                                    if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                    {
                                        string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                    else//còn có thể mượn tiết
                                    {
                                        _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                        _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                        tbDangKy.Visible = false;
                                        string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                }
                            }
                        }//kết thúc kiểm tra Đăng Ký
                    }
                    else                                     //không có vi phạm 
                    {
                        if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                        {
                            if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                            {
                                string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                            else//còn có thể mượn tiết
                            {
                                _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                tbDangKy.Visible = false;
                                string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                        }
                        else
                        {
                            if (_banDG[0].MaChucVu !=1 )         //đọc giả là Cán Bộ
                            {
                                if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                {
                                    string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                                else//còn có thể mượn tiết
                                {
                                    _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                    tbDangKy.Visible = false;
                                    string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                            }
                        }
                    }//kết thúc kiểm tra Đăng Ký
                }                                                           //hết xử lý Vi Phạm có Hóa Đơn
            }
            else                                                             //không có Hoá Đơn
            {
                Data.ChiTietDataTable _banct = _CT.GetByMaDG(_madg);
                if (_banct.Count > 0)                                       //có vi phạm
                {
                    int Max = _banct[0].MaViPham;
                    for (int i = 0; i < _banct.Count; i++)
                    {
                           if (Max == _banqd[0].DuocPhepViPham)
                            {
                                Max = _banqd[0].DuocPhepViPham;                                
                                i = _banct.Count;
                            }
                            else
                            {
                                if (_banct[i].MaViPham > Max)
                                {
                                    Max = _banct[i].MaViPham;                                   
                                }
                            }
                    }
                    Data.ChiTietDataTable ban_ct = _CT.GetMDGMVP(_madg, Max);
                    if (ban_ct[0].IsHetHanNull() == false)       //Hết Hạn khác Null  
                    {
                        //lấy ngày tháng năm của mã vi phạm Max                        
                        string _thoihan = ban_ct[0].HetHan.Trim();
                        int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                        int _thanght = Convert.ToInt32(_tghh.Get_Month());
                        int _namht = Convert.ToInt32(_tghh.Get_Year());
                        string[] _tg = new string[10];
                        _tg = _tghh.catchuoi(_thoihan, '/');
                        int _ngay = Convert.ToInt32(_tg[0]);
                        int _thang = Convert.ToInt32(_tg[1]);
                        int _nam = Convert.ToInt32(_tg[2]);
                        bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngay, _thang, _nam);
                        if (_kiemtra == true)
                        {
                            string _thanhcong = _madg + "Chưa Hết Vi Phạm Lần " + ban_ct[0].MaViPham.ToString() + " Hết Hạn(" + _thoihan + ") !";
                            string _duongdan = Request.QueryString["Duongdan"];
                            Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                        }
                        else
                        {                                                      //Kiểm Tra Đăng Ký
                            if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                            {
                                if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                {
                                    string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                                else//còn có thể mượn tiết
                                {
                                    _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                    tbDangKy.Visible = false;
                                    string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                            }
                            else
                            {
                                if (_banDG[0].MaChucVu !=1)         //đọc giả là Cán Bộ
                                {
                                    if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                    {
                                        string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                    else//còn có thể mượn tiết
                                    {
                                        _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                        _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                        tbDangKy.Visible = false;
                                        string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                        string _duongdan = Request.QueryString["Duongdan"];
                                        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                    }
                                }
                            }

                        }//kết thúc kiểm tra đăng ký
                    }
                    else                                                                    //Hết Hạn bằng Null
                    {
                        if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                        {
                            if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                            {
                                string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                            else//còn có thể mượn tiết
                            {
                                _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                tbDangKy.Visible = false;
                                string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                        }
                        else
                        {
                            if (_banDG[0].MaChucVu !=1)         //đọc giả là Cán Bộ
                            {
                                if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                                {
                                    string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                                else//còn có thể mượn tiết
                                {
                                    _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                    tbDangKy.Visible = false;
                                    string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                    string _duongdan = Request.QueryString["Duongdan"];
                                    Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                                }
                            }
                        }
                    }//kết thúc kiểm tra Đăng Ký
                }
                else                                                        //không có vi phạm 
                {
                    if (_banDG[0].MaChucVu == 1)          //đọc giả là sinh viên
                    {
                        if (_banqd[0].LuongSachChoSinhVienMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                        {
                            string _thanhcong ="Không Thành Công"+" (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                            string _duongdan = Request.QueryString["Duongdan"];
                            Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                        }
                        else//còn có thể mượn tiết
                        {
                            _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                            _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                            tbDangKy.Visible = false;
                            string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                            string _duongdan = Request.QueryString["Duongdan"];
                            Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                        }
                    }
                    else
                    {
                        if (_banDG[0].MaChucVu !=1)         //đọc giả là Cán Bộ
                        {
                            if (_banqd[0].LuongSachCanBoMuon - (_bandk.Count + ban_luotmuon.Count) <= 0)//lần mượn quá qui đinh
                            {
                                string _thanhcong = "Không Thành Công" + " (Bạn Đã Mượn " + ban_luotmuon.Count.ToString() + " Lần Và Đăng Ký " + _bandk.Count.ToString() + " Lần) !";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                            else//còn có thể mượn tiết
                            {
                                _DK.ThemDangKy(_stt, ma_sach, _madg, datedk, datemuon);
                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, ma_sach);
                                tbDangKy.Visible = false;
                                string _thanhcong = "Sau " + datemuon + " Thông Tin Đăng Ký Sẽ Hết Hạn!";
                                string _duongdan = Request.QueryString["Duongdan"];
                                Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim() + "?ThanhCong=" + _thanhcong + "&Bien_1=ChiTietDangKy");
                            }
                        }
                    }
                }//kết thúc kiểm tra Đăng Ký
                                                     // kết thúc kiểm tra Vi Phạm không có Hoá Đơn
            }             
            
        }else
            lbThongBao.Text = "Bạn phải đăng nhập!";     
        
    }
    protected void btCancel_Click(object sender, EventArgs e)
    {
        string _duongdan = Request.QueryString["Duongdan"];
        Response.Redirect("~/ThuVien/DocGia/" + _duongdan.Trim()+"?Bien_1=KhongDongY");
       // Response.Redirect("~/ThuVien/DocGia/ChiTietSach.aspx?MaSach="+Convert.ToInt32(lbSach.Text));
    }
}
