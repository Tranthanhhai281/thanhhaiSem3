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
        LuotMuonTableAdapter L_muon = new LuotMuonTableAdapter();
        if (!IsPostBack)
        {
            grvthongtin.DataSource = L_muon.GetTKe("Chua");
            grvthongtin.DataBind();
            if (L_muon.GetTKe("Chua").Count > 0)
            {
                grvthongtin.Visible = true;
                lbthongbao.Text = "Tất Cả :" + L_muon.GetTKe("Chua").Count.ToString() + " Sách Gia Hạn Chưa Trả";
                btexcel.Visible = true;
                btword.Visible = true;
                btpdf.Visible = true;
            }
            else
            {
                grvthongtin.Visible = false;
                lbthongbao.Text = "Không Có Kết Quả ";
                btexcel.Visible = false;
                btword.Visible = false;
                btpdf.Visible = false;
 
            }           
        }        
    }   

    protected void btthonhke_Click(object sender, EventArgs e)
    {
        lbthongbao.Text = "";
       LuotMuonTableAdapter L_muon=new LuotMuonTableAdapter();
        string _giahan= drplangiahan.SelectedValue;
        if (radiochon.SelectedValue == "0")//thống kê Chưa
        {
            if (drplangiahan.SelectedValue == "-1")

            { grvthongtin.DataSource = L_muon.GetTKe("Chua");
              grvthongtin.DataBind();
              if (L_muon.GetTKe("Chua").Count > 0)
              {
                  grvthongtin.Visible = true;
                  lbthongbao.Text = "Tất Cả: " + L_muon.GetTKe("Chua").Count.ToString() + " Sách Gia Hạn Chưa Trả";
                  btexcel.Visible = true;
                  btword.Visible = true;
                  btpdf.Visible = true;
              }
              else
              {
                  grvthongtin.Visible = false;
                  lbthongbao.Text = "Không Có Kết Quả ";
                  btexcel.Visible = false;
                  btword.Visible = false;
                  btpdf.Visible = false;
              }
            }
            else
            {
                if (Convert.ToInt32(_giahan.Trim()) >= 0)
                {
                    grvthongtin.DataSource = L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Chua");
                    grvthongtin.DataBind();
                    if (L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Chua").Count > 0)
                    {
                        btexcel.Visible = true;
                        btword.Visible = true;
                        btpdf.Visible = true;
                        grvthongtin.Visible = true;
                        lbthongbao.Text = "Có " + L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Chua").Count.ToString() + " Sách Gia Hạn Lần: " + drplangiahan.SelectedValue + " Chưa Trả";
                    }
                    else { grvthongtin.Visible = false;
                        lbthongbao.Text = "Không Có Kết Quả ";
                        btexcel.Visible = false;
                        btword.Visible = false;
                        btpdf.Visible = false;
                    }
                }
            }
        }//theo rồi
        else
        {
            if (radiochon.SelectedValue == "1")
            {
                if (drplangiahan.SelectedValue == "-1")
                {
                    grvthongtin.DataSource = L_muon.GetTKe("Roi");
                    grvthongtin.DataBind();
                    if (L_muon.GetTKe("Roi").Count > 0)
                    {
                        btexcel.Visible = true;
                        btword.Visible = true;
                        btpdf.Visible = true;
                        grvthongtin.Visible = true;
                        lbthongbao.Text = "Tất Cả: " + L_muon.GetTKe("Roi").Count.ToString() + " Sách Gia Hạn Đã Trả";
                    }
                    else
                    {
                        grvthongtin.Visible = false;
                        lbthongbao.Text = "Không Có Kết Quả ";
                        lbthongbao.Text = "Không Có Kết Quả ";
                        btexcel.Visible = false;
                        btword.Visible = false;
                        btpdf.Visible = false;
                    }
                }
                else
                {
                    if (Convert.ToInt32(_giahan.Trim()) >= 0)
                    {
                        grvthongtin.DataSource = L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Roi");
                        grvthongtin.DataBind();
                        if (L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Roi").Count > 0)
                        {
                            btexcel.Visible = true;
                            btword.Visible = true;
                            btpdf.Visible = true;
                            grvthongtin.Visible = true;
                            lbthongbao.Text = "Có " + L_muon.GetByMaGiaHan(Convert.ToInt32(_giahan.Trim()), "Roi").Count.ToString() + " Sách Gia Hạn Lần "+drplangiahan.SelectedValue+" Đã Trả";
                        }
                        else
                        {
                            grvthongtin.Visible = false;
                            lbthongbao.Text = "Không Có Kết Quả ";
                            lbthongbao.Text = "Không Có Kết Quả ";
                            btexcel.Visible = false;
                            btword.Visible = false;
                            btpdf.Visible = false;
                        }
                    }
                }
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
    
    

