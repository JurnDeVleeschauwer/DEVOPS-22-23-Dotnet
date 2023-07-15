using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public static class VMContractRequest
    {

        public class GetIndex
        {
            public int CustomerId { get; set; }
            public int VMId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class GetByDate
        {
            public DateTime Start { get; set; }
            public DateTime? End { get; set; }


        }

        public class GetDetail
        {

            public int VMContractId { get; set; }
        }

        public class Delete
        {
            public int VMContractId { get; set; }
        }

        public class Create
        {
            public VMContractDto.Mutate VMContract { get; set; }
        }

        public class Edit
        {
            public int VMContractId { get; set; }
            public VMContractDto.Mutate VMContract { get; set; }
            public int Id { get; set; }

        }
        public class GetDetailThroughVMId
        {

            public int VMId { get; set; }
        }

    }
}
