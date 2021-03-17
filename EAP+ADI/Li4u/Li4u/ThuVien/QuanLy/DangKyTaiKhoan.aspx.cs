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

public partial class ThuVien_DocGia_DangKy1 : System.Web.UI.Page
{
    string _anh = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Đăng ký tài khoản mới";

    }    

    protected void txtTenDannhap_TextChanged(object sender, EventArgs e)
    {
        lbThanhCong.Text = "";
    }
    protected void tbDangky_Click(object sender, EventArgs e)
    {
        lbCanhBao.Text = "";
        lbMaNv.Text = "";
        int _machucvu = Convert.ToInt32(drpChucVu.SelectedValue.ToString());
        
        string _manhanvien = txtMaNv.Text.Trim();
        string _matkhau = txtMatKhau.Text.Trim();
        string _ten = txtTen.Text.Trim();
        string _ho = txtHo.Text.Trim();
        string _ngay = drpNgay.SelectedValue.ToString().Trim();
        string _thang = drpThang.SelectedValue.ToString().Trim();
        string _nam = txtNam.Text.Trim();
        string _gioitinh = đrpGioi.SelectedItem.ToString().Trim();
        string _email = txtEmail.Text.Trim();

        string _namsinh = _ngay + "/" + _thang + "/" + _nam;
        string _hoten = _ho + " " + _ten;
        bool co = true;
        NhanVienTableAdapter _NV = new NhanVienTableAdapter();
        Data.NhanVienDataTable NV_tb = _NV.GetNhanVien();
        int _length = NV_tb.Count;
        if (_length > 0)
        {
            for (int i = 0; i < _length; i++)
            {
                if (txtMaNv.Text.Trim() != NV_tb[i].MaNhanVien.Trim())
                { co = true; }
                else
                {
                   
                        lbMaNv.Text = "Đã Tồn Tại " + txtMaNv.Text + "!";
                        txtMaNv.Text = "";
                        txtMaNv.Focus();
                
         
                    i = _length - 1;
                    co = false;
                }
            }
            //ket thuc for

            if (co == true)
            {

                lbMaNv.Text = "";
                if (txtMatKhau.Text.Trim().Length < 6)
                {
                    lbCanhBao.Text = "Mât Khẩu Không Bé Hơn 6 Ký Tự!";
                }
                else
                {
                    if (txtNhaplai.Text.Trim().Length != txtMatKhau.Text.Trim().Length)
                    {
                        lbCanhBao.Text = "Xác Định mật Khẩu Không Đúng!";
                        txtNhaplai.Text = "";
                    }
                    else
                    {
                        bool co1 = true;
                        char[] _mang1 = txtMatKhau.Text.Trim().ToCharArray();
                        char[] _mang2 = txtNhaplai.Text.Trim().ToCharArray();
                        for (int i = 0; i < txtMatKhau.Text.Trim().Length; i++)
                        {
                            if (_mang1[i] == _mang2[i])

                                co1 = true;

                            else
                            {
                                co1 = false;
                                lbCanhBao.Text = "Xác Định mật Khẩu Không Đúng!";
                                i = txtMatKhau.Text.Trim().Length - 1;
                            }
                        }
                        if (co1 == true)
                        {
                            lbCanhBao.Text = "";
                            //
                            if (flup.HasFile)//không có ảnh up load 
                            {
                                // Make sure that a JPG has been uploaded
                                if (string.Compare(System.IO.Path.GetExtension(flup.FileName), ".jpg", true) != 0 && string.Compare(System.IO.Path.GetExtension(flup.FileName), ".jpeg", true) != 0)
                                {
                                    lbCanhBao.Text = "Only JPG documents may be used for a category's picture.";
                                    _anh = "khong";
                                }
                                else
                                {
                                    const string BrochureDirectory = "~/ThuVien/QuanLy/Anh/";
                                    string brochurePath = BrochureDirectory + flup.FileName;
                                    string fileNameWithoutExtension =
                                        System.IO.Path.GetFileNameWithoutExtension(flup.FileName);

                                    int iteration = 1;

                                    while (System.IO.File.Exists(Server.MapPath(brochurePath)))
                                    {
                                        brochurePath = string.Concat(BrochureDirectory, fileNameWithoutExtension,
                                            "-", iteration, ".jpg");
                                        iteration++;
                                    }

                                    // Save the file to disk and set the value of the brochurePath parameter
                                    flup.SaveAs(Server.MapPath(brochurePath));
                                    // e.Values["brochurePath"] = brochurePath;
                                    _anh = brochurePath;

                                    if (_email != "")
                                    {
                                        _NV.ThemNhanVien(_manhanvien, _machucvu,
                                            _matkhau, _hoten, _gioitinh, _namsinh, _email, _anh);
                                        lbCanhBao.Text = "";
                                        lbThanhCong.Text = "Thành Công!";
                                    }
                                    else
                                    {
                                        _NV.ThemNhanVien(_manhanvien, _machucvu,
                                            _matkhau, _hoten, _gioitinh, _namsinh, null, _anh);
                                        lbCanhBao.Text = "";
                                        lbThanhCong.Text = "Thành Công!";
                                    }
                                }
                            }
                            else
                            {
                                if (_email == "")
                                {
                                    _NV.ThemNhanVien(_manhanvien, _machucvu, 
                                            _matkhau, _hoten, _gioitinh, _namsinh, null, null);
                                    lbCanhBao.Text = "";
                                    lbThanhCong.Text = "Thành Công!";
                                }
                                else
                                {
                                    _NV.ThemNhanVien(_manhanvien, _machucvu,
                                        _matkhau, _hoten, _gioitinh, _namsinh, _email, null);
                                    lbCanhBao.Text = "";
                                    lbThanhCong.Text = "Thành Công!";
                                }
                            }
                            //


                        }
                    }
                }//kết thúc else _length >6 
            }
        }
        ///_length<0
        else
        {
            
            lbMaNv.Text = "";
            if (txtMatKhau.Text.Trim().Length < 6)
            {
                lbCanhBao.Text = "Mât Khẩu Không Bé Hơn 6 Ký Tự!";
            }
            else
            {
                if (txtNhaplai.Text.Trim().Length != txtMatKhau.Text.Trim().Length)
                {
                    lbCanhBao.Text = "Xác Định mật Khẩu Không Đúng!";
                    txtNhaplai.Text = "";
                }
                else
                {
                    bool co1 = true;
                    char[] _mang1 = txtMatKhau.Text.Trim().ToCharArray();
                    char[] _mang2 = txtNhaplai.Text.Trim().ToCharArray();
                    for (int i = 0; i < txtMatKhau.Text.Trim().Length; i++)
                    {
                        if (_mang1[i] == _mang2[i])

                            co1 = true;

                        else
                        {
                            co1 = false;
                            lbCanhBao.Text = "Xác Định mật Khẩu Không Đúng!";
                            i = txtMatKhau.Text.Trim().Length - 1;
                        }
                    }
                    //xác định mật khẩu đúng
                    if (co1 == true)
                    {
                        lbCanhBao.Text = "";
                        //
                        if (flup.HasFile)//không có ảnh up load 
                        {
                            // Make sure that a JPG has been uploaded
                            if (string.Compare(System.IO.Path.GetExtension(flup.FileName), ".jpg", true) != 0 && string.Compare(System.IO.Path.GetExtension(flup.FileName), ".jpeg", true) != 0)
                            {
                                lbCanhBao.Text = "Only JPG documents may be used for a category's picture.";

                            }
                            else
                            {
                                const string BrochureDirectory = "~/ThuVien/QuanLy/Anh/";
                                string brochurePath = BrochureDirectory + flup.FileName;
                                string fileNameWithoutExtension =
                                    System.IO.Path.GetFileNameWithoutExtension(flup.FileName);

                                int iteration = 1;

                                while (System.IO.File.Exists(Server.MapPath(brochurePath)))
                                {
                                    brochurePath = string.Concat(BrochureDirectory, fileNameWithoutExtension,
                                        "-", iteration, ".jpg");
                                    iteration++;
                                }

                                // Save the file to disk and set the value of the brochurePath parameter
                                flup.SaveAs(Server.MapPath(brochurePath));
                                // e.Values["brochurePath"] = brochurePath;
                                _anh = brochurePath;

                                if (_email != "")
                                {
                                    _NV.ThemNhanVien(_manhanvien, _machucvu,                                        
                                        _matkhau, _hoten, _gioitinh, _namsinh, _email, _anh);
                                    lbThanhCong.Text = "Thành Công!";
                                }
                                else
                                {
                                    _NV.ThemNhanVien(_manhanvien, _machucvu,
                                        _matkhau, _hoten, _gioitinh, _namsinh, null, _anh);
                                    lbCanhBao.Text = "";
                                    lbThanhCong.Text = "Thành Công!";
                                }
                            }
                        }
                        else
                        {
                            if (_email == "")
                            {
                                _NV.ThemNhanVien(_manhanvien, _machucvu,
                                        _matkhau, _hoten, _gioitinh, _namsinh, null, null);
                                lbCanhBao.Text = "";
                                lbThanhCong.Text = "Thành Công!";
                            }
                            else
                            {
                                _NV.ThemNhanVien(_manhanvien, _machucvu,
                                    _matkhau, _hoten, _gioitinh, _namsinh, _email, null);
                                lbCanhBao.Text = "";
                                lbThanhCong.Text = "Thành Công!";
                            }
                        }
                        //


                    }
                }
            }
        }
    }
}
