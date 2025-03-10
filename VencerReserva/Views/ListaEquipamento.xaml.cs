using System.Collections.ObjectModel;
using System.Threading.Tasks;
using VencerReserva.Models;

namespace VencerReserva.Views;

public partial class ListaEquipamento : ContentPage
{
	ObservableCollection<Equipamento> lista = new ObservableCollection<Equipamento>();

	public ListaEquipamento()
	{
		InitializeComponent();

        lts_equipamento.ItemsSource = lista;
	}

    protected async override void OnAppearing()
    {
        try
        {
            lista.Clear();
            List<Equipamento> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));

        } catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void ToolbarItem_Clicked_Add(object sender, EventArgs e)  // Adiciona um equipamento
    {
        try
        {
            Navigation.PushAsync(new Views.NovoEquipamento());

        } catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void txt_search_TextChanged(object sender, TextChangedEventArgs e) // Barra de Pesquisa
    {
        try
        {
            string q = e.NewTextValue;

            lts_equipamento.IsRefreshing = true;

            lista.Clear();

            List<Equipamento> tmp = await App.Db.Search(q);

            tmp.ForEach(i => lista.Add(i));

        } catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private void lts_equipamento_ItemSelected(object sender, SelectedItemChangedEventArgs e) // seleciona um item da lista
    {
        try
        {
            Equipamento equipamento = e.SelectedItem as Equipamento;

            Navigation.PushAsync(new Views.EditarEquipamento
            {
                BindingContext = equipamento
            });
        }
        catch (Exception ex)
        {
            DisplayAlert("Ops", ex.Message, "OK");
        }
    }

    private async void lts_equipamento_Refreshing(object sender, EventArgs e) // Atualiza a barra de pesquisa
    {
        try
        {
            lista.Clear();
            List<Equipamento> tmp = await App.Db.GetAll();

            tmp.ForEach(i => lista.Add(i));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        } finally
        {
            lts_equipamento.IsRefreshing = false;
        }
    }

    private async void MenuItem_Clicked(object sender, EventArgs e) // Remove o item selecionado
    {
        try
        {
            MenuItem selecionado = sender as MenuItem;

            Equipamento equipamento = selecionado.BindingContext as Equipamento;

            bool confirm = await DisplayAlert("Tem certeza?", $"Remover {equipamento.Nome}?", "Sim", "Não");

            if (confirm)
            {
                await App.Db.Delete(equipamento.Id);
                lista.Remove(equipamento);
            }

        }
        catch (Exception ex)
        {
           await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}