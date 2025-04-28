using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Services.Utils
{
    public static class InputsValidator
    {
        public static bool CostValidator(decimal costo, out string errorMessage)
        {
            string validationRule = @"^(?:[0-9]{1,7})$";
            errorMessage = string.Empty;

            if (!Regex.IsMatch(costo.ToString(), validationRule))
            {
                errorMessage = "Ingrese un numero valido entre 0 y 9999999";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool SKUValidator(string sku, out string errorMessage)
        {
            string validationRule = @"^[a-z0-9]{2,3}-[a-z0-9]{2,3}-[a-z0-9]{2,7}-[a-z0-9]{2,3}-[a-z0-9]{2,3}$";
            errorMessage = string.Empty;

            if(!Regex.IsMatch(sku, validationRule, RegexOptions.IgnoreCase))
            {
                errorMessage = "Ingrese un numero SKU válido";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool RatesValidator(decimal rate, out string errorMessage)
        {
            string validationRule = @"^(100([.,]0{1,})?|(\d{1,2})([.,]\d+)?)$";
            errorMessage = string.Empty;

            if (!Regex.IsMatch(rate.ToString(), validationRule))
            {
                errorMessage = "Ingrese una tasa válida entre 0 y 100";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool NamesValidator(string name, out string errorMessage)
        {
            string validationRule = @"^(?! )[A-Za-z0-9]+(?: [A-Za-z0-9]+){0,59}(?<! )$";
            errorMessage = string.Empty;

            if (!Regex.IsMatch(name, validationRule))
            {
                errorMessage = "Ingrese un nombre válido";
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool OrderValidator(string order, out string errorMessage)
        {
            string validationRule = @"^[a-z0-9]{1,30}$";
            errorMessage = string.Empty;

            if (!Regex.IsMatch(order, validationRule, RegexOptions.IgnoreCase))
            {
                errorMessage = "Ingrese un numero de orden valido";
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
