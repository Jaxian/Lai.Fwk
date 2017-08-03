using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DecimalHelper
{
    public static decimal AsDecimal(this object item, decimal valor = default(decimal))
    {
        if (item == null)
            return valor;
        decimal result;
        if (!decimal.TryParse(item.ToString(), out result))
            return valor;
        return result;
    }
    public static decimal calcular_neto(this object item, int valor = default(int))
    {
        decimal ivalor = 0;
        decimal out_valor = 0;
        decimal tmpneto = 0;
        decimal iva = 1.19m;

        tmpneto = valor.AsDecimal();

        ivalor = (tmpneto) / iva;

        out_valor = Convert.ToInt32(ivalor);
        return out_valor;
    }
}