using System;
using System.Globalization;
using System.Linq;

namespace LM.Domain.Helpers
{
    public static class TextoHelper
    {
        public static string ObterNumeros(string texto)
        {
            return string.IsNullOrEmpty(texto) ? "" : new String(texto.Where(Char.IsDigit).ToArray());
        }
        
        public static string ToCamelCase(string texto, bool manterOqueJaEstiverMaiusculo = false)
        {
            texto = texto.Trim();

            if (!manterOqueJaEstiverMaiusculo)
                texto = texto.ToLower();

            var textInfo = new CultureInfo("pt-BR", false).TextInfo;
            return textInfo.ToTitleCase(texto);
        }
    }
}