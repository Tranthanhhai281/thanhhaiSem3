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
    DangKyTableAdapter _Dk = new DangKyTableAdapter();
    protected void Page_Load(object sender, EventArgs e)
    {
        lbrongmadocgia.Visible = false;
        lbrongmasach.Visible = false;
        grvthongtin.Visible = false;
       if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btLap.Enabled = false;
            btTim.Enabled = false;
        }
        else
        {
            btLap.Enabled = false;
            btTim.Enabled = true;
            if (!IsPostBack)//từ trang khác chuyển qua trang này 
            {
                string _bien = Request.QueryString["Bien_1"];//xác định từ trang nào chuyển qua trang này
                if (_bien.Trim() == "ChiTietMuonSach")//từ trang chitietmuonsach.aspx chuyển qua trang trả sách
                {
                    ham("Bạn Đã Lập Lượt Mượn Thành Công");//thông báo trả sách thành công

                    string _biendocgia = Request.QueryString["Ma_DG"];
                    DangKyTableAdapter _Dk = new DangKyTableAdapter();
                    Data.DangKyDataTable ban_dk = _Dk.GetByMaDG(_biendocgia.Trim());
                   
                    if (ban_dk.Count>0)
                    {
                        grvthongtin.Visible = true;
                        grvthongtin.DataSource = ban_dk;
                        grvthongtin.DataBind();
                        lbThongBao.Text = "";
                        btLap.Enabled = false;
                        btTim.Enabled = true;
                    }
                }
                else if (_bien.Trim() == "KhongDongY") {
                    string _biendocgia = Request.QueryString["Ma_DG"];
                    DangKyTableAdapter _Dk = new DangKyTableAdapter();
                    Data.DangKyDataTable ban_dk = _Dk.GetByMaDG(_biendocgia.Trim());

                    if (ban_dk.Count > 0)
                    {
                        grvthongtin.Visible = true;
                        grvthongtin.DataSource = ban_dk;
                        grvthongtin.DataBind();
                        lbThongBao.Text = "";
                        btLap.Enabled = false;
                        btTim.Enabled = true;
                    }
                }
            }
        }      
    }
    protected void btTim_Click(object sender, EventArgs e)
    {
        btTim.Enabled = true;
        lbThongBao.Text = "";
        if (txtDG.Text != "" && txtMaSach.Text != "")
        {
            string ma_DG = txtDG.Text.Trim();
            int ma_sach = Convert.ToInt32(txtMaSach.Text);
            Data.DangKyDataTable ban_DK = _Dk.GetSachDG(ma_sach, ma_DG);
            SachTableAdapter S_ach = new SachTableAdapter();
            Data.SachDataTable ban_sach = S_ach.GetMaSach(ma_sach);
        
            lbrongmasach.Visible = false;
            lbrongmadocgia.Visible = false;            
            DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
            Data.DocGiaDataTable ban_docgia = D_gia.GetByMaDG(ma_DG);
            if (ban_docgia.Count > 0)
            {
                if (ban_sach.Count > 0)
                {
                    if (ban_sach[0]._Muon_Doc.Trim() == "Muon")
                    {
                        if (ban_DK.Count <= 0)//không có thông tin đăng ký
                        {
                            btLap.Enabled = false;
                            grvthongtin.Visible = false;
                                if (ban_sach[0].SachCon > 0)
                                {
                                    btLap.Enabled = true;
                                    lbThongBao.Text = "Chưa Có Thông Tin Đăng Ký - Nhưng Vẫn Còn Sách Cho Mượn!";
                                    grvthongtin.Visible = false;
                                }
                                else
                                {
                                    lbThongBao.Text = "Chưa Có Thông Tin Đăng Ký Hoặc Thông Tin Đã Quá Hạn - Hết Sách !";
                                    btLap.Enabled = false;
                                    grvthongtin.Visible = false;
                                }                           
                        }
                        else//có thông tin đăng ký
                        {
                            string ngay_muon = ban_DK[0].NgayDenMuon.ToString().Trim();
                            string[] mang = ngay_muon.Split('/');
                            lbThongBao.Text = "";
                            btLap.Enabled = false;
                            grvthongtin.Visible = true;
                            grvthongtin.DataSource = _Dk.GetSachDG(ma_sach, ma_DG);
                            grvthongtin.DataBind();
                        }
                    }
                    else
                    {
                        grvthongtin.Visible = false;
                        lbThongBao.Text = "Sách Chỉ Cho Đọc!"; }
                }
                else
                {
                    lbThongBao.Text = "Mã Sách Không Tồn Tại";
                }
            }
            else { lbThongBao.Text = "Mã Đọc Giả Không Tồn Tại"; }
        }
        else { if (txtDG.Text == "") { lbrongmadocgia.Visible = true; } else { lbrongmadocgia.Visible = false; }
        if (txtMaSach.Text == "") { lbrongmasach.Visible = true; } else { lbrongmasach.Visible=false;}
        }
    }
    

    protected void btLap_Click1(object sender, EventArgs e)
    {
        grvthongtin.Visible = false;
        string _nhanVien = Convert.ToString(Session["TaiKhoan"]);
        string madg = txtDG.Text.Trim();
        int masach = int.Parse( txtMaSach.Text);
       
        int cohd = 0;
        LayThoiGian _tghh = new LayThoiGian();
        LuotMuonTableAdapter L_Muon = new LuotMuonTableAdapter();

        SachTableAdapter _sach = new SachTableAdapter();
        DocGiaTableAdapter _DG = new DocGiaTableAdapter();
        ChiTietTableAdapter _CT = new ChiTietTableAdapter();
        DangKyTableAdapter _DK = new DangKyTableAdapter();
        HoaDonTableAdapter _HD = new HoaDonTableAdapter();
        QuiDinhTableAdapter _QD = new QuiDinhTableAdapter();
        
        Data.LuotMuonDataTable ban_luotmuon = L_Muon.GetSachDG(masach, madg);        
        Data.LuotMuonDataTable ban_luotmuonall = L_Muon.GetLuotMuon();
        
        Data.SachDataTable ban_sach = _sach.GetMaSach(masach);
        Data.DocGiaDataTable ban_docgia = _DG.GetByMaDG(madg);//xét chức vụ đọc giả
       // Data.DangKyDataTable _banDK = _DK.GetSachDG(masach, madg);
        Data.ChiTietDataTable _banct = _CT.GetByMaDG(madg);
        Data.HoaDonDataTable _banhd = _HD.GetByMaDG(madg);
        //xét đăng ký
        Data.QuiDinhDataTable ban_quidinh = _QD.GetQuiDinh();       
        Data.DangKyDataTable ban_dk = _DK.GetByMaDG(madg.Trim());
        Data.LuotMuonDataTable ban_luotmuonByDG = L_Muon.DGTraSach("Chua", madg);

        string  _ngaytra = "NULL";
        DateTime _ngaymuon = DateTime.Now;
        string _date = _ngaymuon.ToString("dd/MM/yyyy");
        if (ban_docgia.Count > 0)
        {
            if (ban_sach.Count > 0)
            {
                if (ban_docgia[0].MaChucVu == 1)
                {
                    _ngaytra = _ngaymuon.AddDays(ban_quidinh[0].NgayMuonSV).ToString("dd/MM/yyyy");
                }
                else
                {
                    if (ban_docgia[0].MaChucVu != 1)
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

               /*không Đăng Ký*/              
                    // start

                    if (_banhd.Count > 0)                                                   //có hóa đơn
                    {
                        for (int i = 0; i < _banhd.Count; i++)
                        {
                            if (_banhd[i].ThanhToan.ToString().Trim() == "Chua")

                                cohd++;
                        }
                        if (cohd > 0)//có hóa đơn chưa thanh toán
                            lbThongBao.Text = madg + " cần thanh toán " + cohd.ToString() + " hóa đơn";
                        else
                        //xử lý vi phạm
                        {
                            if (_banct.Count > 0)                                          //có vi phạm
                            {
                                int Max = _banct[0].MaViPham;
                                for (int i = 1; i < _banct.Count; i++)
                                {
                                    if (Max ==ban_quidinh[0].DuocPhepViPham)
                                    {
                                        Max = ban_quidinh[0].DuocPhepViPham;
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
                                Data.ChiTietDataTable ban_ct = _CT.GetMDGMVP(madg, Max);
                                if (ban_ct[0].IsHetHanNull() == false)                 //Hết Hạn khác Null
                                {
                                    //lấy ngày tháng năm của mã vi phạm Max

                                    string _thoihan = ban_ct[0].HetHan.Trim();
                                    int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                                    int _thanght = Convert.ToInt32(_tghh.Get_Month());
                                    int _namht = Convert.ToInt32(_tghh.Get_Year());
                                    string[] _tg = new string[10];
                                    _tg = _tghh.catchuoi(_thoihan, '/');
                                    int _ngayvp = Convert.ToInt32(_tg[0]);
                                    int _thangvp = Convert.ToInt32(_tg[1]);
                                    int _namvp = Convert.ToInt32(_tg[2]);
                                    bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngayvp, _thangvp, _namvp);
                                    if (_kiemtra == true)
                                    {
                                        lbThongBao.Text = "Vi Phạm Lần " + ban_ct[0].MaViPham.ToString() + " Chưa Hết Hạn("+_thoihan+") !";
                                    }
                                    else
                                    {                                                     //Kiểm Tra Lượt Mượn
                                        if (ban_sach.Count > 0)
                                        {
                                            //Kiểm tra Chức Vụ của Đoc Giả

                                            if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                            {
                                                if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                                {
                                                    lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                    if (ban_dk.Count > 0)
                                                    {
                                                        grvthongtin.Visible = true;
                                                        grvthongtin.DataSource = ban_dk;
                                                        grvthongtin.DataBind();
                                                    }
                                                }
                                                else
                                                {
                                                    grvthongtin.Visible = false;
                                                    L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                    lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                    ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                    lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                    btLap.Enabled = false;
                                                    txtMaSach.Text = "";
                                                }
                                            }
                                            else
                                            {
                                                if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                                {
                                                    if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                                    {
                                                        lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                        if (ban_dk.Count > 0)
                                                        {
                                                            grvthongtin.Visible = true;
                                                            grvthongtin.DataSource = ban_dk;
                                                            grvthongtin.DataBind();
                                                        }
                                                    }
                                                    else
                                                    {
                                                        grvthongtin.Visible = false;
                                                        L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                        lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                        _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                        ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                        lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                        btLap.Enabled = false;
                                                        txtMaSach.Text = "";
                                                    }
                                                }
                                            }//hết kiểm tra đọc giả
                                        }
                                        else
                                            lbThongBao.Text = "Mã Sách Không Tồn Tại!";

                                    }//kết thúc kiểm tra Lượt Mượn
                                }
                                else                                                          //Hết Hạn bằng Null
                                {
                                    //kiểm tra Lượt Mượn
                                    if (ban_sach.Count > 0)
                                    {
                                        //Kiểm tra Chức Vụ của Đoc Giả

                                        if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                        {
                                            if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                            {
                                                lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                if (ban_dk.Count > 0)
                                                {
                                                    grvthongtin.Visible = true;
                                                    grvthongtin.DataSource = ban_dk;
                                                    grvthongtin.DataBind();
                                                }
                                            }
                                            else
                                            {
                                                grvthongtin.Visible = false;
                                                L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                btLap.Enabled = false;
                                                txtMaSach.Text = "";
                                            }
                                        }
                                        else
                                        {
                                            if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                            {
                                                if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                                {
                                                    lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                    if (ban_dk.Count > 0)
                                                    {
                                                        grvthongtin.Visible = true;
                                                        grvthongtin.DataSource = ban_dk;
                                                        grvthongtin.DataBind();
                                                    }
                                                }
                                                else
                                                {
                                                    grvthongtin.Visible = false;
                                                    L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                    lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                    ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                    lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                    btLap.Enabled = false;
                                                    txtMaSach.Text = "";
                                                }
                                            }
                                        }//hết kiểm tra đọc giả
                                    }
                                    else
                                        lbThongBao.Text = "Mã Sách Không Tồn Tại!";
                                }//kết thúc kiểm tra Lượt Mượn
                            }
                            else                                     //không có vi phạm 
                            {
                                if (ban_sach.Count > 0)
                                {
                                    //Kiểm tra Chức Vụ của Đoc Giả

                                    if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                    {
                                        if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                        {
                                            lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                            if (ban_dk.Count > 0)
                                            {
                                                grvthongtin.Visible = true;
                                                grvthongtin.DataSource = ban_dk;
                                                grvthongtin.DataBind();
                                            }
                                        }
                                        else
                                        {
                                            grvthongtin.Visible = false;
                                            L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                            lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                            _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                            ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                            lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                            btLap.Enabled = false;
                                            txtMaSach.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                        {
                                            if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                            {
                                                lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                if (ban_dk.Count > 0)
                                                {
                                                    grvthongtin.Visible = true;
                                                    grvthongtin.DataSource = ban_dk;
                                                    grvthongtin.DataBind();
                                                }
                                            }
                                            else
                                            {
                                                grvthongtin.Visible = false;
                                                L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                btLap.Enabled = false;
                                                txtMaSach.Text = "";
                                            }
                                        }
                                    }//hết kiểm tra đọc giả
                                }
                                else
                                    lbThongBao.Text = "Mã Sách Không Tồn Tại!";
                            }//kết thúc kiểm tra Lượt Mượn
                        }                                                   //kết thúc kiểm tra Vi Phạm có Hóa Đơn
                    }
                    else
                    {
                        if (_banct.Count > 0)                                          //có vi phạm
                        {
                            int Max = _banct[0].MaViPham;
                            for (int i = 1; i < _banct.Count; i++)
                            {
                                if (Max == ban_quidinh[0].DuocPhepViPham)
                                {
                                    Max = ban_quidinh[0].DuocPhepViPham;
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
                            Data.ChiTietDataTable ban_ct = _CT.GetMDGMVP(madg, Max);
                            if (ban_ct[0].IsHetHanNull() == false)                 //Hết Hạn khác Null
                            {
                                //lấy ngày tháng năm của mã vi phạm Max

                                string _thoihan = ban_ct[0].HetHan.Trim(); ;
                                int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                                int _thanght = Convert.ToInt32(_tghh.Get_Month());
                                int _namht = Convert.ToInt32(_tghh.Get_Year());
                                string[] _tg = new string[10];
                                _tg = _tghh.catchuoi(_thoihan, '/');
                                int _ngayvp = Convert.ToInt32(_tg[0]);
                                int _thangvp = Convert.ToInt32(_tg[1]);
                                int _namvp = Convert.ToInt32(_tg[2]);
                                bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngayvp, _thangvp, _namvp);
                                if (_kiemtra == true)
                                {
                                    lbThongBao.Text = "Vi Phạm Lần " + ban_ct[0].MaViPham.ToString() + " Chưa Hết Hạn("+_thoihan+") !";
                                }
                                else
                                {                                                    //Kiểm Tra Lượt Mượn
                                    if (ban_sach.Count > 0)
                                    {
                                        //Kiểm tra Chức Vụ của Đoc Giả

                                        if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                        {
                                            if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                            {
                                                lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                if (ban_dk.Count > 0)
                                                {
                                                    grvthongtin.Visible = true;
                                                    grvthongtin.DataSource = ban_dk;
                                                    grvthongtin.DataBind();
                                                }
                                            }
                                            else
                                            {
                                                grvthongtin.Visible = false;
                                                L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                btLap.Enabled = false;
                                                txtMaSach.Text = "";
                                            }
                                        }
                                        else
                                        {
                                            if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                            {
                                                if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                                {
                                                    lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                    if (ban_dk.Count > 0)
                                                    {
                                                        grvthongtin.Visible = true;
                                                        grvthongtin.DataSource = ban_dk;
                                                        grvthongtin.DataBind();
                                                    }
                                                }
                                                else
                                                {
                                                    grvthongtin.Visible = false;
                                                    L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                    lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                    _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                    ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                    lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                    btLap.Enabled = false;
                                                    txtMaSach.Text = "";
                                                }
                                            }
                                        }//hết kiểm tra đọc giả
                                    }
                                    else
                                        lbThongBao.Text = "Mã Sách Không Tồn Tại!";

                                }//kết thúc kiểm tra Lượt Mượn
                            }
                            else                                                                    //Hết Hạn bằng Null
                            {
                                //kiểm tra Lượt Mượn
                                if (ban_sach.Count > 0)
                                {
                                    //Kiểm tra Chức Vụ của Đoc Giả

                                    if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                    {
                                        if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                        {
                                            lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                            if (ban_dk.Count > 0)
                                            {
                                                grvthongtin.Visible = true;
                                                grvthongtin.DataSource = ban_dk;
                                                grvthongtin.DataBind();
                                            }
                                        }
                                        else
                                        {
                                            grvthongtin.Visible = false;
                                            L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                            lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                            _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                            ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                            lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                            btLap.Enabled = false;
                                            txtMaSach.Text = "";
                                        }
                                    }
                                    else
                                    {
                                        if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                        {
                                            if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                            {
                                                lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                                if (ban_dk.Count > 0)
                                                {
                                                    grvthongtin.Visible = true;
                                                    grvthongtin.DataSource = ban_dk;
                                                    grvthongtin.DataBind();
                                                }
                                            }
                                            else
                                            {
                                                grvthongtin.Visible = false;
                                                L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                                lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                                _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                                ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                                lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                                btLap.Enabled = false;
                                                txtMaSach.Text = "";
                                            }
                                        }
                                    }//hết kiểm tra đọc giả
                                }
                                else
                                    lbThongBao.Text = "Mã Sách Không Tồn Tại!";
                            }//kết thúc kiểm tra Lượt Mượn
                        }
                        else                                     //không có vi phạm 
                        {
                            if (ban_sach.Count > 0)
                            {
                                //Kiểm tra Chức Vụ của Đoc Giả

                                if (ban_docgia[0].MaChucVu == 1)//đọc giả là sinh viên
                                {
                                    if (ban_quidinh[0].LuongSachChoSinhVienMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                    {
                                        lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                        if (ban_dk.Count > 0)
                                        {
                                            grvthongtin.Visible = true;
                                            grvthongtin.DataSource = ban_dk;
                                            grvthongtin.DataBind();
                                        }
                                    }
                                    else
                                    {
                                        grvthongtin.Visible = false;
                                        L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                        lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                        _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                        ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                        lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                        btLap.Enabled = false;
                                        txtMaSach.Text = "";
                                    }
                                }
                                else
                                {
                                    if (ban_docgia[0].MaChucVu != 1)         //đọc giả là Cán Bộ
                                    {
                                        if (ban_quidinh[0].LuongSachCanBoMuon - (ban_dk.Count + ban_luotmuonByDG.Count) <= 0)//lần mượn quá qui đinh
                                        {
                                            lbThongBao.Text = ban_luotmuonByDG.ToString();
                                            lbThongBao.Text = "Bạn Đã Mượn " + ban_luotmuonByDG.Count.ToString() + " Lần" + "Và Đăng Ký" + ban_dk.Count.ToString() + " Lần!";
                                            if (ban_dk.Count > 0)
                                            {
                                                grvthongtin.Visible = true;
                                                grvthongtin.DataSource = ban_dk;
                                                grvthongtin.DataBind();
                                            }
                                        }
                                        else
                                        {
                                            grvthongtin.Visible = false;
                                            L_Muon.ThemLuotMuon(_stt, Convert.ToInt32(txtMaSach.Text), madg, 0, _nhanVien, _date, _ngaytra, "Chua");

                                            lbKetQua.Text = "Ngày trả sách " + _ngaytra;
                                            _sach.UpdateSachCon(ban_sach[0].SachCon - 1, masach);
                                            ham("Bạn Đã Lập Lượt Mượn Sách Thành Công!");
                                            lbThongBao.Text = "Bạn Đã Lập Lượt Mượn Sách Thành Công!";
                                            btLap.Enabled = false;
                                            txtMaSach.Text = "";
                                            
                                        }
                                    }
                                }//hết kiểm tra đọc giả
                            }
                            else
                                lbThongBao.Text = "Mã Sách Không Tồn Tại!";
                        }//kết thúc kiểm tra Lượt Mượn
                    }                                                      //kết thúc kiểm tra Vi Phạm không có Hóa Đơn

                    //end
                                //kết thúc
            }
            else
                lbThongBao.Text = "Mã Sách Không tồn tại!";
        }
        else
            lbThongBao.Text = "Mã Đọc Giả Không Tồn Tại!";
    }   
    
}
