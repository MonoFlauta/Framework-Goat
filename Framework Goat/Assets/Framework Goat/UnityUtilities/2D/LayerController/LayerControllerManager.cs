using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkGoat
{
    public class LayerControllerManager
    {
        public static LayerController Instance
        {
            get
            {
                if (Instance == null) _instance = new LayerController();
                return _instance;
            }
        }

        private static LayerController _instance;

        private List<LayerController> _layersControllers;
        private LayerController.SortingOrder _sortingOrder;
        private float _amplitude;

        /// <summary>
        /// Creates a LayerControllerManager
        /// </summary>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public LayerControllerManager(float amplitude = 1)
        {
            _amplitude = amplitude;
            _sortingOrder = LayerController.SortingOrder.Y;
            _layersControllers = new List<LayerController>();
        }

        /// <summary>
        /// Creates a LayerControllerManager
        /// </summary>
        /// <param name="sortingOrder">Sorting order that is going to be used</param>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public LayerControllerManager(LayerController.SortingOrder sortingOrder, float amplitude = 1)
        {
            _amplitude = amplitude;
            _layersControllers = new List<LayerController>();
            _sortingOrder = sortingOrder;
        }

        /// <summary>
        /// Creates a Layer Controller Manager with a given list
        /// </summary>
        /// <param name="layerControllers">List of layer controllers</param>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public LayerControllerManager(List<LayerController> layerControllers, float amplitude = 1)
        {
            _amplitude = amplitude;
            _layersControllers = layerControllers;
            _sortingOrder = LayerController.SortingOrder.Y;
            UpdateLayerControllers();
        }

        /// <summary>
        /// Creates a Layer Controller Manager with a given list
        /// </summary>
        /// <param name="layerControllers">List of layer controllers</param>
        /// <param name="sortingOrder">Sorting order that is going to be used</param>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public LayerControllerManager(List<LayerController> layerControllers, LayerController.SortingOrder sortingOrder, float amplitude)
        {
            _amplitude = amplitude;
            _layersControllers = layerControllers;
            _sortingOrder = sortingOrder;
            UpdateLayerControllers();
        }

        /// <summary>
        /// Sets a sorting order
        /// </summary>
        /// <param name="sortingOrder">Sorting order to be set</param>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public void SetSortingOrder(LayerController.SortingOrder sortingOrder, float amplitude = 1)
        {
            _sortingOrder = sortingOrder;
            _amplitude = amplitude;
            UpdateLayerControllers();
        }

        /// <summary>
        /// Sets an amplitude
        /// </summary>
        /// <param name="amplitude">Amplitude for the layer controller</param>
        public void SetAmplitude(float amplitude)
        {
            _amplitude = amplitude;
        }

        /// <summary>
        /// Adds a Layer Controller
        /// </summary>
        /// <param name="layerController">Layer Controller that is going to be added</param>
        public void AddLayerController(LayerController layerController)
        {
            _layersControllers.Add(layerController);
        }

        /// <summary>
        /// Removes a Layer Controller
        /// </summary>
        /// <param name="layerController">Layer Controller that is going to be removed</param>
        public void RemoveLayerController(LayerController layerController)
        {
            _layersControllers.Remove(layerController);
        }

        /// <summary>
        /// Clears all controllers
        /// </summary>
        public void ClearAllControllers()
        {
            _layersControllers.Clear();
        }

        /// <summary>
        /// Updates all layer controllers
        /// </summary>
        private void UpdateLayerControllers()
        {
            for (int i = _layersControllers.Count - 1; i >= 0; i--)
                _layersControllers[i].SetSortingOrder(_sortingOrder, _amplitude);
        }
    }
}