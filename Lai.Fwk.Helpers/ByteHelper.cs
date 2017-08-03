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
public static class ByteHelper
{
    public static byte[] imageToByteArray(this object item, string imagen = default(string))
    {
        imagen = HttpContext.Current.Request.MapPath(imagen);
        byte[] buffer_new = null;
        try
        {
            string Mime = string.Empty;
            Mime = new System.IO.FileInfo(imagen).Extension;

            System.IO.FileStream fs = new FileStream(imagen, FileMode.Open);
            System.IO.BufferedStream bf = new BufferedStream(fs);
            byte[] buffer = new byte[bf.Length];
            bf.Read(buffer, 0, buffer.Length);

            buffer_new = buffer;
            fs.Close();
        }
        catch (Exception ex)
        {

        }
        return buffer_new;
    }
}