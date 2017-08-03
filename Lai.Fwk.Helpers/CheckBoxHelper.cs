using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

/// <summary>
/// 
/// </summary>
public static class CheckBoxHelper
{
    public static System.Web.UI.WebControls.CheckBox findControlCheckBox(this System.Web.UI.Control item, string idControl)
    {
        System.Web.UI.WebControls.CheckBox objeto = new System.Web.UI.WebControls.CheckBox();
        try
        {
            objeto = ((System.Web.UI.WebControls.CheckBox)item.FindControl(idControl));
        }
        catch (Exception ex)
        {
            //this.Mensaje = ex.Message;
            //this.Existeerror = true;
            //Mail.EnviaMailError(ex.Message, "MetodosBase:findLabelGrid", this.Request, this.Context);
        }

        return objeto;
    }
}