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
            LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
            Data.LuotMuonDataTable ban_luotmuonall = L_muon.GetLuotMuon();
            lbthongbaorong.Visible = false;
            lbtieude1.Visible = false;
            drpThang.Visible = false;
            txtnam.Visible = false;
            grvthongtin.Visible = false;
            if (ban_luotmuonall.Count > 0)
            {
                btexcel.Visible = true;
                btword.Visible = true;
                btpdf.Visible = true;
                grvthongtin.Visible = true;
                grvthongtin.DataSource = ban_luotmuonall;  
                //ban_thongtin la ban dataset
                grvthongtin.DataBind();
                lbthongbao.Text = "Tất Cả: " + ban_luotmuonall.Count.ToString()+" Lượt Mượn";
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
            grvthongtin.Visible=false;
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
        lbthongbaorong.Visible = false;
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        Data.LuotMuonDataTable ban_luotmuonall = L_muon.GetLuotMuon();
        Data.LuotMuonDataTable ban_thongtin = new Data.LuotMuonDataTable();         //new dataset thongtin name
        if (radiochon.SelectedValue == "2")
        {           
            grvthongtin.Visible =false;
            lbtieude1.Visible = false;
            drpThang.Visible = false;
            txtnam.Visible = false;

            if (ban_luotmuonall.Count > 0)
            {
                grvthongtin.Visible = true;
                grvthongtin.DataSource = ban_luotmuonall;//ban_thongtin la ban dataset
                grvthongtin.DataBind();
                lbthongbao.Text = "Tất Cả: " + ban_luotmuonall.Count.ToString() + " Lượt Mượn";
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
                grvthongtin.Visible = false;
                lbthongbaorong.Visible = false;
                string _namnhap = txtnam.Text.Trim();
                string _thangnhap = drpThang.SelectedValue;
                if (ban_luotmuonall.Count > 0)//số mẫu tin của bản lượt mượn khác 0
                {                  
                    lbtieude1.Visible = true;
                    if (radiochon.SelectedValue == "0")//thống kê theo năm
                    {
                        drpThang.Visible = false;
                        txtnam.Visible = true;
                        for (int i = 0; i < ban_luotmuonall.Count; i++)
                        {
                            string ngay_muon = ban_luotmuonall[i].NgayMuon.Trim();
                            string[] sub_ngaymuon = ngay_muon.Split('/');
                            if (_namnhap == sub_ngaymuon[2])
                            {
                                Data.LuotMuonRow luotmuon_row = ban_thongtin.NewLuotMuonRow();//khai báo một hàng mới cho bản thông tin với kiểu hàng của bản lượt mượn
                                int _maluotmuon = ban_luotmuonall[i].MaLuotMuon;
                                Data.LuotMuonDataTable ban_con = L_muon.GetbyMaLuotMuon(_maluotmuon);
                                luotmuon_row.MaLuotMuon = ban_con[0].MaLuotMuon;
                                luotmuon_row.MaSach = ban_con[0].MaSach;
                                luotmuon_row.MaDocGia = ban_con[0].MaDocGia.Trim();
                                luotmuon_row.MaGiaHan = ban_con[0].MaGiaHan;
                                luotmuon_row.MaNhanVien = ban_con[0].MaNhanVien.Trim();
                                luotmuon_row.NgayMuon = ban_con[0].NgayMuon.Trim();
                                luotmuon_row.NgayTra = ban_con[0].NgayTra.Trim();
                                luotmuon_row._Tra_Chua = ban_con[0]._Tra_Chua.Trim();
                                ban_thongtin.Rows.Add(luotmuon_row);
                            }
                        }
                        lbthongbao.Visible = true;
                        lbthongbao.Text = "Có : " + ban_thongtin.Count.ToString() + " Lượt Mượn Năm: " + _namnhap;
                    }               //theo năm
                    else
                    {
                        drpThang.Visible = true;
                        txtnam.Visible = true;
                        if (radiochon.SelectedValue == "1")
                        {
                            for (int i = 0; i < ban_luotmuonall.Count; i++)
                            {
                                string ngay_muon = ban_luotmuonall[i].NgayMuon.Trim();
                                string[] sub_ngaymuon = ngay_muon.Split('/');
                                if (_namnhap == sub_ngaymuon[2] && _thangnhap == sub_ngaymuon[1])
                                {
                                    Data.LuotMuonRow luotmuon_row = ban_thongtin.NewLuotMuonRow();//khai báo một hàng mới cho bản thông tin với kiểu hàng của bản lượt mượn
                                    int _maluotmuon = ban_luotmuonall[i].MaLuotMuon;
                                    Data.LuotMuonDataTable ban_con = L_muon.GetbyMaLuotMuon(_maluotmuon);
                                    luotmuon_row.MaLuotMuon = ban_con[0].MaLuotMuon;
                                    luotmuon_row.MaSach = ban_con[0].MaSach;
                                    luotmuon_row.MaDocGia = ban_con[0].MaDocGia.Trim();
                                    luotmuon_row.MaGiaHan = ban_con[0].MaGiaHan;
                                    luotmuon_row.MaNhanVien = ban_con[0].MaNhanVien.Trim();
                                    luotmuon_row.NgayMuon = ban_con[0].NgayMuon.Trim();
                                    luotmuon_row.NgayTra = ban_con[0].NgayTra.Trim();
                                    luotmuon_row._Tra_Chua = ban_con[0]._Tra_Chua.Trim();
                                    ban_thongtin.Rows.Add(luotmuon_row);
                                }
                            }
                            lbthongbao.Visible = true;
                            lbthongbao.Text = "Có : " + ban_thongtin.Count.ToString() + " Lượt Mượn Tháng: " + _thangnhap + " Năm : " + _namnhap;
                        }
                    }
                    if (ban_thongtin.Count > 0)
                    {
                        btexcel.Visible = true;
                        btword.Visible = true;
                        btpdf.Visible = true;
                        grvthongtin.Visible = true;
                        grvthongtin.DataSource = ban_thongtin;//ban_thongtin la ban dataset
                        grvthongtin.DataBind();

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
                else
                {
                    grvthongtin.Visible = false;
                    lbthongbao.Text = "Không Có Kết Quả!";
                }
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
