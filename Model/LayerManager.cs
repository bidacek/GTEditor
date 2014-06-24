using EasyNotifyFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
	public interface ILayerManager
	{

		public ObservableCollection<Layer> Layers;

		bool CreateLayer(string LayerName);

		bool RemoveLayer(Layer RemovedLayer, Layer MoveTo);


		bool SetActiveLayer(Layer layer);






	}

	public class LayerManager : ILayerManager
	{

		private HashSet<string> _names;

		private ObservableCollection<Layer> _layers; 
		

		public bool CreateLayer(string layerName)
		{
			if (!this.valid(layerName)) return false;


			_layers.Add(new Layer(layerName));

			return true;
		}

		public bool RemoveLayer(Layer RemovedLayer, Layer MoveTo)
		{
			throw new NotImplementedException();
		}

		public bool SetActiveLayer(Layer layer)
		{
			throw new NotImplementedException();
		}

		private bool valid(string name)
		{
			return _names.Contains(name);
		}
	}

	class Layer{

		private string _name; 
		
		public Layer(string name)
		{
			_name = name;
		}

		public bool IsVisible { get; } 

		public bool IsLocked { get; }
		
	
	}

	class LayerVm : Notifier<LayerVm>
	{
		private Layer _layer;

		public LayerVm(Layer layer)
		{
			_layer = layer;
			
		}

		private static readonly INotifiableProperty<LayerVm> prop = CreateProperty(l => l.IsLocked);

		public bool IsLocked
		{
			get { return _layer.IsLocked;}

		}
	
	}
}
