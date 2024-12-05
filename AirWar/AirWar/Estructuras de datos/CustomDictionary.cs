namespace AirWar
{
    // Clase que actúa como un diccionario personalizado usando listas enlazadas
    public class CustomDictionary<TKey, TValue>
    {
        private LinkedList<TKey> keys;
        private LinkedList<TValue> values;

        // Constructor que inicializa las listas enlazadas de claves y valores
        public CustomDictionary()
        {
            keys = new LinkedList<TKey>();
            values = new LinkedList<TValue>();
        }

        // Añade una nueva clave y valor al diccionario
        // Si la clave ya existe, lanza una excepción
        public void Add(TKey key, TValue value)
        {
            if (!keys.Contains(key))
            {
                keys.Add(key);
                values.Add(value);
            }
            else
            {
                throw new ArgumentException("Key already exists.");
            }
        }

        // Verifica si una clave existe en el diccionario
        // Devuelve true si la clave existe, de lo contrario false
        public bool ContainsKey(TKey key)
        {
            return keys.Contains(key);
        }

        // Permite obtener o establecer el valor asociado a una clave
        // Si la clave no existe, lanza una excepción al intentar obtener el valor
        public TValue this[TKey key]
        {
            get
            {
                int index = keys.IndexOf(key);
                if (index >= 0)
                {
                    return values[index];
                }
                throw new KeyNotFoundException("Key not found.");
            }
            set
            {
                int index = keys.IndexOf(key);
                if (index >= 0)
                {
                    values[index] = value;
                }
                else
                {
                    keys.Add(key);
                    values.Add(value);
                }
            }
        }

        // Devuelve todas las claves en el diccionario
        public IEnumerable<TKey> Keys => keys;

        // Devuelve todos los valores en el diccionario
        public IEnumerable<TValue> Values => values;
    }
}
