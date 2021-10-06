# Cписок 1
7(\*\*\*\*).
- Графи на основі списку суміжності (*Edges.AdjacencyList*), матриці суміжності (*Edges.AdjacencyMatrix*)
- Збереження даних у вершинах та ребрах графів (*TVertexData, VEdgeData*)
- Додавання та видалення вершин/ребер (*Graph.AddVertex/Graph.RemoveVertex, Edges.Add/Edges.Remove*)
- Перевірка на зв’язність графу (*Graph.IsConnected*)
- Визначення відстані між двома вершинами графу (*Graph.GetDistance*)

# Список 2
7(\*\*).
- Адреси IPv4 та IPv6
- Адреси підмереж у форматі CIDR (*IPv4/subnetBits, IPv6/subnetBits*)
- Перевірка належності адреси до підмережі (*IPv4/HasSubnet, IPv6/HasSubnet*)

7b(\*). За підтримку вкладених підмереж

7c(\*). За підтримку інших варіантів запису IPv6 адрес, наприклад скорочень `::` та IPv4 адрес в нотації IPv6 (*IPv4/ToIPv6*)

# Додатково
- Графічний інтерфейс (він юзелес, але є 😃)
- Документація **DocFx** (*Lab1Libraries/openDocs.sh*)
- Unit-тести **NUnit** (*Lab1Tests*)
