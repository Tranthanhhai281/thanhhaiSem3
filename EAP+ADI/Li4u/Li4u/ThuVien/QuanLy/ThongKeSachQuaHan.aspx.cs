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
        Data.LuotMuonDataTable ban_thongtin = new Data.LuotMuonDataTable();  //new dataset thongtin name
        LuotMuonTableAdapter L_muon=new LuotMuonTableAdapter();
        /*grvthongtin.DataSource = L_muon.GetTKe("Chua");
        grvthongtin.DataBind();*/
        LayThoiGian _tghh = new LayThoiGian();
        int _ngayht = Convert.ToInt32(_tghh.Get_Day());
        int _thanght = Convert.ToInt32(_tghh.Get_Month());
        int _namht = Convert.ToInt32(_tghh.Get_Year());
        if (L_muon.GetTKe("Chua").Count > 0)
        {
            Data.LuotMuonDataTable ban_luotmuonall = L_muon.GetTKe("Chua");
            for (int i = 0; i < ban_luotmuonall.Count; i++)
            {
                string _ngaytra = ban_luotmuonall[i].NgayTra.Trim();
                string[] mang = _ngaytra.Trim().Split('/');
                int _date = Convert.ToInt32(mang[0]);
                int _month = Convert.ToInt32(mang[1]);
                int _year = Convert.ToInt32(mang[2]);
                string _ngay1 = DateTime.Parse(_month + "/" + _date + "/" + _year).ToString("dd/MM/yyyy");

                bool _kiemtra = _tghh.SoSanhThoiGian(_ngayht, _thanght, _namht, _date, _month, _year);

                if (_kiemtra == false)              //trể hẹn
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
            if (ban_thongtin.Count > 0)
            {
                grvthongtin.Visible = true;
                grvthongtin.DataSource = ban_thongtin;
                grvthongtin.DataBind();
                lbthongbao.Visible = true;
                lbthongbao.Text = "Có : " + ban_thongtin.Count.ToString() + " Sách Quá Hạn ";
            }
            else
            {
                grvthongtin.Visible = false;
                lbthongbao.Visible = true;
                lbthongbao.Text = "Không Có Kết Quả";
            }
        }
    }
    protected void btexcel_Click(object sender, EventArgs e)
    {       
        GridViewExportUtil.Export("SachQuaHan.xls", grvthongtin);
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
