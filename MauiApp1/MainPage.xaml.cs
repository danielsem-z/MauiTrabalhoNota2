using MauiApp1.Data;
using MauiApp1.Entity;
using MauiApp1.Service;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        private PrevisaoRepository _previsaoRepo;

        public MainPage()
        {
            InitializeComponent();
            _previsaoRepo = new PrevisaoRepository();
            LoadSaved();
        }

        private void LoadSaved()
        {
            var previsoes = _previsaoRepo.GetAll();
            ForecastListView.ItemsSource = previsoes.Select(ConvertToViewListRow).ToList();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var previsaoService = new PrevisaoService();
            var cidade = CityEntry.Text;

            if (cidade == null)
            {
                return;
            }

            PrevisaoEntity? previsao = await previsaoService.GetPrevisaoAsync(cidade);
            if (previsao == null)
            {
                await DisplayAlert("Erro", "Previsão não encontrada para a cidade informada.", "OK");
                return;
            }

            _previsaoRepo.Add(previsao);
            LoadSaved();
        }

        private void SearchButton_Clicked(object sender, EventArgs e)
        {
            var dateInput = DateEntry.Date;

            var previsoes = _previsaoRepo.GetByDate(dateInput)
                .Select(ConvertToViewListRow)
                .ToList();

            ForecastListView.ItemsSource = previsoes;
        }

        private object ConvertToViewListRow(PrevisaoEntity previsao)
        {
            return new
            {
                CreatedDate = previsao.CreatedDate?.ToString("dd/MM/yyyy"),
                Name = previsao.Name,
                Temp = $"{previsao.Main?.Temp}°C",
                Weather = previsao.Weather?[0].Description
            };
        }
    }
}
