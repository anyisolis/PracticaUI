namespace PracticaUI;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

	private void onConvertirClicked(object sender, EventArgs e)
	{
		if (!double.TryParse(txtMonto.Text, out double monto) || pckOrigen.SelectedIndex == -1 || pckDetino.SelectedIndex == -1)
		{
			lblResultado.Text = "Seleccione las monedas e ingrese un monto.";
			return;
		}

		double montoEnUSD = pckOrigen.SelectedIndex.ToString() switch
		{
			"HNL (Lempira)" => monto / 24.75,
			"EUR (Euros)" => monto * 1.08,
			_             => monto 
		};

		double resultado = pckDetino.SelectedIndex.ToString() switch
		{
            "HNL (Lempira)" => montoEnUSD * 24.75,
            "EUR (Euros)" => montoEnUSD / 1.08,
            _             => montoEnUSD

        };

		lblResultado.Text = $"Resultado: {resultado:F2}";
	}

}