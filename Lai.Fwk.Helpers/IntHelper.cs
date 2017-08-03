using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public static class IntHelper
{
    public static int AsInt(this object item, int valor = default(int))
    {
        item = item.ToString().Replace(".", "").Replace("$", "").Trim();
        if (item.ToString().Split(',').Count() > 0)
            item = item.ToString().Split(',')[0];

        if (item == null)
            return valor;
        int result;
        if (!int.TryParse(item.ToString(), out result))
            return valor;
        return result;
    }
    public static int diferencia_dias(this DateTime fecha_old, DateTime fecha_new, int diferencia = default(int))
    {
        TimeSpan dias = fecha_new - fecha_old;
        diferencia = dias.Days;

        if (diferencia < 0)
            diferencia = 0;

        return diferencia;
    }
    public static int soloParteN(this object item, int indice)
    {
        if (item == null)
            return 0;

        int valor = 0;
        string p_item = item.ToString();
        string[] p_item_ = p_item.Split('/');

        int indi = 0;
        foreach (string s in p_item_)
        {
            if (indi == indice)
            {
                valor = s.AsInt();
                break;
            }
            indi++;
        }

        return valor;
    }
    public static int calcularEdad(this object item, DateTime fnacimiento = default(DateTime))
    {
        int edad = DateTime.Now.Year - fnacimiento.Year;
        DateTime nacimientoAhora = fnacimiento.AddYears(edad);
        if (fnacimiento.Month > DateTime.Now.Month)
            edad--;
        else
            if (DateTime.Now.Month == fnacimiento.Month)//Si el mes de nacimiento es igual 
            if (DateTime.Now.Day < fnacimiento.Day)//Comparamos el dia de nacimiento 
                edad--;                           //Para restar uno en caso de que dia
                                                  //de Nacimiento sea inferior a dia actual
        return edad;
    }
    public static int numerodiadelaseman(this object item, DateTime fecha = default(DateTime))
    {
        int numdia = 0;

        switch (fecha.ToString("dddd").ToUpper())
        {
            case "LUNES":
                numdia = 1;
                break;
            case "MARTES":
                numdia = 2;
                break;
            case "MIÉRCOLES":
                numdia = 3;
                break;
            case "JUEVES":
                numdia = 4;
                break;
            case "VIERNES":
                numdia = 5;
                break;
            case "SÁBADO":
                numdia = 6;
                break;
            case "DOMINGO":
                numdia = 7;
                break;
        }

        return numdia;
    }
    public static int calcular_diferencia_meses_entre_fechas(this object item, DateTime desde = default(DateTime), DateTime hasta = default(DateTime))
    {
        int meses = 0;

        meses = Math.Abs((hasta.Month - desde.Month) + 12 * (hasta.Year - desde.Year));

        if (meses == 0)
            meses = 1;
        meses = meses + 1;

        return meses;
    }
    public static int soloManzana(this object item, int valor = default(int))
    {
        if (item == null)
            return valor;

        int manzana = 0;
        string[] rol = item.ToString().Split('-');

        int indi = 0;
        foreach (string s in rol)
            if (indi == 0)
            {
                manzana = s.AsInt();
                break;
            }

        return manzana;
    }
    public static int soloPredio(this object item, int valor = default(int))
    {
        if (item == null)
            return valor;

        int predio = 0;
        string[] rol = item.ToString().Split('-');

        int indi = 0;
        foreach (string s in rol)
            if (indi == 1)
            {
                predio = s.AsInt();
                break;
            }

        return predio;
    }
    public static int solorut(this object item, int valor = default(int))
    {
        if (item == null)
            return valor;

        int rut = 0;
        string rutcompleto = string.Empty;
        rutcompleto = item.ToString().Replace(".", "");
        string[] rut_completo_ = rutcompleto.Split('-');

        int indi = 0;
        foreach (string s in rut_completo_)
            if (indi == 0)
            {
                rut = s.AsInt();
                break;
            }

        return rut;
    }
    public static int calcular_iva(this object item, int valor = default(int))
    {
        int ivalor = 0;
        int tmpneto = 0;

        tmpneto = valor;

        ivalor = ((tmpneto * 19) / 100);

        return ivalor;
    }
}