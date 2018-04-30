﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin.Summit
{
    public class ApoioViewModel : GroupedListViewModelBase<string, ApoioWrapper>
    {
        readonly IApoioService _apoioService;

        public ApoioViewModel(IApoioService apoioService) : base(Resource.ApoioTitle, true)
            => _apoioService = apoioService;

        protected override async Task<IEnumerable<ApoioWrapper>> GetItemsAsync()
            => await _apoioService.GetApoioAsync();

        protected override Func<ApoioWrapper, string> GroupBy()
            => x => x.Categoria;

        protected override async Task ItemClickCommandExecuteAsync(ApoioWrapper model)
            => await Task.Run(() => Device.OpenUri(new Uri(model.Link)));
    }
}
