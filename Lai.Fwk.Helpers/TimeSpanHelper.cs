using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class TimeSpanHelper
{
    public static TimeSpan AsTimeSpan(this object item, TimeSpan valor = default(TimeSpan))
    {
        if (item == null)
            return valor;
        TimeSpan result;
        if (!TimeSpan.TryParse(item.ToString(), out result))
            return valor;
        return result;
    }
    public static IEnumerable<TimeSpan> cadaHora(this object item, TimeSpan desde = default(TimeSpan), TimeSpan hasta = default(TimeSpan), double interval = default(double))
    {
        TimeSpan minute = TimeSpan.FromMinutes(interval);
        for (var hora = desde; hora <= hasta; hora = hora.Add(minute))
            yield return hora;
    }
}