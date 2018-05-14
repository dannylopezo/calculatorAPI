using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorRest.Servicios
{
    public class Service
    {
        public ResponseBase<double> Execution { get; set; }

        public Service()
        {
            Execution = new ResponseBase<double>()
            {
                Code = 200,
                Message = "Resultado"
            };
        }
        public ResponseBase<double> Addition(string numbers)
        {
            var result = new ResponseBase<double>();
            var value = 0;
            var data = new List<double>();

            data = Validate(numbers);
            if (Execution.Code == 200)
            {

                foreach (var i in data) value = value + Convert.ToInt32(i);
            }
            result.Code = Execution.Code;
            result.Data = value;
            result.Message = "Suma::" + Execution.Message;

            return result;
        }
        public ResponseBase<double> Substraction(string numbers)
        {
            var result = new ResponseBase<double>();
            var value = 0;
            var data = new List<double>();

            data = Validate(numbers);
            if (Execution.Code == 200)
            {

                foreach (var i in data) value = value - Convert.ToInt32(i);
            }
            result.Code = Execution.Code;
            result.Data = value;
            result.Message = "Resta::" + Execution.Message;

            return result;
        }
        public ResponseBase<double> Multiplication(string numbers)
        {
            var result = new ResponseBase<double>();
            var value = 1;
            var data = new List<double>();

            data = Validate(numbers);
            if (Execution.Code == 200)
            {

                foreach (var i in data) value = value * Convert.ToInt32(i);
            }
            result.Code = Execution.Code;
            result.Data = value;
            result.Message = "Multiplicacion::" + Execution.Message;

            return result;
        }
        public ResponseBase<double> Division(string numbers)
        {
            var result = new ResponseBase<double>();
            var value = 1D;
            var data = new List<double>();

            data = Validate(numbers);
            value = DoDivision(data);
            result.Code = Execution.Code;
            result.Data = value;
            result.Message = "Division::" + Execution.Message;

            return result;
        }
        private List<double> Validate(string numbers)
        {
            var result = new List<double>();

            if (!string.IsNullOrWhiteSpace(numbers))
            {
                var splitter = numbers.Split('/');

                if (splitter.Length > 0)
                {
                    for (var i = 0; i < splitter.Length; ++i)
                    {
                        var isEmpty = string.IsNullOrWhiteSpace(splitter[i].ToString());
                        var isNumber = float.TryParse(splitter[i], out float n);

                        if (!isEmpty && isNumber)
                        {
                            result.Add(Convert.ToDouble(splitter[i]));
                        }
                        else
                        {
                            Execution.Code = 500;
                            Execution.Message = "Parametros invalidos";

                            break;
                        }
                    }
                }
                else
                {
                    Execution.Code = 500;
                    Execution.Message = "Sin parametros";
                }
            }
            else
            {
                Execution.Code = 404;
                Execution.Message = "Parametros no encontrados";
            }

            return result;
        }
        private double DoDivision(List<double> numbers)
        {
            var value = numbers[0];

            for (var i = 1; i < numbers.Count; ++i)
            {
                if (numbers[i] != 0)
                {
                    value = value / numbers[i];
                }
                else
                {
                    Execution.Code = 500;
                    Execution.Message = "Tipos flotantes";
                    value = 0;

                    break;
                }
            }

            return value;
        }

    }

}
