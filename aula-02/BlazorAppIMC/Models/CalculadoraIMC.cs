namespace BlazorAppIMC.Models
{
    public class CalculadoraIMC
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public double? Peso { get; set; }
        public double? Altura { get; set; }

        public double? CalcularImc()
        {
            return Peso/(Altura*Altura);
        }

        public string? Situacao()
        {
            string? result = null;
            if (CalcularImc() <= 18.5) result = "Peso abaixo do normal";
            if (CalcularImc() >= 18.5 && CalcularImc() <= 24.9) result = "Peso normal";
            if (CalcularImc() >= 25 && CalcularImc() <= 29.9) result = "Sobrepeso";
            if (CalcularImc() >= 30) result = "Obesidade";

            return result;
        }
    }
}
