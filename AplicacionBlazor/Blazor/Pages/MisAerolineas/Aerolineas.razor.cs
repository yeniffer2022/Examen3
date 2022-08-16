using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;

namespace Blazor.Pages.MisAerolineas
{
    partial class Aerolineas
    {
        [Inject] private IAerolineaServicio aerolineaServicio { get; set; }
        //[Inject] private NavigationManager navigationManager { get; set; }
       

        private IEnumerable <Aerolinea> listaAerolinea { get; set; }

        protected override async Task OnInitializedAsync()
        {
            listaAerolinea = await aerolineaServicio.GetLista();
        }
    }
}
