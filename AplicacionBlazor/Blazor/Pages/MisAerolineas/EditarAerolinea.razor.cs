using Blazor.Interfaces;
using Microsoft.AspNetCore.Components;
using Modelos;
using CurrieTechnologies.Razor.SweetAlert2;
namespace Blazor.Pages.MisAerolineas
{
    partial class EditarAerolinea
    {
        [Inject] private IAerolineaServicio _aerolineaServicio { get; set; }

        [Inject] private SweetAlertService Swal { get; set; }
        [Inject] NavigationManager _navigationManager { get; set; }
      
        private Aerolinea aero = new Aerolinea();

        [Parameter]  public string Codigo { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (!string.IsNullOrEmpty(Codigo))
            {
                aero = await _aerolineaServicio.GetPorCodigo(Codigo);
            }
        }

        protected async void Guardar()
        {
            if (string.IsNullOrEmpty(aero.Codigo))

            {
                return;
            }

            bool edito = await _aerolineaServicio.Actualizar(aero);

            if (edito)
            {
                await Swal.FireAsync("Felicidades", "Aerolinea guardada con exito", SweetAlertIcon.Success);
            }
            else
            {
                await Swal.FireAsync("Error", "No se pudo guardar la aerolinea", SweetAlertIcon.Error);
            }
            _navigationManager.NavigateTo("/Aerolineas");
        }


        protected void Cancelar()
        {
            _navigationManager.NavigateTo("/Aerolineas");
        }

        protected async Task Eliminar()
        {
            bool elimino = false;

            SweetAlertResult result = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "¿Seguro que desea eliminar la aerolinea?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Aceptar",
                CancelButtonText = "Cancelar"
            });

            if (!string.IsNullOrEmpty(result.Value))
            {
                elimino = await _aerolineaServicio.Eliminar(aero);
                if (elimino)
                {
                    await Swal.FireAsync("Felicidades", "Aerolinea eliminada con exito", SweetAlertIcon.Success);
                    _navigationManager.NavigateTo("/Aerolineas");
                }
                else
                {
                    await Swal.FireAsync("Error", "No se pudo eliminar la aerolinea", SweetAlertIcon.Error);
                }
            }
        }
    }
}
