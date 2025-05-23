﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Descripción breve de NumberToText
/// </summary>
public class NumberToText
{
    private static string[] _ones =
    {
    "cero",
    "un",
    "dos",
    "tres",
    "cuatro",
    "cinco",
    "seis",
    "siete",
    "ocho",
    "nueve"
    };

    private static string[] _teens =
    {
    "diez",
    "once",
    "doce",
    "trece",
    "catorce",
    "quince",
    "dieciseis",
    "diecisiete",
    "dieciocho",
    "diecinueve"
    };

    private static string[] _tens =
    {
    "",
    "diez",
    "veinte",
    "treinta",
    "cuarenta",
    "cincuenta",
    "sesenta",
    "setenta",
    "ochenta",
    "noventa"
    };

    private static string[] _centenas =
    {
    "",
    "ciento",
    "doscientos",
    "trescientos",
    "cuatrocientos",
    "quinientos",
    "seiscientos",
    "setecientos",
    "ochocientos",
    "novecientos"
    };

    private static string[] _thousands =
    {
    "",
    "mil",
    "millon",
    "billon",
    "trillon",
    "cuatrillon"
    };

    /// <summary>
    /// Converts a numeric value to words suitable for the portion of
    /// a check that writes out the amount.
    /// </summary>
    /// <param name="value">Value to be converted</param>
    /// <returns></returns>
    public static string Convertir_Valor(decimal value)
    {
        string digits, temp;
        bool showThousands = false;
        bool allZeros = true;

        // Use StringBuilder to build result
        StringBuilder builder = new StringBuilder();
        // Convert integer portion of value to string
        digits = ((long)value).ToString();
        // Traverse characters in reverse order
        for (int i = digits.Length - 1; i >= 0; i--)
        {
            int ndigit = (int)(digits[i] - '0');
            int column = (digits.Length - (i + 1));

            // Determine if ones, tens, or hundreds column
            switch (column % 3)
            {
                case 0:        // Ones position
                    showThousands = true;
                    if (i == 0)
                    {
                        // First digit in number (last in loop)
                        temp = String.Format("{0} ", _ones[ndigit]);
                    }
                    else if (digits[i - 1] == '1')
                    {
                        // This digit is part of "teen" value
                        temp = String.Format("{0} ", _teens[ndigit]);
                        // Skip tens position
                        i--;
                    }
                    else if (ndigit != 0)
                    {
                        // Any non-zero digit
                        //if (column == 0)
                        //{
                        temp = String.Format("{0} ", _ones[ndigit]);
                        //}
                        //else
                        //{
                        //    temp = String.Format("{0} ", ndigit == 1 ? "un" : _ones[ndigit]);
                        //}
                    }
                    else
                    {
                        // This digit is zero. If digit in tens and hundreds
                        // column are also zero, don't show "thousands"
                        temp = String.Empty;
                        // Test for non-zero digit in this grouping
                        if (digits[i - 1] != '0' || (i > 1 && digits[i - 2] != '0'))
                            showThousands = true;
                        else
                            showThousands = false;
                    }

                    // Show "thousands" if non-zero in grouping
                    if (showThousands)
                    {
                        if (column > 0)
                        {
                            temp = String.Format("{0}{1}{2}",
                            temp,
                            _thousands[column / 3],
                            allZeros ? " " : ", ");
                        }
                        // Indicate non-zero digit encountered
                        allZeros = false;
                    }
                    builder.Insert(0, temp);
                    break;

                case 1:        // Tens column
                    if (ndigit > 0)
                    {
                        temp = String.Format("{0}{1}",
                        _tens[ndigit],
                        (digits[i + 1] != '0') ? " y " : " ");
                        builder.Insert(0, temp);
                    }
                    break;

                case 2:        // Hundreds column
                    if (ndigit > 0)
                    {
                        temp = String.Format("{0} ", _centenas[ndigit]);
                        builder.Insert(0, temp);
                    }
                    break;
            }
        }

        // Append fractional portion/cents
        builder.AppendFormat("con {0:00}/100 soles", (value - (long)value) * 100);

        // Capitalize first letter
        return String.Format("{0}{1}",
        Char.ToUpper(builder[0]),
        builder.ToString(1, builder.Length - 1));
    }

}