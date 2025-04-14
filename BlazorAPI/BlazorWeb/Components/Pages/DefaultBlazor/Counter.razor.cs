using Microsoft.AspNetCore.Components;

namespace BlazorWeb.Components.Pages.DefaultBlazor
{
    public partial class Counter : ComponentBase
    {
        protected int currentCount = 0;
        protected void IncrementCount()
        {
            currentCount++;
        }
    }
}
