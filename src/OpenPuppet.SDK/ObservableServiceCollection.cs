using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace OpenPuppet.SDK
{
    // See: https://github.com/dotnet/runtime/discussions/128166#discussioncomment-16911648
    public class ObservableServiceCollection : Collection<ServiceDescriptor>, IServiceCollection
    {
        public event Action<ServiceDescriptor>? OnAdded;
        public event Action<ServiceDescriptor, ServiceDescriptor>? OnReplaced;
        public event Action<ServiceDescriptor>? OnRemoved;
        public event Action? OnCleared;

        protected override void InsertItem(int index, ServiceDescriptor item)
        {
            OnAdded?.Invoke(item);
            base.InsertItem(index, item);
        }

        protected override void SetItem(int index, ServiceDescriptor item)
        {
            OnReplaced?.Invoke(this[index], item);
            base.SetItem(index, item);
        }

        protected override void RemoveItem(int index)
        {
            OnRemoved?.Invoke(this[index]);
            base.RemoveItem(index);
        }

        protected override void ClearItems()
        {
            OnCleared?.Invoke();
            base.ClearItems();
        }
    }
}
