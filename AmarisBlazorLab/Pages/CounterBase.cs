using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AmarisBlazorLab.Pages
{
    public class CounterBase : ComponentBase
    {
        [CascadingParameter]
        public Task<AuthenticationState> AuthenticationStateTask { get; set; }

        protected async override Task OnInitializedAsync()
        {
            var authenticationState = await AuthenticationStateTask;

            foreach (var item in authenticationState.User.Claims)
            {
                Console.WriteLine($"Claim type: {item.Type}, value: {item.Value}");
            }
        }
    }
}
