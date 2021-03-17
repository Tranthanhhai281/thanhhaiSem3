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
using System.IO;
using System.Text;
using DataTableAdapters;


public partial class ThuVien_QuanLy_Default2 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string m_strFileName = filupexcel.PostedFile.FileName;
        if (m_strFileName == "")
        {
            lbCanhBao.Text = "File không Tồn tại";
        }
        else
        {
            string strTemp = m_strFileName.Substring(m_strFileName.Length - 3);
            strTemp = strTemp.ToUpper();
            if (strTemp == "XLS")
            {
                //bắt đầu
                lbCanhBao.Text = System.IO.Path.GetFileName(m_strFileName);
                Microsoft.Office.Interop.Excel.Application t = new Microsoft.Office.Interop.Excel.Application();
                t.Visible = true;
                //Mở một file excel đã có, và cho biến x trỏ đến file excel này
               // Microsoft.Office.Interop.Excel.Workbook x;
                //x = t.Workbooks.Open(System.IO.Path.GetFullPath(m_strFileName), 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                //kết thúc
            }
            else
            {
                lbCanhBao.Text = "File được chọn không đúng định dạng yêu cầu";
            }
        }
       /* DocGiaTableAdapter D_gia = new DocGiaTableAdapter();
        Data.DocGiaDataTable ban_docgia = D_gia.GetDocGia();
        Microsoft.Office.Interop.Excel.Application t = new Microsoft.Office.Interop.Excel.Application();
        t.Visible = true;
        //Mở một file excel đã có, và cho biến x trỏ đến file excel này
        Microsoft.Office.Interop.Excel.Workbook x;
        x = t.Workbooks.Open(_str, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);

        //Cho một biến s trỏ đến một sheet của file excel x (đã tạo ở Lưu ý 2. hoặc 3.)
        Microsoft.Office.Interop.Excel.Worksheet s;
        s = (Microsoft.Office.Interop.Excel.Worksheet)x.Worksheets[1];   
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
                    LayThoiGian L_tg= new LayThoiGian();
                    bool _b=L_tg.chuoivangay(s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim());
                    s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim();
                    if (s.get_Range("A" + i.ToString(), "A" + i.ToString()).Value2.ToString().Trim() == ban_docgia[j].MaDocGia.Trim()||_b==false)
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
            }
            else {//bản đọc giả không có dữ liệu
                    LayThoiGian L_tg= new LayThoiGian();
                    bool _b=L_tg.chuoivangay(s.get_Range("E" + i.ToString(), "E" + i.ToString()).Value2.ToString().Trim());

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
             }
        }*/
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        string d = Server.MapPath("Excel\\" + System.IO.Path.GetFileName(filupexcel.PostedFile.FileName));
       lbCanhBao.Text = d;
    }
}