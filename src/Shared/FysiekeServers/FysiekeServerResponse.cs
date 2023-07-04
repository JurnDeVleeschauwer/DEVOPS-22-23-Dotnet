using Domain.Common;
using Shared.VirtualMachines;
using System;
using System.Collections.Generic;

namespace Shared.FysiekeServers
{
    public static class FysiekeServerResponse
    {
        public class GetIndex
        {
            public List<FysiekeServerDto.Index> FysiekeServers { get; set; } = new();
            public int TotalAmount { get; set; }
        }

        public class GetDetail
        {
            public FysiekeServerDto.Detail FysiekeServer { get; set; }
        }

        public class Delete
        {
        }

        public class Create
        {
            public int FysiekeServerId { get; set; }
            public Uri UploadUri { get; set; }
        }

        public class Edit
        {
            public int FysiekeServerId { get; set; }
        }

        public class Available
        {
            public List<FysiekeServerDto.Index> Servers { get; set; }
            public int Count { get; set; }

        }

        /* public class Launched
         {
             public VirtualMachineDto.Detail VirtualMachine { get; set; } // VirtualMachine heeft een VMConnection gekregen en wordt teruggeven.
         }*/

        public class ResourcesAvailable
        {
            public List<FysiekeServerDto.Beschikbaarheid> Servers { get; set; }
        }
        public class GraphValues
        {
            public Dictionary<DateTime, Hardware> GraphData { get; set; }
        }


    }
}
