using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// </summary>
public static class DoubleHelper
{
    public static double AsDouble(this object item, double valor = default(double))
    {
        if (item == null)
            return valor;
        double result;
        if (!double.TryParse(item.ToString(), out result))
            return valor;
        return result;
    }
}