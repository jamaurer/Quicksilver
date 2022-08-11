using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer.ServiceLocation;
using EPiServer.Shell.ObjectEditing;

namespace EPiServer.Reference.Commerce.Site.Features.Product.Services
{
    [ServiceConfiguration(typeof(ISelectionQuery))]
    public class AvailabilitySelectionQuery : ISelectionQuery
    {
        SelectItem[] _items;
        public AvailabilitySelectionQuery()
        {
            _items = new SelectItem[] {
                    new SelectItem() { Text = String.Empty, Value = String.Empty },
                    new SelectItem() { Text = "Alternative1", Value = "1" },
                    new SelectItem() { Text = "Alternative 2", Value = "2" } };
        }
        //Will be called when the editor types something in the selection editor.
        public IEnumerable<ISelectItem> GetItems(string query)
        {
            return _items.Where(i => i.Text.StartsWith(query, StringComparison.OrdinalIgnoreCase));
        }
        //Will be called when initializing an editor with an existing value to get the corresponding text representation.
        public ISelectItem GetItemByValue(string value)
        {
            return _items.FirstOrDefault(i => i.Value.Equals(value));
        }
    }
}