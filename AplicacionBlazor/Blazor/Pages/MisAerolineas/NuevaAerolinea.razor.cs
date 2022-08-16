using Blazor.Interfaces;
using CurrieTechnologies.Razor.SweetAlert2;
using Microsoft.AspNetCore.Components;
using Modelos;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;

namespace Blazor.Pages.MisAerolineas
{
    partial class NuevaAerolinea
    {
        [Inject] private IAerolineaServicio aerolineaServicio { get; set; }
        
        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
       
        [Inject] private IUsuarioServicio _usuarioServicio { get; set; }


        private Aerolinea aero = new Aerolinea();

        protected override async Task OnInitializedAsync()
        {
            
            aero.Fecha = DateTime.Now;
        }


        protected async Task Guardar()
        {
            if (string.IsNullOrEmpty (aero.Codigo))
            {
                return;
            }


            Aerolinea aerolineaExistente = new Aerolinea ();
            aerolineaExistente = await aerolineaServicio.GetPorCodigo(aero.Codigo);

            if (!string.IsNullOrEmpty(aerolineaExistente.Codigo))
            {
                await Swal.FireAsync("Advertencia", "Ya existe un vuelo con este código", SweetAlertIcon.Warning);
                return;
            }

            bool inserto = await aerolineaServicio.Nuevo(aero);
            if (inserto)
            {
                await Swal.FireAsync("Felicidades", "El vuelo fue guardado con éxito ", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se puedo guardar el vuelo ", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Aerolineas");
        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Aerolineas");
        }
    }
}
