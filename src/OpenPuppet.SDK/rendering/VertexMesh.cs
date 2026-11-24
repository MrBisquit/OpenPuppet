using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.rendering
{
    public class VertexMesh<T>(List<T> verticies, List<int> indicies) where T : IVertex<T>
    {
        public T[] Verticies { get; } = [.. verticies];
        public int[] Indices { get; } = [.. indicies];

        public static VertexMesh<T> Unify(IEnumerable<VertexMesh<T>> meshes)
        {
            List<T> verticies = [];
            List<int> indicies = [];
            int offset = 0;
            foreach (var mesh in meshes)
            {
                verticies.AddRange(mesh.Verticies);
                indicies.AddRange(mesh.Indices.Select(i => i + offset));
                offset += mesh.Verticies.Length;
            }
            return new VertexMesh<T>(verticies, indicies);
        }
    }
}
