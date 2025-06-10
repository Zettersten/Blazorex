using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace Blazorex.Abstractions;

public abstract class CanvasManagerBase : ComponentBase
{
    protected readonly Dictionary<string, CanvasCreationOptions> _names = [];
    protected readonly Dictionary<string, ICanvas> _canvases = [];

    public void CreateCanvas(string name, CanvasCreationOptions options)
    {
        _names.Add(name, options);

        StateHasChanged();
    }

    internal async ValueTask OnChildCanvasAddedAsync(ICanvas canvas)
    {
        await OnCanvasAdded.InvokeAsync(canvas);
    }

    [Parameter]
    public EventCallback<ICanvas> OnCanvasAdded { get; set; }
}
