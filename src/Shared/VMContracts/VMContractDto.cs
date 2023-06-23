using FluentValidation;
using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.VMContracts
{
    public static class VMContractDto
    {
        public class Index
        {
            public int Id { get; set; }

            public int CustomerId { get; set; }
            public int VMId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class Detail : Index
        {
            public int Id { get; set; }
            public int CustomerId { get; set; }
            public int VMId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
        }

        public class Mutate
        {
            public int CustomerId { get; set; }
            public int VMId { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            /*public class Validator : AbstractValidator<Mutate>
            {
                public Validator()
                {
                    RuleFor(x => x.Name).NotEmpty().Length(1, 250);
                    RuleFor(x => x.Price).InclusiveBetween(1, 250);
                    RuleFor(x => x.Category).NotEmpty().Length(1, 250);
                    RuleFor(x => x.ImageAmount).GreaterThanOrEqualTo(1);
                }
            }*/

        }
    }
}
