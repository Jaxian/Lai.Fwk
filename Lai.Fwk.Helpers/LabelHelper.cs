using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

public static class LabelHelper
{
    public static System.Web.UI.WebControls.Label findControlLabel(this System.Web.UI.Control item, string idControl)
    {
        System.Web.UI.WebControls.Label objeto = new System.Web.UI.WebControls.Label();
        try
        {
            objeto = ((System.Web.UI.WebControls.Label)item.FindControl(idControl));
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