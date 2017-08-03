using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

public static class StringHelper
{
    public static string AsAnioMesDia(this object item, DateTime valor = default(DateTime))
    {
        string r_valor = string.Empty;

        r_valor = valor.Year + "/" + valor.Month + "/" + valor.Day;

        return r_valor;
    }
    public static string AsMesDiaAnio(this object item, DateTime valor = default(DateTime))
    {
        string r_valor = string.Empty;
        DateTime fdate = new DateTime();
        fdate = item.AsDateTime();

        r_valor = fdate.Month + "/" + fdate.Day + "/" + fdate.Year;

        return r_valor;
    }
    public static string AsMesAnio(this object item, DateTime valor = default(DateTime))
    {
        string r_valor = string.Empty;
        valor = item.AsDateTime();

        r_valor = valor.Month + "/" + valor.Year;

        return r_valor;
    }
    public static string calcularDigitoVerificador(this object item, int numero = default(int))
    {
        string cadenaNumero = numero.ToString();
        int calculador = 0;
        string digitoVerificador = string.Empty;

        try
        {

            int[] factores = { 3, 2, 7, 6, 5, 4, 3, 2 };
            int indiceFactor = factores.Length - 1;

            for (int i = cadenaNumero.Length - 1; i >= 0; i--)
            {
                calculador = calculador + (factores[indiceFactor] * int.Parse(cadenaNumero.Substring(i, 1)));
                indiceFactor--;
            }

            int resultado = 11 - (calculador % 11);

            if (resultado == 11)
            {
                digitoVerificador = "0";
            }
            else if (resultado == 10)
            {
                digitoVerificador = "K";
            }
            else
            {
                digitoVerificador = resultado.ToString();
            }
        }
        catch
        {
            digitoVerificador = "";
        }

        return digitoVerificador;
    }
    public static string formatearRut(this object item, string rut = default(string))
    {
        int cont = 0;
        string format;
        if (item.ToString().Length == 0)
        {
            return "";
        }
        else
        {
            item = item.ToString().Replace(".", "");
            item = item.ToString().Replace("-", "");
            format = "-" + item.ToString().Substring(item.ToString().Length - 1);
            for (int i = item.ToString().Length - 2; i >= 0; i--)
            {
                format = item.ToString().Substring(i, 1) + format;
                cont++;
                if (cont == 3 && i != 0)
                {
                    format = "." + format;
                    cont = 0;
                }
            }
            return format;
        }
    }
    public static string solodvr(this object item, string rutcompleto = default(string))
    {
        if (item == null)
            return rutcompleto;

        string dvr = "";
        rutcompleto = item.ToString().Replace(".", "");
        string[] rut_completo_ = item.ToString().Split('-');

        int indi = 0;
        foreach (string s in rut_completo_)
        {
            if (indi == 1)
            {
                dvr = s;
                break;
            }
            indi++;
        }
        return dvr.ToUpper();
    }
    public static string solousuario(this object item, string email = default(string))
    {
        string usuario = "";
        string[] emailcompleto = item.ToString().Split('@');

        int indi = 0;
        foreach (string s in emailcompleto)
            if (indi == 0)
            {
                usuario = s;
                break;
            }

        return usuario.ToLower();
    }
    public static string solodominio(this object item, string email = default(string))
    {
        string dominio = "";
        string[] emailcompleto = item.ToString().Split('@');

        int indi = 0;
        foreach (string s in emailcompleto)
        {
            if (indi == 1)
            {
                dominio = s;
                break;
            }
            indi++;
        }

        return dominio.ToLower(); ;
    }
    public static string AsAnioMes(this DateTime item, DateTime fecha = default(DateTime))
    {
        string periodo = string.Empty;

        periodo = item.Year + "-" + item.Month;

        return periodo;
    }
    public static string AsMesAnio(this DateTime item, DateTime fecha = default(DateTime))
    {
        string periodo = string.Empty;

        periodo = item.Month + "-" + item.Year;

        return periodo;
    }
    public static string primeraMayuscula(this object item, string valor = default(string))
    {
        item = item.ToString().ToLower();
        return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(item.ToString());
    }
    public static string obtener_Nombre_dia(this object item, DateTime fecha = default(DateTime))
    {
        return fecha.ToString("dddd").ToUpper().primeraMayuscula();
    }
    public static string obtener_Nombre_Mes_Numero(this object item, int numeroMes = default(int))
    {
        try
        {
            DateTimeFormatInfo formatoFecha = CultureInfo.CurrentCulture.DateTimeFormat;
            string nombreMes = primeraMayuscula(formatoFecha.GetMonthName(numeroMes));
            return nombreMes;
        }
        catch
        {
            return "Desconocido";
        }
    }
    public static string formatear_valor_pesos(this object item, string valor = default(string))
    {
        if (valor.AsDecimal() > 0)
            return string.Format("${0:###,###0.}", valor.AsDecimal());
        else
            return string.Format("${0:###,###0.}", valor.AsInt());
    }
    public static string formatear_valor_numerico(this object item, string valor = default(string))
    {
        if (valor.AsDecimal() > 0)
            return string.Format("{0:###,###0.}", valor.AsDecimal());
        else
            return string.Format("{0:###,###0.}", valor.AsInt());
    }
}
