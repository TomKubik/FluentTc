using System.Collections.Generic;

namespace FluentTc.Domain
{
    public class SnapshotDependencies
    {
        public override string ToString()
        {
            return "snapshot-dependencies";
        }

        public List<BuildModel> Build { get; set; }
    }
}