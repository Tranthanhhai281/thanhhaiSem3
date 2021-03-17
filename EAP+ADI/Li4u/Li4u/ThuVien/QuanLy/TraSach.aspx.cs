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
        
       if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            btTim.Enabled = false;
        }
        else
        {
            btTim.Enabled = true;           
        }
       if (!IsPostBack)//từ trang khác chuyển qua trang này 
       {
           string _bien = Request.QueryString["Bien_1"];//xác định từ trang nào chuyển qua trang này
           if (_bien.Trim() == "ChiTietTraSach")//từ trang chitiettrasach.aspx chuyển qua trang trả sách
           {
               ham("Bạn Trả Sách Thành Công");//thông báo trả sách thành công

               string _biendocgia = Request.QueryString["Ma_DG"];
               LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
               Data.LuotMuonDataTable ban_luotmuon = L_muon.DGTraSach("Chua", _biendocgia.Trim());
               if (ban_luotmuon.Count > 0)
               {
                   grvthongtin.Visible = true;
                   grvthongtin.DataSource = ban_luotmuon;
                   grvthongtin.DataBind();
                   lbThongBao.Text = "";
               }
           }
           else
           {
               if (_bien.Trim() == "KhongDongY")
               {
                   string _biendocgia = Request.QueryString["Ma_DG"];
                   LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
                   Data.LuotMuonDataTable ban_luotmuon = L_muon.DGTraSach("Chua", _biendocgia.Trim());
                   if (ban_luotmuon.Count > 0)
                   {
                       grvthongtin.Visible = true;
                       grvthongtin.DataSource = ban_luotmuon;
                       grvthongtin.DataBind();
                       lbThongBao.Text = "";
                   }
               }
               else           //trang LapChiTietViPham.aspx
               {
                   if (_bien.Trim() == "LapViPham")
                   {
                       ham("Bạn Đã Lập Vi Phạm Thành Công!");
                       string _madocgia = Request.QueryString["Ma_DG"];
                       LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
                       Data.LuotMuonDataTable ban_luotmuon = L_muon.DGTraSach("Chua", _madocgia.Trim());
                       if (ban_luotmuon.Count > 0)
                       {
                           grvthongtin.Visible = true;
                           grvthongtin.DataSource = ban_luotmuon;
                           grvthongtin.DataBind();
                           lbThongBao.Text = "";
                           btTim.Enabled = true;
                       }
                   }
                   else
                   {
                       if (_bien.Trim() == "LapViPhamKDY")
                       {
                           string _madocgia = Request.QueryString["Ma_DG"];
                           LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
                           Data.LuotMuonDataTable ban_luotmuon = L_muon.DGTraSach("Chua", _madocgia.Trim());
                           if (ban_luotmuon.Count > 0)
                           {
                               grvthongtin.Visible = true;
                               grvthongtin.DataSource = ban_luotmuon;
                               grvthongtin.DataBind();
                               lbThongBao.Text = "";
                               btTim.Enabled = true;
                           }
                       }
                   }

               }//end LapChiTietViPham.aspx page

           }
       }
    }
    protected void btTim_Click(object sender, EventArgs e)
    {       
        if (txtDG.Text != "" && txtMaSach.Text != "")
        {
            lbrongmadocgia.Visible = false;
            lbrongmasach.Visible = false;
            string ma_DG = txtDG.Text.Trim();
            int ma_sach = Convert.ToInt32(txtMaSach.Text);
            LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();

            SachTableAdapter S_ach = new SachTableAdapter();
            Data.SachDataTable ban_sach = S_ach.GetMaSach(ma_sach);
            DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
            Data.DocGiaDataTable ban_docgia = D_gia.GetByMaDG(ma_DG);
            if (ban_docgia.Count > 0)
            {
                if (ban_sach.Count > 0)
                {
                    Data.LuotMuonDataTable ban_luotmuon = L_muon.GetTraSach(ma_sach, ma_DG);   //là những lượt mượn chưa trả sách.             
                    DateTime datenow = DateTime.Now;
                    if (ban_luotmuon.Count > 0)//có mượn sách
                    {
                        grvthongtin.Visible = true;
                        grvthongtin.DataSource = L_muon.GetTraSach(ma_sach, ma_DG);
                        grvthongtin.DataBind();
                        lbThongBao.Text = "";
                    }
                    else
                    {
                        lbThongBao.Text = "Không Có Thông Tin Lượt Mượn Hoặc Đọc Giả Đã Trả Sách!";
                        grvthongtin.Visible = false;
                    }
                }
                else
                {
                    grvthongtin.Visible = false;
                    if (txtMaSach.Text == "")
                    { lbrongmasach.Visible = true; }
                    else { lbrongmasach.Visible = false; }
                    if (txtDG.Text == "")
                    { lbrongmadocgia.Visible = true; }
                    else { lbrongmadocgia.Visible = false; }
                }
            }
            else
            {
                lbThongBao.Text = "Mã Sách Không Tồn Tại";
            }
        }
        else { lbThongBao.Text = "Mã Đọc Giả Không Tồn Tại"; }
    }
   
    protected void grvthongtin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
       

    }
   
   
}
