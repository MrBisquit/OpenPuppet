using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OpenPuppet.rendering
{
    public interface IVertex<TSelf> where TSelf : IVertex<TSelf>
    {
        public static abstract uint Size { get; set; }
        public static abstract VertexPropLayer[] PropLayers { get; set; }

        public static abstract List<TSelf> FromVec3(List<Vector3> vecs);
        public static abstract List<TSelf> FromGeneralData(List<GeneralVertexData> vecs);
    }

    public struct GeneralVertexData(Vector3 position, Vector3 normal, Vector2 uv, Vector4 color)
    {
        public Vector3 Position = position;
        public Vector3 Normal = normal;
        public Vector2 UV = uv;
        public Vector4 Color = color;
    }
}
