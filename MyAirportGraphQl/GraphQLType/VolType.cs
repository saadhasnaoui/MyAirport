using GraphQL.Types;
using MyAirport.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAirportGraphQl.GraphQLType
{
    public class VolType : ObjectGraphType<Vol>
    {
        public VolType()
        {
            Field(x => x.VolId);
            Field(x => x.Cie);
            Field(x => x.Des);
            Field(x => x.Dhc);
            Field(x => x.Imm);
            Field(x => x.Lig);
            Field(x => x.Pax);
            Field(x => x.Pkg);
        }

    }
}
