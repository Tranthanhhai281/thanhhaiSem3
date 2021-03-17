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

public partial class ThuVien_QuanLy_ThongKeSachMuon : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        btexcel.Visible = false;
        btword.Visible = false;
        btpdf.Visible = false;
        if (radiochon.SelectedValue == "2")
        {
            lbthongbao.Text = "";
            DangKyTableAdapter D_ky = new DangKyTableAdapter();
            Data.DangKyDataTable ban_dangkyall = D_ky.GetDangKy();
            lbthongbaorong.Visible = false;
            lbtieude1.Visible = false;
            drpThang.Visible = false;
            txtnam.Visible = false;
            grvthongtin.Visible = false;
            if (ban_dangkyall.Count > 0)
            {
                btexcel.Visible = true;
                btword.Visible = true;
                btpdf.Visible = true;
                grvthongtin.Visible = true;
                grvthongtin.DataSource = ban_dangkyall;                   //ban_thongtin la ban dataset
                grvthongtin.DataBind();
                lbthongbao.Text = "Tất Cả: " + ban_dangkyall.Count.ToString() + " Lượt Đăng Ký";
            }
            else
            {
                grvthongtin.Visible = false;
                lbthongbao.Text = "Không Có Kết Quả!";
                btexcel.Visible = false;
                btword.Visible = false;
                btpdf.Visible = false;
            }
        }
        else
        {
            lbthongbao.Text = "";
            grvthongtin.Visible = false;
            lbtieude1.Visible = true;
            lbthongbaorong.Visible = false;
            if (radiochon.SelectedValue == "0")
            {
                drpThang.Visible = false;
                txtnam.Visible = true;
            }
            else
            {
                drpThang.Visible = true;
                txtnam.Visible = true;
            }
        }     
    }
    protected void btthongke_Click(object sender, EventArgs e)
    {
        lbthongbao.Text = "";
        DangKyTableAdapter D_ky = new DangKyTableAdapter();
        Data.DangKyDataTable ban_dangkyall = D_ky.GetDangKy();
        Data.DangKyDataTable ban_thongtin = new Data.DangKyDataTable();//new dataset thongtin name
        lbthongbao.Text = "";
        lbthongbaorong.Visible = false;
        //new dataset thongtin name
        if (radiochon.SelectedValue == "2")
        {
            grvthongtin.Visible = false;
            lbtieude1.Visible = false;
            drpThang.Visible = false;
            txtnam.Visible = false;

            if (ban_dangkyall.Count > 0)
            {
                grvthongtin.Visible = true;
                grvthongtin.DataSource = ban_dangkyall;//ban_thongtin la ban dataset
                grvthongtin.DataBind();
                lbthongbao.Text = "Tất Cả: " + ban_dangkyall.Count.ToString() + " Lượt Đăng Ký";
            }
            else
            {
                grvthongtin.Visible = false;
                lbthongbao.Text = "Không Có Kết Quả!";
            }
        }
        else//Tất Cả
        {
            if (txtnam.Text.Trim() != "")
            {
                lbthongbaorong.Visible = false;
                string _namnhap = txtnam.Text.Trim();
                string _thangnhap = drpThang.SelectedValue;
                if (ban_dangkyall.Count > 0)//số mẫu tin của bản lượt mượn khác 0
                {
                    if (radiochon.SelectedValue == "0")//thống kê theo năm
                    {
                        for (int i = 0; i < ban_dangkyall.Count; i++)
                        {
                            string ngay_muon = ban_dangkyall[i].NgayDangKy.Trim();
                            string[] sub_ngaymuon = ngay_muon.Split('/');
                            if (_namnhap == sub_ngaymuon[2])
                            {
                                Data.DangKyRow dangky_row = ban_thongtin.NewDangKyRow();//khai báo một hàng mới cho bản thông tin với kiểu hàng của bản lượt mượn
                                int _madangky = ban_dangkyall[i].STT;
                                Data.DangKyDataTable ban_con = D_ky.GetBySTT(_madangky);
                                dangky_row.STT = ban_con[0].STT;
                                dangky_row.MaSach = ban_con[0].MaSach;
                                dangky_row.MaDocGia = ban_con[0].MaDocGia.Trim();
                                dangky_row.NgayDangKy = ban_con[0].NgayDangKy.Trim();
                                dangky_row.NgayDenMuon = ban_con[0].NgayDenMuon.Trim();
                                ban_thongtin.Rows.Add(dangky_row);
                            }
                        }
                        lbthongbao.Visible = true;
                        lbthongbao.Text = "Có : " + ban_thongtin.Count.ToString() + " Lượt Đăng Ký Năm: " + _namnhap;
                    }//theo năm
                    else
                    {
                        if (radiochon.SelectedValue == "1")
                        {
                            for (int i = 0; i < ban_dangkyall.Count; i++)
                            {
                                string ngay_muon = ban_dangkyall[i].NgayDangKy.Trim();
                                string[] sub_ngaymuon = ngay_muon.Split('/');
                                if (_namnhap == sub_ngaymuon[2] && _thangnhap == sub_ngaymuon[1])
                                {
                                    Data.DangKyRow dangky_row = ban_thongtin.NewDangKyRow();//khai báo một hàng mới cho bản thông tin với kiểu hàng của bản lượt mượn
                                    int _madangky = ban_dangkyall[i].STT;
                                    Data.DangKyDataTable ban_con = D_ky.GetBySTT(_madangky);
                                    dangky_row.STT = ban_con[0].STT;
                                    dangky_row.MaSach = ban_con[0].MaSach;
                                    dangky_row.MaDocGia = ban_con[0].MaDocGia.Trim();
                                    dangky_row.NgayDangKy = ban_con[0].NgayDangKy.Trim();
                                    dangky_row.NgayDenMuon = ban_con[0].NgayDenMuon.Trim();
                                    ban_thongtin.Rows.Add(dangky_row);
                                }
                            }
                            lbthongbao.Visible = true;
                            lbthongbao.Text = "Có : " + ban_thongtin.Count.ToString() + " Lượt Đăng Ký Tháng: " + _thangnhap + " Năm : " + _namnhap;
                        }
                    }
                    if (ban_thongtin.Count > 0)
                    {
                        grvthongtin.Visible = true;
                        grvthongtin.DataSource = ban_thongtin;//ban_thongtin la ban dataset
                        grvthongtin.DataBind();
                        btexcel.Visible = true;
                        btword.Visible = true;
                        btpdf.Visible = true;
                    }
                    else
                    {
                        grvthongtin.Visible = false;
                        lbthongbao.Text = "Không Có Kết Quả!";
                        btexcel.Visible = false;
                        btword.Visible = false;
                        btpdf.Visible = false;
                    }

                }//số mẫu tin của bản lượt mượn khác 0
            }
            else
            {
                lbthongbaorong.Visible = true;
            }
        }
    }

    protected void btexcel_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.Export("BaoCao.xls", grvthongtin);
    }
    protected void btword_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.XuatDuLieuRaWord(grvthongtin);
    }
    protected void btpdf_Click(object sender, EventArgs e)
    {
        GridViewExportUtil.XuatDuLieuGridRaPDF(grvthongtin);
    }
}
