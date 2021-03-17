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
/// Summary description for QuiDinh
/// </summary>
public class QuiDinh
{
    private QuiDinhTableAdapter _quidinh = null;
    protected QuiDinhTableAdapter qui_dinh
    {
        get
        {
            if (_quidinh == null)
                _quidinh = new QuiDinhTableAdapter();
            return _quidinh;
        }
    }
    [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Select, false)]
    public Data.QuiDinhDataTable GetQuiDinh()
    {
        return this.qui_dinh.GetQuiDinh();
    }
}
