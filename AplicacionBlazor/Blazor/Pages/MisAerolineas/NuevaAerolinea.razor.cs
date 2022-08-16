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
          
            //aerolinea.Fecha = DateTime.Now;
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
                await Swal.FireAsync("Advertencia", "Ya existe la aerolinea con este codigo", SweetAlertIcon.Warning);
                return;
            }

            bool inserto = await aerolineaServicio.Nuevo(aero);
            if (inserto)
            {
                await Swal.FireAsync("Advertencia", "Aerolinea guardada con exito ", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Advertencia", "No se puedo guardar la aerolinea ", SweetAlertIcon.Error);
            }
        }

        protected async Task Cancelar()
        {
            _navigationManager.NavigateTo("/Aerolineas");
        }
    }
}
