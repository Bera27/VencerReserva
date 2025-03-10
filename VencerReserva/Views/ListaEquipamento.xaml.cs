using System.Collections.ObjectModel;
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

    private void ToolbarItem_Clicked_Add(object sender, EventArgs e)  // Adiciona um equipamento
    {

    }

    private void txt_search_TextChanged(object sender, TextChangedEventArgs e) // Barra de Pesquisa
    {

    }

    private void lts_equipamento_ItemSelected(object sender, SelectedItemChangedEventArgs e) // seleciona um item da lista
    {

    }

    private void lts_equipamento_Refreshing(object sender, EventArgs e) // Atualiza a barra de pesquisa
    {

    }
}