namespace AirWar
{
    public class Grafo
    {
        private CustomDictionary<int, LinkedList<int>> adjList;

        public Grafo()
        {
            adjList = new CustomDictionary<int, LinkedList<int>>();
        }

        // Añadir un vértice al grafo
        public void AddVertice(int vertice)
        {
            if (!adjList.ContainsKey(vertice))
            {
                adjList[vertice] = new LinkedList<int>();
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
        public LinkedList<int> GetAdyacentes(int vertice)
        {
            if (adjList.ContainsKey(vertice))
            {
                return adjList[vertice];
            }
            return new LinkedList<int>();
        }

        // Obtener todos los vértices del grafo
        public IEnumerable<int> GetVertices()
        {
            return adjList.Keys;
        }
    }
}