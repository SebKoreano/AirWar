using System;
using System.Collections.Generic;

namespace AirWar
{
    public class Grafo
    {
        private Dictionary<int, List<int>> adjList;

        public Grafo()
        {
            adjList = new Dictionary<int, List<int>>();
        }

        // Añadir un vértice al grafo
        public void AddVertice(int vertice)
        {
            if (!adjList.ContainsKey(vertice))
            {
                adjList[vertice] = new List<int>();
            }
        }

        // Añadir una arista al grafo
        public void AddArista(int origen, int destino)
        {
            if (adjList.ContainsKey(origen) && adjList.ContainsKey(destino))
            {
                adjList[origen].Add(destino);
            }
        }

        // Obtener la lista de adyacencia de un vértice
        public List<int> GetAdyacentes(int vertice)
        {
            if (adjList.ContainsKey(vertice))
            {
                return adjList[vertice];
            }
            return new List<int>();
        }

        // Obtener todos los vértices del grafo
        public IEnumerable<int> GetVertices()
        {
            return adjList.Keys;
        }
    }
}