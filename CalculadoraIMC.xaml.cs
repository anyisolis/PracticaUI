namespace PracticaUI;

public partial class CalculadoraIMC : ContentPage
{
    public CalculadoraIMC()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Validar que los campos contengan números válidos
        if (double.TryParse(txtPeso.Text, out double peso) &&
            double.TryParse(txtAltura.Text, out double altura))
        {
            // Validar que el peso sea estrictamente mayor que 0 (y la altura también)
            if (peso <= 0 || altura <= 0)
            {
                DisplayAlert("Error", "El peso y la altura deben ser mayores que 0.", "OK");
                return;
            }

            // Cálculo del IMC (Peso / Altura al cuadrado)
            double imc = peso / (altura * altura);

            // Mostrar el valor del IMC
            lblValorIMC.Text = $"IMC: {imc:F2}";

            // Asignar el diagnóstico y color según el rango
            if (imc < 18.5)
            {
                lblDiagnostico.Text = "Diagnóstico: Bajo peso";
                lblDiagnostico.TextColor = Colors.Blue;
            }
            else if (imc >= 18.5 && imc < 25)
            {
                lblDiagnostico.Text = "Diagnóstico: Peso normal";
                lblDiagnostico.TextColor = Colors.Green;
            }
            else if (imc >= 25 && imc < 30)
            {
                lblDiagnostico.Text = "Diagnóstico: Sobrepeso";
                lblDiagnostico.TextColor = Colors.DarkOrange;
            }
            else
            {
                lblDiagnostico.Text = "Diagnóstico: Obesidad";
                lblDiagnostico.TextColor = Colors.Red;
            }

            // Hacer visible la tarjeta de resultados con los rangos
            brResultado.IsVisible = true;
        }
        else
        {
            DisplayAlert("Error", "Por favor ingresa valores numéricos válidos.", "OK");
        }
    }
}