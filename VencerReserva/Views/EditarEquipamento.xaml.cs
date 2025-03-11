using VencerReserva.Models;

namespace VencerReserva.Views;

public partial class EditarEquipamento : ContentPage
{
	public EditarEquipamento()
	{
		InitializeComponent();

        dtpck_checkIn.MinimumDate = DateTime.Now;
        dtpck_checkOut.MinimumDate = dtpck_checkIn.Date.AddDays(1);
	}

    private async void ToolbarItem_Clicked(object sender, EventArgs e)
    {
        Equipamento equipamentoAnexado = BindingContext as Equipamento;

        Equipamento equipamento = new Equipamento
        {
            Id = equipamentoAnexado.Id,
            Nome = txt_nome.Text,
            CheckIn = dtpck_checkIn.Date,
            CheckOut = dtpck_checkOut.Date,
            Responsavel = txt_responsavel.Text,
            Sala = txt_sala.Text,
            Quantidade = Convert.ToInt32(txt_quantidade.Text),
        };

        await App.Db.Update(equipamento);
        await DisplayAlert("Sucesso!", "Registro Atualizado", "OK");
        await Navigation.PopAsync();
    }

    private void dtpck_checkIn_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker elemento = sender as DatePicker;

        DateTime dataselecionadaCheckin = elemento.Date;

        dtpck_checkOut.MinimumDate = dataselecionadaCheckin.AddDays(1);
    }
}