using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Model;

namespace BLL.Service
{
    public class ValidateNIF
    {
        private string _nif;

        public ValidateNIF(string nif) 
        {
            _nif = nif;
        }

        public Response Action () 
        {
            Response response = new Response();

            try 
            {
                if (_nif == null) 
                {
                    throw new ArgumentException("The NIF value is null");
                }

                if (_nif.Length != 9) 
                {
                    throw new ArgumentException("The NIF length is incorrect");
                }

                List<int> digitsNif = _nif.Select(x => Convert.ToInt32(x.ToString())).ToList();

                if (digitsNif[0] == 1 || digitsNif[0] == 2) 
                {
                    response.Type = "Single Person";
                }
                else if (digitsNif[0] == 5) 
                {
                    response.Type = "Legal Person";
                }
                else 
                {
                    throw new ArgumentException("The NIF is invalid");
                }

                int calculateDigits = digitsNif[7] * 2 + digitsNif[6] * 3 + digitsNif[5] * 4 + digitsNif[4] * 5 
                + digitsNif[3] * 6 + digitsNif[2] * 7 + digitsNif[1] * 8 + digitsNif[0] * 9;

                int divisionRest = calculateDigits % 11;
                int lastDigitHasToBe = divisionRest <= 1 ? 0 : 11 - divisionRest;

                if (digitsNif[8] == lastDigitHasToBe) {
                    response.IsValid = true;
                }
                else 
                {
                    throw new ArgumentException("The NIF is invalid");
                }        
                
            }
            catch (Exception ex)
            {
                response.IsValid = false;
                response.ErrorMessage = ex.Message;
            }            

            return response;            
        }
    }
}
