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
    
    private Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "Thêm Đọc Giả";
        
        if (Convert.ToString(Session["TaiKhoan"]) == "")
        {
            tbThem.Enabled = false;
            bthienthi.Enabled = false;
        }
        else {
            tbThem.Enabled = true;
            bthienthi.Enabled = true;
            if (!IsPostBack)
            {
               string ten_file = Request.QueryString["Ten_file"];
                string filepath = Server.MapPath(ten_file.Trim());
               
                GetListofSheetsAndCharts(filepath, true, drpsheet);
            }
        }
    }    
    
    protected void tbDangky_Click(object sender, EventArgs e)
    {
        string m_strFileName = Request.QueryString["Ten_file"];
        string filepath = Server.MapPath(m_strFileName.Trim());
        DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
        Data.DocGiaDataTable ban_docgia = D_gia.GetDocGia();
        Microsoft.Office.Interop.Excel.Application t = new Microsoft.Office.Interop.Excel.Application();
       
        //Mở một file excel đã có, và cho biến x trỏ đến file excel này
        Microsoft.Office.Interop.Excel.Workbook x;
        x = t.Workbooks.Open(filepath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

        //Cho một biến s trỏ đến một sheet của file excel x (đã tạo ở Lưu ý 2. hoặc 3.)
        Microsoft.Office.Interop.Excel.Worksheet s;
        s = (Microsoft.Office.Interop.Excel.Worksheet)x.Worksheets[drpsheet.SelectedIndex+1];
        int i = 2;
        while (s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2 != null)
        {
            bool _co = false;
            string _madocgia = "", _machucvu = "", _hoten = "", _giotinh = "", _namsinh = "", _email = "";
            if (ban_docgia.Count > 0)//bản dữ liệu đã có dữ liệu
            {
                //duyệt từng dòng bản đọc giả xét mã đọc giả không trùng.
                for (int j = 0; j < ban_docgia.Count; j++)
                {
                    LayThoiGian L_tg = new LayThoiGian();
                    bool _b = L_tg.chuoivangay(s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim());
                    s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim();
                    if (s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2.ToString().Trim() == ban_docgia[j].MaDocGia.Trim()|| _b == false)
                    {//nếu trùng mã đọc giả thì tăng i lên 1.
                        _co = false;
                        j = ban_docgia.Count;
                        i++;
                    }
                    else//không trùng.
                    {
                        _co = true;
                    }
                }
                if (_co == true)//thêm nếu mã đọc giả không trùng
                {
                    _madocgia = s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2.ToString().Trim();
                    _machucvu = s.get_Range("B" + i.ToString(), "B" + i.ToString()).Value2.ToString().Trim();
                    _hoten = s.get_Range("C" + i.ToString(), "C" + i.ToString()).Value2.ToString().Trim();
                    _giotinh = s.get_Range("D" + i.ToString(), "D" + i.ToString()).Value2.ToString().Trim();
                    _namsinh = s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim();

                    if (s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2 == null)//nếu không có email
                    {
                        _email = null;
                    }
                    else//có email
                    { _email = s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2.ToString().Trim(); }

                    D_gia.ThemDG(_madocgia, int.Parse(_machucvu), _hoten, _giotinh, _namsinh, _email);

                    i++;
                }
                lbThanhCong.Text = "Đã Thêm Đọc Giả Thành Công";
            }
            else
            {//bản đọc giả không có dữ liệu
                LayThoiGian L_tg = new LayThoiGian();
                bool _b = L_tg.chuoivangay(s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim());

                if (_b == false)//nếu ngày không đúng định dạng mm/dd/yyyy "01/29/2011"
                { i++; }
                else
                {
                    _madocgia = s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2.ToString().Trim();
                    _machucvu = s.get_Range("B" + i.ToString(), "B" + i.ToString()).Value2.ToString().Trim();
                    _hoten = s.get_Range("C" + i.ToString(), "C" + i.ToString()).Value2.ToString().Trim();
                    _giotinh = s.get_Range("D" + i.ToString(), "D" + i.ToString()).Value2.ToString().Trim();
                    _namsinh = s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim();

                    if (s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2 == null)//không có email
                    {
                        _email = null;
                    }
                    else//có email
                    { _email = s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2.ToString().Trim(); }
                    D_gia.ThemDG(_madocgia, int.Parse(_machucvu), _hoten, _giotinh, _namsinh, _email);
                    i++;
                }
                lbThanhCong.Text = "Đã Thêm Đọc Giả Thành Công";
            }            
         }
       // string xoa_file = Request.QueryString["Ten_file"];
       // System.IO.File.Delete(Server.MapPath(xoa_file.Trim())); 
     } 
    
    protected void radiochon_SelectedIndexChanged(object sender, EventArgs e)
    {

    }    
        // Trong hàm này, ta xây dựng Hàm GetListofSheetsAndCharts(m_strFileName, true, drpShtAndChrt) để tách File thành các Sheet và Chart, có nội dung như sau:
    public void GetListofSheetsAndCharts(string strFileName, bool bReadOnly, DropDownList drpList)
    {
        //excelApp.Visible = true;
        Microsoft.Office.Interop.Excel.Workbook workbook = null;
        try
        {
            if (!bReadOnly)
            {
                // mở chế độ Write.
                workbook = excelApp.Workbooks.Open(strFileName, 2, false, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
            }
            else
            {
                // Mở chế độ Read
                workbook = excelApp.Workbooks.Open(strFileName, 2, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, true, 0, true, 1, 0);
            }
            // Đọc File Excel.

            object SheetRChart = null;
            int nTotalWorkSheets = workbook.Sheets.Count;
            int nIndex = 0;
            for (int nWorkSheet = 1; nWorkSheet <= nTotalWorkSheets; nWorkSheet++)
            {
                SheetRChart = workbook.Sheets[(object)nWorkSheet];
                if (SheetRChart is Microsoft.Office.Interop.Excel.Worksheet)
                {
                    ListItem lstItemAdd = new ListItem(((Microsoft.Office.Interop.Excel.Worksheet)SheetRChart).Name + "*WorkSheet", nIndex.ToString(), true);
                    drpList.Items.Add(lstItemAdd);
                    lstItemAdd = null;
                    nIndex++;
                }
                else if (SheetRChart is Microsoft.Office.Interop.Excel.Chart)
                {
                    ListItem lstItemAdd = new ListItem(((Microsoft.Office.Interop.Excel.Chart)SheetRChart).Name + "*Chart", nIndex.ToString(), true);
                    drpList.Items.Add(lstItemAdd);
                    lstItemAdd = null;
                    nIndex++;
                }
            }
            if (workbook != null)
            {
                if (!bReadOnly)
                {
                    // Đóng chế độ Write
                    workbook.Save();
                    workbook = null;
                }
                else
                {
                    // Đóng chế độ Read
                    workbook.Close(false, false, Type.Missing);
                    workbook = null;
                }
            }
        }
        catch (Exception expFile)
        {
            Response.Write(expFile.ToString());
        }
        finally
        {
            if (workbook != null)
            {
                if (!bReadOnly)
                {
                    // Đóng chế độ Write
                    workbook.Save();
                    workbook = null;
                }
                else
                {
                    // Đóng chế độ Read
                    workbook.Close(false, false, Type.Missing);
                    workbook = null;
                }
            }
        }    
    }
    protected void bthienthi_Click(object sender, EventArgs e)
    {
        string m_strFileName = Request.QueryString["Ten_file"];
        string filepath = Server.MapPath(m_strFileName.Trim());
        int _k = drpsheet.SelectedIndex + 1;
        DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
        Data.DocGiaDataTable ban_docgia = D_gia.GetDocGia();
        Microsoft.Office.Interop.Excel.Application t = new Microsoft.Office.Interop.Excel.Application();
       // t.Visible = true;
        //Mở một file excel đã có, và cho biến x trỏ đến file excel này
        Microsoft.Office.Interop.Excel.Workbook x;
        x = t.Workbooks.Open(filepath, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

        //Cho một biến s trỏ đến một sheet của file excel x (đã tạo ở Lưu ý 2. hoặc 3.)
        Microsoft.Office.Interop.Excel.Worksheet s;
        s = (Microsoft.Office.Interop.Excel.Worksheet)x.Worksheets[_k];
        int i =2 ;
        Data.DocGiaDataTable ban_thongtin = new Data.DocGiaDataTable();
        while (s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2 != null)
        {
            Data.DocGiaRow luot_rows = ban_thongtin.NewDocGiaRow();           
            string _madocgia = "", _machucvu = "", _hoten = "", _giotinh = "", _namsinh = "", _email = "";
           
                //duyệt từng dòng bản đọc giả xét mã đọc giả không trùng.               
               
                _madocgia = s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2.ToString().Trim();
                _machucvu = s.get_Range("B" + i.ToString(), "B" + i.ToString()).Value2.ToString().Trim();
                _hoten = s.get_Range("C" + i.ToString(), "C" + i.ToString()).Value2.ToString().Trim();
                _giotinh = s.get_Range("D" + i.ToString(), "D" + i.ToString()).Value2.ToString().Trim();
                _namsinh = s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim();

                if (s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2 == null)//nếu không có email
                {_email = null;}
                else//có email
                { _email = s.get_Range("F" + i.ToString(), "F" + i.ToString()).Value2.ToString().Trim(); }
                luot_rows.MaDocGia = _madocgia;
                luot_rows.MaChucVu = Convert.ToInt32(_machucvu);
                luot_rows.HoTen = _hoten;
                luot_rows.GioiTinh = _giotinh;
                luot_rows.NamSinh = _namsinh;
                luot_rows.Email = _email;
                ban_thongtin.Rows.Add(luot_rows);
                i++;               
         }
        if (ban_thongtin.Count > 0)
        {
            grvthongtin.Visible = true;
            grvthongtin.DataSource = ban_thongtin;
            grvthongtin.DataBind();
        }
        else { grvthongtin.Visible = false; }

    }
    protected void grvthongtin_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
