using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTEditor.UserControls
{

	class LayerManagerVM
	{


		#region Private Fields
		private readonly ILayerManager _layerMan;


		#endregion	
		public ObservableCollection<ILayerVM> Layer { get; }


		public LayerManagerVM(LayerManager layerManager)
		{
			_layerMan = layerManager;
			_layerMan.La

		}



		void ShippingAddresses_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (_IgnoreChanges)
				return;

			_IgnoreChanges = true;

			// If a reset, then e.OldItems is emtpy. Just clear and reload.
			if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Reset)
			{
				ShippingAddresses.Clear();

				foreach (var sa in _Customer.ShippingAddresses)
					_ShippingAddresses.Add(new ShippingAddressVM(sa));
			}
			else
			{
				// Remove items from collection.
				var toRemove = new List<ShippingAddressVM>();

				if (null != e.OldItems && e.OldItems.Count > 0)
					foreach (var item in e.OldItems)
						foreach (var existingItem in ShippingAddresses)
							if (existingItem.IsViewFor((Models.ShippingAddress)item))
								toRemove.Add(existingItem);

				foreach (var item in toRemove)
					ShippingAddresses.Remove(item);

				// Add new items to the collection.
				if (null != e.NewItems && e.NewItems.Count > 0)
					foreach (var item in e.NewItems)
						ShippingAddresses.Add(new ShippingAddressVM((Models.ShippingAddress)item));
			}

			_IgnoreChanges = false;
		}
	
	}
}
