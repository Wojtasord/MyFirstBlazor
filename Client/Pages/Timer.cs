using System;
using System.Threading;
using Microsoft.AspNetCore.Components;

namespace MyFirstBlazor.Client.Pages
{
    public class Timer : ComponentBase
    {
        [Parameter]
        public double TimeInSeconds { get; set; }
        [Parameter]
        public Action Tick { get; set; }

        protected override void OnInitialized()
        {
            var timer = new System.Threading.Timer(
                (_)=> InvokeAsync(()=>Tick?.Invoke()),
                null,
                TimeSpan.FromSeconds(TimeInSeconds),
                Timeout.InfiniteTimeSpan );
        }
    }
}