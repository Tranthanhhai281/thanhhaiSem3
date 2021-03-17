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

public partial class ThuVien_DocGia_SachTinHoc : System.Web.UI.Page
{
    public void ThongBaoJava(string _thamso)
    {
        ClientScript.RegisterClientScriptBlock(this.GetType(), "", "<script language='javascript'>alert(" + "'" + _thamso.ToString() + "'" + ");</script>");
    }
    SachTableAdapter S_ach = new SachTableAdapter();
    
    protected void Page_Load(object sender, EventArgs e)
    {     
               
        SachTableAdapter S_ach = new SachTableAdapter();
        Data.SachDataTable ban_sachall = S_ach.GetSach();
        if (ban_sachall.Count > 0)
        {
            lbThongBao.Visible = false;
            CollectionPager1.MaxPages = 10000;
            CollectionPager1.PageSize = 16; // số items hiển thị trên một trang.
            CollectionPager1.DataSource = S_ach.GetSach().DefaultView;
            CollectionPager1.BindToControl = lvDemo;
            lvDemo.DataSource = CollectionPager1.DataSourcePaged;
            lvDemo.DataBind();
        }
        else
        {
            lbThongBao.Visible = true;
            lbThongBao.Text = "0 Kết Quả";
        }
        //xóa vi phạm có mã vi pham lớn nhất đã hết hạn phạt

        /*QuiDinhTableAdapter Q_dinh = new QuiDinhTableAdapter();
        Data.QuiDinhDataTable ban_qidinh = Q_dinh.GetQuiDinh();
        if (ban_qidinh.Count > 0)
        {
            int ma_vp = ban_qidinh[0].DuocPhepViPham;
            ChiTietTableAdapter _CT = new ChiTietTableAdapter();
            Data.ChiTietDataTable _banct = _CT.GetLonHonCP(ma_vp);
            LayThoiGian _tghh = new LayThoiGian();
            if (_banct.Count > 0)                                          //có vi phạm
            {
                int _ngayht = Convert.ToInt32(_tghh.Get_Day());
                int _thanght = Convert.ToInt32(_tghh.Get_Month());
                int _namht = Convert.ToInt32(_tghh.Get_Year());
                for (int i = 0; i < _banct.Count; i++)
                {
                    if (_banct[i].IsHetHanNull() == false && _banct[i].MaViPham == ban_qidinh[0].DuocPhepViPham)                 //Hết Hạn khác Null
                    {
                        //lấy ngày tháng năm của những mẫu tin có mã vi phạm bằng mã vi phạm được phép.

                        string _thoihan = _banct[i].HetHan.Trim();
                        string[] _tg = new string[10];
                        _tg = _tghh.catchuoi(_thoihan, '/');
                        int _ngay = Convert.ToInt32(_tg[0]);
                        int _thang = Convert.ToInt32(_tg[1]);
                        int _nam = Convert.ToInt32(_tg[2]);
                        string _maDG = _banct[i].MaDocGia.Trim();
                        bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngay, _thang, _nam);
                        if (_kiemtra == false)// ngày hiện tại đã vượt qua trường hết hạn
                        {
                            _CT.DeleteChiTiet(_maDG);//xóa vi phạm của đọc giả
                        }
                    }
                }
            }
        }
        //xóa Đăng Ký hết hạn.
        */
        DangKyTableAdapter D_ky = new DangKyTableAdapter();
        Data.DangKyDataTable ban_dangky = D_ky.GetDangKy();
        if (ban_dangky.Count > 0)
        {
            LayThoiGian _tghh = new LayThoiGian();
            int _ngayht = Convert.ToInt32(_tghh.Get_Day());
            int _thanght = Convert.ToInt32(_tghh.Get_Month());
            int _namht = Convert.ToInt32(_tghh.Get_Year());
            for (int i = 0; i < ban_dangky.Count; i++)
            {
                string _ngaydenmuon = ban_dangky[i].NgayDenMuon.Trim();

                string[] _tg = new string[10];
                _tg = _tghh.catchuoi(_ngaydenmuon, '/');
                int _ngaymuon = Convert.ToInt32(_tg[0]);
                int _thangmuon = Convert.ToInt32(_tg[1]);
                int _nammuon = Convert.ToInt32(_tg[2]);

                bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _ngaymuon, _thangmuon, _nammuon);
                if (_kiemtra == false)// ngày hiện tại đã vượt qua trường hết hạn
                {
                    int _luotdangky = ban_dangky[i].STT;
                    int _masach = ban_dangky[i].MaSach;
                    Data.SachDataTable ban_sach = S_ach.GetMaSach(_masach);
                    D_ky.DeletedBySTT(_luotdangky);//xóa vi phạm của đọc giả
                    if (ban_sach.Count > 0)
                    {
                        S_ach.UpdateSachCon(ban_sach[0].SachCon + 1, _masach);
                    }
                }
            }
        }       
    }
    protected string Anh_Bia(object AnhBia)
    {
        string _anh = Convert.ToString(AnhBia);
        if (string.IsNullOrEmpty(_anh)==true)
            return "~/ThuVien/Anh/khongsach.jpg";
        else
            return _anh.Trim();
    }
    
    protected void lvDemo_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        
    }
    protected string ten_sach(object TenSach)//xử lý tên sách quá dài
    {
        string _ten = Convert.ToString(TenSach);
        string[] substr = _ten.Split(' ');
        if (substr.Length <= 4)
            return _ten;
        else
            return substr[0] + " " + substr[1] + " " + substr[2] + " " + substr[3] + " ...";
    }
}
