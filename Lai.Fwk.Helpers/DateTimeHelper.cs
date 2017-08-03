using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DateTimeHelper
{
    public static DateTime AsDateTime(this object item, DateTime valor = default(DateTime))
    {
        if (item == null)
            return valor;
        DateTime result;
        if (!DateTime.TryParse(item.ToString(), out result))
            return valor;
        return result;
    }
    public static DateTime primerDiaMes(this DateTime item, DateTime valor = default(DateTime))
    {
        return new DateTime(item.Year, item.Month, 1);
    }
    public static DateTime ultimoDiaMes(this object item, DateTime valor = default(DateTime))
    {
        DateTime mes_siguiente = item.AsDateTime().AddMonths(1);
        mes_siguiente = ("01/" + mes_siguiente.Month + "/" + mes_siguiente.Year).AsDateTime();
        DateTime ultimo_dia_mes = mes_siguiente.AddDays(-1);
        return ultimo_dia_mes;
    }
    public static DateTime sumar_meses_fecha(this DateTime item, int meses = default(int))
    {
        DateTime hasta = new DateTime();

        hasta = item.AddMonths(meses);

        return hasta;
    }
    public static IEnumerable<DateTime> cadaDia(this object item, DateTime desde = default(DateTime), DateTime hasta = default(DateTime))
    {
        for (var dia = desde.Date; dia.Date <= hasta.Date; dia = dia.AddDays(1))
            yield return dia;
    }
}