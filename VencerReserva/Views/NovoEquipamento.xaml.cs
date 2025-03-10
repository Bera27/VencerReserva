using System.Threading.Tasks;
using VencerReserva.Models;

namespace VencerReserva.Views;

public partial class NovoEquipamento : ContentPage
{
	public NovoEquipamento()
	{
		InitializeComponent();



        dtpck_checkIn.MinimumDate = DateTime.Now;

        dtpck_checkOut.MinimumDate = dtpck_checkIn.Date.AddDays(1);
	}

    private async void ToolbarItem_Clicked_Salvar(object sender, EventArgs e)
    {
        try
        {
            Equipamento equipamento = new Equipamento
            {
                Nome = txt_nome.Text,
                CheckIn = dtpck_checkIn.Date,
                CheckOut = dtpck_checkOut.Date
            };

            await App.Db.Insert(equipamento);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
            await Navigation.PopAsync();
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void dtpck_checkIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime dataselecionada = elemento.Date;

        dtpck_checkOut.MinimumDate = dataselecionada.AddDays(1);
    }
}