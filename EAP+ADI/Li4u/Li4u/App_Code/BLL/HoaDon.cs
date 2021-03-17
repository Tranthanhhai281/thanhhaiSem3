using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DataTableAdapters;

/// <summary>
/// Summary description for HoaDon
/// </summary>
/// 
[System.ComponentModel.DataObject]

public class HoaDon
{
    private HoaDonTableAdapter _hoadon = null;
    protected HoaDonTableAdapter hoa_don
    {
        get
        {
            if (_hoadon == null)
                _hoadon = new HoaDonTableAdapter();
            return _hoadon;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.HoaDonDataTable GetDocGia()
    {
        return this.hoa_don.GetHoaDon();
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.HoaDonDataTable GetByMaDG(String MaDG)
    {
        return this.hoa_don.GetByMaDG(MaDG);
    }

	
}
