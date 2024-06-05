using System;

namespace ConnectLibrary
{
    public class Network
    {
        private int[] parent;
        private int[] rank;

        // Constructor
        // Verifies if number is positive
        public Network(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Size must be a positive integer.");
            }
            parent = new int[size];
            rank = new int[size];

            for (int i = 0; i < size; i++)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }

        public void Connect(int a, int b)
        {
            a -= 1;
            b -= 1;
            Validate(a);
            Validate(b);
            Union(a, b);
        }

        public bool Query(int a, int b)
        {
            a -= 1;
            b -= 1;
            Validate(a);
            Validate(b);
            return Find(a) == Find(b);
        }

        private int Find(int x)
        {
            if (parent[x] != x)
            {
                parent[x] = Find(parent[x]);
            }
            return parent[x];
        }

        private void Union(int x, int y)
        {
            int rootX = Find(x);
            int rootY = Find(y);

            if (rootX != rootY)
            {
                if (rank[rootX] > rank[rootY])
                {
                    parent[rootY] = rootX;
                }
                else if (rank[rootX] < rank[rootY])
                {
                    parent[rootX] = rootY;
                }
                else
                {
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }
        }

        private void Validate(int index)
        {
            if (index < 0 || index >= parent.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
            }
        }
    }
}
